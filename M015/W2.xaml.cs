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
using System.Windows.Shapes;

namespace M015
{
	/// <summary>
	/// Interaction logic for W2.xaml
	/// </summary>
	public partial class W2 : Window
	{
		public W2()
		{
			InitializeComponent();

			Microsoft.Win32.OpenFileDialog ofd = new();
			bool? open = ofd.ShowDialog();
			if (open == true)
			{
				string opened = ofd.FileName; //Pfad der ausgewählten Datei
				//File einlesen...
			}

			Microsoft.Win32.SaveFileDialog sfd = new();

			DialogResult = true;
		}
	}
}
