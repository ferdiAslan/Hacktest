#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Foundation;
using UIKit;
using Syncfusion.SfNavigationDrawer.iOS;
using CoreAnimation;

namespace SampleBrowser
{
	public class HomeViewController : UIViewController
	{
		//Header
		UIView content;
		UIView header;
		CALayer overlay;
		UILabel title;
		nfloat startY;
		UIMarginLabel allControlsLabel;
		public CALayer bottomBorder;
		UIButton menuButton;
		UIMarginLabel popularControlsLabel;

		public NSMutableArray FeaturedSamples { get; set; }
		public NSMutableArray controls { get; set; }

		UICollectionView collectionView;
		UICollectionView collectionViewAllControls;

		UICollectionViewFlowLayout layout;
		UICollectionViewFlowLayout flowLayoutAllControls;

		static public SFNavigationDrawer navigationDrawer;

		public HomeViewController()
		{
			this.View.BackgroundColor = Utility.backgroundColor;
		}

		protected HomeViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			content = new UIView();
			content.Frame = this.View.Frame;

			this.ParseFeaturedSamplesPlist();

			this.ParseControlsPlist();

			this.LoadHeaderView();
		}

		private void ParseFeaturedSamplesPlist()
		{
			string controlListPathString = NSBundle.MainBundle.BundlePath + "/plist/FeatureSamples.plist";
			NSDictionary controlDict = new NSDictionary();
			controlDict = NSDictionary.FromFile(controlListPathString);
			NSString controlDictKey = new NSString("Samples");
			NSArray controlDictArray = controlDict.ValueForKey(controlDictKey) as NSArray;

			FeaturedSamples = new NSMutableArray();
			NSString image;

			for (nuint i = 0; i < controlDictArray.Count; i++)
			{
				NSDictionary dict = controlDictArray.GetItem<NSDictionary>(i);
				image = (NSString)dict.ValueForKey(new NSString("Image")).ToString();

				if (Utility.IsIpad)
					image = new NSString(image + "_iPad");
				
				Control control = new Control();
				control.ControlName = (NSString)dict.ValueForKey(new NSString("ControlName")).ToString();
				control.name = (NSString)dict.ValueForKey(new NSString("Class")).ToString();
				control.dispName = new NSString(dict.ValueForKey(new NSString("DisplayName")).ToString());
				control.image = UIImage.FromBundle(image);

				FeaturedSamples.Add(control);

			}
		}

		void NavigationDrawer_DidClose(object sender, EventArgs e)
		{
			overlay.Hidden = true;
		}

		private void ParseControlsPlist()
		{
			string controlListPathString = NSBundle.MainBundle.BundlePath + "/plist/ControlList.plist";
			NSDictionary controlDict = new NSDictionary();
			controlDict = NSDictionary.FromFile(controlListPathString);
			NSString controlDictKey = new NSString("Control");
			NSArray controlDictArray = controlDict.ValueForKey(controlDictKey) as NSArray;

			controls = new NSMutableArray();

			if (controlDictArray.Count > 0)
			{

				for (nuint i = 0; i < controlDictArray.Count; i++)
				{
					NSDictionary dict = controlDictArray.GetItem<NSDictionary>(i);
					string image = dict.ValueForKey(new NSString("ControlName")).ToString();
					image = "Controls/" + image;
					Control control = new Control();
					control.name = new NSString(dict.ValueForKey(new NSString("ControlName")).ToString());
					control.description = new NSString(dict.ValueForKey(new NSString("Description")).ToString());
					control.image = UIImage.FromBundle(image);

					if (!UIDevice.CurrentDevice.CheckSystemVersion(9, 0) && control.name == "PDFViewer")
						continue;

					if (dict.ValueForKey(new NSString("IsNew")) != null && dict.ValueForKey(new NSString("IsNew")).ToString() == "YES")
					{
						control.tag = new NSString("NEW");
					}
					else if (dict.ValueForKey(new NSString("IsUpdated")) != null && dict.ValueForKey(new NSString("IsUpdated")).ToString() == "YES")
					{
						control.tag = new NSString("UPDATED");
					}
					else if (dict.ValueForKey(new NSString("IsPreview")) != null && dict.ValueForKey(new NSString("IsPreview")).ToString() == "YES")
					{
						control.tag = new NSString("PREVIEW");
					}
					else {
						control.tag = new NSString("");
					}

					if ((dict.ValueForKey(new NSString("Type1"))) != null)
					{
						control.IsMultipleSampleView = true;
						control.Type1 = new NSString(dict.ValueForKey(new NSString("Type1")).ToString());
						control.Type2 = new NSString(dict.ValueForKey(new NSString("Type2")).ToString());
					}

					controls.Add(control);
				}
			}
		}

