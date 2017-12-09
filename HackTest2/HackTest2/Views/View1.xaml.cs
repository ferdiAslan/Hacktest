using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackTest2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class View1 : ContentView
	{
		public View1 ()
		{
			InitializeComponent ();
		}
		public string SourceImage
		{
			get { return (string)GetValue(SourceImageProperty); }
			set { SetValue(SourceImageProperty, value); }
		}
		private void ChangeImage(string file)
		{
			if(file != null)
			{
				_image = new Image
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					Source = ImageSource.FromFile(file)
				};
			}
		}
			
		public static readonly BindableProperty SourceImageProperty =
			BindableProperty.Create(nameof(SourceImage), typeof(string), typeof(View1), propertyChanged: (s,o,n) =>
			{
				(s as View1).ChangeImage((string)n);
			});
	}
}