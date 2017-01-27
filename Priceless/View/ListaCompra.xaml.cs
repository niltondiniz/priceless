using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Priceless
{
	public partial class ListaCompra : ContentPage
	{
		public ListaCompra()
		{
			BindingContext = ((App)App.Current).produtoCompraViewModel;
			InitializeComponent();
		}

		public async void DeleteItem(object sender, EventArgs e)
		{
			var item = (Xamarin.Forms.Button)sender;
			ProdutoCompra listitem = (from itm in ((App)App.Current).produtoCompraViewModel.ListaCompra where itm.Imagem == item.CommandParameter.ToString() select itm).FirstOrDefault<ProdutoCompra>();

			bool resposta = await DisplayAlert("Confirma exclusão do item?", listitem.Descricao, "Sim", "Não");
			if (resposta)
			{
				((App)App.Current).produtoCompraViewModel.Delete<ProdutoCompra>(listitem);
				((App)App.Current).produtoCompraViewModel.AtualizaLista();
				((App)App.Current).produtoCompraViewModel.Total = ((App)App.Current).produtoCompraViewModel.TotalCompra();
			}

		}

		public void MaisQtd(object sender, EventArgs e)
		{
			var item = (Xamarin.Forms.Button)sender;
			ProdutoCompra listitem = (from itm in ((App)App.Current).produtoCompraViewModel.ListaCompra where itm.Imagem == item.CommandParameter.ToString() select itm).FirstOrDefault<ProdutoCompra>();

			listitem.Quantidade++;
			((App)App.Current).produtoCompraViewModel.Update<ProdutoCompra>(listitem);
			((App)App.Current).produtoCompraViewModel.AtualizaLista();
			((App)App.Current).produtoCompraViewModel.Total = ((App)App.Current).produtoCompraViewModel.TotalCompra();
		}

		public void MenosQtd(object sender, EventArgs e)
		{
			var item = (Xamarin.Forms.Button)sender;
			ProdutoCompra listitem = (from itm in ((App)App.Current).produtoCompraViewModel.ListaCompra where itm.Imagem == item.CommandParameter.ToString() select itm).FirstOrDefault<ProdutoCompra>();

			if (listitem.Quantidade > 0)
				listitem.Quantidade--;
			((App)App.Current).produtoCompraViewModel.Update<ProdutoCompra>(listitem);
			((App)App.Current).produtoCompraViewModel.AtualizaLista();
			((App)App.Current).produtoCompraViewModel.Total = ((App)App.Current).produtoCompraViewModel.TotalCompra();
		}
	}
}
