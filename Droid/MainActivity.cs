using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Util;
using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Droid;

namespace Priceless.Droid
{
	[Activity(Label = "Priceless.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
			  ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override async void OnCreate(Bundle savedInstanceState)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
			ImageCircleRenderer.Init();
			var activity = (Activity)Forms.Context;
			var view = activity.FindViewById(Android.Resource.Id.Content);

			LoadApplication(new App());

			try
			{
				//Snackbar.Make(view, "Aguarde carregando...", Snackbar.LengthLong).Show();
				//await ((App)App.Current).produtoViewModel.GetProdutos();
				//await ((App)App.Current).desejoViewModel.GetListaDesejos();
				//await ((App)App.Current).settingsViewModel.CidadeAtual();
				//Snackbar.Make(view, "Pronto!", Snackbar.LengthLong).Show();
				//Snackbar.Make(view, CrossPushNotification.SenderId, Snackbar.LengthLong).Show();
			}
			catch (Exception e)
			{
				Log.Debug("X", "Exceção gerada em: {0}", e.Message);
			}


			//var x = typeof(Xamarin.Forms.Themes.DarkThemeResources);
			//var y = typeof(Xamarin.Forms.Themes.LightThemeResources);
			var z = typeof(Xamarin.Forms.Themes.Android.UnderlineEffect);
		}
	}
}
