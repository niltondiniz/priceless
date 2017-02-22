using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Abas : TabbedPage
	{
		public Abas()
		{
			((App)App.Current).mainNavigation = this;
			InitializeComponent();

			if (((App)App.Current).settings != null)
			{
				var expiraEm = ((App)App.Current).settings.ExpirinDate;
				if (expiraEm <= DateTime.Now)
				{
					((App)App.Current).NavigateToMain();
				}
				/*else
				{
					if ((settings != null) && (settings.Name != null))
					{
						NavigateToHome();
					}
				}*/
				((App)App.Current).NotificaSettings(((App)App.Current).settings);
			}
			else {
				((App)App.Current).NavigateToMain();
			}
		}
	}
}