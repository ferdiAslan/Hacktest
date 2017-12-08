#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser.SfRating
{
	public class CustomLabel :Label
	{
		public CustomLabel()
		{
			this.HorizontalTextAlignment = TextAlignment.Center;
		}

		public static readonly BindableProperty CurvedCornerRadiusProperty =
			BindableProperty.Create(nameof(CurvedCornerRadius), typeof(double), typeof(CustomLabel), 10.0);

		public double CurvedCornerRadius
		{
			get { return (double)GetValue(CurvedCornerRadiusProperty); }
			set { SetValue(CurvedCornerRadiusProperty, value); }
		}

	}
}
