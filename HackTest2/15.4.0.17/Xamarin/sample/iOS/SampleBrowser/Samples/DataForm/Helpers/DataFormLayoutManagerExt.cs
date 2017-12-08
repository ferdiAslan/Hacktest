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

using Foundation;
using UIKit;
using Syncfusion.iOS.DataForm;
using Syncfusion.iOS.DataForm.Editors;

namespace SampleBrowser
{

    /// <summary>
    /// Represents a class that used to customize the DataForm.
    /// </summary>
    public class DataFormLayoutManagerExt : DataFormLayoutManager
    {
        public DataFormLayoutManagerExt(SfDataForm dataform) : base(dataform)
        {

        }
        protected override nfloat GetLeftPaddingForEditor(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("EmailType") || dataFormItem.Name.Equals("AddressTypes"))
                return 50;
            if (!dataFormItem.ShowLabel)
                return 50;
            return base.GetLeftPaddingForEditor(dataFormItem);
        }
        protected override nfloat GetLeftPaddingForLabel(DataFormItem dataFormItem)
        {
            if (dataFormItem.Name.Equals("SaveTo"))
                return 50;
            return base.GetLeftPaddingForLabel(dataFormItem);
        }      
    } 
}