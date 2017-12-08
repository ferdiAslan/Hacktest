#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfBusyIndicator.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfBusyIndicator
{
	public partial class BusyIndicator : SampleView
	{
		public BusyIndicator()
		{
			InitializeComponent();
			sfbusyindicator.ViewBoxWidth = 150;
			sfbusyindicator.ViewBoxHeight = 150;
			sfbusyindicator.BackgroundColor = Color.White;
			sfbusyindicator.VerticalOptions = LayoutOptions.FillAndExpand;
			Optionview();

			this.BackgroundColor = Color.FromRgb(236, 235, 242);
		}

		void animationPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Device.OS == TargetPlatform.Android)
			{
				switch (animationPicker.SelectedIndex)
				{
					case 0:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.Ball;
						sfbusyindicator.TextColor = Color.FromHex("#243FD9");
						break;
					case 1:
						sfbusyindicator.Duration = 0.3f;
						sfbusyindicator.AnimationType = AnimationTypes.Battery;
						sfbusyindicator.TextColor = Color.FromHex("#A70015");
						break;
					case 2:
						sfbusyindicator.Duration = 1.4f;
						sfbusyindicator.AnimationType = AnimationTypes.DoubleCircle;
						sfbusyindicator.TextColor = Color.FromHex("#958C7B");
						break;
					case 3:
						sfbusyindicator.Duration = 0.8f;
						sfbusyindicator.AnimationType = AnimationTypes.ECG;
						sfbusyindicator.TextColor = Color.FromHex("#DA901A");
						break;
					case 4:
						sfbusyindicator.Duration = 0.6f;
						sfbusyindicator.AnimationType = AnimationTypes.Globe;
						sfbusyindicator.TextColor = Color.FromHex("#9EA8EE");
						break;
					case 5:
						sfbusyindicator.Duration = 1f;
						sfbusyindicator.AnimationType = AnimationTypes.HorizontalPulsingBox;
						sfbusyindicator.TextColor = Color.FromHex("#E42E06");
						break;
					case 6:
						sfbusyindicator.Duration = 0.5f;
						sfbusyindicator.AnimationType = AnimationTypes.Print;
						sfbusyindicator.TextColor = Color.FromHex("#5E6FF8");
						break;
					case 7:
						sfbusyindicator.Duration = 0.3f;
						sfbusyindicator.AnimationType = AnimationTypes.Rectangle;
						sfbusyindicator.TextColor = Color.FromHex("#27AA9E");
						break;
					case 8:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.SingleCircle;
						sfbusyindicator.TextColor = Color.FromHex("#AF2541");
						break;
					case 9:
						sfbusyindicator.Duration = 5;
						sfbusyindicator.AnimationType = AnimationTypes.SlicedCircle;
						sfbusyindicator.TextColor = Color.FromHex("#779772");
						break;
					case 10:
						sfbusyindicator.Duration = 1.5f;
						sfbusyindicator.AnimationType = AnimationTypes.Gear;
						sfbusyindicator.TextColor = Color.Gray;
						break;
					case 11:
						sfbusyindicator.Duration = 0.1f;
						sfbusyindicator.AnimationType = AnimationTypes.Box;
						sfbusyindicator.TextColor = Color.FromHex("#243FD9");
						break;
				}
			}
			else
			{
				switch (animationPicker.SelectedIndex)
				{
					case 0:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.Ball;
						sfbusyindicator.TextColor = Color.FromHex("#243FD9");
						break;
					case 1:
						sfbusyindicator.Duration = 2;
						sfbusyindicator.AnimationType = AnimationTypes.Battery;
						sfbusyindicator.TextColor = Color.FromHex("#A70015");
						break;
					case 2:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.DoubleCircle;
						sfbusyindicator.TextColor = Color.FromHex("#958C7B");
						break;
					case 3:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.ECG;
						sfbusyindicator.TextColor = Color.FromHex("#DA901A");
						break;
					case 4:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.Globe;
						sfbusyindicator.TextColor = Color.FromHex("#9EA8EE");
						break;
					case 5:
						sfbusyindicator.Duration = 0.5f;
						sfbusyindicator.AnimationType = AnimationTypes.HorizontalPulsingBox;
						sfbusyindicator.TextColor = Color.FromHex("#E42E06");
						break;
					case 6:
						sfbusyindicator.Duration = 1;
						sfbusyindicator.AnimationType = AnimationTypes.Print;
						sfbusyindicator.TextColor = Color.FromHex("#5E6FF8");
						break;
					case 7:
						sfbusyindicator.Duration = 0.2f;
						sfbusyindicator.AnimationType = AnimationTypes.Rectangle;
						sfbusyindicator.TextColor = Color.FromHex("#27AA9E");
						break;
					case 8:
						sfbusyindicator.Duration = 2;
						sfbusyindicator.AnimationType = AnimationTypes.SingleCircle;
						sfbusyindicator.TextColor = Color.FromHex("#AF2541");
						break;
					case 9:
						sfbusyindicator.Duration = 2;
						sfbusyindicator.AnimationType = AnimationTypes.SlicedCircle;
						sfbusyindicator.TextColor = Color.FromHex("#779772");
						break;
					case 10:
						sfbusyindicator.Duration = 1.5f;
						sfbusyindicator.AnimationType = AnimationTypes.Gear;
						sfbusyindicator.TextColor = Color.Gray;
						break;
				
				}
			}

		}

		public void Optionview()
		{
			animationPicker.BackgroundColor = Color.White;
			if (Device.OS == TargetPlatform.WinPhone)
				animationPicker.BackgroundColor = Color.Gray;

			animationPicker.Items.Add("Ball");
			animationPicker.Items.Add("Battery");
			animationPicker.Items.Add("DoubleCircle");
			animationPicker.Items.Add("ECG");
			animationPicker.Items.Add("Globe");
			animationPicker.Items.Add("HorizontalPulsingBox");
			animationPicker.Items.Add("Print");
			animationPicker.Items.Add("Rectangle");
			animationPicker.Items.Add("SingleCircle");
			animationPicker.Items.Add("SlicedCircle");
			animationPicker.Items.Add("Gear");

			animationPicker.HeightRequest = 40;
			animationPicker.SelectedIndex = 0;
			animationPicker.SelectedIndexChanged += animationPicker_SelectedIndexChanged;

			if (Device.OS == TargetPlatform.Android)
			{
				sfbusyindicator.Duration = 1;
				sfbusyindicator.ViewBoxWidth = 100;
				sfbusyindicator.ViewBoxHeight = 100;
			}
			if (Device.OS == TargetPlatform.Android && Device.Idiom == TargetIdiom.Tablet)
			{
				animationLabel.FontSize = 24;
			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				sfbusyindicator.Duration = 1;
				animationPicker.BackgroundColor = Color.White;
				animationLabel = new Label()
				{
					Text = "\nAnimation Type",
					HeightRequest = 20,
					TextColor = Color.Black
				};
				animationLabel.FontAttributes = FontAttributes.Bold;
				animationLabel.FontSize = 25;
			}
			else if (Device.OS == TargetPlatform.WinPhone)
			{
				animationLabel = new Label() { Text = "Animation Type", HeightRequest = 35, TextColor = Color.Black };
				animationPicker.HeightRequest = 100;
				animationLabel.FontAttributes = FontAttributes.Bold;
				animationLabel.FontSize = 25;
				sfbusyindicator.Title = " ";
			}
			else
			{
				animationLabel = new Label() { Text = "Animation Type", HeightRequest = 35, TextColor = Color.Black };
				animationLabel.FontAttributes = FontAttributes.Bold;
				animationLabel.FontSize = 25;
			}

			if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
			{
				animationPicker.BackgroundColor = Color.Gray;
			}

		}

		public View getContent()
		{
			return this.Content;
		}
	}
}



