
using Xamarin.Forms;

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

			App.PostSuccessFacebookAction = async (token) =>
			{
				await ((App)App.Current).mainNavigation.Navigation.PushAsync(new DiplayTokenPage(token));
			};
		}
	}
}
