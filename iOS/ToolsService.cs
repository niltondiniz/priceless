using System;
using Priceless.iOS;
using Xamarin.Forms;
using Facebook.LoginKit;

[assembly: Dependency(typeof(ToolsService))]
namespace Priceless.iOS
{
	public class ToolsService : ITools
	{
		public void LogoutFromFacebook()
		{
			var fbSession = new LoginManager();
			fbSession.LogOut();
		}
	}
}