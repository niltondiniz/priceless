using System;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(Priceless.iOS.Config))]
namespace Priceless.iOS
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
					var diretorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
					_diretorioDB = System.IO.Path.Combine(diretorio, "..", "Library");
				}
				return _diretorioDB;
			}
		}

		private ISQLitePlatform _plataforma;
		public ISQLitePlatform Plataforma
		{
			get
			{
				if (_plataforma == null)
				{
					_plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
				}

				return _plataforma;
			}


		}
	}
}
