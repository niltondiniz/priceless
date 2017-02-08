using System;
using Android.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.Droid.CloseApplication))]
namespace Priceless.Droid
{
	public class CloseApplication : ICloseApplication
	{
		public void closeApplication()
		{
			var activity = (Activity)Forms.Context;
			activity.FinishAffinity();
		}
	}
}
