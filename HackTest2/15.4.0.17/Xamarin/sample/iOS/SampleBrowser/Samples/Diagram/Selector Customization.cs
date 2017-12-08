#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using SampleBrowser;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public partial class SelectorCustomization : SampleView
	{
		SfDiagram Diagram;
		UIView HandleSelectorsView = new UIView();
		public SelectorCustomization()
		{
			Diagram = new SfDiagram();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			//Set Diagram width and height
			Diagram.Width = (float)Frame.Width;
			Diagram.Height = (float)Frame.Height;
			this.AddSubview(Diagram);
			Initialize();
			Diagram.AddNode(CreateNode(225, 150, 100, 100, ShapeType.Ellipse));
			Diagram.AddNode(CreateNode(150, 300, 100, 100, ShapeType.Rectangle));
			Diagram.AddNode(CreateNode(300, 300, 100, 100, ShapeType.Diamond));
		}
		void Initialize()
		{
			//Tool Box
			HandleSelectorsView.Frame = new CGRect(this.Frame.Width - 260, 50, 250, 160);
			HandleSelectorsView.Hidden = true;
			HandleSelectorsView.Layer.BorderWidth = 2;
			HandleSelectorsView.Layer.CornerRadius = 5;
			HandleSelectorsView.Layer.BorderColor = UIColor.FromRGB(99, 184, 225).CGColor;
			this.AddSubview(HandleSelectorsView);
			var offsetY = 20;
			CreateSwitch(HandleSelectorsView, (float)HandleSelectorsView.Frame.Width - 60, offsetY, 10, 10, "Enable Corners");
			CreateSwitch(HandleSelectorsView, (float)HandleSelectorsView.Frame.Width - 60, offsetY + 40, 10, 10, "Enable Centers");
			CreateSwitch(HandleSelectorsView, (float)HandleSelectorsView.Frame.Width - 60, offsetY + 80, 10, 10, "Enable Rotator");

			//Tool Box Enabler
			var label = new UILabel();
			label.Frame = new CGRect(Frame.Width - 310, 10, 250, 20);
			label.Text = "Handle Selector";
			label.TextAlignment = UITextAlignment.Center;
			var Switch = new UISwitch();
			Switch.Frame = new CGRect(Frame.Width - 70, 5, 20, 10);
			Switch.On = false;
			Switch.OnTintColor = UIColor.FromRGB(99, 184, 225);
			Switch.ValueChanged += Switch_ValueChanged; ;
			AddSubview(Switch);
			AddSubview(label);
		}
		void Switch_ValueChanged(object sender, EventArgs e)
		{
			if (HandleSelectorsView.Hidden)
			{
				HandleSelectorsView.Hidden = false;
			}
			else
			{
				HandleSelectorsView.Hidden = true;
			}
		}

		Node CreateNode(float X, float Y, float Width, float Height, ShapeType Shape)
		{
			var node = new Node(X, Y, Width, Height, Shape);
			node.Style = new Style() { Brush = new SolidBrush(UIColor.White), StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225)) };
			return node;
		}

		void CreateSwitch(UIView parent, float X, float Y, float W, float H, String Label)
		{
			var Switch = new UISwitch();
			Switch.Frame = new CGRect(X, Y, W, H);
			Switch.On = true;
			Switch.OnTintColor = UIColor.FromRGB(99, 184, 225);
			Switch.ValueChanged += Switch_TouchUpInside;
			parent.AddSubview(Switch);
			var SwitchLabel = new UILabel();
			SwitchLabel.Frame = new CGRect(10, Y + 5, 150, 20);
			SwitchLabel.Text = Label;
			SwitchLabel.TextColor = UIColor.Black;
			parent.AddSubview(SwitchLabel);
		}

		void Switch_TouchUpInside(object sender, EventArgs e)
		{
			for (int i = 0; i <= 4; i = i + 2)
				if (HandleSelectorsView.Subviews[i] == (sender as UISwitch))
				{
					switch (i)
					{
						case 0:
							if ((sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(true, SelectorPosition.TopLeft);
								Diagram.ShowSelectorHandle(true, SelectorPosition.TopRight);
								Diagram.ShowSelectorHandle(true, SelectorPosition.BottomLeft);
								Diagram.ShowSelectorHandle(true, SelectorPosition.BottomRight);
							}
							else if (!(sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(false, SelectorPosition.TopLeft);
								Diagram.ShowSelectorHandle(false, SelectorPosition.TopRight);
								Diagram.ShowSelectorHandle(false, SelectorPosition.BottomLeft);
								Diagram.ShowSelectorHandle(false, SelectorPosition.BottomRight);
							}
							break;
						case 2:
							if ((sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(true, SelectorPosition.TopCenter);
								Diagram.ShowSelectorHandle(true, SelectorPosition.BottomCenter);
								Diagram.ShowSelectorHandle(true, SelectorPosition.MiddleLeft);
								Diagram.ShowSelectorHandle(true, SelectorPosition.MiddleRight);
							}
							else if (!(sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(false, SelectorPosition.TopCenter);
								Diagram.ShowSelectorHandle(false, SelectorPosition.BottomCenter);
								Diagram.ShowSelectorHandle(false, SelectorPosition.MiddleLeft);
								Diagram.ShowSelectorHandle(false, SelectorPosition.MiddleRight);
							}
							break;
						case 4:
							if ((sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(true, SelectorPosition.Rotator);
							}
							else if (!(sender as UISwitch).On)
							{
								Diagram.ShowSelectorHandle(false, SelectorPosition.Rotator);
							}
							break;
					}
					break;
				}
		}
	}
}