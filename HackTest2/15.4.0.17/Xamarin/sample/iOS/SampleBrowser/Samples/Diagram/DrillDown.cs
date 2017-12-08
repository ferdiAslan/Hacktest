#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public partial class DrillDown : SampleView
	{
		SfDiagram diagram;
		private const float DefaultToolbarHeight = 0f;
		private UIView parentView;
		UIButton button;
		UILabel label;
		int x = 0;
		int y = 25;
		int offsety = 0;
		int rowcount = 0;

		Dictionary<string, string> HColor;
        DataModel datamodel = new DataModel();

		private ObservableCollection<UIButton> buttons = new ObservableCollection<UIButton>();
		private ObservableCollection<UILabel> labels = new ObservableCollection<UILabel>();

		public DrillDown()
		{
			parentView = new UIView(this.Frame);

            //initialize the diagram.
			diagram = new SfDiagram();

            //Dictionary collection
			HColor = new Dictionary<string, string>();
			HColor.Add("Managing Director", "#F16F69");
			HColor.Add("Project Manager", "#0AA6CE");
			HColor.Add("Project Lead", "#14AD85");
			HColor.Add("Senior S/W Engg", "#14AD85");
			HColor.Add("Project Trainee", "#0F688D");

            //To represent button
			button = UIButton.FromType(UIButtonType.RoundedRect);
			button.SetTitle("Root", UIControlState.Normal);
			button.TouchUpInside += root;
			var rootsize = button.CurrentTitle.StringSize(button.Font);
			button.Frame = new CGRect(25, 25, rootsize.Width + 10, rootsize.Height + 10);
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			parentView.Frame = new CGRect(0, DefaultToolbarHeight, this.Frame.Width, this.Frame.Height - (DefaultToolbarHeight));
			diagram.BeginNodeRender += Dia_BeginNodeRender;
			diagram.BackgroundColor = UIColor.White;
			diagram.EnableSelectors = false;
			diagram.Width = (float)parentView.Frame.Width;
			diagram.Height = (float)parentView.Frame.Height;

			datamodel.Data();

			//To Represent DataSourceSttings Properties
			DataSourceSettings settings = new DataSourceSettings();
			settings.ParentId = "ReportingPerson";
			settings.Id = "Name";
			settings.DataSource = datamodel.employee;
			diagram.DataSourceSettings = settings;

            //Initialize node clicked event
			diagram.NodeClicked += Dia_NodeClicked;

			UpdateRootNode();

			clearConnectors();

			parentView.AddSubview(diagram);
			this.AddSubview(parentView);
			parentView.AddSubview(button);
		}

        /// <summary>
        /// Beginnoderender event args
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
		void Dia_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
		{
			var node = (args.Item as Node);
			node.Width = 120;
			node.Height = 130;
			node.Template = DrawTemplate(node);
		}

        /// <summary>
        /// Template for Node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
		UIView DrawTemplate(Node node)
		{
			//TEMPLATE
			var template = new UIView();
			template.Frame = new CGRect(0, 0, node.Width, node.Height);
			template.BackgroundColor = datamodel.GetColorFromHexaValue(HColor[(node.Content as DiagramEmployee).Designation]);

			template.AddSubview(image(UIImage.FromBundle((node.Content as DiagramEmployee).ImageUrl), node));
			template.AddSubview(name((node.Content as DiagramEmployee).Name, node));
			template.AddSubview(designation((node.Content as DiagramEmployee).Designation, node));
			if ((node.Content as DiagramEmployee).HasChild)
			{
				template.AddSubview(expcollimage(UIImage.FromBundle("Images/Diagram/multiuser.png"), node));
			}
			else
			{
				template.AddSubview(expcollimage(UIImage.FromBundle("Images/Diagram/singleuser.png"), node));
			}
			return template;
		}

        /// <summary>
        /// Image view
        /// </summary>
        /// <param name="i"></param>
        /// <param name="node"></param>
        /// <returns></returns>
		UIImageView image(UIImage i, Node node)
		{
			var img = new UIImageView();
			int width = 60;
			int height = 60;
			img.Frame = new CGRect((-width / 2 + node.Width / 2), 10, width, height);
			img.Image = i;
			return img;
		}

        /// <summary>
        /// Expand collpase the node
        /// </summary>
        /// <param name="i"></param>
        /// <param name="node"></param>
        /// <returns></returns>
		UIImageView expcollimage(UIImage i, Node node)
		{
			var img = new UIImageView();
			int width = 20;
			int height = 20;
			img.Frame = new CGRect((-width / 2 + node.Width / 2), 105, width, height);
			img.Image = i;
			return img;
		}

        /// <summary>
        /// Node annotation
        /// </summary>
        /// <param name="text"></param>
        /// <param name="node"></param>
        /// <returns></returns>
		UILabel name(string text, Node node)
		{
			var txt = new UILabel();
			txt.Text = text;
			txt.TextColor = UIColor.White;
			txt.Font = UIFont.BoldSystemFontOfSize(12);

			var size = new CGSize();
			size = txt.Text.StringSize(txt.Font);

			txt.Frame = new CoreGraphics.CGRect((-size.Width / 2 + node.Width / 2), 15, node.Width, node.Height);
			return txt;
		}

        /// <summary>
        /// Label for Node
        /// </summary>
        /// <param name="text"></param>
        /// <param name="node"></param>
        /// <returns></returns>
		UILabel designation(string text, Node node)
		{
			var design = new UILabel();
			design.Text = text;
			design.TextColor = UIColor.White;
			design.Font = UIFont.FromName(".SF UI Text", 12);

			var size = new CGSize();
			size = design.Text.StringSize(design.Font);

			design.Frame = new CoreGraphics.CGRect((-size.Width / 2 + node.Width / 2), 30, node.Width, node.Height);

			return design;
		}

        /// <summary>
        /// Update the root node
        /// </summary>
		private void UpdateRootNode()
		{
			for (int i = 0; i < diagram.Nodes.Count; i++)
			{
				if ((diagram.Nodes[i].Content as DiagramEmployee).ReportingPerson != null)
				{
					diagram.Nodes[i].IsVisible = false;
				}
				else
				{
					diagram.Nodes[i].OffsetX = 30;
					diagram.Nodes[i].OffsetY = 100 + offsety;
					diagram.Nodes[i].IsVisible = true;
				}
			}
		}

        /// <summary>
        /// Diagram Nodeclicked event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
		void Dia_NodeClicked(object sender, NodeClickedEventArgs args)
		{
			var node = (args.Item as Node);
			int temp = 70;

			if (node.Children.Count() > 0)
			{
                UpdateButton(node);
				UpdateChildNodes(node, temp);
				node.IsVisible = false;
			}
		}

        /// <summary>
        /// Update the child nodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="temp"></param>
		private void UpdateChildNodes(Node node, int temp)
		{
			UpdateNodes(node);
			for (int i = 0; i < node.Children.Count(); i++)
			{
				if (i % 2 == 0)
				{
					node.Children.ToList()[i].OffsetX = 30;
					node.Children.ToList()[i].OffsetY = temp + offsety + 30;
				}
				else
				{
					node.Children.ToList()[i].OffsetX = 160;
					node.Children.ToList()[i].OffsetY = temp + offsety + 30;
					temp = ((int)(temp + node.Children.ToList()[0].OffsetY)+40);
				}
				node.Children.ToList()[i].IsVisible = true;
			}
		}

        /// <summary>
        /// Button event
        /// </summary>
        /// <param name="node"></param>
		private void UpdateButton(Node node)
		{
			label = new UILabel();
			label.TextColor = UIColor.Blue;
			label.Text = "/";
			button = UIButton.FromType(UIButtonType.RoundedRect);
			button.SetTitle((node.Content as DiagramEmployee).Name, UIControlState.Normal);
			var size = button.CurrentTitle.StringSize(button.Font);
			x = GetButtonPosition();
			int x1 = x, y1 = y;
			int x2 = x1 + 5, y2 = y;
			label.Frame = new CGRect(x1, y1, 5, size.Height + 10);
			button.Frame = new CGRect(x2, y2, size.Width + 10, size.Height + 10);
			button.TouchUpInside += root;
			parentView.AddSubview(button);
			parentView.AddSubview(label);
			int offY = y2 + (int) button.Frame.Height;
			if (offY > 100)
			{
				offsety = offY - 100;
			}
		}

        /// <summary>
        /// Get the button position
        /// </summary>
        /// <returns></returns>
		private int GetButtonPosition()
		{
			buttons.Clear();
			foreach (var view in parentView.Subviews)
			{
				if (view is UIButton)
				{
					buttons.Add(view as UIButton);
				}
			}
			int count = buttons.Count;
			x = 25;
			for (int i = 0; i < buttons.Count; i++)
			{
				x += (int) buttons.ToList()[i].Frame.Width;
				if (parentView.Frame.Width < x + buttons.ToList()[i].Frame.Width)
				{
					x = 25;
					rowcount++;
				}
				if (i != buttons.Count - 1) x += 5;
			}
			y = 25;
			for (int j = 0; j < rowcount; j++)
			{
				y += 25;
			}
			rowcount = 0;
			return x;
		}

        /// <summary>
        /// Clear the connector collection
        /// </summary>
		void clearConnectors()
		{
			for (int i = 0; i < diagram.Connectors.Count; i++)
			{
				diagram.Connectors[i].IsVisible = false;
			}
		}

        /// <summary>
        /// set the root node.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		void root(object sender, EventArgs e)
		{
			if ((sender as UIButton).CurrentTitle == "Root")
			{
				UpdateRootNode();
			}
			else
			{
				Updatechild((sender as UIButton).CurrentTitle);
			}
            Removebutton((sender as UIButton).CurrentTitle);
		}

        /// <summary>
        /// remove the button
        /// </summary>
        /// <param name="name"></param>
		private void Removebutton(string name)
		{
			GetButtons();
			GetLabels();
			int index = 0;
			bool canRemoveItem = false;
			do
			{
				if (canRemoveItem)
				{
					(buttons.ToList()[index]).RemoveFromSuperview();
					(labels.ToList()[index - 1]).RemoveFromSuperview();
				}
				else if (buttons.ToList()[index].CurrentTitle == name)
				{
					canRemoveItem = true;
				}
				index++;
			}
			while (index < buttons.Count);
			buttons.Clear();
			GetButtons();
			buttons.Clear();
		}

        /// <summary>
        /// Get the buttons
        /// </summary>
		private void GetButtons()
		{
			buttons.Clear();
			foreach (var view in parentView.Subviews)
			{
				if (view is UIButton)
				{
					buttons.Add(view as UIButton);
				}
			}
		}

        /// <summary>
        /// Get the labels
        /// </summary>
		private void GetLabels()
		{
			labels.Clear();
			foreach (var view in parentView.Subviews)
			{
				if (view is UILabel)
				{
					labels.Add(view as UILabel);
				}
			}
		}

        /// <summary>
        /// Update the child
        /// </summary>
        /// <param name="name"></param>
		private void Updatechild(string name)
		{
			for (int i = 0; i < diagram.Nodes.Count; i++)
			{
				if ((diagram.Nodes[i].Content as DiagramEmployee).Name == name)
				{
					UpdateChildNodes(diagram.Nodes[i], 70);
				}
			}
		}

        /// <summary>
        /// Update the nodes
        /// </summary>
        /// <param name="node"></param>
		private void UpdateNodes(Node node)
		{
			for (int i = 0; i < diagram.Nodes.Count; i++)
			{
				diagram.Nodes[i].IsVisible = false;
			}
		}
	}
}
