#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using System.Diagnostics;
using Syncfusion.SfSchedule.XForms;

namespace PatientMonitor
{
	public partial class ScheduleViewPage : ContentPage
    {
		
	    #region Constructor

		public ScheduleViewPage()
		{
			InitializeComponent ();
            this.Icon = "appointment.png";
            if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
            {
                schedule.ScheduleView = ScheduleView.WorkWeekView;
            }
        }

		#endregion
		 
	}
}
