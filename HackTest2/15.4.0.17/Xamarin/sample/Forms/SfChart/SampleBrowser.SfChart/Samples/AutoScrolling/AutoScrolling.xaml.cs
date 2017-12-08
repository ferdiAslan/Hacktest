#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfChart
{
	public partial class AutoScrolling : SampleView
	{
		AutoScrollingViewModel viewModel;
		public AutoScrolling()
		{
			InitializeComponent();

			viewModel = Chart.BindingContext as AutoScrollingViewModel;
			viewModel.LoadData();
            (Chart.SecondaryAxis as NumericalAxis).Maximum = 100;
			(Chart.SecondaryAxis as NumericalAxis).Minimum = 0;
		}

        public override void OnAppearing()
        {
            viewModel.IsDisappear = false;

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), viewModel.UpdateData);

            base.OnAppearing();
        }

		public override void OnDisappearing()
		{
			viewModel.IsDisappear = true;
			base.OnDisappearing();
		}
	}
}
