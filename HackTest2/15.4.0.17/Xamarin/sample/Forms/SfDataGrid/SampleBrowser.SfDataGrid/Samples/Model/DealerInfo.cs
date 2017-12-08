#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class DealerInfo : INotifyPropertyChanged
    {
        #region private variables

        private int productNo;
        private int productID;
        private string dealerName;
        private bool isOnline;
        private int productprice;
        private ImageSource dealerImage;
        private DateTime shippedDate;

        #endregion

        #region Public Properties

        public ImageSource DealerImage
        {
            get { return this.dealerImage; }
            set
            {
                this.dealerImage = value;
                RaisePropertyChanged("DealerImage");
            }
        }

        public int ProductID
        {
            get { return productID; }
            set
            {
                this.productID = value;
                RaisePropertyChanged("ProductID");
            }
        }

        public string DealerName
        {
            get { return this.dealerName; }
            set
            {
                this.dealerName = value;
                RaisePropertyChanged("DealerName");
            }
        }

        public bool IsOnline
        {
            get { return this.isOnline; }
            set
            {
                this.isOnline = value;
                RaisePropertyChanged("IsOnline");
            }
        }

        public int ProductPrice
        {
            get { return productprice; }
            set
            {
                productprice = value;
                RaisePropertyChanged("ProductPrice");
            }
        }

        public int ProductNo
        {
            get { return productNo; }
            set
            {
                this.productNo = value;
                RaisePropertyChanged("ProductNo");
            }
        }

        public DateTime ShippedDate
        {
            get { return shippedDate; }
            set
            {
                shippedDate = value;
                RaisePropertyChanged("ShippedDate");
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}

