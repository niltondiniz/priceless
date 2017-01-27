using System;
namespace Priceless
{
	public class Desejo
	{
		public string Nome { get; set; }
		public string CategoriaNome { get; set; }
		public int IdCategoria { get; set; }
		public int IdSubCategoria { get; set; }
		public int Status { get; set; }

		public Desejo(string nome, string categoriaNome, int idCategoria, int idSubCategoria, int status)
		{
			this.Nome = nome;
			this.CategoriaNome = categoriaNome;
			this.IdCategoria = idCategoria;
			this.IdSubCategoria = idSubCategoria;
			this.Status = status;
		}
	}
}