﻿using Rg.Plugins.Popup.Pages;
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
	public partial class PopupPage1 : PopupPage
	{
		public PopupPage1()
		{
			InitializeComponent();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		// Method for animation child in PopupPage
		// Invoced after custom animation end
		protected override Task OnAppearingAnimationEnd()
		{
			return Content.FadeTo(0.5);
		}

		// Method for animation child in PopupPage
		// Invoked before custom animation begin
		protected override Task OnDisappearingAnimationBegin()
		{
			return Content.FadeTo(1);
		}

		protected override bool OnBackButtonPressed()
		{
			// Prevent hide popup
			//return base.OnBackButtonPressed();
			return true;
		}

		// Invoced when background is clicked
		protected override bool OnBackgroundClicked()
		{
			// Return default value - CloseWhenBackgroundIsClicked
			return base.OnBackgroundClicked();
		}
	}
}