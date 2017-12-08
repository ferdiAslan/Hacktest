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

namespace SampleBrowser
{
	public class AutoRowHeight:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public AutoRowHeight ()
		{
			this.SfGrid = new SfDataGrid ();
			this.SfGrid.AllowSorting = false;
            this.SfGrid.SelectionMode = SelectionMode.Single;
			this.SfGrid.AllowTriStateSorting = false;
			this.SfGrid.AlternationCount = 2;
            this.SfGrid.ColumnSizer = ColumnSizer.None;
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = new AutoRowHeightViewModel ().ReleaseInformation;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.QueryRowHeight += GridQueryRowHeight;
            if (!UserInterfaceIdiomIsPhone)
            {
                GridTextColumn sno = new GridTextColumn();
                sno.MappingName = "SNo";
                sno.HeaderText = "S.No";
                sno.ColumnSizer = ColumnSizer.Auto;
                sno.HeaderTextAlignment = UITextAlignment.Center;
                sno.TextAlignment = UITextAlignment.Center;
                this.SfGrid.Columns.Insert(0, sno);
                this.SfGrid.ColumnSizer = ColumnSizer.Star;
            }
            this.AddSubview (SfGrid);
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
            if (e.Column.MappingName == "SNo")
                e.Cancel = true;
            if (e.Column.MappingName == "ReleaseVersion")
            {
                e.Column.LineBreakMode = UILineBreakMode.WordWrap;
                e.Column.HeaderText = "Release Version";
                e.Column.TextAlignment = UITextAlignment.Left | UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "Platform")
            {
                e.Column.HeaderText = "Platform";
                e.Column.LineBreakMode = UILineBreakMode.WordWrap;
                e.Column.TextAlignment = UITextAlignment.Left ;
            }
            else if (e.Column.MappingName == "Features")
            {
                e.Column.HeaderText = "Feature";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.LineBreakMode = UILineBreakMode.WordWrap;
            }
            else if (e.Column.MappingName == "Description")
            {
                e.Column.HeaderText = "Description";
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.LineBreakMode = UILineBreakMode.WordWrap;
            }
        }

		void GridQueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
            if (e.RowIndex > 0)
            {
                double height = SfDataGridHelpers.GetRowHeight(SfGrid, e.RowIndex);
                e.Height = height;
                e.Handled = true;
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

