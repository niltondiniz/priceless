using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class MasterDetail : MasterDetailPage
	{
		public MasterDetail()
		{
			BindingContext = ((App)App.Current).settingsViewModel;
			InitializeComponent();
		}
	}
}
