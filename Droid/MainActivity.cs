using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Droid;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System.Threading.Tasks;
using Xamarin.Facebook;
using Java.Lang;
using Xamarin.Facebook.Login;

namespace Priceless.Droid
{
	[Activity(Label = "Priceless.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
	          ScreenOrientation = ScreenOrientation.Portrait),MetaData("com.facebook.sdk.ApplicationId", Value = "@string/app_id")]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

		public static ICallbackManager CallbackManager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			ImageCircleRenderer.Init();
			var activity = (Activity)Forms.Context;

			FacebookSdk.SdkInitialize(this.ApplicationContext);
			CallbackManager = CallbackManagerFactory.Create();

			//LoginManager.Instance.RegisterCallback(mCallbackManager, this);
			LoadApplication(new App());

		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
		}
	}
}
