using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace Priceless
{

	public class ProdutoCompraViewModel : ViewModelBase, INotifyPropertyChanged
	{

		private int _id;
		private string _descricao;
		private int _status;
		private int _quantidade;
		private double _valor;
		private string _dadosProduto;
		private double _total;
		private string _imagem;
		private string _supermercadoImagem;
		private string _filtro;
		public ObservableCollection<ProdutoCompra> _listaCompra;
		public ObservableCollection<ProdutoCompra> _listaFiltrada;

		public ContentPage page;
		public ProdutoCompra produto;
		public ICommand Salvar { get; protected set; }
		public event PropertyChangedEventHandler PropertyChanged;
		private string _supermercado;


		private void OnPropertyChanged(string nome)
		{
			PropertyChanged(this, new PropertyChangedEventArgs(nome));
		}
		public ObservableCollection<ProdutoCompra> ListaCompra
		{
			get { return _listaCompra; }
			set
			{
				_listaCompra = value;
				OnPropertyChanged("ListaCompra");
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

		public ObservableCollection<ProdutoCompra> ListaFiltro
		{
			get { return _listaFiltrada; }
			set
			{
				if (value != null)
				{
					OnPropertyChanged("ListaFiltro");
					_listaFiltrada = value;
				}
			}
		}

		public string DadosProduto
		{
			get
			{
				return "Teste";//string.Format("Qtd:{0} x R$ {1}", this.Quantidade, string.Format("{0:N}", this.Valor));
			}
			set
			{
				if (value != _dadosProduto)
				{
					_dadosProduto = value;
					OnPropertyChanged("Quantidade");
				}
			}
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

		public string Descricao
		{
			get { return _descricao; }
			set
			{
				if (value != _descricao)
				{
					_descricao = value;
					OnPropertyChanged("Descricao");
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

		public int Quantidade
		{
			get { return _quantidade; }
			set
			{
				if (value != _quantidade)
				{
					_quantidade = value;
					OnPropertyChanged("Quantidade");
				}
			}
		}

		public double Valor
		{
			get { return _valor; }
			set
			{
				if (value != _valor)
				{
					_valor = value;
					OnPropertyChanged("Valor");
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

		public string SupermercadoImagem
		{
			get { return _supermercadoImagem; }
			set
			{
				if (value != _supermercadoImagem)
				{
					_supermercadoImagem = value;
					OnPropertyChanged("SupermercadoImagem");
				}
			}
		}

		public double TotalCompra()
		{
			double total = 0;
			if (ListaCompra != null)
			{
				foreach (var item in ListaCompra)
				{
					total += (item.Quantidade * item.Valor);
				}
			}
			return total;
		}

		public double Total
		{
			get { return TotalCompra(); }
			set
			{
				_total = value;
				OnPropertyChanged("Total");
			}

		}

		private void FiltraLista()
		{
			if (ListaCompra.Count > 0)
			{
				ListaFiltro = new ObservableCollection<ProdutoCompra>(ListaCompra.Where(p => p.Descricao.ToLower().Contains(this.Filtro.ToLower()) || p.Supermercado.ToLower().Contains(this.Filtro.ToLower())));
			}

		}

		public void AtualizaLista()
		{
			var lista = new ObservableCollection<ProdutoCompra>(this.Listar());

			if (this.ListaCompra != null)
				this.ListaCompra.Clear();
			else
				this.ListaCompra = new ObservableCollection<ProdutoCompra>();

			foreach (var item in lista)
			{
				this.ListaCompra.Add(item);
			}

			if (ListaFiltro != null)
				ListaFiltro.Clear();
			else
				ListaFiltro = new ObservableCollection<ProdutoCompra>();

			//Adiciona os itens filtrados na lista Observavel para mostrar na tela o resultado do filtro
			foreach (ProdutoCompra pc in ListaCompra)
			{
				ListaFiltro.Add(pc);
			}
		}

		public ProdutoCompraViewModel()
		{
			_listaFiltrada = new ObservableCollection<ProdutoCompra>();
			_listaCompra = new ObservableCollection<ProdutoCompra>();
			AtualizaLista();

			this.Salvar = new Command(async () =>
			{

				if (produto != null)
				{
					Descricao = produto.Descricao;
					Quantidade = produto.Quantidade;
					Status = produto.Status;
					Valor = produto.Valor;
					Id = produto.Id;
				}
				else {
					produto = new ProdutoCompra
					{
						Descricao = this.Descricao,
						Quantidade = this.Quantidade,
						Status = this.Status,
						Valor = this.Valor,
						Id = this.Id
					};
				}


				if (this.Id == 0)
				{
					this.Insert<ProdutoCompra>(produto);
					this.ListaCompra.Add(produto);
					await page.DisplayAlert("Sucesso", "Produto cadastrado com sucesso", "Ok");
				}
				else
				{
					this.Update<ProdutoCompra>(produto);
					AtualizaLista();
					await page.DisplayAlert("Sucesso", "Produto alterado com sucesso", "Ok");
				}
				OnPropertyChanged("Total");

				await page.Navigation.PopModalAsync();

			});
		}

		public void Limpar()
		{
			Id = 0;
			Descricao = "";
			Status = 0;
			Quantidade = 0;
			Valor = 0.00;
			Supermercado = "";
			SupermercadoImagem = "";

		}
	}
}
