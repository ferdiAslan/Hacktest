#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using UIKit;
using Foundation;

namespace SampleBrowser
{
	public class OrderInfo : INotifyPropertyChanged
	{
		public OrderInfo ()
		{
		}

		#region private variables

		private string _orderID;
		private string _employeeID;
		private string _customerID;
		private string _firstname;
		private string _lastname;
		private string _gender;
		private string _shipCity;
		private string _shipCountry;
		private string _freight;
		private DateTime _shippingDate;
		private string _isClosed;


		#endregion

		#region Public Properties
		[Preserve]
		public string OrderID {
			get {
				return _orderID; 
			}
			set { 
				this._orderID = value; 
				RaisePropertyChanged ("OrderID"); 
			}
		}
		[Preserve]
		public string EmployeeID {
			get { 
				return _employeeID; 
			}
			set { 
				this._employeeID = value;
				RaisePropertyChanged ("EmployeeID");
			}
		}
		[Preserve]
		public string CustomerID {
			get {
				return _customerID;
			}
			set {
				this._customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}
		[Preserve]
		public string FirstName {
			get { 
				return _firstname; 
			}
			set { 
				this._firstname = value;
				RaisePropertyChanged ("FirstName");
			}
		}
		[Preserve]
		public string LastName {
			get { 
				return _lastname; 
			}
			set { 
				this._lastname = value;
				RaisePropertyChanged ("LastName");
			}
		}
		[Preserve]
		public string Gender {
			get { 
				return _gender; 
			}
			set { 
				this._gender = value;
				RaisePropertyChanged ("Gender");
			}
		}
		[Preserve]
		public string ShipCity {
			get { 
				return _shipCity; 
			}
			set { 
				this._shipCity = value;
				RaisePropertyChanged ("ShipCity");
			}
		}
		[Preserve]
		public string ShipCountry {
			get { 
				return _shipCountry; 
			}
			set { 
				this._shipCountry = value;
				RaisePropertyChanged ("ShipCountry");
			}
		}
		[Preserve]
		public string Freight {
			get { 
				return _freight; 
			}
			set {
				this._freight = value;
				RaisePropertyChanged ("Freight"); 
			}
		}
		[Preserve]
		public string IsClosed {
			get {
				return _isClosed;
			}
			set {
				this._isClosed = value;
				RaisePropertyChanged ("IsClosed");
			}
		}
		[Preserve]
		public DateTime ShippingDate {
			get { 
				return _shippingDate;
			}
			set { 
				this._shippingDate = value;
				RaisePropertyChanged ("ShippingDate");
			}
		}



		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged (String Name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged (this, new PropertyChangedEventArgs (Name));
		}

		#endregion
	}
}

