#region Copyright Syncfusion Inc. 2001 - 2017
// Copyright Syncfusion Inc. 2001 - 2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Syncfusion.SfRating.XForms;
using Xamarin.Forms;
using SampleBrowser.Core;

namespace SampleBrowser.SfRating
{
	public partial class Rating_Customization : SampleView
	{
		List<int> Votes = new List<int>();
		bool isVoted = false;
		public List<CustomLabel> RatingLabel = new List<CustomLabel>();
		int angryCount = 1, unHappyCount = 2, neutralCount = 2, happyCount = 1, excitedCount = 4;

		public Rating_Customization()
		{
			InitializeComponent();
            if (Device.OS == TargetPlatform.Android)
            {
                rating.ItemSize = 55;
                rating.ItemSpacing = 5;
                description.FontSize = 12;
                mButton.HeightRequest = 40;
                bottomStack.Margin = new Thickness(0, 5, 0, 0);
            }
			else if (Device.OS == TargetPlatform.iOS)
			{
				rating.ItemSize = 50;
				bottomStack.Padding=new Thickness(0,0,0,0);
				rating.HeightRequest=50;
			}

			Votes.Add(1);
			Votes.Add(2);
			Votes.Add(2);
			Votes.Add(3);
			Votes.Add(4);
			Votes.Add(3);
			Votes.Add(5);
			Votes.Add(5);
			Votes.Add(5);
			Votes.Add(5);
			rating.ValueChanged += Rating_ValueChanged;
			ObservableCollection<SfRatingItem> customItems = new ObservableCollection<SfRatingItem>();
			customItems.Add(new SfRatingItem() { SelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Angry_selected.png"), "10%", "Angry", this), UnSelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Angry_Unselected.png"), "10%", "Angry", this) });
			customItems.Add(new SfRatingItem() { SelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.UnHappy_selected.png"), "20%", "Unhappy", this), UnSelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.UnHappy_Unselected.png"), "20%", "Unhappy", this) });
			customItems.Add(new SfRatingItem() { SelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Neutral_selected.png"), "20%", "Neutral", this), UnSelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Neutral_Unselected.png"), "20%", "Neutral", this) });
			customItems.Add(new SfRatingItem() { SelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Happy_selected.png"), "10%", "Happy", this), UnSelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Happy_Unselected.png"), "10%", "Happy", this) });
			customItems.Add(new SfRatingItem() { SelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Excited_selected.png"), "40%", "Excited", this), UnSelectedView = new CustomRatingView(ImagePathConverter.GetImageSource("SampleBrowser.SfRating.Excited_Unselected.png"), "40%", "Excited", this) });
			rating.Items = customItems;
			//headLineText.Text = "Linda, USA Sports . Wednesday ," + DateTime.Now.ToString("M") + ", " + DateTime.Now.Year.ToString();
			if (Device.OS == TargetPlatform.Windows)
			{
				rating.ItemSize = 55;
				rating.ItemSpacing = 5;
                //countButton.BackgroundColor = Color.FromHex("#FF5500");
                //maincontent.Height = 180;
			}

            if(Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
            {
                description.FontSize = 11;
               // maincontent.Height = 100;
            }

            mButton.BackgroundColor  = Color.White;
            mButton.TextColor = Color.Black;
        }

		void Rating_ValueChanged(object sender, ValueEventArgs e)
		{
			if (!isVoted)
			{
				Votes.Add((int)e.Value);
				isVoted = true;
				if ((int)e.Value == 1)
					angryCount += 1;
				else if ((int)e.Value == 2)
					unHappyCount += 1;
				else if ((int)e.Value == 3)
					neutralCount += 1;
				else if ((int)e.Value == 4)
					happyCount += 1;
				else if ((int)e.Value == 5)
					excitedCount += 1;
			}
			else
			{

				if (Votes[Votes.Count - 1] == 1)
					angryCount -= 1;
				else if (Votes[Votes.Count - 1] == 2)
					unHappyCount -= 1;
				else if (Votes[Votes.Count - 1] == 3)
					neutralCount -= 1;
				else if (Votes[Votes.Count - 1] == 4)
					happyCount -= 1;
				else if (Votes[Votes.Count - 1] == 5)
					excitedCount -= 1;
				Votes.RemoveAt(Votes.Count - 1);
				Votes.Add((int)e.Value);
				if ((int)e.Value == 1)
					angryCount += 1;
				else if ((int)e.Value == 2)
					unHappyCount += 1;
				else if ((int)e.Value == 3)
					neutralCount += 1;
				else if ((int)e.Value == 4)
					happyCount += 1;
				else if ((int)e.Value == 5)
					excitedCount += 1;
			}

		}
		void Handle_Clicked(object sender, System.EventArgs e)
		{
            for (int i = 0; i < RatingLabel.Count; i = i + 2)
			{
				if (i == 0)
				{
					RatingLabel[i].Text = (((angryCount * 100) / Votes.Count)).ToString() + "%";
					RatingLabel[i + 1].Text = (((angryCount * 100) / Votes.Count)).ToString() + "%";
				}
				if (i == 2)
				{
					RatingLabel[i].Text = (((unHappyCount* 100) / Votes.Count)).ToString() + "%";
					RatingLabel[i + 1].Text = (((unHappyCount * 100) / Votes.Count)).ToString() + "%";
				}
				if (i == 4)
				{
					RatingLabel[i].Text = (((neutralCount* 100) / Votes.Count)).ToString() + "%";
					RatingLabel[i + 1].Text = (((neutralCount * 100) / Votes.Count)).ToString() + "%";
				}
				if (i == 6)
				{
					RatingLabel[i].Text = (((happyCount* 100) / Votes.Count)).ToString() + "%";
					RatingLabel[i + 1].Text = (((happyCount * 100) / Votes.Count)).ToString() + "%";
				}
				if (i == 8)
				{
					RatingLabel[i].Text = (((excitedCount * 100) / Votes.Count)).ToString() + "%";
					RatingLabel[i + 1].Text = (((excitedCount * 100) / Votes.Count)).ToString() + "%";
				}
				RatingLabel[i].HorizontalTextAlignment = TextAlignment.Center;
			}
			isVoted = false;
			this.rating.Value = 0;
		}
}
}
