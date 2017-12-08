#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.XlsIO
{
	[Preserve(AllMembers = true)]
    public class SamplePages : SampleView
    {
        public SamplePages()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

