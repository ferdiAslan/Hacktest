#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;


namespace SampleBrowser
{
    public class StackingBar : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.Title.Text = "Sales Comparison";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.DockPosition = ChartDock.Bottom;

            CategoryAxis PrimaryAxis = new CategoryAxis();
            PrimaryAxis.Title.Text = "Month";
            PrimaryAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            PrimaryAxis.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = PrimaryAxis;

            NumericalAxis numericalAxis = new NumericalAxis();
            numericalAxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            numericalAxis.Title.Text = "Percentage (%)";
            numericalAxis.Minimum = -20;
            numericalAxis.Maximum = 100;
            numericalAxis.Interval = 20;
            chart.SecondaryAxis = numericalAxis;

            StackingBarSeries stackingBarSeries = new StackingBarSeries();
            stackingBarSeries.LegendIcon = ChartLegendIcon.Rectangle;
            stackingBarSeries.Label = "Apple";
			stackingBarSeries.ItemsSource = MainPage.GetStackedBarData1();
			stackingBarSeries.XBindingPath = "XValue";
			stackingBarSeries.YBindingPath = "YValue";

            StackingBarSeries stackingBarSeries1 = new StackingBarSeries();
            stackingBarSeries1.LegendIcon = ChartLegendIcon.Rectangle;
            stackingBarSeries1.Label = "Orange";
			stackingBarSeries1.ItemsSource = MainPage.GetStackedBarData2();
			stackingBarSeries1.XBindingPath = "XValue";
			stackingBarSeries1.YBindingPath = "YValue";

            StackingBarSeries stackingBarSeries2 = new StackingBarSeries();
            stackingBarSeries2.LegendIcon = ChartLegendIcon.Rectangle;
            stackingBarSeries2.Label = "Wastage";
			stackingBarSeries2.ItemsSource = MainPage.GetStackedBarData3();
			stackingBarSeries2.XBindingPath = "XValue";
			stackingBarSeries2.YBindingPath = "YValue";

            chart.Series.Add(stackingBarSeries);
            chart.Series.Add(stackingBarSeries1);
            chart.Series.Add(stackingBarSeries2);

            stackingBarSeries.TooltipEnabled = true;
            stackingBarSeries1.TooltipEnabled = true;
            stackingBarSeries2.TooltipEnabled = true;
			
            stackingBarSeries.EnableAnimation = true;
            stackingBarSeries1.EnableAnimation = true;
            stackingBarSeries2.EnableAnimation = true;
       
            return chart;
        }
    }
}
