#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class FeaturesFragment : Fragment
	{
		static internal List<SampleBase> Samples;
		internal SampleBase CurrentSample;
		internal TextView BaseTextView;
		static internal int CurrentIndex;
		internal SamplePage currentSamplePage;
		Activity activity;
		public FeaturesFragment(List<SampleBase> sample,Activity act)
		{
			Samples = sample;
			activity = act;
		}

		public FeaturesFragment()
		{

		}

		public override void OnViewCreated(View view, Android.OS.Bundle savedInstanceState)
		{
			GridView listView = view.FindViewById<GridView>(Resource.Id.List);
			listView.Adapter = new HomeScreenAdapter(this.Activity, Samples);
			if (MainActivity.isTablet)
			{
				listView.SetNumColumns(2);
			}
			else
			{
				listView.SetNumColumns(1);
			}
			listView.ItemClick += OnListItemClick;
			if(activity!=null)
			(activity as FeaturesTabbedPage).SettingsButton.Visibility = ViewStates.Invisible;
			base.OnViewCreated(view, savedInstanceState);
		}

		protected void OnListItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
		{
			MainActivity.isFeatureSamples = false;
			Intent intent = new Intent(this.Activity, typeof(NewSampleActivityPage));
			CurrentIndex = e.Position;
			StartActivity(intent);

		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.FeatureLayout, null);
		}
	}
}