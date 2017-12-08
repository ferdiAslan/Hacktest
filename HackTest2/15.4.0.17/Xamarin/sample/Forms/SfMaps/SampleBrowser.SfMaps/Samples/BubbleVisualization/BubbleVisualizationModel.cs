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

namespace SampleBrowser.SfMaps
{
    public class BubbleVisualizationModel
    {
        public BubbleVisualizationModel(string country, string countrycode, double population, int Index)
        {
            Country = country;
            Code = countrycode;
            Population = population;
            index = Index;
        }

        public string Code
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }

        public double Population
        {
            get;
            set;
        }

        public int index
        {
            get;
            set;
        }
    }
}
