using CoreGraphics;
using Facebook.LoginKit;
using Facebook.CoreKit;
using System;
using Priceless;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Collections.Generic;
using UIKit;
using System.Drawing;
using Foundation;
using Priceless.iOS;

[assembly: ExportRenderer(typeof(FacebookButton), typeof(FacebookButtonRenderer))]
namespace Priceless.iOS
{
	public class FacebookButtonRenderer : ButtonRenderer
	{
		private LoginButton loginButton;
		ProfilePictureView pictureView;
		UILabel nameLabel;
		List<string> readPermissions = new List<string> { "public_profile" };

		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
			{
				return;
			}

			loginButton = new LoginButton(new CGRect(48, 0, 218, 46))
			{
				LoginBehavior = LoginBehavior.Native,
				ReadPermissions = readPermissions.ToArray()
			};

			var facebookLoginButtonText = new NSAttributedString("Entrar com Facebook",
			new UIStringAttributes()
			{
				ForegroundColor = UIColor.White
			});
			loginButton.SetAttributedTitle(facebookLoginButtonText, UIControlState.Normal);

			loginButton.Completed += (sender, args) =>
			{
				FacebookButton facebookButton = (FacebookButton)e.NewElement;
				FacebookEventArgs fbArgs = new FacebookEventArgs();


				if (args.Result.Token != null)
				{
					fbArgs.UserId = args.Result.Token.UserID;
					fbArgs.AccessToken = args.Result.Token.TokenString;
					fbArgs.TokenExpiration = args.Result.Token.ExpirationDate.ToDateTime();

					var request = new GraphRequest("/" + args.Result.Token.UserID, new NSDictionary("fields", "first_name,last_name,email,birthday,picture"), AccessToken.CurrentAccessToken.TokenString, null, "GET");
					request.Start((connection, result, error) =>
					{
						var userInfo = result as NSDictionary;
						nameLabel.Text = userInfo["first_name"].ToString();

						((App)App.Current).settings.AccessToken = fbArgs.AccessToken;

						try
						{
							//((App)App.Current).settings.BirthDay = DateTime.Parse(userInfo["birthday"].ToString() + " 00:00:00");
							((App)App.Current).settings.Email = userInfo["email"].ToString();	
						}
						catch(Exception erro)
						{
							Console.WriteLine(erro.Message);
						}

						((App)App.Current).settings.ExpirinDate = fbArgs.TokenExpiration;
						((App)App.Current).settings.Name = userInfo["first_name"].ToString() + " " + userInfo["last_name"].ToString();
						((App)App.Current).settings.Imagem = userInfo["picture"].ToString();

						var picture = userInfo["picture"] as NSDictionary;
						picture = picture["data"] as NSDictionary;

						((App)App.Current).settings.Imagem = picture["url"].ToString();
						((App)App.Current).settingsViewModel.Gravar();
						((App)App.Current).NavigateToHome();
					});

				}


				facebookButton.Login(facebookButton, fbArgs);
				// The user image profile is set automatically once is logged in

				//pictureView = new ProfilePictureView(new CGRect(80, -500, 220, 220));
				//this.AddSubview(pictureView);

				nameLabel = new UILabel(new RectangleF(80, -200, 280, 280))
				{
					TextAlignment = UITextAlignment.Center,
					BackgroundColor = UIColor.Clear
				};
				this.AddSubview(nameLabel);

			};

			SetNativeControl(loginButton);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			// Facebook login button has its own look and feel, so the layout properties
			// are the only important properties to check
			if (e.PropertyName == VisualElement.XProperty.PropertyName)
			{
				FacebookButton button = (FacebookButton)sender;
				CGRect frame = loginButton.Frame;
				frame.X = (nfloat)button.X;
				loginButton.Frame = frame;
			}
			else if (e.PropertyName == VisualElement.YProperty.PropertyName)
			{
				FacebookButton button = (FacebookButton)sender;
				CGRect frame = loginButton.Frame;
				frame.Y = (nfloat)button.Y;
				loginButton.Frame = frame;
			}
			else if (e.PropertyName == VisualElement.WidthProperty.PropertyName)
			{
				FacebookButton button = (FacebookButton)sender;
				CGRect frame = loginButton.Frame;
				frame.Width = (nfloat)button.Width;
				loginButton.Frame = frame;
			}
			else if (e.PropertyName == VisualElement.HeightProperty.PropertyName)
			{
				FacebookButton button = (FacebookButton)sender;
				CGRect frame = loginButton.Frame;
				frame.Height = (nfloat)button.Height;
				loginButton.Frame = frame;
			}
		}

	}
}