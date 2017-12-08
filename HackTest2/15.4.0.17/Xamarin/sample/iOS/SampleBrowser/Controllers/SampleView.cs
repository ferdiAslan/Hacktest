#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	public class SampleView : UIView
	{
		public SampleView()
		{
		}

		public UIView OptionView
		{
			get;
			set;
		}

		public CGSize PopoverSize
		{
			get
			{
				return new CGSize(320.0, 400.0);
			}
		}

        public UINavigationController NavigationController
        {
            get; set;
        }

    }
}

