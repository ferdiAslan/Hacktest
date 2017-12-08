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

namespace SampleBrowser
{
	public class Red : DataGridStyle
	{
		public Red ()
		{
		}

		public override UIColor GetHeaderBackgroundColor ()
		{
			return UIColor.FromRGB (242, 242, 242);
		}

		public override UIColor GetAlternatingRowBackgroundColor ()
		{
			return UIColor.FromRGB (252, 242, 240);
		}

		public override UIColor GetSelectionBackgroundColor ()
		{
			return UIColor.FromRGB (201, 93, 55);
		}

		public override UIColor GetSelectionForegroundColor ()
		{
			return UIColor.FromRGB (255, 255, 255);
		}

		public override UIColor GetCaptionSummaryRowBackgroundColor ()
		{
			return UIColor.FromRGB (224, 224, 224);
		}

		public override UIColor GetCaptionSummaryRowForeGroundColor ()
		{
			return UIColor.FromRGB (51, 51, 51);
		}

		public override UIColor GetBordercolor ()
		{
			return UIColor.FromRGB (180, 180, 180);
		}

//		public override int GetHeaderSortIndicatorDown ()
//		{
//			return Resource.Drawable.SortingDown;
//		}
//
//		public override int GetHeaderSortIndicatorUp ()
//		{
//			return Resource.Drawable.SortingUp;
//		}
	}
}

