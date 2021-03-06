using System.ComponentModel;
using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

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
			if (((App)App.Current).settings != null)
				this.Insert<SettingsModel>(((App)App.Current).settings);
			else
				this.Update<SettingsModel>(((App)App.Current).settings);
		}

		public async Task CidadeAtual()
		{
			try
			{
				string json = await GpsLocation.GetCurrentLocation();
				JObject gpsResult = JObject.Parse(@json);
				((App)App.Current).settingsViewModel.City = json;

				string dados = (string)gpsResult["results"][0]["address_components"][3]["long_name"];
				((App)App.Current).settingsViewModel.City = dados;

				/*
				foreach (var obj in gpsResult)
				{
					var data = obj["results"]
					{
						string token = obj.Value.ToString();
						dynamic cidade = JArray.Parse(token);

						foreach(var addressComponent in cidade)
						{
							var tipo = addressComponent["address_components"][0]["types"][0];

							if (tipo.Value.ToString() == "locality")
							{
								var cid = addressComponent["address_components"][0]["long_name"];
								((App)App.Current).settingsViewModel.City = cid.Value.ToString();
							}

						}
					}
				}*/
			}
			catch(Exception e)
			{
				((App)App.Current).settingsViewModel.City = "Local Desconhecido" + e.Message;
			}


		}

	}
}
