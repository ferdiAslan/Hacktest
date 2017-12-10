using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest2.data
{
	public class AccountList
	{
	}
	public class AccountClass
	{
		public int accountNumber { get; set; }
		public string currencyCode { get; set; }
	}
	public class CreditCards
	{
		public string creditCardNumber { get; set; }
	}

	public class CustomerClass
	{
		public CreditCards creditCards { get; set; }
		public List<AccountClass> accounts { get; set; }
	}

	public class CustomerListClass
	{
		public List<CustomerClass> customerList { get; set; }
	}

	public class ReturnClass
	{
		public CustomerListClass Return { get; set; }
	}
	public class AccountResponceClass
	{
		public ReturnClass response { get; set; }
	}
}
