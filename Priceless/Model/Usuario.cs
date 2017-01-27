using System;
using Newtonsoft.Json;

namespace Priceless
{
	public class Usuario
	{
		[JsonProperty("nome")]
		public string nome { get; set; }
		[JsonProperty("email")]
		public string email { get; set; }
		[JsonProperty("id_facebook")]
		public string id_facebook { get; set; }
		public string id_priceless { get; set; }
		public string token { get; set; }

		public Usuario()
		{
		}
	}
}
