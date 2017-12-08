#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfDataGrid
{
    [Preserve(AllMembers = true)]
    public class ReleaseInfoRepository
    {
        public ReleaseInfoRepository()
        {
        }

        #region GetOrderDetails

        public ObservableCollection<ReleaseInfo> GetReleaseDetails(int count)
        {
            ObservableCollection<ReleaseInfo> releaseDetails = new ObservableCollection<ReleaseInfo>();

            for (int i = 0; i < count; i++)
            {
                var details = new ReleaseInfo()
                {
                    SNo = i+1,
                    DateOfRelease = DateOfRelease[i],
                    ReleaseVersion = ReleaseVersion[i],
                    Description = Description[i],
                    Platform = Platforms[i],
                    Features = Features[i]
                };
                releaseDetails.Add(details);
            }
            return releaseDetails;
        }
        #endregion

        string[] Platforms = new string[] {
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
            "Xamarin Forms",
            "Xamarin Android",
            "Xamarin iOS",
        };

        string[] ReleaseVersion = new string[] {
            "1.2",
            "1.2",
            "1.2",
            "1.2",
            "1.2",
            "1.2",
            "1.2",
            "1.3",
            "1.3",
            "1.3",
            "1.3",
            "1.3",
            "1.3",
            "1.3",
            "1.4",
            "1.4",
            "1.4",
            "1.4",
            "1.4",
            "1.4",
            "1.5",
            "1.5",
            "1.5",
            "1.5",
            "1.5",
            "1.5",
            "1.5",
            "1.5",
        };

        string[] DateOfRelease = new string[] {
            "Jan 14, 2016",
            "Jan 14, 2016",
            "Jan 14, 2016",
            "Feb 12, 2016",
            "Feb 12, 2016",
            "Feb 12, 2016",
            "Mar 17, 2016",
            "Mar 17, 2016",
            "Mar 17, 2016",
            "Apr 5, 2016",
            "Apr 5, 2016",
            "Apr 5, 2016",
            "May 3, 2016",
            "May 3, 2016",
            "May 3, 2016",
            "June 24, 2016",
            "June 24, 2016",
            "June 24, 2016",
            "July 29, 2016",
            "July 29, 2016",
            "July 29, 2016",
            "Aug 30, 2016",
            "Aug 30, 2016",
            "Aug 30, 2016",
            "Sept 28, 2016",
            "Sept 28, 2016",
            "Sept 28, 2016",
            "Oct 27, 2016",
            "Oct 27, 2016",
            "Oct 27, 2016",
        };

        string[] Features = new string[] {
            "Swiping",
            "Pull To Refresh",
            "Paging",
            "Selection in row header",
            "Multiple selection color",
            "Animating the selected row",
            "Long press event",
            "Double click event",
            "Header Template",
            "Swiping",
            "Double click event",
            "Swiping",
            "Double click event",
            "Unbound column",
            "Multi-line text",
            "Cell border customization",
            "Scroll to a row/column index",
            "Group expand and collapse",
            "Customize SfDataPager",
            "Enabling / disabling the bouncing behavior",
            "Unbound column",
            "Group expand collapse",
            "Auto column width",
            "Column drag and drop",
            "Column drag and drop",
            "Export unbound columns",
            "Auto column width",
            "Row drag and drop"
        };

       string[] Description = new string[] {
            "Enables the users to swipe the grid rows",
            "Pull To Refresh action refreshes the grid",
            "View the data in page segments",
            "Apply selection using row header",
            "Apply different selection colors for different rows",
            "Add an animation upon selecting a row",
            "Users can listen to LongPresses in the grid",
            "Users can listen to double taps in the grid",
            "Load custom views as templates in header cells",
            "Enables the users to swipe the grid rows",
            "Users can listen to double taps in the grid",
            "Enables the users to swipe the grid rows",
            "Users can listen to double taps in the grid",
            "Assign values to column in runtime based on values of other cells",
            "Displays multi-line text for the record cells in its columns",
            "Customize the vertical, horizontal or both borders for the grid",
            "Scroll to a particular row and/or column index",
            "Expand or collapse groups in runtime",
            "Customize the appearance of the SfDataPager",
            "Enable/disable the bouncing of the grid when over-scrolled",
            "Assign values to column in runtime based on values of other cells",
            "Expand or collapse groups in runtime",
            "Automatically adjusts the width of the column to fit the content",
            "Rearrange the columns by dragging and dropping them",
            "Rearrange the columns by dragging and dropping them",
            "Export unbound columns to PDF or EXCEL",
            "Automatically adjusts the width of the column to fit the content",
            "Rearrange the rows by dragging and dropping them",
        };
    }
}