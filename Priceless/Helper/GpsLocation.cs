using System;
//using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace Priceless
{
	public static class GpsLocation
	{
		public static async Task<string> GetCurrentLocation()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;
				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
				var dados = await RequestClient.GetRequest("http://maps.googleapis.com/maps/",
														   string.Format("api/geocode/json?latlng={0},{1}&sensor=false",
																		 position.Latitude.ToString().Replace(",", "."),
																		 position.Longitude.ToString().Replace(",", ".")));
				return dados;
				//Debug.WriteLine("Position Status: {0}", position.Timestamp);
				//Debug.WriteLine("Position Latitude: {0}", position.Latitude);
				//Debug.WriteLine("Position Longitude: {0}", position.Longitude);
			}
			catch (Exception ex)
			{
				//Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
				return "";
			}
		}
	}
}
