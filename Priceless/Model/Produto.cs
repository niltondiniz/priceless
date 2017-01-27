using System;
using Newtonsoft.Json;
namespace Priceless
{
	public class Produto
	{
		[JsonProperty("nome")]
		public string Nome { get; set; }
		[JsonProperty("imagem")]
		public string Imagem { get; set; }
		[JsonProperty("data_inicio")]
		public string DataInicio { get; set; }
		[JsonProperty("data_final")]
		public string DataFinal { get; set; }
		[JsonProperty("categoria")]
		public string Categoria { get; set; }
		[JsonProperty("valor_original")]
		public string ValorOriginal { get; set; }
		[JsonProperty("valor_promocional")]
		public string ValorPromocional { get; set; }
		[JsonProperty("id_supermercado")]
		public string IdSupermercado { get; set; }
		[JsonProperty("supermercado")]
		public string Supermercado { get; set; }
		[JsonProperty("img_supermercado")]
		public string ImgSupermercado { get; set; }
		public string DataExpiraPromo
		{
			get
			{
				return string.Format("Expira em: {0}", this.DataFinal);
			}
		}

		public double ValorPromocionalDouble
		{
			get
			{
				return double.Parse(this.ValorPromocional.Replace(".", ",").Replace("R$ ", ""));
			}
		}

		public string SupermercadoImagem
		{
			get
			{
				return ImgSupermercado;
			}
		}

		public Produto()
		{
		}
	}
}
