﻿using System;
using Xamarin.Forms;
using Priceless;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Net;
using System.IO;

[assembly: ExportRenderer(typeof(Login), typeof(Priceless.iOS.LoginPageRenderer))]

namespace Priceless.iOS
{
	public class LoginPageRenderer : PageRenderer
	{
		bool done = false;
		string urlAuthFace = "https://m.facebook.com/dialog/oauth/";
		string urlAuthGoogle = "https://accounts.google.com/o/oauth2/v2/auth";
		string scopeFace = "public_profile, email";
		string scopeGoogle = "email";
		string idFacebook = "725451004148227";
		string idGoogle = "431792804486-041f465rr514skjvu185eit3oieap7ii.apps.googleusercontent.com";
		string profileGoogle = "https://www.googleapis.com/oauth2/v1/userinfo";
		string profileFace = "https://graph.facebook.com/me?fields=email,first_name,last_name,gender,name,picture,birthday";
		string urlProfile = "";
		string tipoLogin = "";
		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);

			if (done)
				return;

			OAuth2Authenticator auth = null;

			if (((App)App.Current).settings == null)
			{
				((App)App.Current).settings = new Settings();
			}

			if (((App)App.Current).tipoAuth == "facebook")
			{
				auth = new OAuth2Authenticator(
					clientId: idFacebook,
					scope: scopeFace,
					authorizeUrl: new Uri(urlAuthFace),
					redirectUrl: new Uri("http://www.niltondiniz.com/")

				);
				urlProfile = profileFace;
				tipoLogin = "facebook";
			}

			if (((App)App.Current).tipoAuth == "google")
			{
				auth = new OAuth2Authenticator(
					clientId: idGoogle,
					scope: scopeGoogle,
					authorizeUrl: new Uri(urlAuthGoogle),
					redirectUrl: new Uri("https://priceless-154902.firebaseapp.com/__/auth/handler")
				);
				urlProfile = profileGoogle;
				tipoLogin = "google";
			}

			//Teste

			if (auth != null)
			{
				auth.Completed += async (sender, eventArgs) =>
				{
					if (eventArgs.IsAuthenticated)
					{
						//Baixando imagem do Profile
						var webClient = new WebClient();
						webClient.DownloadDataCompleted += (s, e) =>
						{
							var bytes = e.Result;
							string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
							string localFilename = "profile.png";
							string localPath = Path.Combine(documentsPath, localFilename);
							File.WriteAllBytes(localPath, bytes);
							((App)App.Current).settings.Imagem = localPath;
							((App)App.Current).settingsViewModel.Gravar();
							((App)App.Current).NotificaSettings(((App)App.Current).settings);
						};

						//Pegando as infos do perfil
						var request = new OAuth2Request("GET", new Uri(urlProfile), null, eventArgs.Account);
						var response = await request.GetResponseAsync();
						var obj = JObject.Parse(response.GetResponseText());

						if (obj != null)
						{
							var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
							var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);
							((App)App.Current).settings.ExpirinDate = expiryDate;
							((App)App.Current).settings.AccessToken = eventArgs.Account.Properties["access_token"].ToString();
							((App)App.Current).settings.Email = obj["email"].ToString();
							var name = obj["name"].ToString().Replace("\"", "");
							((App)App.Current).settings.Name = name;

							if (tipoLogin != "google")
							{
								((App)App.Current).settings.Imagem = obj["picture"]["data"]["url"].ToString();
								((App)App.Current).settings.BirthDay = DateTime.Parse(obj["birthday"].ToString() + " 00:00:00", new CultureInfo("en-US", true));
							}
							else
							{
								((App)App.Current).settings.Imagem = obj["picture"].ToString();
							}

							//Baixando Imagem do Perfil
							webClient.DownloadDataAsync(new Uri(((App)App.Current).settings.Imagem));

							//Gravando usuario na api Priceless
							await ((App)App.Current).usuarioViewModel.CriarUsuario(
								((App)App.Current).settings.Name,
								((App)App.Current).settings.Email,
								((App)App.Current).settings.AccessToken
							);

							//Voltando 2 niveis
							await App.Current.MainPage.Navigation.PopAsync();
							await App.Current.MainPage.Navigation.PopAsync();

						}

					}
					else {
						await App.Current.MainPage.Navigation.PopAsync();
					}
				};
			}

			done = true;
			PresentViewController(auth.GetUI(), true, null);
		}
	}
}