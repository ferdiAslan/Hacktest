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
	public class RangeArea : SampleView
	{
		public RangeArea()
		{
			SFChart chart = new SFChart();
			chart.Title.Text = new NSString("World Gold Price");
			SFCategoryAxis primary = new SFCategoryAxis();
			primary.Title.Text = new NSString("Month");
			chart.PrimaryAxis = primary;
			chart.SecondaryAxis = new SFNumericalAxis();
			chart.SecondaryAxis.Minimum = new NSNumber(5);
			chart.SecondaryAxis.Maximum = new NSNumber(55);
			chart.SecondaryAxis.Title.Text = new NSString("Gold Price");
			ChartViewModel dataModel = new ChartViewModel();

			SFRangeAreaSeries series1 = new SFRangeAreaSeries();
			series1.ItemsSource = dataModel.RangeAreaData;
			series1.XBindingPath = "XValue";
			series1.High = "High";
			series1.Low = "Low";
			series1.EnableTooltip = true;
			series1.Alpha = 0.5f;
			series1.Label = "India";
			series1.LegendIcon = SFChartLegendIcon.Rectangle;
			series1.EnableAnimation = true;
			chart.Series.Add(series1);

			SFRangeAreaSeries series2 = new SFRangeAreaSeries();
			series2.ItemsSource = dataModel.RangeAreaData1;
			series2.XBindingPath = "XValue";
			series2.High = "High";
			series2.Low = "Low";
			series2.EnableTooltip = true;
			series2.Alpha = 0.5f;
			series2.Label = "Germany";
			series2.LegendIcon = SFChartLegendIcon.Rectangle;
			series2.EnableAnimation = true;
			chart.Series.Add(series2);

			chart.Legend.Visible = true;
			chart.Legend.DockPosition = SFChartLegendPosition.Bottom;
			chart.ColorModel.Palette = SFChartColorPalette.TomatoSpectrum;
			chart.AddChartBehavior(new SFChartZoomPanBehavior());
			chart.PrimaryAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
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
