using System;
using Newtonsoft.Json;
namespace Priceless
{
	public class SubCategoria
	{
		[JsonProperty("id")]
		public int Id { get; set; }
		[JsonProperty("nome")]
		public string Nome { get; set; }
		[JsonProperty("created_at")]
		public string CreatedAt { get; set; }
		[JsonProperty("updated_at")]
		public string UpdatedAt { get; set; }
		[JsonProperty("company_id")]
		public object CompanyId { get; set; }
		[JsonProperty("category_id")]
		public int CategoryId { get; set; }
	}
}
