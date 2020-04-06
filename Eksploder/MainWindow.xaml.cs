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
using System.IO;

namespace Eksploder
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			foreach (string drajv in System.Environment.GetLogicalDrives())
			{
				var particija = NapraviTVi(drajv);
				DriveInfo dr = new DriveInfo(drajv);
				DirectoryInfo root = dr.RootDirectory;
				if (dr.IsReady)
				{
					foreach (DirectoryInfo dir in root.GetDirectories())
					{
						particija.Items.Add(dir.Name);
					}
					foreach (FileInfo fajl in root.GetFiles())
					{
						particija.Items.Add(fajl.Name);
					}
				}
				tv.Items.Add(particija);
			}

		}

		public TreeViewItem NapraviTVi(string s)
		{
			TreeViewItem TVi = new TreeViewItem();
			TVi.Header = s;
			return TVi;
		}

		private void Rek(object sender, RoutedEventArgs e)
		{
			Odbrojac(5);
			//a();
		}

		private void a()
		{
			b();
			MessageBox.Show("Stigao do kraja a");
		}

		private void b()
		{
			c();
		}

		private void c()
		{
			MessageBox.Show("Treca metoda");
		}



		private void Odbrojac(int x)
		{
			if (--x == 0)
			{
				MessageBox.Show("Stigao do kraja!");
			} else
			{
				Odbrojac(x);
				MessageBox.Show($"Zavrsavam else sa: {x}");
			}
		}
	}
}
