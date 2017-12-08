#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Org.Json;
using System.Collections.Generic;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Com.Syncfusion.Sfbusyindicator;
using Com.Syncfusion.Sfbusyindicator.Enums;

namespace SampleBrowser
{
	public class ColorMappings : SamplePage
	{
		SfMaps maps;
        Toast currentToast;
		Handler handler;
        public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			handler = new Handler();
			LinearLayout layout = new LinearLayout(context);
			layout.Orientation = Orientation.Vertical;
			maps = new SfMaps (context);
            currentToast = new Toast(context);
            ShapeFileLayer layer = new ShapeFileLayer();
			layer.Uri ="usa_state.shp";
            layer.ShapeSelected += (object sender, ShapeFileLayer.ShapeSelectedEventArgs e) => {
                JSONObject data = (JSONObject)e.P0;
                if (data != null)
                {
                    if (currentToast != null)
                    {
                        currentToast.Cancel();
                    }
                    currentToast = Toast.MakeText(context, data.Get("Name") + "\n" + data.Get("Type"), ToastLength.Short);
                    currentToast.Show();
                }
            };
            layer.EnableSelection = true;
            layer.ShapeIdTableField ="STATE_NAME";
			layer.ShapeIdPath ="Name";
			layer.DataSource = GetDataSource ();
			layer.LegendSetting = new LegendSetting (){ ShowLegend = true };
			layer.ShapeSettings.ShapeStrokeThickess = 2;
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ShapeColorValuePath ="Type";
			maps.Layers.Add (layer);

			SfBusyIndicator sfBusyIndicator = new SfBusyIndicator(context);
			sfBusyIndicator.IsBusy = true;
			sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;
			sfBusyIndicator.ViewBoxWidth = 50;
			sfBusyIndicator.ViewBoxHeight = 50;
			sfBusyIndicator.TextColor = Color.ParseColor("#779772");
			//sfBusyIndicator.SetBackgroundColor(Color.ParseColor("#779772"));

			layout.AddView(sfBusyIndicator);
			Java.Lang.Runnable run = new Java.Lang.Runnable(() =>
				 {
					 layout.RemoveView(sfBusyIndicator);
					 layout.AddView(maps);

				 });
			handler.PostDelayed(run, 100);

			return layout;
		}

       

