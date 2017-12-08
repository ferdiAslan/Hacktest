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
	public class StackedBar :SampleView
	{
		public StackedBar ()
		{
			SFChart chart 							  = new SFChart ();
			chart.Title.Text						  = new NSString ("Sales Comparison");
			SFCategoryAxis primaryAxis 				  = new SFCategoryAxis ();
			primaryAxis.LabelPlacement 				  = SFChartLabelPlacement.BetweenTicks;
			primaryAxis.Title.Text					  = new NSString ("Month");
			chart.PrimaryAxis 						  = primaryAxis;
			chart.SecondaryAxis 					  = new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text			  = new NSString ("Percentage (%)");
			chart.SecondaryAxis.Minimum 			  = new NSNumber (-20);
			chart.SecondaryAxis.Maximum				  = new NSNumber (100);
			chart.SecondaryAxis.Interval			  = new NSNumber (20);
			chart.SecondaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			ChartViewModel dataModel				  = new ChartViewModel ();

			SFStackingBarSeries series1 = new SFStackingBarSeries();
			series1.ItemsSource = dataModel.StackedBarData1;
			series1.XBindingPath = "XValue";
			series1.YBindingPath = "YValue";
			series1.EnableTooltip = true;
			series1.Label = "Apple";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFStackingBarSeries series2 = new SFStackingBarSeries();
			series2.ItemsSource = dataModel.StackedBarData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Label = "Orange";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFStackingBarSeries series3 = new SFStackingBarSeries();
			series3.ItemsSource = dataModel.StackedBarData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Label = "Wastage";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			chart.Legend.Visible 					  = true;
			chart.Legend.DockPosition				  = SFChartLegendPosition.Bottom;
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