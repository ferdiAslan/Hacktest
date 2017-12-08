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
using CoreGraphics;
using Foundation;
using UIKit;

namespace SampleBrowser
{
	public static class Utility
	{
		public static UIColor themeColor = UIColor.FromRGB(3.0f/255.0f, 126.0f / 255.0f, 249.0f / 255.0f);// Dark Blue
//UIColor.FromRGB(0, 129.0f / 255.0f, 241.0f / 255.0f); Light blue //
//3, 126, 249

		public static UIColor backgroundColor = UIColor.FromRGB(242.0f / 255.0f, 242.0f / 255.0f, 242.0f / 255.0f);

		public static UIFont titleFont = UIFont.FromName("Helvetica", 14f);

		public static UIFont smallFont = UIFont.FromName("Helvetica", 10f);

		public static bool IsIpad
		{
			get
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
			}
		}


		public static CGSize SizeForStringWithFont(string text, UIFont font)
		{
			NSString nsString = new NSString(text);
			UIStringAttributes attribs = new UIStringAttributes { Font = font};
			CGSize size = nsString.GetSizeUsingAttributes(attribs);

			return size;
		}

		public static void DisposeEx(UIView view)
		{
			try
			{
				var disposeView = true;
				var disconnectFromSuperView = true;
				var disposeSubviews = true;
				var removeGestureRecognizers = false; // WARNING: enable at your own risk, may causes crashes
													  //var removeConstraints = true;
				var removeLayerAnimations = true;
				var associatedViewsToDispose = new List<UIView>();
				var otherDisposables = new List<IDisposable>();

				if (view is UIActivityIndicatorView)
				{
					var aiv = (UIActivityIndicatorView)view;
					if (aiv.IsAnimating)
					{
						aiv.StopAnimating();
					}
				}
				else if (view is UITableView)
				{
					var tableView = (UITableView)view;

					if (tableView.DataSource != null)
					{
						otherDisposables.Add(tableView.DataSource);
					}
					if (tableView.BackgroundView != null)
					{
						associatedViewsToDispose.Add(tableView.BackgroundView);
					}

					tableView.Source = null;
					tableView.Delegate = null;
					tableView.DataSource = null;
					tableView.WeakDelegate = null;
					tableView.WeakDataSource = null;
					associatedViewsToDispose.AddRange(tableView.VisibleCells ?? new UITableViewCell[0]);
				}
				else if (view is UITableViewCell)
				{
					var tableViewCell = (UITableViewCell)view;
					disposeView = false;
					disconnectFromSuperView = false;
					if (tableViewCell.ImageView != null)
					{
						associatedViewsToDispose.Add(tableViewCell.ImageView);
					}
				}
				else if (view is UICollectionView)
				{
					var collectionView = (UICollectionView)view;
					disposeView = false;
					if (collectionView.DataSource != null)
					{
						otherDisposables.Add(collectionView.DataSource);
					}
					if (!(collectionView.BackgroundView == null))
					{
						associatedViewsToDispose.Add(collectionView.BackgroundView);
					}
					collectionView.Source = null;
					collectionView.Delegate = null;
					collectionView.DataSource = null;
					collectionView.WeakDelegate = null;
					collectionView.WeakDataSource = null;
				}
				else if (view is UICollectionViewCell)
				{
					var collectionViewCell = (UICollectionViewCell)view;
					disposeView = false;
					disconnectFromSuperView = false;
					if (collectionViewCell.BackgroundView != null)
					{
						associatedViewsToDispose.Add(collectionViewCell.BackgroundView);
					}
				}
				else if (view is UIWebView)
				{
					var webView = (UIWebView)view;
					if (webView.IsLoading)
						webView.StopLoading();
					webView.LoadHtmlString(string.Empty, null); // clear display
					webView.Delegate = null;
					webView.WeakDelegate = null;
				}
				else if (view is UIImageView)
				{
					var imageView = (UIImageView)view;
					if (imageView.Image != null)
					{
						otherDisposables.Add(imageView.Image);
						imageView.Image = null;
					}
				}
				

				var gestures = view.GestureRecognizers;
				if (removeGestureRecognizers && gestures != null)
				{
					foreach (var gr in gestures)
					{
						view.RemoveGestureRecognizer(gr);
						gr.Dispose();
					}
				}

				if (removeLayerAnimations && view.Layer != null)
				{
					view.Layer.RemoveAllAnimations();
				}

				if (disconnectFromSuperView && view.Superview != null)
				{
					view.RemoveFromSuperview();
				}

				var constraints = view.Constraints;
				if (constraints != null && constraints.Any() && constraints.All(c => c.Handle != IntPtr.Zero))
				{
					view.RemoveConstraints(constraints);
					foreach (var constraint in constraints)
					{
						constraint.Dispose();
					}
				}

				foreach (var otherDisposable in otherDisposables)
				{
					otherDisposable.Dispose();
				}

				foreach (var otherView in associatedViewsToDispose)
				{
					DisposeEx(otherView);
				}

				var subViews = view.Subviews;
				if (disposeSubviews && subViews != null)
				{
					foreach (UIView subview in subViews)
						DisposeEx(subview);
				}

				if (view is ISpecialDisposable)
				{
					((ISpecialDisposable)view).SpecialDispose();
				}
				else 
					if (disposeView)
				{
					if (view.Handle != IntPtr.Zero)
						view.Dispose();
				}


			}
			catch (Exception error)
			{
				//SystemLog.Exception(error);
			}
		}

		public static bool IsDisposedOrNull(UIView view)
		{
			if (view == null)
				return true;

			if (view.Handle == IntPtr.Zero)
				return true; ;

			return false;
		}

		public interface ISpecialDisposable
		{
			void SpecialDispose();
		}
	}
}



