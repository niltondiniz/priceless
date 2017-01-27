using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.Droid.Config))]
namespace Priceless.Droid
{
	public class Config : IConfig
	{

		public Config()
		{

		}

		private string _diretorioDB;
		public string DiretorioDB
		{
			get
			{
				if (string.IsNullOrEmpty(_diretorioDB))
				{
					_diretorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
				}
				return _diretorioDB;
			}
		}

		private SQLite.Net.Interop.ISQLitePlatform _plataforma;
		public SQLite.Net.Interop.ISQLitePlatform Plataforma
		{
			get
			{
				if (_plataforma == null)
				{
					_plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
				}
				return _plataforma;
			}
		}
	}
}
