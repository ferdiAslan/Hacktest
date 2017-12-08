#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.SfChart
{
	public class StepAreaSeriesViewModel
	{
		public ObservableCollection<ChartDataModel> StepAreaData1 { get; set; }

		public StepAreaSeriesViewModel()
		{
			StepAreaData1 = new ObservableCollection<ChartDataModel>
			{
				new ChartDataModel(2006, 400),
				new ChartDataModel(2007, 480),
				new ChartDataModel(2008, 460),
				new ChartDataModel(2009, 520),
				new ChartDataModel(2010, 450),
				new ChartDataModel(2011, 450)
			};
		}
	}
}