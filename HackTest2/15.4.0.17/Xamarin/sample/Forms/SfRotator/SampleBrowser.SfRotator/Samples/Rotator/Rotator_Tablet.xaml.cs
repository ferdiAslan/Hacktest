#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfRotator.XForms;

using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRotator
{
	public partial class Rotator_TabletView : SampleView
	{
		double width;

		public Rotator_TabletView()
		{
			InitializeComponent();
			width = Core.SampleBrowser.ScreenWidth;
			sfRotator.BindingContext = new RotatorViewModel();
			settingsWindows();
		}

		#region Settings options
		private void settingsWindows()
		{

			directionPicker.Items.Add("Horizontal");
			directionPicker.Items.Add("Vertical");
			directionPicker.SelectedIndex = 0;

			directionPicker.SelectedIndexChanged += picker1_SelectedIndexChanged;
			tabPicker.Items.Add("Bottom");
			tabPicker.Items.Add("Top");
			tabPicker.Items.Add("Left");
			tabPicker.Items.Add("Right");
			tabPicker.SelectedIndex = 0;

			modePicker.Items.Add("Dots");
			modePicker.Items.Add("Thumbnail");
			modePicker.SelectedIndex = 0;

			tabPicker.SelectedIndexChanged += picker2_SelectedIndexChanged;

			modePicker.SelectedIndexChanged += picker3_SelectedIndexChanged;
			toggleButton.Toggled += toggleStateChanged;


			if (Device.OS == TargetPlatform.Android)
			{

			}
			else if (Device.OS == TargetPlatform.iOS)
			{
				sfRotator.WidthRequest = width;
				sfRotator.HeightRequest = Core.SampleBrowser.ScreenHeight / 2 + 20;
				emptyLabel.WidthRequest = 200;

			}
			if (Device.OS == TargetPlatform.Android)
			{

				directionLabel.FontSize = 20;
				tabLabel.FontSize = 20;
				emptyLabel.FontSize = 20;
				modeLabel.FontSize = 20;
			}
			if (Device.OS == TargetPlatform.WinPhone)
			{
				emptyLabel.WidthRequest = 150;
				directionPicker.HeightRequest = 90;
				tabPicker.HeightRequest = 90;
				directionLabel.Text = "  " + "Tick Placement";
				directionLabel.HeightRequest = 22;
				tabLabel.Text = "  " + "Label Placement";
				tabLabel.HeightRequest = 22;
				modeLabel.Text = "  " + "Label Placement";
				modeLabel.HeightRequest = 22;
				emptyLabel.Text = "  " + "Label";
				emptyLabel.HeightRequest = 22;

			}

		}

		void picker1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (directionPicker.SelectedIndex)
			{
				case 0:
					{
						sfRotator.NavigationDirection = NavigationDirection.Horizontal;
						break;
					}
				case 1:
					{
						sfRotator.NavigationDirection = NavigationDirection.Vertical;
						break;
					}
			}
		}
		void picker2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (tabPicker.SelectedIndex)
			{
				case 0:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Bottom;
						break;
					}
				case 1:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Top;
						break;
					}
				case 2:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Left;
						break;
					}
				case 3:
					{
						sfRotator.NavigationStripPosition = NavigationStripPosition.Right;
						break;
					}
			}
		}
		void picker3_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (modePicker.SelectedIndex)
			{
				case 0:
					{
						sfRotator.NavigationStripMode = NavigationStripMode.Dots;
						break;
					}
				case 1:
					{
						sfRotator.NavigationStripMode = NavigationStripMode.Thumbnail;
						break;
					}

			}
		}
		void toggleStateChanged(object sender, ToggledEventArgs e)
		{
			sfRotator.EnableAutoPlay = e.Value;
		}

		#endregion

		public View getContent()
		{
			return this.Content;
		}

	}
}



