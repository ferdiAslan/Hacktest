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
		public DetailPage2 ()
		{
			InitializeComponent ();
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

		private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
		{
			//var page = new PopupPage1();
			Bulut.FadeTo(0, 300);
			//await PopupNavigation.PushAsync(page);
			await yaratik.TranslateTo(0, -185, 500);
			frame.IsVisible = true;
		}
	}
}