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
			LoadApplication(new App());
		}

		async void Share(ImageSource imageSource)
		{
			var intent = new Intent(Intent.ActionSend);
			intent.SetType("image/png");

			var handler = new ImageLoaderSourceHandler();
			var bitmap = await handler.LoadImageAsync(imageSource, this);

			var path = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads
				+ Java.IO.File.Separator + "logo.png");

			using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
			{
				bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
			}

			intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));

			var intentChooser = Intent.CreateChooser(intent, "Share via");

			StartActivityForResult(intentChooser, 1000);
		}

		protected async override void OnResume()
		{
			base.OnResume();
			await Task.Delay(10);

			//do other resume things...
		}
	
	}
}
