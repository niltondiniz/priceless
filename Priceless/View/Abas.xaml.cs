using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Abas : TabbedPage
	{
		public Abas()
		{
			//((App)App.Current).mainNavigation = this;
			InitializeComponent();
			//((App)App.Current).NavigateToMain();

			//((App)App.Current).settings = ((App)App.Current).settingsViewModel.GetLista<Settings>()[0];
			/*if (((App)App.Current).settings != null)
			{
				var expiraEm = ((App)App.Current).settings.ExpirinDate;
				if (expiraEm <= DateTime.Now)
				{
					((App)App.Current).NavigateToLogin();
				}

				((App)App.Current).NotificaSettings(((App)App.Current).settings);
			}
			else {
				((App)App.Current).NavigateToLogin();
			}*/
		}

		protected override bool OnBackButtonPressed()
		{

			Device.BeginInvokeOnMainThread(async () =>
			{
				var result = await this.DisplayAlert("Priceless", "A aplicação será encerrada", "Sim", "Não");
				if (result)
				{
					var closer = DependencyService.Get<ICloseApplication>();
					if (closer != null)
						closer.CloseApplication();
				}

			});

			return true;
		}
	}
}