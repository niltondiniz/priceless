using System;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.iOS.CloseApplication))]
namespace Priceless.iOS
{
	public class CloseApplication : ICloseApplication
	{
		public void closeApplication()
		{
			Thread.CurrentThread.Abort();
		}
	}
}
