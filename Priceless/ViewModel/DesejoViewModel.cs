using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Priceless
{
	public class DesejoViewModel : INotifyPropertyChanged
	{

		public ObservableCollection<Categoria> _listaCategoria;
		public ObservableCollection<Desejo> _listaDesejos;
		public ObservableCollection<Desejo> _listaFiltrada;
		private string _nome;
		private string _categoria_nome;
		private string _id_sub_categoria;
		private string _id_categoria;
		private int _status;
		private string _filtro;

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}

		public ObservableCollection<Desejo> ListaDesejos
		{
			get { return _listaDesejos; }
			set
			{
				_listaDesejos = value;
				//OnPropertyChanged("ListaDesejos");
			}
		}

		public ObservableCollection<Categoria> ListaCategoria
		{
			get { return _listaCategoria; }
			set
			{
				_listaCategoria = value;
				OnPropertyChanged("ListaCategoria");
			}
		}

		public ObservableCollection<Desejo> ListaFiltrada
		{
			get { return _listaFiltrada; }
			set
			{
				_listaFiltrada = value;
				OnPropertyChanged("ListaFiltrada");
			}
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

		public string NomeCategoria
		{
			get { return _categoria_nome; }
			set
			{
				if (value != _categoria_nome)
				{
					_nome = value;
					OnPropertyChanged("NomeCategoria");
				}
			}
		}

		public string IdCategoria
		{
			get { return _id_categoria; }
			set
			{
				if (value != _id_categoria)
				{
					_id_categoria = value;
					OnPropertyChanged("IdCategoria");
				}
			}
		}

		public string IdSubCategoria
		{
			get { return _id_sub_categoria; }
			set
			{
				if (value != _id_sub_categoria)
				{
					_id_sub_categoria = value;
					OnPropertyChanged("IdSubCategoria");
				}
			}
		}

		public int Status
		{
			get { return _status; }
			set
			{
				if (value != _status)
				{
					_status = value;
					OnPropertyChanged("Status");
				}
			}
		}

		public string Filtro
		{
			get { return _filtro; }
			set
			{
				if (value != _filtro)
				{
					_filtro = value;
					OnPropertyChanged("Filtro");
					this.FiltraLista();
				}
			}
		}

		private void FiltraLista()
		{
			if (ListaDesejos.Count > 0)
			{
				ListaFiltrada = new ObservableCollection<Desejo>(ListaDesejos.Where(p => p.Nome.ToLower().Contains(this.Filtro.ToLower()) || p.CategoriaNome.ToLower().Contains(this.Filtro.ToLower())));
			}

		}

		public async Task GetListaDesejos()
		{
			try
			{
				var client = new System.Net.Http.HttpClient();
				client.BaseAddress = new Uri("http://priceless2m.herokuapp.com/");
				var response = await client.GetAsync("api/busca_categorias/W88oZcUg4dTN1dyc07DWD9kRIOUwcPHGSlHuGR47");
				string dadosJson = response.Content.ReadAsStringAsync().Result;

				try
				{
					ListaCategoria = new ObservableCollection<Categoria>((List<Categoria>)JsonConvert.DeserializeObject(dadosJson, typeof(List<Categoria>)));
				}
				catch (Exception e)
				{

				}

				if (ListaCategoria.Count > 0)
				{
					this.ListaDesejos = new ObservableCollection<Desejo>();
					foreach (Categoria categoria in ListaCategoria)
					{
						foreach (SubCategoria subCategoria in categoria.sub_categorias)
						{
							Desejo desejo = new Desejo(subCategoria.Nome, categoria.nome, categoria.id, subCategoria.Id, 1);
							ListaDesejos.Add(desejo);
						}
					}
				}

				try
				{
					this.ListaFiltrada = ListaDesejos;
				}
				catch (Exception e)
				{

				}

			}
			catch (Exception e)
			{
				//Debug.WriteLine(e.Message);
			}
		}

		public DesejoViewModel()
		{
		}
	}
}
