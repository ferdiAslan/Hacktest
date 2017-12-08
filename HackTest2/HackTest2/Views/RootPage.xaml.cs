using HackTest2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackTest2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RootPage : MasterDetailPage
	{
		public RootPage ()
		{
			InitializeComponent ();
			Detail = new NavigationPage(new DetailPage1());
			IsPresented = false;

		}

		public void OnButton1Clicked(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new DetailPage1());
			IsPresented = false;
		}

		public void OnButton2Clicked(object sender, System.EventArgs e)
		{
			Detail = new NavigationPage(new DetailPage2());
			IsPresented = false;
		}
	}
}