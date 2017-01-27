using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Priceless
{
	public class AcessoDados : IDisposable
	{
		private SQLite.Net.SQLiteConnection _conexao;

		public AcessoDados()
		{
			var config = DependencyService.Get<IConfig>();
			_conexao = new SQLite.Net.SQLiteConnection(config.Plataforma, System.IO.Path.Combine(config.DiretorioDB, "bancodados2.db3"));

			_conexao.CreateTable<ProdutoCompra>();
		}

		public void Insert(ProdutoCompra produtoCompra)
		{
			_conexao.Insert(produtoCompra);
		}

		public void Update(ProdutoCompra produtoCompra)
		{
			_conexao.Update(produtoCompra);
		}

		public void Delete(ProdutoCompra produtoCompra)
		{
			_conexao.Delete(produtoCompra);
		}

		public ProdutoCompra ObterPorId(int id)
		{
			return _conexao.Table<ProdutoCompra>().FirstOrDefault(c => c.Id == id);
		}

		public List<ProdutoCompra> Listar()
		{
			return _conexao.Table<ProdutoCompra>().OrderBy(c => c.Descricao).ToList();
		}

		public void Dispose()
		{
			_conexao.Dispose();
		}
	}
}
