#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using UIKit;
using Syncfusion.SfDataGrid;
using CoreGraphics;

namespace SampleBrowser
{
	public class RenderingDynamicData:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public RenderingDynamicData ()
		{
			this.SfGrid = new SfDataGrid ();
			GridTextColumn stockColumn = new GridTextColumn ();
			stockColumn.UserCellType = typeof(StockCell);
			stockColumn.MappingName = "StockChange";
			stockColumn.HeaderText = "Stock Change";
			stockColumn.AllowSorting = false;
			this.SfGrid.Columns.Add (stockColumn);
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = new StocksViewModel ().Stocks;
            if (Utility.IsIpad)
                this.SfGrid.ColumnSizer = ColumnSizer.Star;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			this.AddSubview (SfGrid);
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "LastTrade") {
				e.Column.HeaderText = "Last Trade";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "Change") {
				e.Column.TextAlignment = UITextAlignment.Right;
			} else if (e.Column.MappingName == "PreviousClose") {
				e.Column.HeaderText = "Previous Close";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "Open") {
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "Account") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 15;
				e.Column.Format = "C";
			} else if (e.Column.MappingName == "Symbol") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 30;
			} else if (e.Column.MappingName == "Volume") {
				e.Column.TextAlignment = UITextAlignment.Center;
			}
		}

		public override void LayoutSubviews ()
		{
            this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            SfGrid.Dispose();
        }
    }
}

