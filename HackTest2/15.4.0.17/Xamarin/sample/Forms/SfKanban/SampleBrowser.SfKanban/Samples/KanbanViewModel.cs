#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfKanban.XForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using System;

namespace SampleBrowser.SfKanban
{
    //[Preserve(AllMembers = true)]
    //public class KanbanListModel
    //{
    //    public KanbanListModel()
    //    {
    //        ModelCards = new ObservableCollection<KanbanModel>();
    //        ModelCards.Add(new KanbanModel()
    //        {
    //            ID = 1,
    //            Title = "MiOS - 1002",
    //            Category = "Open",
    //            Description = "Analyze customer requirements",
    //            ColorKey = "Red",
    //            Tags = new string[] { "Incident", "Customer" }
    //        });
    //        ModelCards.Add(new KanbanModel()
    //        {
    //            ID = 6,
    //            Title = "MXamarin - 4576",
    //            Category = "Open",
    //            Description = "Show the retrieved data from the server in grid control",
    //            ColorKey = "Green",
    //            Tags = new string[] { "Story", "Customer" }
    //        });
    //        ModelCards.Add(new KanbanModel()
    //        {
    //            ID = 13,
    //            Title = "MUWP - 13",
    //            Category = "In Progress",
    //            Description = "Add responsive support to application",
    //            ColorKey = "Brown",
    //            Tags = new string[] { "Story", "Customer" }
    //        });
    //        ModelCards.Add(new KanbanModel()
    //        {
    //            ID = 2543,
    //            Title = "MXamarin_iOS - 2543",
    //            Category = "Code Review",
    //            Description = "Check login page validation",
    //            ColorKey = "Brown",
    //            Tags = new string[] { "Story", "Customer" }
    //        });
    //    }
    //    public ObservableCollection<KanbanModel> ModelCards { get; set; }
    //}


    public class KanbanGetStartedViewModel
    {
        public void Init()
        {
            
        }

        public ObservableCollection<KanbanModel> Cards { get; set; }

        public List<object> IList;

        public KanbanGetStartedViewModel()
        {
            Cards = new ObservableCollection<KanbanModel>();

            IList = new List<object>() { "Open", "Test", "Close", "InProgress" };

            Cards.Add(
                new KanbanModel()
                {
                    ID = 1,
                    Title = "iOS - 1",
                    ImageURL = "Image8.png",
                    Category = "Open",
                    Description = "Analyze customer requirements",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Release Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 6,
                    Title = "Xamarin - 6",
                    ImageURL = "Image9.png",
                    Category = "Open",
                    Description = "Show the retrived data from the server in grid control",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "iOS - 3",
                    ImageURL = "Image10.png",
                    Category = "Open",
                    Description = "Fix the filtering issues reported in safari",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    ImageURL = "Image11.png",
                    Category = "Open",
                    Description = "Add input validation for editing",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug", "Customer", "Breaking Issue" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Android - 15",
                    Category = "Open",
                    ImageURL =  "Image12.png",
                    Description = "Arrange web meeting for cutomer requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 3,
                    Title = "Android - 3",
                    Category = "Code Review",
                    ImageURL = "Image13.png",
                    Description = "API Improvements",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 4,
                    Title = "UWP - 4",
                    ImageURL = "Image14.png",
                    Category = "Code Review",
                    Description = "Enhance editing functionality",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 9,
                    Title = "Xamarin - 9",
                    ImageURL = "Image15.png",
                    Category = "Code Review",
                    Description = "Improve application performance",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL =  "Image16.png",
                    Category = "In Progress",
                    Description = "Add responsive support to applicaton",
                    ColorKey = "Brown",
                    Tags = new string[] { "Story", "Kanban" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 17,
                    Title = "Xamarin - 17",
                    Category = "In Progress",
                    ImageURL = "Image17.png",
                    Description = "Fix the issues reported in IE browser",
                    ColorKey = "Brown",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Xamarin - 21",
                    Category = "In Progress",
                    ImageURL = "Image18.png",
                    Description = "Improve performance of editing functionality",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Customer" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 19,
                    Title = "iOS - 19",
                    Category = "In Progress",
                    ImageURL ="Image19.png",
                    Description = "Fix the issues reported by the customer",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 8,
                    Title = "Android",
                    Category = "Code Review",
                    ImageURL = "Image20.png",
                    Description = "Check login page validation",
                    ColorKey = "Brown",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 24,
                    Title = "UWP - 24",
                    ImageURL =  "Image21.png",
                    Category = "In Progress",
                    Description = "Test editing functionality",
                    ColorKey = "Orange",
                    Tags = new string[] { "Feature", "Customer", "Release" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "iOS - 20",
                    Category = "In Progress",
                    ImageURL = "Image22.png",
                    Description = "Fix the issues reported in data binding",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 12,
                    Title = "Xamarin - 12",
                    Category = "In Progress",
                    ImageURL = "Image23.png",
                    Description = "Test editing functionality",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 11,
                    Title = "iOS - 11",
                    Category = "In Progress",
                    ImageURL =  "Image24.png",
                    Description = "Check filtering validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature", "Release", }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 13,
                    Title = "UWP - 13",
                    ImageURL = "Image25.png",
                    Category = "Closed",
                    Description = "Fix cannot open user's default database sql error",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug", "Internal", "Release" }
                });

            Cards.Add(
                new KanbanModel()
                {
                    ID = 14,
                    Title = "Android - 14",
                    Category = "Closed",
                    ImageURL = "Image26.png",
                    Description = "Arrange web meeting with customer to get login page requirement",
                    ColorKey = "Red",
                    Tags = new string[] { "Feature" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 15,
                    Title = "Xamarin - 15",
                    Category = "Closed",
                    ImageURL ="Image27.png",
                    Description = "Login page validation",
                    ColorKey = "Red",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 16,
                    Title = "Xamarin - 16",
                    ImageURL = "Image28.png",
                    Category = "Closed",
                    Description = "Test the application in IE browser",
                    ColorKey = "Purple",
                    Tags = new string[] { "Bug" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 20,
                    Title = "UWP - 20",
                    ImageURL = "Image29.png",
                    Category = "Closed",
                    Description = "Analyze stored procedure",
                    ColorKey = "Brown",
                    Tags = new string[] { "CustomSample", "Customer", "Incident" }
                }
            );

            Cards.Add(
                new KanbanModel()
                {
                    ID = 21,
                    Title = "Android - 21",
                    Category = "Closed",
                    ImageURL = "Image30.png",
                    Description = "Arrange web meeting with customer to get editing requirements",
                    ColorKey = "Orange",
                    Tags = new string[] { "Story", "Improvement" }
                }
            );

        }

    }
}
