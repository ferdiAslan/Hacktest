using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackTest2.data
{
    public class Transaction
    {
		TransResponseClass response { get; set; }
    }

	public class TransactionRequest
	{
		public string accountNo { get; set; }
		public string ccy { get; set; }
		public bool continuousSearch { get; set; }
		public bool descSort { get; set; }
		public DateTime startDate { get; set; }
		public DateTime endDate { get; set; }
		public int noOfPage { get; set; }
		public int noOfRecs { get; set; }
		public int postNo { get; set; }
	}

	public class SingleTransClass
	{
		public double amount { get; set; }
		public string post_Narr { get; set; }
		public string contractNo { get; set; }
		public string channel { get; set; }
		public string inputDate { get; set; }
		public string post_No { get; set; }
		public string availBal { get; set; }
		public string tranType { get; set; }
		public string input_Date { get; set; }
		public string balance { get; set; }
		public string createTime { get; set; }
		public string trxnName { get; set; }
		public string receiptId { get; set; }
	}
	
	public class TransReturnClass
	{
		public int postNo { get; set; }
		public List<SingleTransClass> list { get; set; }
	}
	public class TransResponseClass
	{
		public TransReturnClass Return { get; set; }
	}

	public class TransactionResponce
	{
		public TransResponseClass response { get; set; }
	}

}
