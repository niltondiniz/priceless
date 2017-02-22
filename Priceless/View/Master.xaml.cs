using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Master : ContentPage
	{
		public Master()
		{
			BindingContext = ((App)App.Current).settingsViewModel;
			InitializeComponent();
		}

		public async void Sair(object sender, EventArgs e)
		{
			bool resposta = await DisplayAlert("Deseja sair do aplicativo?", "Confirmação", "Sim", "Não");
			if (resposta)
			{
				((App)App.Current).settingsViewModel.DeleteAll<Settings>();
				((App)App.Current).settings = null;
				((App)App.Current).NavigateToHome();
			}
		}
	}
}
