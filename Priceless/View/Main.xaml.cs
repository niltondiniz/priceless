using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Priceless
{
	public partial class Main : ContentPage
	{
		public Main()
		{
			InitializeComponent();

			this.btnLogarFacebook.Clicked += (sender, e) =>
			{
				((App)App.Current).tipoAuth = "facebook";
				((App)App.Current).NavigateToLogin();
			};

			this.btnLogarGoogle.Clicked += (sender, e) =>
			{
				((App)App.Current).tipoAuth = "google";
				((App)App.Current).NavigateToLogin();
			};

			NavigationPage.SetHasBackButton(this, false);
		}

		protected override bool OnBackButtonPressed()
		{

			Device.BeginInvokeOnMainThread(async () =>
			{
				var result = await this.DisplayAlert("Priceless", "Poxa! Já vai?", "Sim", "Não");
				if (result)
				{
					var closer = DependencyService.Get<ICloseApplication>();
					if (closer != null)
						closer.closeApplication();
				}

			});

			return true;
		}
	}
}
