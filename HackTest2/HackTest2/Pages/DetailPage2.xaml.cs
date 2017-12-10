using HackTest2.data;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackTest2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPage2 : ContentPage
	{
		private List<string> suggestionList;
		private bool IsOpen;
		public DetailPage2 ()
		{
			InitializeComponent ();
			ProvideData();
			suggestionList = new List<string> { "1", "2", "3" };
			IsOpen = true;
			
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await Task.Delay(1000);
			UpdateUI();
		}

		private async void UpdateUI()
		{
			Bulut.IsVisible = true;
			await Task.Delay(500);
			buton1.IsVisible = true;
			await Task.Delay(500);
			buton2.IsVisible = true;
			await Task.Delay(500);
			buton3.IsVisible = true;
		}

		//private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		//{
		//	ApiData data = new ApiData();
		//	data.getMasterData();
		//}

		private async void OpenFrame1(object sender, EventArgs e)
		{
			if (IsOpen)
			{
				Bulut.FadeTo(0, 300);
				await yaratik.TranslateTo(0, -185, 500);
				frame.IsVisible = true;
				IsOpen = false;
			}
			frame.IsVisible = true;
			PrepareList(ListType.compaing);

		}
		private async void OpenFrame2(object sender, EventArgs e)
		{
			if (IsOpen)
			{
				Bulut.FadeTo(0, 300);
				await yaratik.TranslateTo(0, -185, 500);
				frame.IsVisible = true;
				IsOpen = false;
			}

			frame.IsVisible = true;
			PrepareList(ListType.investment);

			//ApiData data = new ApiData();
			//var asd = await data.GetCurrencyRates();
			//var asd = await data.GetTransList();

			//GetAzureData azuredata = new GetAzureData();
			//var clasification = await azuredata.getIncomeLevelClassData();

		}

		private async void OpenFrame3(object sender, EventArgs e)
		{
			if (IsOpen)
			{
				Bulut.FadeTo(0, 300);
				await yaratik.TranslateTo(0, -185, 500);
				frame.IsVisible = true;
				IsOpen = false;
			}

			frame.IsVisible = true;
			PrepareList(ListType.banking);

		}

		private async void yaratikTapped(object sender, EventArgs e)
		{
			if (IsOpen)
			{
				Bulut.FadeTo(0, 300);
				await yaratik.TranslateTo(0, -185, 500);
				IsOpen = false;
			}

			PrepareList(ListType.compaing);
			yaratik.SourceImage = "hayvan2.png";
			frame.IsVisible = true;
			mapImage.IsVisible = true;
			//PrepareList(ListType.banking);

		}

		private async void mapTapped(object sender, EventArgs e)
		{
			int a = 5;
			if(mapImage.IsVisible)
				(Application.Current.MainPage as MasterDetailPage).Detail = new NavigationPage(new MapPage());

		}

		private void PrepareList(ListType type )
		{
			suggestionList.Clear();
			stack.Children.Clear();
			switch (type)
			{
				case ListType.compaing:
					suggestionList = new List<string> { "1", "2", "3" };
					break;
				case ListType.investment:
					suggestionList = new List<string> { "4", "5", "6" };
					break;
				case ListType.banking:
					suggestionList = new List<string> { "7", "78", "9" };
					break;
				default:
					break;
			}
			foreach(var item in suggestionList)
			{
				var label = new Label { Text = item };
				stack.Children.Add(label);
			}
		}

		private async void ProvideData()
		{
			ApiData data = new ApiData();
			GetAzureData azureData = new GetAzureData();

			TransactionRequest request = new TransactionRequest
			{
				accountNo = "10000846",
				ccy = "TL",
				continuousSearch = true,
				descSort = true,
				startDate = DateTime.Now.Subtract(TimeSpan.FromDays(60)),
				endDate = DateTime.Now.Add(TimeSpan.FromDays(60)),
				noOfPage = 1,
				noOfRecs = 7,
				postNo = 0
			};

			var _list = await data.GetTransList(request);

			AzureExpenceData expenceData = new AzureExpenceData
			{
				accountid = request.accountNo,
				akaryakit = _list.response.Return.list[0].amount,
				altın = _list.response.Return.list[1].amount,
				döviz = _list.response.Return.list[2].amount,
				giyim = _list.response.Return.list[3].amount,
				kira = _list.response.Return.list[4].amount,
				kozmetik = _list.response.Return.list[5].amount,
				yiyecek = _list.response.Return.list[6].amount,
			};

			double amount = 0;
			foreach (var item in _list.response.Return.list)
				amount += item.amount;

			var firstClassification = await azureData.getExpenseClassificationData(expenceData);

			var secondClassfication = await azureData.getIncomeLevelClassData(request.accountNo, amount.ToString());

		}


	}
	public enum ListType
	{
		compaing,
		investment,
		banking
	}		
}