using System;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;

namespace Priceless.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			ImageCircleRenderer.Init();



			LoadApplication(new App());

			try
			{
				((App)App.Current).produtoViewModel.GetProdutos();
				((App)App.Current).desejoViewModel.GetListaDesejos();

			}
			catch (Exception e)
			{
				//Log.Debug("X", "Exceção gerada em: {0}", e.Message);
			}

			return base.FinishedLaunching(app, options);

			//var y = typeof(Xamarin.Forms.Themes.LightThemeResources);
			var z = typeof(Xamarin.Forms.Themes.iOS.UnderlineEffect);
		}
	}
}
