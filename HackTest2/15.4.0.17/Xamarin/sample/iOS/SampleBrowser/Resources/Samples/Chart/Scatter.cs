#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
#endif

namespace SampleBrowser
{
	public class Scatter : SampleView
	{

		public Scatter()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = new NSString("Old Faithful Eruption");
			SFNumericalAxis primary = new SFNumericalAxis();
			primary.ShowMajorGridLines = false;
			chart.PrimaryAxis = primary;
			chart.PrimaryAxis.Title.Text = new NSString("Eruption Duration");
			SFNumericalAxis secondary = new SFNumericalAxis();
			secondary.ShowMajorGridLines = false;
			secondary.Minimum = new NSNumber(-500);
			secondary.Maximum = new NSNumber(700);
			chart.SecondaryAxis = secondary;
			chart.SecondaryAxis.Title.Text = new NSString("Waiting Time Between Eruption");
			ChartViewModel dataModel = new ChartViewModel();

			SFScatterSeries series = new SFScatterSeries();
			series.ItemsSource = dataModel.ScatterData;
			series.XBindingPath = "XValue";
			series.YBindingPath = "YValue";
			series.EnableTooltip = true;
			series.ScatterHeight = 5;
			series.ScatterWidth = 5;
			series.Alpha = 0.7f;
			series.EnableAnimation = true;
			chart.Series.Add(series);

			chart.AddChartBehavior(new SFChartZoomPanBehavior());
			this.AddSubview(chart);

		}

		public override void LayoutSubviews()
		{
			foreach (var view in this.Subviews)
			{
				view.Frame = Bounds;
			}
			base.LayoutSubviews();
		}

	}
}