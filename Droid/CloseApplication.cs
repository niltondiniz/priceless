using System;
using Android.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.Droid.CloseApplication))]
namespace Priceless.Droid
{
	public class CloseApplication : ICloseApplication
	{
		void ICloseApplication.CloseApplication()
		{
			var activity = (Activity)Forms.Context;
			activity.FinishAffinity();
		}
	}
}
