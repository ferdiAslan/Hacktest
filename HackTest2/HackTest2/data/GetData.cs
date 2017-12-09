using Newtonsoft.Json;
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
			client.DefaultRequestHeaders.Add("Authorization", "Bearer 7192fa39-54e4-44be-8bb6-a38dbe1e8dc7");

			var msg = await client.GetStringAsync("https://api.yapikredi.com.tr/api/investmentrates/v1/currencyRates");

			ResponseClass obj = JsonConvert.DeserializeObject<ResponseClass>(msg);
		}

	}

	public class CurrencyRates
	{
		public double averageRate { get; set; }
		public double sellRate { get; set; }
		public double previousDaySellRate { get; set; }
		public double changeRatioDaily { get; set; }
		public double previousDayBuyRate { get; set; }
		public double previousDayAverageRate { get; set; }
		public double buyRate { get; set; }
		public string minorCurrency { get; set; }
		public string majorCurrency { get; set; }
	}

	public class CurrencyRates1
	{
		public List<CurrencyRates> exchangeRateList { get; set; }
	}

	public class ResponseClass
	{
		public CurrencyRates1 response { get; set; }
	}
}
