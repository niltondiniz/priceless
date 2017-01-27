using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Main : ContentPage
	{
		public Main()
		{
			InitializeComponent();

			this.btnLogarFacebook.Clicked += async (sender, e) =>
			{
				((App)App.Current).tipoAuth = "facebook";
				await Navigation.PushAsync(new Login());
			};

			this.btnLogarGoogle.Clicked += async (sender, e) =>
			{
				((App)App.Current).tipoAuth = "google";
				await Navigation.PushAsync(new Login());
			};

			NavigationPage.SetHasBackButton(this, false);
		}
	}
}
