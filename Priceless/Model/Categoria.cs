using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Priceless
{
	public class Categoria
	{
		[JsonProperty("nome")]
		public string nome { get; set; }
		[JsonProperty("id")]
		public int id { get; set; }
		//[JsonProperty("sub_categorias")]
		public List<SubCategoria> sub_categorias { get; set; }
	}
}
