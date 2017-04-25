using System;

using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;
using Facebook.CoreKit;

namespace Priceless.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		string appId = "725451004148227";
		string appName = "Priceless";

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{

			global::Xamarin.Forms.Forms.Init();
			ImageCircleRenderer.Init();
			Settings.AppID = appId;
			Settings.DisplayName = appName;

			LoadApplication(new App());

			try
			{
				((App)App.Current).produtoViewModel.GetProdutos();
				((App)App.Current).desejoViewModel.GetListaDesejos();
				((App)App.Current).settingsViewModel.CidadeAtual();

			}
			catch (Exception e)
			{
				//Log.Debug("X", "Exceção gerada em: {0}", e.Message);
			}

			return base.FinishedLaunching(app, options);

		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			// We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
			return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
		}

	}
}
