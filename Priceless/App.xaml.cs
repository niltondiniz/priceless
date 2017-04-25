using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Priceless
{
	public partial class App : Application
	{
		public string tipoAuth { get; set; }
		public ProdutoViewModel produtoViewModel;
		public UsuarioVIewModel usuarioViewModel;
		public ProdutoCompraViewModel produtoCompraViewModel;
		public DesejoViewModel desejoViewModel;
		public SettingsViewModel settingsViewModel;
		public SettingsModel settings { get; set; }
		public Page mainNavigation { get; set; }
		public static Action<string> PostSuccessFacebookAction { get; set; }

		public void HideLoginView()
		{
			if (mainNavigation != null)
			{
				mainNavigation.Navigation.PopToRootAsync();
				this.NavigateToHome();
			}
				
		}

		public void NavigateToMain()
		{
			if (mainNavigation != null)
				mainNavigation.Navigation.PushAsync(new Main());
		}

		public void NavigateToLogin()
		{
			//if (mainNavigation != null)
			//mainNavigation.Navigation.PushAsync(new Login());
			MainPage = new Login();
		}

		public void NavigateToHome()
		{
			MainPage = new MasterDetail();

			((App)App.Current).produtoViewModel.GetProdutos();
			((App)App.Current).desejoViewModel.GetListaDesejos();
			((App)App.Current).settingsViewModel.CidadeAtual();
			((App)App.Current).NotificaSettings(((App)App.Current).settings);

		}

		public void NotificaSettings(SettingsModel _settings)
		{
			if (_settings != null)
			{
				((App)App.Current).settingsViewModel.AccessToken = this.settings.AccessToken;
				((App)App.Current).settingsViewModel.BirthDate = this.settings.BirthDay;
				((App)App.Current).settingsViewModel.Email = this.settings.Email;
				((App)App.Current).settingsViewModel.ExpirinDate = this.settings.ExpirinDate;
				((App)App.Current).settingsViewModel.Id = this.settings.Id;
				((App)App.Current).settingsViewModel.Imagem = this.settings.Imagem;
				((App)App.Current).settingsViewModel.Name = this.settings.Name;
			}
		}

		public App()
		{
			produtoViewModel = new ProdutoViewModel();
			usuarioViewModel = new UsuarioVIewModel();
			produtoCompraViewModel = new ProdutoCompraViewModel();
			desejoViewModel = new DesejoViewModel();
			settingsViewModel = new SettingsViewModel();
			settings = new SettingsModel();

			Resources = new ResourceDictionary();
			Resources.Add("primaryPink", Color.FromHex("E91E63"));
			Resources.Add("primaryDarkPink", Color.FromHex("C2185B"));

			try
			{
				var lstSettings = settingsViewModel.GetLista<SettingsModel>();
				if(lstSettings.Count > 0)
				{
					settings = lstSettings[0];	
				}

				if (settings.AccessToken != null)
				{
					NavigateToHome();
				}
				else
				{
					NavigateToLogin();	
				}
			}
			catch
			{
				settings = null;
			}
		}
	}
}
