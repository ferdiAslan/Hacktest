using HackTest2.Views;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HackTest2
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new RootPage();
		}
	}
}