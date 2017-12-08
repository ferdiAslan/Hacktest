#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfListView
{
    [Preserve(AllMembers = true)]
    public class ProductRepository
    {
        internal string[] Names = new string[]
        {
            "Apple",
            "Banana",
            "Papaya",
            "Lime",
            "Pomegranate",
            "Orange",
            "Watermelon",
            "Apricot",
            "Grapes",
            "Cherry",
            "Custard Apple",
            "Dragon",
            "Pear",
            "Mango",
            "Lemon",
            "Guava",
            "Jackfruit",
            "Kiwi",
            "Peaches",
            "Pineapple",
            "Strawberry",
            "Raspberry"
        };

        internal string[] Weights = new string[]
        {
            "500 gm",
            "850 gm",
            "500 gm",
            "500 gm",
            "400 gm",
            "500 gm",
            "950 gm",
            "900 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "950 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "500 gm",
            "750 gm",
            "500 gm",
            "500 gm"
        };

        internal double[] Prices = new double[]
        {
            2.47,
            1.40,
            1.48,
            2.28,
            10.47,
            1.00,
            3.98,
            14.99,
            1.50,
            7.48,
            26.20,
            22.66,
            1.47,
            7.10,
            7.40,
            6.00,
            7.27,
            7.33,
            9.99,
            2.00,
            13.99,
            16.99
        };
    }
}
