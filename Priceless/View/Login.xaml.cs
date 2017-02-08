using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}
