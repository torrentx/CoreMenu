using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace CoreMenu
{
	public sealed partial class Menu : UserControl
	{
		public Menu()
		{
			this.InitializeComponent();
			_menuitems = new List<MenuItem>();
		}

		private List<MenuItem> _menuitems;
		public List<MenuItem> MenuItems
		{
			get
			{
				return _menuitems;
			}
			set
			{
				_menuitems = value;
			}
		}

		public void UpdateSource()
		{
			MenuChildren.ItemsSource = _menuitems;
			MenuChildren.UpdateLayout();
		}
	}
}