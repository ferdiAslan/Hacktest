using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HackTest2.data
{
    public class GetAzureData
    {
		public GetAzureData()
		{

		}

		public async Task<int> getExpenseClassificationData(AzureExpenceData data )
		{
			using (var client = new HttpClient())
			{
				var scoreRequest = new
				{
					Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
						{
							"input1",
							new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
								{
									"account_id", data.accountid
								},
								{
									"AKARYAKIT", data.akaryakit.ToString()
								},
								{
									"GIYIM", data.giyim.ToString()
								},
								{
									"YIYECEK", data.yiyecek.ToString()
								},
								{
									"KOZMETIK", data.kozmetik.ToString()
								},
								{
									"KIRA", data.kira.ToString()
								},
								{
									"DOVIZ", data.döviz.ToString()
								},
								{
									"ALTIN", data.altın.ToString()
								},
								}
							}
						},
					},
					GlobalParameters = new Dictionary<string, string>()
					{
					}
				};

				const string apiKey = "gp5Uw+phjaAcgm36LCFzQpmE0/XwNxG2gi2tfSwAFT4fLrX9fRoxQ3xxBJiQR9EBa20ffprkrCR36jJj5sodmA=="; // Replace this with the API key for the web service
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
				client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/c6eedface4894d989c5ecdf0dd067bbd/services/dc3964c112464ddfb74bf6cb6ad3049b/execute?api-version=2.0&format=swagger");


				var stringContent = new StringContent(JsonConvert.SerializeObject(scoreRequest), Encoding.UTF8, "application/json");

				HttpResponseMessage response = await client.PostAsync("", stringContent);

				if (response.IsSuccessStatusCode)
				{
					string result = await response.Content.ReadAsStringAsync();
					
					var results = JObject.Parse(result).SelectToken("Results.output1") as JArray;

					foreach (var result11 in results)
					{
						var UserClass = result11.Value<int>("Assignments");
						return UserClass;
					}
				}
				else
				{
					//Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode))/*;*/

					// Print the headers - they include the requert ID and the timestamp,
					// which are useful for debugging the failure
					//Console.WriteLine(response.Headers.ToString());

					string responseContent = await response.Content.ReadAsStringAsync();
					//Console.WriteLine(responseContent);
				}
			}
			return -1;

		}

		public async Task<int> getIncomeLevelClassData(string accountId, string amount)
		{
			using (var client = new HttpClient())
			{
				var scoreRequest = new
				{
					Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
						{
							"input1",
							new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
									{
										"account_id", accountId
									},
									{
										"amount", amount
									},
								}
							}
						},
					},
					GlobalParameters = new Dictionary<string, string>()
					{
					}
				};

				const string apiKey = "CtMyVIgxVo2jm9qHM93NFqchKyHPbd5NDV2Jb4sdm5RRgrOm6DADil11jGaLmouDYkTekfk7TDtgmEjJXkwxHQ=="; // Replace this with the API key for the web service
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
				client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/c6eedface4894d989c5ecdf0dd067bbd/services/bd6fd371ea4a47b2b705093ba12ee0c0/execute?api-version=2.0&format=swagger");

				// WARNING: The 'await' statement below can result in a deadlock
				// if you are calling this code from the UI thread of an ASP.Net application.
				// One way to address this would be to call ConfigureAwait(false)
				// so that the execution does not attempt to resume on the original context.
				// For instance, replace code such as:
				//      result = await DoSomeTask()
				// with the following:
				//      result = await DoSomeTask().ConfigureAwait(false)

				var stringContent = new StringContent(JsonConvert.SerializeObject(scoreRequest), Encoding.UTF8, "application/json");

				HttpResponseMessage response = await client.PostAsync("", stringContent);

				if (response.IsSuccessStatusCode)
				{
					string result = await response.Content.ReadAsStringAsync();

					var results = JObject.Parse(result).SelectToken("Results.output1") as JArray;

					foreach (var result11 in results)
					{
						var UserClass = result11.Value<int>("Assignments");
						return UserClass;
					}
				}
			}
			return -1;
		}
	}

}