        JSONArray GetDataSource()
		{
			JSONArray array = new JSONArray ();

			array.Put(getJsonObject("Alabama", "Vegetables", 9 ));
			array.Put(getJsonObject( "Alaska", "Vegetables", 3 ));
			array.Put(getJsonObject( "Arizona", "Rice", 11 ));
			array.Put(getJsonObject( "Arkansas", "Vegetables", 6 ));
			array.Put(getJsonObject( "California", "Rice", 55 ));
			array.Put(getJsonObject( "Colorado", "Rice", 9 ));
			array.Put(getJsonObject( "Connecticut", "Grains", 7 ));
			array.Put(getJsonObject( "Delaware", "Grains", 3 ));
			array.Put(getJsonObject( "District of Columbia", "Grains", 3 ));
			array.Put(getJsonObject( "Florida", "Rice", 29 ));
			array.Put(getJsonObject( "Georgia", "Rice", 16 ));
			array.Put(getJsonObject( "Hawaii", "Grains", 4 ));
			array.Put(getJsonObject( "Idaho", "Grains", 4 ));
			array.Put(getJsonObject( "Illinois", "Vegetables", 20 ));
			array.Put(getJsonObject( "Indiana", "Grains", 11 ));
			array.Put(getJsonObject( "Iowa", "Vegetables", 6 ));
			array.Put(getJsonObject( "Kansas", "Rice", 6 ));
			array.Put(getJsonObject( "Kentucky", "Grains", 8 ));
			array.Put(getJsonObject( "Louisiana", "Rice", 8 ));
			array.Put(getJsonObject( "Maine", "Grains", 4 ));
			array.Put(getJsonObject( "Maryland", "Grains", 10 ));
			array.Put(getJsonObject( "Massachusetts", "Grains", 11 ));
			array.Put(getJsonObject( "Michigan", "Grains", 16 ));
			array.Put(getJsonObject( "Minnesota", "Wheat", 10 ));
			array.Put(getJsonObject( "Mississippi", "Vegetables", 6 ));
			array.Put(getJsonObject( "Missouri", "Vegetables", 10 ));
			array.Put(getJsonObject( "Montana", "Grains", 3 ));
			array.Put(getJsonObject( "Nebraska", "Rice", 5 ));
			array.Put(getJsonObject( "Nevada", "Wheat", 6 ));
			array.Put(getJsonObject( "New Hampshire", "Grains", 4 ));
			array.Put(getJsonObject( "New Jersey", "Vegetables", 14 ));
			array.Put(getJsonObject( "New Mexico", "Rice", 5 ));
			array.Put(getJsonObject( "New York", "Vegetables", 29 ));
			array.Put(getJsonObject( "North Carolina", "Rice", 15 ));
			array.Put(getJsonObject( "North Dakota", "Grains", 3 ));
			array.Put(getJsonObject( "Ohio", "Vegetables", 18 ));
			array.Put(getJsonObject( "Oklahoma", "Rice", 7 ));
			array.Put(getJsonObject( "Oregon", "Wheat", 7 ));
			array.Put(getJsonObject( "Pennsylvania", "Vegetables", 20 ));
			array.Put(getJsonObject( "Rhode Island", "Grains", 4 ));
			array.Put(getJsonObject( "South Carolina", "Rice", 9 ));
			array.Put(getJsonObject( "South Dakota", "Grains", 3 ));
			array.Put(getJsonObject( "Tennessee", "Vegetables", 11 ));
			array.Put(getJsonObject( "Texas", "Vegetables", 38 ));
			array.Put(getJsonObject( "Utah", "Rice", 6 ));
			array.Put(getJsonObject( "Vermont", "Grains", 3 ));
			array.Put(getJsonObject( "Virginia", "Rice", 13 ));
			array.Put(getJsonObject( "Washington", "Vegetables", 12 ));
			array.Put(getJsonObject( "West Virginia", "Grains", 5 ));
			array.Put(getJsonObject( "Wisconsin", "Grains", 10 ));
			array.Put(getJsonObject( "Wyoming", "Wheat", 3 ));
			return array;
		}

		JSONObject getJsonObject(String name,String type,double count)
		{
			JSONObject obj= new JSONObject();
			obj.Put ("Name", name);
			obj.Put ("Type", type);
			return obj;
		}

		void SetColorMapping(ShapeSetting setting)
		{
			List<ColorMapping> colorMappings= new List<ColorMapping>();

			

			EqualColorMapping colorMapping2= new EqualColorMapping();
			colorMapping2.Value= "Rice";
			colorMapping2.LegendLabel= "Rice";
			colorMapping2.Color =Color.ParseColor("#FD8C48");
			colorMappings.Add(colorMapping2);

			EqualColorMapping colorMapping3= new EqualColorMapping();
			colorMapping3.Value= "Wheat";
			colorMapping3.LegendLabel= "Wheat";
			colorMapping3.Color =Color.ParseColor("#E54D42");
			colorMappings.Add(colorMapping3);

			EqualColorMapping colorMapping4= new EqualColorMapping();
			colorMapping4.Value= "Grains";
			colorMapping4.LegendLabel= "Grains";
			colorMapping4.Color =Color.ParseColor("#3A99D9");
			colorMappings.Add(colorMapping4);


            EqualColorMapping colorMapping1= new EqualColorMapping();
			colorMapping1.Value= "Vegetables";
			colorMapping1.LegendLabel= "Vegetables";
			colorMapping1.Color =Color.ParseColor("#29BB9C");
			colorMappings.Add(colorMapping1);
			setting.ColorMapping = colorMappings;
		}

	}
}

