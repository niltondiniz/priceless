using Android.App;
using Android.OS;
using Android.Content.PM;
using System.Threading.Tasks;
using Xamarin.Facebook;
using System;
using Xamarin.Facebook.Login;
using Android.Content;
using Xamarin.Forms;

namespace Priceless.Droid
{
	[
		Activity(
			Label = "LoginActivity",
			Icon = "@drawable/icon",
			Theme = "@style/MyTheme",
			ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
			ScreenOrientation = ScreenOrientation.Portrait
		),
		MetaData("com.facebook.sdk.ApplicationId", Value = "@string/app_id")
	]
	public class LoginActivity : Activity, IFacebookCallback
	{

		private ICallbackManager mCallbackManager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			FacebookSdk.SdkInitialize(this.ApplicationContext);
			mCallbackManager = CallbackManagerFactory.Create();
			LoginManager.Instance.RegisterCallback(mCallbackManager, this);

			SetContentView(Resource.Layout.login);


			if (AccessToken.CurrentAccessToken != null && Xamarin.Facebook.Profile.CurrentProfile != null)
			{
				Console.WriteLine("Logado!!");
			}

		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			mCallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
		}

		protected async override void OnResume()
		{
			base.OnResume();
			await Task.Delay(10);
		}

		public void OnCancel()
		{
			throw new NotImplementedException();
		}

		public void OnError(FacebookException p0)
		{
			Console.WriteLine(p0.Message);
		}

		public void OnSuccess(Java.Lang.Object result)
		{
			LoginResult loginResul = result as LoginResult;
			Console.WriteLine(loginResul.AccessToken.UserId);

			OnBackPressed();

		}

	}

}
