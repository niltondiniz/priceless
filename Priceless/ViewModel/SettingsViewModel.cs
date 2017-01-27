using System.ComponentModel;
using System;

namespace Priceless
{

	public class SettingsViewModel : ViewModelBase, INotifyPropertyChanged
	{

		private int _id;
		private string _accessToken;
		private DateTime _expirinDate;
		private string _name;
		private string _email;
		private string _imagem;
		private DateTime _birthDate;
		private string _city;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}


		public int Id
		{
			get { return _id; }
			set
			{
				if (value != _id)
				{
					_id = value;
					OnPropertyChanged("Id");
				}
			}
		}

		public string AccessToken
		{
			get { return _accessToken; }
			set
			{
				if (value != _accessToken)
				{
					_accessToken = value;
					OnPropertyChanged("AccessToken");
				}
			}
		}

		public DateTime ExpirinDate
		{
			get { return _expirinDate; }
			set
			{
				if (value != _expirinDate)
				{
					_expirinDate = value;
					OnPropertyChanged("ExpirinDate");
				}
			}
		}

		public string Name
		{
			get { return _name; }
			set
			{
				if (value != _name)
				{
					_name = value;
					OnPropertyChanged("Name");
				}
			}
		}

		public string Email
		{
			get { return _email; }
			set
			{
				if (value != _email)
				{
					_email = value;
					OnPropertyChanged("Email");
				}
			}
		}

		public string Imagem
		{
			get { return _imagem; }
			set
			{
				if (value != _imagem)
				{
					_imagem = value;
					OnPropertyChanged("Imagem");
				}
			}
		}

		public DateTime BirthDate
		{
			get { return _birthDate; }
			set
			{
				if (value != _birthDate)
				{
					_birthDate = value;
					OnPropertyChanged("BirthDate");
				}
			}
		}

		public string City
		{
			get { return _city; }
			set
			{
				if (value != _city)
				{
					_city = value;
					OnPropertyChanged("City");
				}
			}
		}

		public SettingsViewModel()
		{



		}

		public void Gravar()
		{
			if (this.GetSettings() == null)
			{
				this.Insert<Settings>(((App)App.Current).settings);
			}
			else
			{
				this.Update<Settings>(((App)App.Current).settings);
			}
		}

	}
}
