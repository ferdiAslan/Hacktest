#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleBrowser
{
    public class ExportingViewModel
    {
        #region Constructor 

        public ExportingViewModel()
        {
            OrderDetailsRepository order = new OrderDetailsRepository();
            OrdersInfo = order.GetOrderDetails(100);
        }

        #endregion

        #region ItemsSource

        private ObservableCollection<OrderInfo> _ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return _ordersInfo; }
            set { this._ordersInfo = value; }
        }

        #endregion
    }
}
