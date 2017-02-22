using System;
using System.Linq;
using Xamarin.Forms;

namespace Priceless
{
	public partial class ListaPromocao : ContentPage
	{

		public ListaPromocao()
		{
			BindingContext = ((App)App.Current).produtoViewModel;
			InitializeComponent();

			if (((App)App.Current).produtoViewModel != null)
			{

				ListPromocao.RefreshCommand = new Command(async () =>
				{
					await ((App)App.Current).produtoViewModel.GetProdutos();
					ListPromocao.IsRefreshing = false;

				});

			}

		}

		public void AddListaCompra(object sender, EventArgs e)
		{
			var item = (Xamarin.Forms.Button)sender;
			Produto listitem = (from itm in ((App)App.Current).produtoViewModel.ListaFiltrada where itm.Imagem == item.CommandParameter.ToString() select itm).FirstOrDefault<Produto>();
			ProdutoCompra produtoCompra = new ProdutoCompra();
			produtoCompra.Descricao = listitem.Nome;
			produtoCompra.Imagem = listitem.Imagem;
			produtoCompra.Valor = listitem.ValorPromocionalDouble;
			produtoCompra.Quantidade = 1;
			produtoCompra.Supermercado = listitem.Supermercado;
			produtoCompra.SupermercadoImagem = listitem.SupermercadoImagem;

			((App)App.Current).produtoCompraViewModel.Insert<ProdutoCompra>(produtoCompra);
			((App)App.Current).produtoCompraViewModel.AtualizaLista();
			((App)App.Current).produtoCompraViewModel.Total = ((App)App.Current).produtoCompraViewModel.TotalCompra();
			DisplayAlert("Sucesso!", "Item adicionado a lista de compras", "Ok");

		}

		public void ShareItem(object sender, EventArgs e)
		{
			Image img = new Image();
			img.Source = "https://static.adzerk.net/Advertisers/33d63a87eb0144dbb2039b21b8d72587.png";
			MessagingCenter.Send<ImageSource>(img.Source, "Share");
		}
	}
}
