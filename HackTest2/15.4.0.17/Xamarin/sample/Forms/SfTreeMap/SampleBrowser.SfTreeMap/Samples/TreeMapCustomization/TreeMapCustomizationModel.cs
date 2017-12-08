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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfTreeMap
{
    public class OlympicMedals
    {
        public string Country { get; set; }
        public string GameName { get; set; }
        public double GoldMedals { get; set; }
        public double SilverMedals { get; set; }
        public double BronzeMedals { get; set; }
        public double TotalMedals { get; set; }
        public ImageSource GameImgSource { get; set; }
        private string imagename;
        public string ImageName
        {

            get { return imagename; }
            set
            {
                imagename = value;
                GameImgSource = ImageSource.FromResource("SampleBrowser.SfTreeMap.Icons." + imagename);
            }
        }



    }
}
