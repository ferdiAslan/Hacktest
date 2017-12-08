#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SampleBrowser.Core.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

            
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            SetScreenDimension();
           
            if (AnalyticsInfo.VersionInfo.DeviceFamily != "Windows.Mobile")
                this.Resources.Remove("TitleTextBlockStyle");
            var titleBar = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().TitleBar;

            // set up our brushes
            SolidColorBrush bkgColor = Current.Resources["TitleBarBackgroundThemeBrush"] as SolidColorBrush;
            SolidColorBrush btnHoverColor = Current.Resources["TitleBarButtonHoverThemeBrush"] as SolidColorBrush;
            SolidColorBrush btnPressedColor = Current.Resources["TitleBarButtonPressedThemeBrush"] as SolidColorBrush;

            // override colors!
            titleBar.BackgroundColor = bkgColor.Color;
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = bkgColor.Color;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonHoverBackgroundColor = btnHoverColor.Color;
            titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonPressedBackgroundColor = btnPressedColor.Color;
            titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.White;
            titleBar.InactiveBackgroundColor = bkgColor.Color;
            titleBar.InactiveForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonInactiveBackgroundColor = bkgColor.Color;
            titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.White;

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().BackgroundColor = Color.FromArgb(1, 0, 125, 230);
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().BackgroundOpacity = 1;
                Windows.UI.ViewManagement.StatusBar.GetForCurrentView().ForegroundColor = Colors.White;
            }

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = false;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;
                List<Assembly> assembliesToInclude = new List<Assembly>();
                assembliesToInclude.Add(typeof(Syncfusion.ListView.XForms.UWP.SfListViewRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfAutoComplete.XForms.UWP.SfAutoCompleteRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfBarcode.XForms.UWP.SfBarcodeRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfBusyIndicator.XForms.UWP.SfBusyIndicatorRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfCalendar.XForms.UWP.SfCalendarRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfCarousel.XForms.UWP.SfCarouselRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfChart.XForms.UWP.SfChartRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.RangeNavigator.XForms.UWP.SfRangeNavigatorRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfDataGrid.XForms.UWP.SfDataGridRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfGauge.XForms.UWP.SfGaugeRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfKanban.XForms.UWP.SfKanbanRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfMaps.XForms.UWP.SfMapsRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfNavigationDrawer.XForms.UWP.SfNavigationDrawerRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfNumericTextBox.XForms.SfNumericTextBox).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfNavigationDrawer.XForms.UWP.SfNavigationDrawerRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfNumericUpDown.XForms.UWP.SfNumericUpDownRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfPdfViewer.XForms.UWP.SfPdfDocumentViewRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfRangeSlider.XForms.UWP.SfRangeSliderRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfRating.XForms.UWP.SfRatingRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfRotator.XForms.UWP.SfRotatorRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfSchedule.XForms.UWP.SfScheduleRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfSparkline.XForms.UWP.SfSparklineRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfSunburstChart.XForms.UWP.SfSunburstChartRenderer).GetTypeInfo().Assembly);
                assembliesToInclude.Add(typeof(Syncfusion.SfTreeMap.XForms.UWP.SfTreeMapRenderer).GetTypeInfo().Assembly);
                Xamarin.Forms.Forms.Init(e, assembliesToInclude);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        private void SetScreenDimension()
        {
            double topPadding = 0;
            double bottomPadding = 0;
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                topPadding = Windows.UI.ViewManagement.StatusBar.GetForCurrentView().OccludedRect.Height;
                bottomPadding = 15;
            }
            SampleBrowser.App.ScreenWidth = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            SampleBrowser.App.ScreenHeight = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Height - (topPadding + bottomPadding);
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
