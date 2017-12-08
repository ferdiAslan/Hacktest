#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    /// <summary>
    /// Represents a class that used as data source for list view.
    /// </summary>
    public class ListViewCustomAdapter : BaseAdapter
    {
        internal ObservableCollection<ContactsInfo> _contactList;
        Activity context;

        public override int Count
        {
            get
            {
                return _contactList.Count;
            }
        }

        public ListViewCustomAdapter(Activity activity)
        {
            context = activity;
            _contactList = new ListViewGroupingViewModel().ContactsInfo;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            Android.Views.View view = convertView;
            var item = _contactList[position];
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.ListViewRowLayout, null);
            view.FindViewById<TextView>(Resource.Id.Text1).Text = item.ContactName;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ContactImage);

            return view;
        }
    }
}