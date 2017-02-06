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
		public Settings settings { get; set; }

		public static Action HideLoginView
		{
			get
			{
				return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
			}
		}

		public async static Task NavigateToMain()
		{
			await App.Current.MainPage.Navigation.PushAsync(new Main());
		}

		public async static Task NavigateToProfile(string message)
		{
			await App.Current.MainPage.Navigation.PushAsync(new Profile(message));
		}

		public async static Task NavigateToHome()
		{

			await App.Current.MainPage.Navigation.PushAsync(new MasterDetail());
		}

		public void NotificaSettings(Settings _settings)
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
			settings = new Settings();

			NavigationPage MainPageLocal = null;
			var nav = new NavigationPage(new MasterDetail());

			Resources = new ResourceDictionary();
			Resources.Add("primaryPink", Color.FromHex("E91E63"));
			Resources.Add("primaryDarkPink", Color.FromHex("C2185B"));

			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryPink"];
			nav.BarTextColor = Color.White;

			MainPage = nav;

			settings = settingsViewModel.GetSettings();

			if (settings != null)
			{
				var expiraEm = settings.ExpirinDate;
				if (expiraEm <= DateTime.Now)
				{
					MainPage.Navigation.PushAsync(new Main());
				}
				else {
					if ((settings != null) && (settings.Name != null))
					{
						MainPageLocal = new NavigationPage(new MasterDetail());
					}
				}
				NotificaSettings(this.settings);
			}
			else {
				MainPage.Navigation.PushAsync(new Main());
			}


		}
	}
}
