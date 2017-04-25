using System;
using Android.App;
using Xamarin.Facebook.Login;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.Droid.Facebook))]
namespace Priceless.Droid
{
	public class Facebook: IFacebook
	{
		public Facebook()
		{
			
		}

		public bool Login()
		{
			try
			{
				var activity = (Activity)Forms.Context;
				activity.StartActivity(typeof(LoginActivity));
				return true;
			}
			catch(Exception e)
			{
				return false;
			}

		}

		public bool Logoff()
		{
			try
			{
				LoginManager.Instance.LogOut();
				return true;
			}
			catch(Exception e)
			{
				return false;
			}

		}
	}
}
