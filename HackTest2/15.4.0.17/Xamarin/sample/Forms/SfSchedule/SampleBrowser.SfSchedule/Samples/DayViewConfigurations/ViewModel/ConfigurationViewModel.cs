#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System.ComponentModel;
using System.Collections;

namespace SampleBrowser.SfSchedule
{
    [Preserve(AllMembers = true)]
    public class ConfigurationViewModel : INotifyPropertyChanged
    {
        #region Properties

        public ScheduleAppointmentCollection Appointments { get; set; }
        List<string> teamManagement;
        List<Color> color_collection;
        List<DateTime> start_time_collection;
        List<DateTime> end_time_collection;

        private int workStartHour = 8;

        public int WorkStartHour
        {
            get { return workStartHour; }
            set
            {
                workStartHour = value;
                RaiseOnPropertyChanged("WorkStartHour");
            }
        }


        private int endHour = 16;
        public int EndHour
        {
            get { return endHour; }
            set
            {
                endHour = value;
                RaiseOnPropertyChanged("EndHour");
            }
        }

        #endregion Properties

        #region Constructor

        public ConfigurationViewModel()
        {
            Appointments = new ScheduleAppointmentCollection();
            CreateRandomNumbersCollection();
            CreateStartTimeCollection();
            CreateEndTimeCollection();
            CreateSubjectCollection();
            CreateColorCollection();
            IntializeAppoitments(10);
        }

        #endregion Constructor

        #region Methods

        #region InitializeAppointments
        private void IntializeAppoitments(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ScheduleAppointment scheduleAppointment = new ScheduleAppointment();
                scheduleAppointment.Color = color_collection[i];
                scheduleAppointment.Subject = teamManagement[i];
                scheduleAppointment.StartTime = start_time_collection[i];
                scheduleAppointment.EndTime = end_time_collection[i];
                Appointments.Add(scheduleAppointment);
            }
        }

        #endregion InitializeAppointments

        #region SubjectCollection

        //creating subject collection
        private void CreateSubjectCollection()
        {
            teamManagement = new List<string>();
            teamManagement.Add("General Meeting");
            teamManagement.Add("Plan Execution");
            teamManagement.Add("Project Plan");
            teamManagement.Add("Consulting");
            teamManagement.Add("Performance Check");
            teamManagement.Add("General Meeting");
            teamManagement.Add("Plan Execution");
            teamManagement.Add("Project Plan");
            teamManagement.Add("Consulting");
            teamManagement.Add("Performance Check");

        }

        #endregion SubjectCollection

        #region creating color collection

        //creating color collection
        private void CreateColorCollection()
        {
            color_collection = new List<Color>();
            color_collection.Add(Color.FromHex("#FFA2C139"));
            color_collection.Add(Color.FromHex("#FFD80073"));
            color_collection.Add(Color.FromHex("#FF1BA1E2"));
            color_collection.Add(Color.FromHex("#FFE671B8"));
            color_collection.Add(Color.FromHex("#FFF09609"));
            color_collection.Add(Color.FromHex("#FF339933"));
            color_collection.Add(Color.FromHex("#FF00ABA9"));
            color_collection.Add(Color.FromHex("#FFE671B8"));
            color_collection.Add(Color.FromHex("#FF1BA1E2"));
            color_collection.Add(Color.FromHex("#FFD80073"));
            color_collection.Add(Color.FromHex("#FFA2C139"));
            color_collection.Add(Color.FromHex("#FFA2C139"));
            color_collection.Add(Color.FromHex("#FFD80073"));
            color_collection.Add(Color.FromHex("#FF339933"));
            color_collection.Add(Color.FromHex("#FFE671B8"));
            color_collection.Add(Color.FromHex("#FF00ABA9"));
        }

        #endregion creating color collection

        #region CreateRandomNumbersCollection

        //creating random number collection
        List<int> randomNums = new List<int>();
        private void CreateRandomNumbersCollection()
        {
            randomNums = new List<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random = rand.Next(9, 15);
                randomNums.Add(random);
            }
        }

        #endregion CreateRandomNumbersCollection

        #region CreateStartTimeCollection

        // creating StartTime collection
        private void CreateStartTimeCollection()
        {
            start_time_collection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;

            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, randomNums[count], 0, 0);
                DateTime startDateTime = startTime.AddDays(i);
                start_time_collection.Add(startDateTime);
                count++;
            }
        }

        #endregion CreateStartTimeCollection

        #region CreateEndTimeCollection

        //  creating EndTime collection
        private void CreateEndTimeCollection()
        {
            end_time_collection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, randomNums[count] + 1, 0, 0);
                DateTime endDateTime = endTime.AddDays(i);
                end_time_collection.Add(endDateTime);
                count++;
            }
        }

        #endregion CreateEndTimeCollection


        #endregion Methods

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseOnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}


