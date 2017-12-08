#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using SampleBrowser.Core.iOS;

namespace SampleBrowser.SfBarcode.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        double statusBarHeight, navBarHeight;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            statusBarHeight = app.StatusBarFrame.Size.Height;
            navBarHeight = new CustomNavigationPageRenderer().NavigationBar.Frame.Height;
            global::Xamarin.Forms.Forms.Init();
			new Syncfusion.SfBarcode.XForms.iOS.SfBarcodeRenderer();
            SampleBrowser.SfBarcode.iOS.SfBarcodeSampleBrowser.Init();
            Syncfusion.ListView.XForms.iOS.SfListViewRenderer.Init();
            SampleBrowser.Core.iOS.CoreSampleBrowser.Init(UIScreen.MainScreen.Bounds,app.StatusBarFrame.Size.Height);
            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
        }
    }
}
