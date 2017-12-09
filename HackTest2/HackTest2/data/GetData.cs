using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HackTest2.data
{
    public class GetData
    {
		//HttpClient client;
		public GetData()
		{
			//client = new HttpClient(new HttpClientHandler())
			//{
			//	BaseAddress = new Uri("https://api.yapikredi.com.tr/api/"),

			//};
			////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");


		}
		public async void getMasterData()
		{
			var client = new HttpClient(new HttpClientHandler());
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			client.DefaultRequestHeaders.Add("Authorization", "Bearer cef9ef54-758d-47e8-8ad4-336e4c698d27");

			var msg = await client.GetStringAsync("https://api.yapikredi.com.tr/api/investmentrates/v1/currencyRates");
		}

	}
}
