using System;
using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace Priceless

{
	[Table("produtocompra")]
	public class ProdutoCompra : ModelBase
	{
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		[NotNull]
		public string Descricao
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string Imagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public int Status
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		public int Quantidade
		{
			get { return GetValue<int>(); }
			set { SetValue(value); }
		}

		public double Valor
		{
			get { return GetValue<double>(); }
			set { SetValue(value); }
		}

		public string Supermercado
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public string SupermercadoImagem
		{
			get { return GetValue<string>(); }
			set { SetValue(value); }
		}

		public ProdutoCompra(int id, string descricao, int status)
		{
			this.Id = id;
			this.Descricao = descricao;
			this.Status = status;
		}

		public ProdutoCompra()
		{

		}
	}
}
