using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace Priceless
{
	[Table("settingsmodel")]
	public class SettingsModel : ModelBase
	{

		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		public string AccessToken
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public DateTime ExpirinDate
		{
			get { return GetValue<DateTime>(); }
			set { SetValue(value); }
		}

		public string Name
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Email
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Imagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public DateTime BirthDay
		{
			get { return GetValue<DateTime>(); }
			set { SetValue(value); }
		}

		public SettingsModel()
		{

		}

		public SettingsModel(string _accessToken, DateTime _expirinDate, string _name, string _email, string _imagem, DateTime _birthDay)
		{
			this.AccessToken = _accessToken;
			this.ExpirinDate = _expirinDate;
			this.Name = _name;
			this.Email = _email;
			this.Imagem = _imagem;
			this.BirthDay = _birthDay;
		}

	}
}
