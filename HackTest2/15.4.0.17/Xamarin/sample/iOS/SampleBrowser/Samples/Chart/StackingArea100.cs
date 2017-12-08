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
	public class StackingArea100 :SampleView
	{
		public StackingArea100 ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 					= new NSString ("Annual Temperature Comparison");
			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.Title.Text 				= new NSString ("Year");
			chart.PrimaryAxis 					= primaryAxis;
			chart.SecondaryAxis 				= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text 		= new NSString ("Temperature (%)");
			chart.SecondaryAxis.Interval 		= new NSNumber (10);
			ChartViewModel dataModel			= new ChartViewModel();

			SFStackingArea100Series series1 = new SFStackingArea100Series();
			series1.ItemsSource = dataModel.StackedArea100Data1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.BorderColor = UIColor.FromRGB(255, 190, 6);
			series1.Alpha = 0.5f;
			series1.Label = "USA";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStackingArea100Series series2 = new SFStackingArea100Series();
			series2.ItemsSource = dataModel.StackedArea100Data2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.BorderColor = UIColor.FromRGB(81, 72, 58);
			series2.Alpha = 0.5f;
			series2.Label = "India";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFStackingArea100Series series3 = new SFStackingArea100Series();
			series3.ItemsSource = dataModel.StackedArea100Data3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.5f;
			series3.BorderColor = UIColor.FromRGB(193, 82, 68);
			series3.Label = "Canada";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			SFStackingArea100Series series4 = new SFStackingArea100Series();
			series4.ItemsSource = dataModel.StackedArea100Data4;
			series4.XBindingPath = "XValue";
			series4.YBindingPath = "YValue";
			series4.EnableTooltip = true;
			series4.Alpha = 0.5f;
			series4.BorderColor = UIColor.FromRGB(144, 168, 78);
			series4.Label = "China";
			series4.LegendIcon = SFChartLegendIcon.Rectangle;
			series4.EnableAnimation = true;
			chart.Series.Add(series4);

			chart.Legend.Visible 				= true;
			chart.Legend.DockPosition 			= SFChartLegendPosition.Bottom;
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
			this.AddSubview(chart);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
			}
			base.LayoutSubviews ();
		}

	}

}