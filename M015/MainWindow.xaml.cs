using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M015;

public partial class MainWindow : Window
{
	public int Counter = 0;

	public MainWindow()
	{
		InitializeComponent();
		Combo.ItemsSource = new List<string>() { "E1", "E2", "E3" }; //ComboBox mit Elementen füllen
		LB.ItemsSource = new List<string>() { "L1", "L2", "L3" };
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Counter++;
		//TB.Text = Counter.ToString();

		//string selected = LB.SelectedItems.OfType<string>().Aggregate("", (agg, element) => agg + element + ", ").Trim(',', ' ');
		//TB.Text = selected;

		W2 window = new W2();
		window.Show(); //freies normales Fenster, blockiert nicht den Hintergrund
		bool? b = window.ShowDialog(); //Dialog, blockiert den Hintergrund
		if (b == true)
		{
			TB.Text = "Erfolg";
		}
		else
		{
			TB.Text = "Misserfolg";
		}
	}

	private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = e.AddedItems[0].ToString();
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		string selected = e.AddedItems.OfType<string>().Aggregate("", (agg, element) => agg + element + ", ").Trim(',', ' ');
		TB.Text = selected;
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		CheckBox cb = sender as CheckBox;
		TB.Text = cb.Content + " checked";
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		CheckBox cb = sender as CheckBox;
		TB.Text = cb.Content + " unchecked";
	}

	private void MenuItem_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult res = MessageBox.Show("Möchtest du wirklich beenden?", "Beenden?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
		if (res == MessageBoxResult.Yes)
		{
			Environment.Exit(0);
		}
	}
}
