using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
    public class ApiData
    {
		private static string refreshToken;

		public ApiData()
		{
			//client = new HttpClient(new HttpClientHandler())
			//{
			//	BaseAddress = new Uri("https://api.yapikredi.com.tr/api/"),

			//};
			////client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");


		}

		public async Task<ResponseClass> GetCurrencyRates()
		{

			ResponseClass obj = await GetAsync<ResponseClass>("https://api.yapikredi.com.tr/api/investmentrates/v1/currencyRates");
			return obj;
		}

		public async Task<AccountResponceClass> GetCustomerList()
		{
			AccountResponceClass obj = await GetAsync<AccountResponceClass>("https://api.yapikredi.com.tr/api/simulationdata/v1/listTestData");
			return obj;
		}

		public async Task<TransactionResponce> GetTransList(TransactionRequest request)
		{
			var stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
			

			var myHttpClient = await GetHttpClient();
			var response = await myHttpClient.PostAsync(new Uri("https://api.yapikredi.com.tr/api/currentAccounts/account/v1/accountTransactionList"), stringContent);

			var json = await response.Content.ReadAsStringAsync();
			TransactionResponce result = JsonConvert.DeserializeObject<TransactionResponce>(json, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });

			return result;
		}

		private async Task<string> getToken()
		{
			var formContent = new FormUrlEncodedContent(new[]
			{
				new KeyValuePair<string, string>("scope", "oob"),
				new KeyValuePair<string, string>("client_secret", "67947fbb8ccd44b097f060272c565dce"),
				new KeyValuePair<string, string>("grant_type", "client_credentials"),
				new KeyValuePair<string, string>("client_id", "l7xxacee8141363e466ab29f6966426763b9"),
			});

			var myHttpClient = new HttpClient();
			var response = await myHttpClient.PostAsync(new Uri("https://api.yapikredi.com.tr/auth/oauth/v2/token"), formContent);

			var json = await response.Content.ReadAsStringAsync();
			TokenModel result = JsonConvert.DeserializeObject<TokenModel>(json);

			if(result != null)
				return result.access_token;
			else
			{
				throw new Exception("token doesnt work");
			}
		}

		public async Task<TResult> GetAsync<TResult>(string uriString) where TResult : class
		{
			var uri = new Uri(uriString);
			using (var client = await GetHttpClient())
			{
				HttpResponseMessage response = await client.GetAsync(uri);
				if (response.StatusCode != HttpStatusCode.OK)
				{
					return default(TResult);
				}
				var json = await response.Content.ReadAsStringAsync();
				var asd = JsonConvert.DeserializeObject<TResult>(json, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
				return asd;
			}
		}

		private async Task<HttpClient> GetHttpClient()
		{
			var client = new HttpClient(new HttpClientHandler());
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
			string asd = "Bearer " + await getToken();
			client.DefaultRequestHeaders.Add("Authorization", asd);
			return client;

		}
	}


}
