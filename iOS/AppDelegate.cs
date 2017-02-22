﻿using System;

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
				((App)App.Current).settingsViewModel.CidadeAtual();

			}
			catch (Exception e)
			{
				//Log.Debug("X", "Exceção gerada em: {0}", e.Message);
			}

			return base.FinishedLaunching(app, options);

		}
	}
}
