#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public partial class HierarchicalLayout : SampleView
	{
        SfDiagram diagram;
		public HierarchicalLayout()
		{
            diagram = new SfDiagram();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

            //Set diagram width and height
            diagram.Width = (float)Frame.Width;
			diagram.Height = (float)Frame.Height;
			diagram.EnableSelectors = false;
            
            //Employee Datasource collection
            ObservableCollection<Employee> employee = new ObservableCollection<Employee>();
			employee.Add(new Employee { ID = 1, Name = "Plant Manager", Gender = "Male", Color = UIColor.FromRGB(0, 0, 139) });
			employee.Add(new Employee { ID = 2, Name = "Production Manager", Gender = "Male", ReportingId = "1", Color = UIColor.FromRGB(222, 20, 60) });
			employee.Add(new Employee { ID = 3, Name = "Administrative Officer", Gender = "Male", ReportingId = "1", Color = UIColor.FromRGB(222, 20, 60) });
			employee.Add(new Employee { ID = 4, Name = "Maintenance Manager", Gender = "Male", ReportingId = "1", Color = UIColor.FromRGB(222, 20, 60) });
			employee.Add(new Employee { ID = 5, Name = "Control Room", Gender = "Male", ReportingId = "2", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 6, Name = "Plant Operator", Gender = "Male", ReportingId = "2", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 7, Name = "Electrical Supervisor", Gender = "Male", ReportingId = "4", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 8, Name = "Mechanical Supervisor", Gender = "Male", ReportingId = "4", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 9, Name = "Foreman", Gender = "Male", ReportingId = "5", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 10, Name = "Foreman", Gender = "Male", ReportingId = "6", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 11, Name = "Craft Personnel", Gender = "Male", ReportingId = "9", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 12, Name = "Craft Personnel", Gender = "Male", ReportingId = "9", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 13, Name = "Craft Personnel", Gender = "Male", ReportingId = "10", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 14, Name = "Craft Personnel", Gender = "Male", ReportingId = "7", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 15, Name = "Craft Personnel", Gender = "Male", ReportingId = "7", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 16, Name = "Craft Personnel", Gender = "Male", ReportingId = "8", Color = UIColor.FromRGB(32, 178, 170) });
			employee.Add(new Employee { ID = 17, Name = "Craft Personnel", Gender = "Male", ReportingId = "8", Color = UIColor.FromRGB(32, 178, 170) });

            //Set parentid and id for DataSourceSettings
            DataSourceSettings setting = new DataSourceSettings();
			setting.DataSource = employee;
			setting.Id = "ID";
			setting.ParentId = "ReportingId";
			diagram.BeginNodeRender += diagram_BeginNodeRender;
			diagram.DataSourceSettings = setting;

            //To Represent LayoutManager Properties
            diagram.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Hierarchical,
                }
            };

			for (int i = 0; i < diagram.Connectors.Count; i++)
			{
				diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(UIColor.LightGray);
				diagram.Connectors[i].TargetDecorator.FillColor = UIColor.LightGray;
				diagram.Connectors[i].TargetDecorator.StrokeColor = UIColor.LightGray;
			}
			this.AddSubview(diagram);
		}

        /// <summary>
        /// Beginnoderender event args
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
		void diagram_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
		{
			var node = (args.Item as Node);
			node.Width = 125;
			node.Height = 50;
			node.Style.Brush = new SolidBrush((node.Content as Employee).Color);
			node.Style.StrokeBrush = new SolidBrush((node.Content as Employee).Color);
			var label = CreateLabel((node.Content as Employee).Name, node.Width, node.Height);
			node.Annotations.Add(new Annotation() { HorizontalAlignment = HorizontalAlignment.Center, VerticalAlignment = VerticalAlignment.Center, Content = label });
		}

        /// <summary>
        /// Employee class
        /// </summary>
		public class Employee
		{
            /// <summary>
            /// Gets or set the ID
            /// </summary>
			public int ID
			{
				get;
				set;
			}

            /// <summary>
            /// Get or set the Name
            /// </summary>
            public string Name
			{
				get;
				set;
			}

            /// <summary>
            /// Gets or set the reporting ID
            /// </summary>
			public string ReportingId
			{
				get;
				set;
			}

            /// <summary>
            /// Get or set the Gender
            /// </summary>
            public string Gender
			{
				get;
				set;
			}

            /// <summary>
            /// Get or set the Color
            /// </summary>
            public UIColor Color
			{
				get;
				set;
			}
		}

        /// <summary>
        /// Defines the node label
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
		UILabel CreateLabel(string text, nfloat width, nfloat height)
		{
			var label = new UILabel()
			{
				Frame = new CGRect(0, 0, width, height),
				Text = text,
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.White,
				Font = UIFont.BoldSystemFontOfSize(11),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};
			return label;
		}
	}
}
