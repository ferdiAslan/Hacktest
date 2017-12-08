#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
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
using Android.Text;
using Syncfusion.SfDataGrid;
using Android.Graphics;
using System.Globalization;

namespace SampleBrowser
{
    public class FrozenView : SamplePage
    {
        #region Fields

        SfDataGrid sfGrid;
        FrozenViewViewModel viewModel;

        #endregion

        #region Override Methods

        public override View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewModel = new FrozenViewViewModel ();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.Products;
            sfGrid.SelectionMode = SelectionMode.Single;
            sfGrid.FrozenRowsCount = 2;
            sfGrid.FrozenColumnsCount = 1;
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            return sfGrid;
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridAutoGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }

        #endregion

        #region CallBacks

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "SupplierID") {
				e.Column.HeaderText = "Supplier ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ProductName") {
				e.Column.HeaderText = "Product Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Quantity") {
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "UnitPrice") {
				e.Column.HeaderText = "Unit Price";
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "UnitsInStock") {
				e.Column.HeaderText = "Units In Stock";
				e.Column.TextAlignment = GravityFlags.Center;
			}
        }

        #endregion
    }
}