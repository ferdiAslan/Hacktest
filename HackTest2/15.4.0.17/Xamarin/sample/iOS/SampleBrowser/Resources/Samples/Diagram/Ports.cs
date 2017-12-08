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
	public partial class Ports : SampleView
	{
		SfDiagram diagram;
		public Ports()
		{
            //Initialize the sfdiagram
			diagram = new SfDiagram();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

            //Set diagram width and height
            diagram.Width = (float)Frame.Width;
			diagram.Height = (float)Frame.Height;
			diagram.EnableSelectors = false;

            //Create Node
			Node n1 = DrawNode(100, 35, 150, 60, ShapeType.RoundedRectangle, "Start", 25);
			n1.Ports.Add(DrawPort(0.5, 1));
			diagram.AddNode(n1);

			Node n2 = DrawNode(100, 150, 150, 60, ShapeType.Rectangle, "Process", 0);
			n2.Ports.Add(DrawPort(0.5, 0));
			n2.Ports.Add(DrawPort(0.5, 1));
			n2.Ports.Add(DrawPort(1, 0.5));
			diagram.AddNode(n2);

			Node n3 = DrawNode(100, 300, 150, 60, ShapeType.Rectangle, "Process1", 0);
			n3.Ports.Add(DrawPort(0.5, 0));
			n3.Ports.Add(DrawPort(0.5, 1));
			n3.Ports.Add(DrawPort(1, 0.5));
			diagram.AddNode(n3);

			Node n4 = DrawNode(100, 400, 150, 60, ShapeType.RoundedRectangle, "End", 25);
			n4.Ports.Add(DrawPort(0.5, 0));
			diagram.AddNode(n4);

			Node n5 = DrawNode(300, 150, 120, 60, ShapeType.Diamond, "Decision", 0);
			n5.Ports.Add(DrawPort(0, 0.5));
			n5.Ports.Add(DrawPort(0.5, 1));
			diagram.AddNode(n5);

            //Create Connector
			Connector c1 = DrawConnector(n1, n2, 0, 0);
			diagram.AddConnector(c1);

			Connector c2 = DrawConnector(n2, n3, 1, 0);
			diagram.AddConnector(c2);

			Connector c3 = DrawConnector(n3, n4, 1, 0);
			diagram.AddConnector(c3);

			Connector c4 = DrawConnector(n2, n5, 2, 0);
			diagram.AddConnector(c4);

			Connector c5 = DrawConnector(n5, n3, 1, 2);
			diagram.AddConnector(c5);

			this.AddSubview(diagram);
		}

        //Creates the Node with Specified input
        private Node DrawNode(float offsetX, float offsetY, float width, int height, ShapeType shape, string annotation, int cornerRadius)
		{
			var node = new Node();
			node.OffsetX = offsetX;
			node.OffsetY = offsetY;
			node.Width = width;
			node.Height = height;
			node.Style.Brush = new SolidBrush(UIColor.White);
			node.Style.StrokeBrush = new SolidBrush(UIColor.LightGray);
			node.ShapeType = shape;
			node.CornerRadius = cornerRadius;
			node.Annotations.Add(new Annotation() { Content = CreateLabel(annotation, node.Width, node.Height) });
			return node;
		}

		/// <summary>
        /// Draw port
        /// </summary>
        /// <param name="offX"></param>
        /// <param name="offY"></param>
        /// <returns></returns>
		private Port DrawPort(double offX, double offY)
		{
			var port = new Port();
			port.NodeOffsetX = offX;
			port.NodeOffsetY = offY;
			port.Width = 10;
			port.Height = 10;
			port.Style = new Style() { Brush = new SolidBrush(UIColor.Clear), StrokeBrush = new SolidBrush(UIColor.DarkGray), StrokeWidth = 3 };
			return port;
		}

		/// <summary>
        /// Draw connector based on source and target node
        /// </summary>
        /// <param name="srcNode"></param>
        /// <param name="trtNode"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
		private Connector DrawConnector(Node srcNode, Node trtNode, int p1, int p2)
		{
			var connector = new Connector(srcNode, trtNode);
			connector.SourcePort = srcNode.Ports[p1];
			connector.TargetPort = trtNode.Ports[p2];
			connector.TargetDecorator.FillColor = UIColor.Clear;
			connector.Style.StrokeBrush = new SolidBrush(UIColor.LightGray);
			return connector;
		}

		/// <summary>
        /// Create label
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
		UILabel CreateLabel(string text, nfloat width, nfloat height)
		{
			var label = new UILabel()
			{
				Text = text,
				TextColor = UIColor.Black,
				TextAlignment = UITextAlignment.Center,
				Font = UIFont.FromName(".SF UI Text", 13),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0,
				Frame = new CGRect(0, 0, width, height)
			};
			return label;
		}
	}
}
