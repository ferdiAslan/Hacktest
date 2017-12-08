#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public class DiagramStencil : SampleView
	{
		SfDiagram Diagram;
		UIView PaletteView = new UIView();
		public DiagramStencil()
		{
			Diagram = new SfDiagram();
		}
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			AddSubview(Diagram);
			CreatePalette();
			PaletteView.Frame = new CoreGraphics.CGRect(Frame.Width - Frame.Width / 3.5 - 5, 60, Frame.Width / 3.5, Frame.Height / 1.5);
			AddSubview(PaletteView);
		}

		void CreatePalette()
		{
			var ExpCollButton = new UIButton();
			ExpCollButton.Frame = new CoreGraphics.CGRect(Frame.Width - 60, 5, 50, 50);
			var expcoll = new UIImageView(UIImage.FromBundle("Images/Diagram/expcoll.png"));
			expcoll.Frame = new CoreGraphics.CGRect(0, 0, 40, 40);
			ExpCollButton.TouchUpInside += ExpCollButton_TouchUpInside;
			ExpCollButton.AddSubview(expcoll);
			AddSubview(ExpCollButton);
			Stencil stencil = new Stencil();
			SymbolCollection coll = new SymbolCollection();
			coll.Add(new Node()
			{
				ShapeType = ShapeType.Ellipse,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				},
			});
			coll.Add(new Node()
			{
				ShapeType = ShapeType.Rectangle,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				},
			});
			coll.Add(new Node()
			{
				ShapeType = ShapeType.RoundedRectangle,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll.Add(new Node()
			{
				ShapeType = ShapeType.Plus,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll.Add(new Node()
			{
				ShapeType = ShapeType.Hexagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			SymbolCollection coll1 = new SymbolCollection();
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Diamond,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Pentagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Hexagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Heptagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Octagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			coll1.Add(new Node()
			{
				ShapeType = ShapeType.Decagon,
				Style = new Style()
				{
					Brush = new SolidBrush(UIColor.Clear),
					StrokeBrush = new SolidBrush(UIColor.FromRGB(99, 184, 225))
				}
			});
			SymbolCollection coll2 = new SymbolCollection();
			coll2.Add(new Connector() { SourcePoint = new CGPoint(0, 0), TargetPoint = new CGPoint(50, 50), SegmentType = SegmentType.StraightSegment, });
			coll2.Add(new Connector(new CGPoint(50, 50), new CGPoint(0, 0)));

			stencil.BackgroundColor = UIColor.White;
			stencil.SymbolGroups.Add(new SymbolGroup() { Items = coll, Header = " SHAPES" });
			stencil.SymbolGroups.Add(new SymbolGroup() { Items = coll1, Header = " SHAPES" });
			stencil.SymbolGroups.Add(new SymbolGroup() { Items = coll2, Header = " CONNECTORS" });

			Diagram.ShowSelectorHandle(false,SelectorPosition.Rotator);
			PaletteView.Layer.CornerRadius = 5;
			stencil.Width = (float)PaletteView.Frame.Width;
			stencil.Height = (float)PaletteView.Frame.Height;
			PaletteView.AddSubview(stencil);
			Diagram.Stencil = stencil;
		}

		void ExpCollButton_TouchUpInside(object sender, EventArgs e)
		{
			if (!PaletteView.Hidden)
			{
				PaletteView.Hidden = true;
			}
			else
			{
				PaletteView.Hidden = false;
			}
		}
	}
}
