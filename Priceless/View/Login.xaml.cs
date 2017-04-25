using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			Title = "Login";
			BackgroundColor = Color.White;
			BackgroundImage = "fundo_login.png";
			StackLayout layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0)
			};

			Label lblExplanation = new Label
			{
				Text = "Priceless",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				VerticalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				TextColor = Color.White
			};

			Image imgLogo = new Image
			{
				Source = "logo_transparente.png",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 250              

			};

			FacebookButton fbButton = new FacebookButton();
			fbButton.HeightRequest = 60;
			fbButton.VerticalOptions = LayoutOptions.End;

			//Add your event handler for the OnLogin to operate with the Facebook credentials comming from SDK
			fbButton.OnLogin += LoginWithFacebook;

			//Adding views to layout
			layout.Children.Add(imgLogo);
			layout.Children.Add(lblExplanation);
			layout.Children.Add(fbButton);
			this.Content = layout;

		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}

		private async void LoginWithFacebook(object sender, FacebookEventArgs e)
		{
			/*
                If you successfully login to facebook, you must got the three parameters that login return to the app.
                Handle whatever credetianls storage here with the data you have recovered. If you are using Parse Login with Facebook
                you may use DependencyService to access your service and pass the parameters you have recovered.
                Example:
            */
			//var success = await DependencyService.Get<IParse>().LoginWithFacebook(e.UserId, e.AccessToken, e.TokenExpiration);

			bool success = (!string.IsNullOrEmpty(e.UserId) &&
							!string.IsNullOrEmpty(e.AccessToken) &&
							e.TokenExpiration != null);

			if (success)
			{
				//var message = string.Format("You have succesfully access to your facebook account. Data returned:\n\nUserId: {0}\n\nAccess Token: {1}\n\nExpiration Date: {2}",
				//	e.UserId, e.AccessToken, e.TokenExpiration);
				//await DisplayAlert("Success", message, "Ok");

			}
			else
			{
				await DisplayAlert(
					"Error",
					"There was an error trying to login to facebook",
					"Ok"
				);
			}
			//DependencyService.Get<ITools>().LogoutFromFacebook();
		}
	}
}
