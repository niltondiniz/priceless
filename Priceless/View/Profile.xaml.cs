using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Priceless
{
	public partial class Profile : ContentPage
	{


		public Profile(string message)
		{
			InitializeComponent();
			this.lblMessage.Text = message;
		}
	}
}
