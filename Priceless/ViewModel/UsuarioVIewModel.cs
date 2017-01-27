using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Priceless
{
	public class UsuarioVIewModel : INotifyPropertyChanged
	{
		private string _nome;
		private string _email;
		private string _id_facebook;
		private string _id_priceless;
		private string _token;

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}

		public string Nome
		{
			get { return _nome; }
			set
			{
				if (value != _nome)
				{
					_nome = value;
					OnPropertyChanged("Nome");
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

		public string IdFacebook
		{
			get { return _id_facebook; }
			set
			{
				if (value != _id_facebook)
				{
					_id_facebook = value;
					OnPropertyChanged("IdFacebook");
				}
			}
		}

		public string IdPriceless
		{
			get { return _id_priceless; }
			set
			{
				if (value != _id_priceless)
				{
					_id_priceless = value;
					OnPropertyChanged("IdPriceless");
				}
			}
		}

		public string Token
		{
			get { return _token; }
			set
			{
				if (value != _token)
				{
					_token = value;
					OnPropertyChanged("Token");
				}
			}
		}

		public async Task CriarUsuario(string nome, string email, string idFacebook)
		{
			try
			{

				var client = new System.Net.Http.HttpClient();
				client.BaseAddress = new Uri("http://priceless2m.herokuapp.com/");

				string jsonData = Uri.EscapeUriString("user[nome]=" + nome + "&user[email]=" + email + "&user[id_facebook]=" + idFacebook + "&authenticity_token=ourDdJ/PKP3TXMBWkHZK7QDY/JDFEV7tJaU1aGZ1sPI=");
				var content = new StringContent(jsonData, Encoding.UTF8, "application/x-www-form-urlencoded");

				var response = await client.PostAsync("api/new_user/W88oZcUg4dTN1dyc07DWD9kRIOUwcPHGSlHuGR47", content);
				string dadosJson = response.Content.ReadAsStringAsync().Result;

				dynamic jsonObj = JObject.Parse(dadosJson);
				App.Current.Properties["id_priceless"] = jsonObj["id"];
				App.Current.Properties["token"] = jsonObj["token"];

			}
			catch (Exception e)
			{
				//Debug.WriteLine(e.Message);
			}
		}

		public UsuarioVIewModel()
		{
		}
	}
}
