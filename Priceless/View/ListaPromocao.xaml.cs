using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Pages;

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
	}
}
