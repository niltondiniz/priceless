using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.App;
using Priceless;

namespace Priceless.Droid
{
	public class LoginPageRenderer : PageRenderer
	{
		public LoginPageRenderer()
		{
			var activity = this.Context as Activity;
			activity.StartActivity(typeof(LoginActivity));
			App.Current.MainPage.Title = "Login";
		}
	}
}
