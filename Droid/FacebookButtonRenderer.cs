using Android.Runtime;
using Priceless.Droid;
using Priceless;
using System;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Collections.Generic;
using Android.OS;
using Org.Json;

[assembly: ExportRenderer(typeof(FacebookButton), typeof(FacebookButtonRenderer))]
namespace Priceless.Droid
{
	/// <summary>
	/// FacebookLogin button renderer implementation for Xamarin.Forms in the Android side.
	/// This implement the native look and feel from Facebook SDK for Android LoginButton object and handle
	/// Facebook Login basic authentication for Android
	/// </summary>
	public class FacebookButtonRenderer : ButtonRenderer,GraphRequest.IGraphJSONObjectCallback
	{
		private LoginButton loginButton;
		ProfilePictureView pictureView;
		Label nameLabel;
		List<string> readPermissions = new List<string> { "public_profile" };

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			loginButton = new LoginButton(Forms.Context);
			loginButton.LoginBehavior = LoginBehavior.NativeWithFallback;

			//Implement FacebookCallback with LoginResult type to handle Callback's result
			var loginCallback = new FacebookCallback<LoginResult>
			{
				HandleSuccess = loginResult =>
				{
					/*
                        If login success, We can now retrieve our needed data and build our 
                        FacebookEventArgs parameters
                    */

					FacebookButton facebookButton = (FacebookButton)e.NewElement;
					FacebookEventArgs fbArgs = new FacebookEventArgs();

					if (loginResult.AccessToken != null)
					{
						fbArgs.UserId = loginResult.AccessToken.UserId;
						fbArgs.AccessToken = loginResult.AccessToken.Token;
						var expires = loginResult.AccessToken.Expires;

						//TODO better way to retrive Java.Util.Date and cast it to System.DateTime type
						fbArgs.TokenExpiration = new DateTime(expires.Year, expires.Month, expires.Day, expires.Hours, expires.Minutes, expires.Seconds);

						Bundle param = new Bundle();
						param.PutString("fields", "first_name,last_name,email,birthday,picture");

						var request = new GraphRequest(loginResult.AccessToken, "/me/acounts", param, HttpMethod.Get);
						request.ExecuteAsync();
						
						/*((connection, result, error) =>
						{
							var userInfo = result as NSDictionary;
							nameLabel.Text = userInfo["first_name"].ToString();

							((App)App.Current).settings.AccessToken = fbArgs.AccessToken;
							((App)App.Current).settings.BirthDay = DateTime.Parse(userInfo["birthday"].ToString());
							((App)App.Current).settings.Email = userInfo["email"].ToString();
							((App)App.Current).settings.ExpirinDate = fbArgs.TokenExpiration;
							((App)App.Current).settings.Name = userInfo["first_name"].ToString() + " " + userInfo["last_name"].ToString();
							((App)App.Current).settings.Imagem = userInfo["picture"].ToString();

							var picture = userInfo["picture"] as NSDictionary;
							picture = picture["data"] as NSDictionary;

							((App)App.Current).settings.Imagem = picture["url"].ToString();
							((App)App.Current).settingsViewModel.Gravar();
							((App)App.Current).NavigateToHome();
						});*/
					}
					/*
                        Pass the parameters into Login method in the FacebookButton 
                        object and handle it on Xamarin.Forms side
                    */
					facebookButton.Login(facebookButton, fbArgs);
				},
				HandleCancel = () =>
				{
					//Handle any cancel the user has perform
					Console.WriteLine("User cancel de login operation");
				},
				HandleError = loginError =>
				{
					//Handle any error happends here
					Console.WriteLine("Operation throws an error: " + loginError.Cause.Message);
				}
			};
			LoginManager.Instance.RegisterCallback(MainActivity.CallbackManager, loginCallback);
			//Set the LoginButton as NativeControl
			SetNativeControl(loginButton);

		}


		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}

		public void OnCompleted(JSONObject p0, GraphResponse p1)
		{
			Console.WriteLine(p0.ToString());
		}
	}

	/// <summary>
	/// FacebookCallback<TResult> class which will handle any result the FacebookActivity returns.
	/// </summary>
	/// <typeparam name="TResult">The callback result's type you will handle</typeparam>
	public class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
	{
		public Action HandleCancel { get; set; }
		public Action<FacebookException> HandleError { get; set; }
		public Action<TResult> HandleSuccess { get; set; }

		public void OnCancel()
		{
			var c = HandleCancel;
			if (c != null)
				c();
		}

		public void OnError(FacebookException error)
		{
			var c = HandleError;
			if (c != null)
				c(error);
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			var c = HandleSuccess;
			if (c != null)
				c(result.JavaCast<TResult>());
		}
	}
}