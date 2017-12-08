#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class CustomerDetails
	{
		#region private variables
		private string _customerID;
		private string _firstname;
		private string _lastname;
		private string _gender;
		private string _city;
		private string _country;
		#endregion

		#region Public Properties

		public string CustomerID {
			get {
				return _customerID;
			}
			set {
				this._customerID = value;
				RaisePropertyChanged ("CustomerID");
			}
		}

		public string FirstName {
			get { 
				return _firstname; 
			}
			set { 
				this._firstname = value;
				RaisePropertyChanged ("FirstName");
			}
		}

		public string LastName {
			get { 
				return _lastname; 
			}
			set { 
				this._lastname = value;
				RaisePropertyChanged ("LastName");
			}
		}

		public string Gender {
			get { 
				return _gender; 
			}
			set { 
				this._gender = value;
				RaisePropertyChanged ("Gender");
			}
		}

		public string City {
			get { 
				return _city; 
			}
			set { 
				this._city = value;
				RaisePropertyChanged ("City");
			}
		}

		public string Country {
			get { 
				return _country; 
			}
			set { 
				this._country = value;
				RaisePropertyChanged ("Country");
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

