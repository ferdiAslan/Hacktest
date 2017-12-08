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
	public class Area : SampleView
	{
		public Area ()
		{
			SFChart chart 					= new SFChart ();
			chart.Title.Text				= new NSString ("Average Sales Comparison");
			chart.Title.TextAlignment		= UITextAlignment.Center;
			SFCategoryAxis primaryAxis 		= new SFCategoryAxis();
			chart.PrimaryAxis 				= primaryAxis;
			primaryAxis.Title.Text			= new NSString ("Year");	
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			chart.SecondaryAxis 			= secondaryAxis;
			secondaryAxis.Title.Text		= new NSString ("Sales Amount in Millions");
			secondaryAxis.Minimum 			= new NSNumber (2);
			secondaryAxis.Maximum 			= new NSNumber (5);
			secondaryAxis.Interval			= new NSNumber (0.5);
			ChartViewModel dataModel 		= new ChartViewModel ();

			SFAreaSeries series1	= new SFAreaSeries();
			series1.ItemsSource		= dataModel.AreaData1;
			series1.XBindingPath	= "XValue";
			series1.YBindingPath	= "YValue";
			series1.EnableTooltip	= true;
			series1.Alpha 			= 0.5f;
			series1.Label			= "ProductA"; 		
			series1.LegendIcon 		= SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFAreaSeries series2 = new SFAreaSeries();
			series2.ItemsSource = dataModel.AreaData2;
			series2.XBindingPath = "XValue";
			series2.YBindingPath = "YValue";
			series2.EnableTooltip = true;
			series2.Alpha = 0.5f;
			series2.Label = "ProductB";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			SFAreaSeries series3 = new SFAreaSeries();
			series3.ItemsSource = dataModel.AreaData3;
			series3.XBindingPath = "XValue";
			series3.YBindingPath = "YValue";
			series3.EnableTooltip = true;
			series3.Alpha = 0.5f;
			series3.Label = "ProductC";
			series3.LegendIcon = SFChartLegendIcon.Rectangle;
			series3.EnableAnimation = true;
			chart.Series.Add(series3);

			chart.Legend.Visible			= true;
			chart.Legend.DockPosition		= SFChartLegendPosition.Bottom;
			chart.ColorModel.Palette 		= SFChartColorPalette.TomatoSpectrum;

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

