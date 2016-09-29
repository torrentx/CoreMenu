using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
namespace CoreMenu
{
	public sealed partial class MenuItem : UserControl, INotifyPropertyChanged
	{
		private bool _isSelected;
		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				_isSelected = value;
				SelectedVis = value ? Visibility.Visible : Visibility.Collapsed;
				OnPropertyChanged("IsSelected");
			}
		}

		private Visibility _selectedVis = Visibility.Collapsed;
		public Visibility SelectedVis
		{
			get { return _selectedVis; }
			set
			{
				_selectedVis = value;
				this.OnPropertyChanged("SelectedVis");
			}
		}
		public delegate void ButtonClick(object sender, PointerRoutedEventArgs e);
		public ButtonClick Click { get; set; }
		public string Label { get; set; }
		public Symbol Symbol { get; set; }
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
				UpdateSource();
			}
		}

		public MenuItem()
		{
			this.InitializeComponent();
		}

		public char SymbolAsChar
		{
			get
			{
				return (char)Symbol;
			}
		}

		public void UpdateSource()
		{
			MenuChildren.ItemsSource = _menuitems;
			MenuChildren.UpdateLayout();
		}

		private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
		{
			Click.Invoke(sender, e);
		}

		public void AddSubItem(MenuItem item)
		{
			MenuChildren.Items.Add(item);
			MenuChildren.UpdateLayout();
		}

		public event PropertyChangedEventHandler PropertyChanged = delegate { };
		public void OnPropertyChanged(string propertyName)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
