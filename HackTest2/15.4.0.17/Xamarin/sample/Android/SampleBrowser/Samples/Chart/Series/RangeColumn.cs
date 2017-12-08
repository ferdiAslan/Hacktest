#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    internal class RangeColumn : SamplePage
    {
        SfChart chart;
        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.Title.Text = "Maximum and Minimum Temperature - 2012";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.TomatoSpectrum;

            CategoryAxis categoryaxis = new CategoryAxis();
            categoryaxis.Title.Text = "Month";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Title.Text = "Temperature (celsius)";
            chart.SecondaryAxis = numericalaxis;

            RangeColumnSeries rangeColumnSeries = new RangeColumnSeries();
			rangeColumnSeries.ItemsSource = MainPage.GetRangeColumnData1();
			rangeColumnSeries.XBindingPath = "XValue";
			rangeColumnSeries.High = "High";
			rangeColumnSeries.Low = "Low";
            rangeColumnSeries.Label = "India";
            rangeColumnSeries.LegendIcon = ChartLegendIcon.Rectangle;

            RangeColumnSeries rangeColumnSeries1 = new RangeColumnSeries();
			rangeColumnSeries1.ItemsSource = MainPage.GetRangeColumnData2();
			rangeColumnSeries1.XBindingPath = "XValue";
			rangeColumnSeries1.High = "High";
			rangeColumnSeries1.Low = "Low";
            rangeColumnSeries1.Label = "Germany";
            rangeColumnSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            
            chart.Series.Add(rangeColumnSeries);
            chart.Series.Add(rangeColumnSeries1);
            rangeColumnSeries.TooltipEnabled = true;
            rangeColumnSeries1.TooltipEnabled = true;
			
            rangeColumnSeries.EnableAnimation = true;
            rangeColumnSeries1.EnableAnimation = true;
            return chart;
        }
    }
}