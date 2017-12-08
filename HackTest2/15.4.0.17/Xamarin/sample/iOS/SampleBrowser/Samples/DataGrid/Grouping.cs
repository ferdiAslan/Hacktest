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
using CoreGraphics;
using System.Globalization;

namespace SampleBrowser
{
	public class Grouping:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public Grouping ()
		{
			this.SfGrid = new SfDataGrid ();
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.ItemsSource = new GroupingViewModel ().ProductDetails;
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "Product" });
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
            this.SfGrid.AllowGroupExpandCollapse = true;
            this.SfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
            this.SfGrid.AllowResizingColumn = true;
            this.SfGrid.GridStyle = new CustomGridStyle(); 

            //TableSummary codes
            GridTableSummaryRow summaryRow = new GridTableSummaryRow();
            summaryRow.Title = "Total items:{Total} items";
            summaryRow.ShowSummaryInRow = true;
            summaryRow.Position = Position.Bottom;
            GridSummaryColumn summaryColumn = new GridSummaryColumn();
            summaryColumn.Name = "Total";
            summaryColumn.MappingName = "ProductID";
            summaryColumn.Format = "{Count}";
            summaryColumn.SummaryType = Syncfusion.Data.SummaryType.CountAggregate;
            summaryRow.SummaryColumns.Add(summaryColumn);
            this.SfGrid.TableSummaryRows.Add(summaryRow);

            this.AddSubview (SfGrid);
		}

		void SfGrid_QueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			if (SfDataGridHelpers.IsCaptionSummaryRow (SfGrid, e.RowIndex)) {
				e.Height = 30;
				e.Handled = true;
			}
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnEventArgs e)
		{
            if (UserInterfaceIdiomIsPhone)
                e.Column.MaximumWidth = 150;
            else
                e.Column.MaximumWidth = 300;
            if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
			} else if (e.Column.MappingName == "UserRating") {
				e.Column.HeaderText = "User Rating";
			} else if (e.Column.MappingName == "ProductModel") {
				e.Column.HeaderText = "Product Model";
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Price") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShippingDays") {
				e.Column.HeaderText = "Shipping Days";
			} else if (e.Column.MappingName == "ProductType") {
				e.Column.HeaderText = "Product Type";
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "Availability") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 15;
			}
		}

		public override void LayoutSubviews ()
		{
            if(Utility.IsIpad)
            {
                if ((UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeLeft)
                    || (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.LandscapeRight))
                    this.SfGrid.ColumnSizer = ColumnSizer.Star;
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

