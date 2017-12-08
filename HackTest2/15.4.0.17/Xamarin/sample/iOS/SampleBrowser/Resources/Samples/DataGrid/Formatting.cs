#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using System.Globalization;
using CoreGraphics;

namespace SampleBrowser
{
	public class Formatting:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;
		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Formatting ()
		{
			SfGrid = new SfDataGrid ();
			GridTextColumn customerImageColumn = new GridTextColumn ();
			customerImageColumn.UserCellType = typeof(GridImageCell);
			customerImageColumn.MappingName = "CustomerImage";
			customerImageColumn.HeaderText = "Image";

			GridTextColumn isOpenColumn = new GridTextColumn ();
			isOpenColumn.UserCellType = typeof(BoolFormatCell);
			isOpenColumn.MappingName = "IsOpen";
			isOpenColumn.HeaderText = "Is Open";

			GridTextColumn balanceScaleColumn = new GridTextColumn ();
			balanceScaleColumn.UserCellType = typeof(LinearGuageCell);
			balanceScaleColumn.MappingName = "BalanceScale";
			balanceScaleColumn.HeaderText = "Balance Scale";

			GridTextColumn chartcell = new GridTextColumn ();
			chartcell.UserCellType = typeof(LineChartCell);
			chartcell.MappingName = "Transactions";
			chartcell.HeaderText = "Transactions";

			GridTextColumn customerIdColumn = new GridTextColumn ();
			customerIdColumn.MappingName = "CustomerID";
			customerIdColumn.HeaderText = "Customer ID";
			customerIdColumn.TextAlignment = UITextAlignment.Center;


			GridTextColumn currentColumn = new GridTextColumn ();
			currentColumn.MappingName = "Current";
			currentColumn.Format = "C";
			currentColumn.CultureInfo = new CultureInfo ("en-US");
			currentColumn.TextAlignment = UITextAlignment.Center;

			GridTextColumn customerNameColumn = new GridTextColumn ();
			customerNameColumn.MappingName = "CustomerName";
			customerNameColumn.HeaderText = "Customer Name";
			customerNameColumn.TextMargin = 10;
			customerNameColumn.TextAlignment = UITextAlignment.Left;

			GridTextColumn savingsColumn = new GridTextColumn ();
			savingsColumn.MappingName = "Savings";
			savingsColumn.Format = "C";
			savingsColumn.CultureInfo = new CultureInfo ("en-US");
			savingsColumn.TextAlignment = UITextAlignment.Center;

			SfGrid.Columns.Add (customerImageColumn);
			SfGrid.Columns.Add (chartcell);
			SfGrid.Columns.Add (customerIdColumn);
			SfGrid.Columns.Add (currentColumn);
			SfGrid.Columns.Add (customerNameColumn);
			SfGrid.Columns.Add (savingsColumn);
			SfGrid.Columns.Add (balanceScaleColumn);
			SfGrid.Columns.Add (isOpenColumn);
			SfGrid.AutoGenerateColumns = false;
            this.SfGrid.SelectionMode = SelectionMode.Single;
            SfGrid.ItemsSource = new FormattingViewModel ().BankInfo;
			SfGrid.GridStyle.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			SfGrid.SelectionMode = SelectionMode.Single;
			SfGrid.HeaderRowHeight = 45;
			SfGrid.RowHeight = 65;
			this.AddSubview (SfGrid);
		}

		public override void LayoutSubviews ()
		{
            if (Utility.IsIpad)
            {
                if ((UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft)
                    || (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight))
                    this.SfGrid.ColumnSizer = ColumnSizer.LastColumnFill;
                else
                    this.SfGrid.ColumnSizer = ColumnSizer.None;
            }
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

