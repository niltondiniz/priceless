using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class ListaDesejo : ContentPage
	{
		public ListaDesejo()
		{
			BindingContext = ((App)App.Current).desejoViewModel;
			InitializeComponent();
		}
	}
}
