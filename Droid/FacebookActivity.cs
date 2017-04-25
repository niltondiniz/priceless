using System;
using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

[assembly: MetaData("com.facebook.sdk.ApplicationId", Value = "@string/app_id")]
namespace Priceless.Droid
{
	[Activity(Label = "")]
	public class FacebookActivity : Activity, IFacebookCallback
	{

		private ICallbackManager mCallbackManager;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			FacebookSdk.SdkInitialize(this.ApplicationContext);

			if (AccessToken.CurrentAccessToken != null && Xamarin.Facebook.Profile.CurrentProfile != null)
			{
				Console.WriteLine("Logado!!");
			}

			mCallbackManager = CallbackManagerFactory.Create();
			LoginManager.Instance.RegisterCallback(mCallbackManager, this);


		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);

			mCallbackManager.OnActivityResult(requestCode, (int)requestCode, data);
		}

		public void OnCancel()
		{
			throw new NotImplementedException();
		}

		public void OnError(FacebookException p0)
		{
			throw new NotImplementedException();
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			LoginResult loginResul = result as LoginResult;
			Console.WriteLine(loginResul.AccessToken.UserId);
		}
	}

}