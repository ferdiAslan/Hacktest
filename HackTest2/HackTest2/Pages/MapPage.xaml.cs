using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HackTest2.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		private MapPageType _typeofpage;
		public MapPage ()
		{
			InitializeComponent ();
			_typeofpage = MapPageType.type1;
		}
		private  void mapTapped(object sender, EventArgs e)
		{
			MapImage.Source = ImageSource.FromFile("map_2.png");
			_typeofpage = MapPageType.type1;
		}
		private void LevelTapped(object sender, EventArgs e)
		{
			if(_typeofpage == MapPageType.type1)
			{
				MapImage.Source = ImageSource.FromFile("map_3.png");
				_typeofpage = MapPageType.type2;
			}

		}
		private void pointTapped(object sender, EventArgs e)
		{
			if (_typeofpage == MapPageType.type2)
			{
				MapImage.Source = ImageSource.FromFile("map_4.png");
				_typeofpage = MapPageType.type3;
			}

		}
	}
	public enum MapPageType
	{
		type1,
		type2,
		type3
	}
}