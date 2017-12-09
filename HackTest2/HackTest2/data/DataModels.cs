using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest2.data
{
    class DataModels
    {
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

	public class TokenModel
	{
		public string access_token { get; set; }
		public int expires_in { get; set; }
		public string token_type { get; set; }
		public string scope { get; set; }
	}

	public class LoginModel
	{
		public string scope { get; set; }
		public string client_secret { get; set; }
		public string grant_type { get; set; }
		public string client_id { get; set; }
	}
}