		public UITableView table;
		public string[] tableItems;
		UIView HeaderView;
		UIImageView userImg;
		UILabel version;
		UIView centerview;
		UIView yellowSeperater;
		UILabel headerDetails;

		private void LoadHeaderView()
		{
			//NavigationDrawer
			navigationDrawer = new SFNavigationDrawer();
			navigationDrawer.BackgroundColor = UIColor.Clear;
			navigationDrawer.ContentView = content;

			menuButton = new UIButton();
			menuButton.SetBackgroundImage(new UIImage("Images/menu.png"), UIControlState.Normal);

			//navigationDrawer.ContentView = this.View;
			if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				navigationDrawer.DrawerWidth = (this.View.Bounds.Width * 40) / 100;
			}
			else
				navigationDrawer.DrawerWidth = (this.View.Bounds.Width * 75) / 100;

			navigationDrawer.DrawerHeight = this.View.Bounds.Height;

			HeaderView = new UIView();

			HeaderView.BackgroundColor = UIColor.FromRGBA(249.0f / 255.0f, 78.0f / 255.0f, 56.0f / 255.0f, 0.97f);

			userImg = new UIImageView();

			userImg.Image = new UIImage("Controls/synclogo.png");

			version = new UILabel();
			version.Text = "Version " + NSUserDefaults.StandardUserDefaults.ValueForKey(new NSString("VersionNumber"));
			version.Font = UIFont.FromName("Helvetica", 12f);
			version.TextColor = UIColor.White;
			version.TextAlignment = UITextAlignment.Left;
			HeaderView.AddSubview(version);

			yellowSeperater = new UIView();
			yellowSeperater.BackgroundColor = UIColor.FromRGB(255.0f / 255.0f, 198.0f / 255.0f, 14.0f / 255.0f);
			HeaderView.AddSubview(yellowSeperater);

			headerDetails = new UILabel();
			headerDetails.LineBreakMode = UILineBreakMode.WordWrap;
			headerDetails.Lines = 0;
			headerDetails.Text = "The toolkit contains all the components that are typically required for building line-of-business applications for IOS";
			headerDetails.TextColor = UIColor.White;
			headerDetails.Font = UIFont.FromName("Helvetica", 18f);
			HeaderView.AddSubview(headerDetails);

			HeaderView.AddSubview(userImg);

			//Menu Page Design
			table = new UITableView(new CGRect(0, 20, navigationDrawer.DrawerWidth, this.View.Frame.Height)); // defaults to Plain style
			table.SeparatorColor = UIColor.Clear;
			tableItems = new string[] { "Product Page", "Whats New", "Documentation" };
			NavigationTableSource tablesource = new NavigationTableSource(this, tableItems);
			tablesource.customise = false;
			table.Source = tablesource;
			table.BackgroundColor = UIColor.Clear;
			centerview = new UIView();
			centerview.Add(table);
			centerview.BackgroundColor = UIColor.Clear;

			navigationDrawer.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;

			menuButton.TouchDown += (object sender, System.EventArgs e) =>
			 {
				HideDrawer(false);
			 };

			//Header View

			header = new UIView();
			header.BackgroundColor = UIColor.FromRGB(0, 122.0f / 255.0f, 238.0f / 255.0f);

			title = new UILabel();
			title.TextColor = UIColor.White;
			title.Text = "Syncfusion Xamarin Samples";
			title.Font = UIFont.FromName("HelveticaNeue-Medium", 16f);

