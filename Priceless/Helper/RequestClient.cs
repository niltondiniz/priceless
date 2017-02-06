using System;
using System.Net.Http;
using System.Threading.Tasks;
using Plugin.Connectivity;

namespace Priceless
{
	public static class RequestClient
	{
		public static async Task<string> GetRequest(string baseAddress, string complAddress)
		{
			string dados = "";

			if (CrossConnectivity.Current.IsConnected)
			{
				var httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(baseAddress);
				var response = await httpClient.GetAsync(complAddress);
				dados = response.Content.ReadAsStringAsync().Result;
			}
			return dados;
		}
	}
}
