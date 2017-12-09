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
			suggestionList = new List<string>();
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

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			GetData data = new GetData();
			data.getMasterData();
		}

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

			GetData data = new GetData();
			data.getMasterData();

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

			yaratik.SourceImage = "hayvan2.png";
			frame.IsVisible = false;
			//PrepareList(ListType.banking);

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


	}
	public enum ListType
	{
		compaing,
		investment,
		banking
	}		
}