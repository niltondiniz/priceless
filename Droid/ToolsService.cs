using System;
using Priceless.Droid;
using Xamarin.Forms;
using Xamarin.Facebook.Login;

[assembly: Dependency(typeof(ToolsService))]
namespace Priceless.Droid
{
	public class ToolsService : ITools
	{
		public void LogoutFromFacebook()
		{
			LoginManager.Instance.LogOut();
		}
	}
}
