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
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class StackingBar100 : SampleView
	{
		public StackingBar100()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = new NSString("Sales by Year");
			SFNumericalAxis primaryAxis = new SFNumericalAxis();
			primaryAxis.Interval = new NSNumber(1);
			primaryAxis.Title.Text = new NSString("Year");
			chart.PrimaryAxis = primaryAxis;
			chart.SecondaryAxis = new SFNumericalAxis();
			chart.SecondaryAxis.Title.Text = new NSString("Sales Percentage (%)");
			ChartViewModel dataModel = new ChartViewModel();

			SFStackingBar100Series series1 = new SFStackingBar100Series();
			series1.ItemsSource = dataModel.StackedBar100Data1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "John";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStackingBar100Series series2 = new SFStackingBar100Series();
			series2.ItemsSource = dataModel.StackedBar100Data2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "Andrew";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFStackingBar100Series series3 = new SFStackingBar100Series();
			series3.ItemsSource = dataModel.StackedBar100Data3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Label = "Thomas";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			SFStackingBar100Series series4 = new SFStackingBar100Series();
			series4.ItemsSource = dataModel.StackedBar100Data4;
			series4.XBindingPath = "XValue";
			series4.YBindingPath = "YValue";
			series4.EnableTooltip = true;
			series4.Label = "Henry";
			series4.LegendIcon = SFChartLegendIcon.Rectangle;
			series4.EnableAnimation = true;
			chart.Series.Add(series4);

			chart.Legend.Visible = true;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
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
