#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
	internal class RotatorViewModel
	{
		public RotatorViewModel()
		{
			if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
			{
				
				ImageCollection.Add(new RotatorModel("movie1.png"));
				ImageCollection.Add(new RotatorModel("movie2.png"));
				ImageCollection.Add(new RotatorModel("movie3.png"));
				ImageCollection.Add(new RotatorModel("movie6.png"));
				ImageCollection.Add(new RotatorModel("movie4.png"));
				ImageCollection.Add(new RotatorModel("movie5.png"));
			}
		}
		private List<RotatorModel> imageCollection = new List<RotatorModel>();

		public List<RotatorModel> ImageCollection
		{
			get { return imageCollection; }
			set { imageCollection = value; }
		}

	}



}



