using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Priceless
{
	public class ProdutoViewModel : INotifyPropertyChanged
	{

		public ObservableCollection<Produto> _listaProdutos;
		public ObservableCollection<Supermercado> _listaSupermercados;
		public ObservableCollection<Produto> _listaFiltrada;
		private string _nome;
		private string _imagem;
		private string _data_inicio;
		private string _data_final;
		private string _categoria;
		private double _valor_original;
		private double _valor_promocional;
		private Supermercado _objSupermercado;
		private string _supermercado;
		private string _imagemSupermercado;
		private string _filtro;
		private string _filtroSupermercado;

		public Command Share { get; set; }
		public ImageSource Source { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}

		public ObservableCollection<Produto> ListaProdutos
		{
			get { return _listaProdutos; }
			set
			{
				_listaProdutos = value;
				OnPropertyChanged("ListaProdutos");
			}
		}

		public ObservableCollection<Supermercado> ListaSupermercados
		{
			get
			{
				if (_listaSupermercados != null)
				{
					return _listaSupermercados;
				}
				else
				{
					_listaSupermercados = new ObservableCollection<Priceless.Supermercado>();
					return _listaSupermercados;
				}
			}

			set
			{
				_listaSupermercados = value;
				OnPropertyChanged("ListaSupermercados");
			}
		}

		public ObservableCollection<Produto> ListaFiltrada
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

		public string DataInicio
		{
			get { return _data_inicio; }
			set
			{
				if (value != _data_inicio)
				{
					_data_inicio = value;
					OnPropertyChanged("DataInicio");
				}
			}
		}

		public string DataFinal
		{
			get
			{

				return string.Format("Expira em: {0}", _data_final);
			}
			set
			{
				if (value != _data_final)
				{
					_data_final = value;
					OnPropertyChanged("DataFinal");
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

		public string Categoria
		{
			get { return _categoria; }
			set
			{
				if (value != _categoria)
				{
					_categoria = value;
					OnPropertyChanged("Categoria");
				}
			}
		}

		public double ValorOriginal
		{
			get { return _valor_original; }
			set
			{
				if (value != _valor_original)
				{
					_valor_original = value;
					OnPropertyChanged("ValorOriginal");
				}
			}
		}

		public double ValorPromocional
		{
			get { return _valor_promocional; }
			set
			{
				if (value != _valor_promocional)
				{
					_valor_promocional = value;
					OnPropertyChanged("ValorPromocional");
				}
			}
		}

		public Supermercado ObjSupermercado
		{
			get { return _objSupermercado; }
			set
			{
				if (value != _objSupermercado)
				{
					_objSupermercado = value;
					OnPropertyChanged("ObjSupermercado");
				}
			}
		}

		public string Supermercado
		{
			get { return _supermercado; }
			set
			{
				if (value != _supermercado)
				{
					_supermercado = value;
					OnPropertyChanged("Supermercado");
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

		public string SupermercadoImagem
		{
			get { return _imagemSupermercado; }
			set
			{
				if (value != _imagemSupermercado)
				{
					_imagemSupermercado = value;
					OnPropertyChanged("SupermercadoImagem");
				}
			}
		}

		public string FiltroSupermercado
		{

			get { return _filtroSupermercado; }

			set
			{
				if (value != _filtroSupermercado)
				{
					_filtroSupermercado = value;
					OnPropertyChanged("FiltroSupermercado");
				}
			}
		}

		private void FiltraLista()
		{
			if (ListaProdutos.Count > 0)
			{
				ListaFiltrada = new ObservableCollection<Produto>(ListaProdutos.Where(p => p.Nome.ToLower().Contains(this.Filtro.ToLower()) || p.Supermercado.ToLower().Contains(this.Filtro.ToLower())));
			}

		}

		public void FiltraLista(string Supermercado)
		{
			if (ListaProdutos.Count > 0)
			{
				ListaFiltrada = new ObservableCollection<Produto>(ListaProdutos.Where(p => p.Supermercado.ToLower().StartsWith(Supermercado.ToLower(), StringComparison.Ordinal)));
			}
		}

		public async Task GetProdutos()
		{
			try
			{
				var resultado = await RequestClient.GetRequest("http://priceless2m.herokuapp.com/", "api/busca_produtos/W88oZcUg4dTN1dyc07DWD9kRIOUwcPHGSlHuGR47");
				ListaProdutos = new ObservableCollection<Produto>((List<Produto>)JsonConvert.DeserializeObject(resultado, typeof(List<Produto>)));
				ListaFiltrada = ListaProdutos;
			}
			catch (Exception e)
			{
				//Debug.WriteLine(e.Message);
			}
		}

		public ProdutoViewModel()
		{
			Share = new Command(ShareCommand);
		}

		void ShareCommand()
		{
			Image img = new Image();
			img.Source = "https://static.adzerk.net/Advertisers/33d63a87eb0144dbb2039b21b8d72587.png";
			MessagingCenter.Send<ImageSource>(img.Source, "Share");
		}
	}
}