			popularControlsLabel = new UIMarginLabel();
			popularControlsLabel.Text = "Featured Samples";
			popularControlsLabel.Font = UIFont.FromName("HelveticaNeue-Medium", 14f);
			popularControlsLabel.Insets = new UIEdgeInsets(0, 35, 0, 0);
			popularControlsLabel.TextColor = UIColor.White;
			popularControlsLabel.Layer.CornerRadius = 12.0f;
			popularControlsLabel.ClipsToBounds = true;
			popularControlsLabel.BackgroundColor = UIColor.FromRGB(231.0f / 255.0f, 130.0f / 255.0f, 130.0f / 255.0f);

			layout = new UICollectionViewFlowLayout();
			layout.ScrollDirection = UICollectionViewScrollDirection.Horizontal;

			if (Utility.IsIpad)
				layout.MinimumLineSpacing = 20;
			else
				layout.MinimumLineSpacing = 15;

			collectionView = new UICollectionView(CGRect.Empty, layout);
			collectionView.DataSource = new SampleCollectionSource(this);
			collectionView.Delegate = new FeaturedSampleCollectionDelegate(this);
			collectionView.BackgroundColor = UIColor.Clear;

			flowLayoutAllControls = new UICollectionViewFlowLayout();
			flowLayoutAllControls.ScrollDirection = UICollectionViewScrollDirection.Vertical;
			collectionViewAllControls = new UICollectionView(CGRect.Empty, flowLayoutAllControls);
			collectionViewAllControls.RegisterClassForCell(typeof(UICollectionViewCell), "controlCell");
			collectionViewAllControls.DataSource = new AllControlsCollectionSource(controls);
			collectionViewAllControls.Delegate = new AllControlsCollectionDelegate(this);
			collectionViewAllControls.BackgroundColor = Utility.backgroundColor;

			UINib nib = UINib.FromName("CustomCell", null);
			collectionView.RegisterNibForCell(nib, "cell");

			string nibName = "ControlCell";

			if (UIDevice.CurrentDevice.CheckSystemVersion(9, 0) || Utility.IsIpad)
			{
				nibName = "ControlCell_9";
			}

			UINib nibAllControls = UINib.FromName(nibName, null);
			collectionViewAllControls.RegisterNibForCell(nibAllControls, "controlCell");

			allControlsLabel = new UIMarginLabel();
			allControlsLabel.Text = "All Controls";
			allControlsLabel.Font = UIFont.FromName("Helvetica-Bold", 16f);
			allControlsLabel.Insets = new UIEdgeInsets(0, 20, 0, 0);
			allControlsLabel.TextColor = UIColor.Black;
			allControlsLabel.BackgroundColor = Utility.backgroundColor;


			bottomBorder = new CALayer();
			bottomBorder.BorderWidth = 1;
			bottomBorder.BorderColor = (UIColor.FromRGB(213.0f / 255.0f, 213.0f / 255.0f, 213.0f / 255.0f)).CGColor;
			bottomBorder.Hidden = true;
			allControlsLabel.Layer.AddSublayer(bottomBorder);


			content.AddSubview(header);
			content.AddSubview(menuButton);
			content.AddSubview(title);
			content.AddSubview(popularControlsLabel);
			content.AddSubview(collectionView);
			content.AddSubview(collectionViewAllControls);
			content.AddSubview(allControlsLabel);

			overlay = new CALayer();
			overlay.ZPosition = 1000;
			overlay.Hidden = true;
			overlay.BackgroundColor = (UIColor.FromRGBA(0.0f / 255.0f, 0.0f / 255.0f, 0.0f / 255.0f, 0.05f)).CGColor;
			content.Layer.AddSublayer(overlay);

