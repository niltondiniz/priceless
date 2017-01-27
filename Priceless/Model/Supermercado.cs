using System;
using Newtonsoft.Json;
namespace Priceless
{
	public class Supermercado
	{
		[JsonProperty("id")]
		public int id { get; set; }
		[JsonProperty("nome")]
		public string nome { get; set; }
		[JsonProperty("cnpj")]
		public string cnpj { get; set; }
		[JsonProperty("rua")]
		public string rua { get; set; }
		[JsonProperty("ie")]
		public string ie { get; set; }
		[JsonProperty("bairro")]
		public string bairro { get; set; }
		[JsonProperty("estado")]
		public string estado { get; set; }
		[JsonProperty("cidade")]
		public string cidade { get; set; }
		[JsonProperty("cep")]
		public string cep { get; set; }
		[JsonProperty("created_at")]
		public string created_at { get; set; }
		[JsonProperty("updated_at")]
		public string updated_at { get; set; }
		[JsonProperty("status")]
		public object status { get; set; }
		[JsonProperty("imagem_file_name")]
		public string imagem_file_name { get; set; }
		[JsonProperty("imagem_content_type")]
		public string imagem_content_type { get; set; }
		[JsonProperty("imagem_file_size")]
		public int imagem_file_size { get; set; }
		[JsonProperty("imagem_updated_at")]
		public string imagem_updated_at { get; set; }


		public Supermercado()
		{

		}

	}
}