			this.View.AddSubview(navigationDrawer);
		}

		public void DrawerEvent(int index)
		{
			switch (index)
			{
				case 0:
					UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.syncfusion.com/products/xamarin"));
					break;
				case 1:
					UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.syncfusion.com/products/whatsnew/xamarin-iOS"));
					break;
				case 2:
					UIApplication.SharedApplication.OpenUrl(new NSUrl("https://help.syncfusion.com/xamarin-ios/introduction/overview"));
					break;
				default:
					break;
			}

			HideDrawer(true);
		}

		public void HideDrawer(bool flag)
		{
			overlay.Hidden = flag;
			navigationDrawer.ToggleDrawer();
		}

		public void HideOverlay()
		{
			overlay.Hidden = true;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.NavigationController.SetNavigationBarHidden(true, false);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			overlay.Hidden = true;
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();


			content.Frame = this.View.Frame;

			overlay.Frame = this.View.Frame;

			//Side Menu Frame
			navigationDrawer.Frame = new CGRect(0, 0, this.View.Frame.Width, this.View.Frame.Height);
			HeaderView.Frame = new CGRect(0, 0, navigationDrawer.DrawerWidth, (navigationDrawer.Frame.Height * 65) / 100);

			nfloat yellowLineStart = (HeaderView.Frame.Height * 50) / 100;
			yellowSeperater.Frame = new CGRect(20, yellowLineStart, HeaderView.Frame.Width - 40, 3);
			headerDetails.Frame = new CGRect(20, yellowLineStart + 6, HeaderView.Frame.Width - 40, yellowLineStart - 50);

			nfloat x = 20, y = yellowLineStart - 100;
			float imageWidth = 200, imageHeight = 70, lblWidth = 140;

			userImg.Frame = new CGRect(x, y, imageWidth, imageHeight);
			version.Frame = new CGRect(HeaderView.Frame.Width - 120, HeaderView.Frame.Height - 50, 150, 50);
			centerview.Frame = new CGRect(0, lblWidth, navigationDrawer.DrawerWidth, 500);

			navigationDrawer.DrawerHeaderView = HeaderView;
			navigationDrawer.DrawerHeaderView.Superview.BackgroundColor = UIColor.Clear;
			navigationDrawer.DrawerContentView = centerview;
			navigationDrawer.DrawerContentView.BackgroundColor = UIColor.FromRGBA(1.0f, 1.0f, 1.0f, 0.96f);
			navigationDrawer.DrawerContentView.Superview.BackgroundColor = UIColor.Clear;
			navigationDrawer.DrawerHeaderHeight = (navigationDrawer.Frame.Height * 65) / 100;
			navigationDrawer.DidClose += NavigationDrawer_DidClose;
			//Content Page Frame
			nfloat width = this.View.Frame.Size.Width;
			nfloat height = this.View.Frame.Size.Height;

			float itemSpace = (Utility.IsIpad) ? 15 : 10;
			startY = 30;

			menuButton.Frame = new CGRect(10, startY, 22, 22);
			title.Frame = new CGRect(40, startY, height, 22);

			startY += title.Frame.Height + itemSpace;

			float popularSamplesLabelHeight = 25;
			popularControlsLabel.Frame = new CGRect(-10, startY, 170, popularSamplesLabelHeight);

			startY += popularSamplesLabelHeight + itemSpace + 5;

			float collectionHeight = (Utility.IsIpad) ? 210 : 160;
			float collectionWidth = (Utility.IsIpad) ? 180 : 130;
			float originX = (Utility.IsIpad) ? 20 : 10;

			originX = 20;

			collectionView.Frame = new CGRect(originX, startY, width - originX, collectionHeight);
			layout.ItemSize = new CGSize(collectionWidth, collectionHeight);

			startY += collectionHeight;

			header.Frame = new CGRect(0, 0, width, startY);

			float allcontrolsHeight = 50;
			allControlsLabel.Frame = new CGRect(0, startY, width, allcontrolsHeight);
			bottomBorder.Frame = new CGRect(-1, allControlsLabel.Layer.Frame.Size.Height - 1, allControlsLabel.Layer.Frame.Size.Width, 1);

			startY += allcontrolsHeight;

			collectionViewAllControls.Frame = new CGRect(0, startY, width, height - startY);
			flowLayoutAllControls.ItemSize = new CGSize(width - 20, 100);

			//Update frames for iPad mode
			if (Utility.IsIpad)
			{
				nfloat cellWidth = (width / 2) - 60;
				collectionViewAllControls.Frame = new CGRect(40, startY, width - 100, height - startY);
				flowLayoutAllControls.ItemSize = new CGSize(cellWidth, 100);

			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}

	
}

