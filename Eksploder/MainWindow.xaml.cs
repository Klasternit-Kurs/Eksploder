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
				var particija = NapraviTVi(drajv);//drajv);
				particija.Tag = "C:\\Test";
				DriveInfo dr = new DriveInfo(drajv);
				if (dr.IsReady)
				{
					UcitajFajlove(particija);
				}
				tv.Items.Add(particija);
			}

		}

		public void UcitajFajlove(TreeViewItem gde)
		{
			DirectoryInfo dir = new DirectoryInfo(gde.Tag.ToString());
			try
			{
				foreach (DirectoryInfo d in dir.GetDirectories())
				{
					var podD = NapraviTVi(d.Name);
					podD.Tag = d.FullName;
					gde.Items.Add(podD);
					if (d.GetDirectories().Length > 0 || d.GetFiles().Length > 0)
						podD.Items.Add(NapraviTVi("*"));
				}
				foreach (FileInfo fajl in dir.GetFiles())
				{
					gde.Items.Add(fajl.Name);
				}
			}
			catch { }
		}

			/*public void UcitajFajlove(TreeViewItem gde)
			{
				DirectoryInfo dir = new DirectoryInfo(gde.Tag.ToString());
				try
				{
					foreach (DirectoryInfo d in dir.GetDirectories())
					{
						var podD = NapraviTVi(d.Name);
						podD.Tag = d.FullName;
						gde.Items.Add(podD);
						UcitajFajlove(podD);
					}
					foreach (FileInfo fajl in dir.GetFiles())
					{
						gde.Items.Add(fajl.Name);
					}
				}
				catch { }
			}*/

			public TreeViewItem NapraviTVi(string s)
		{
			TreeViewItem TVi = new TreeViewItem();
			TVi.Header = s;
			return TVi;
		}

		private void Rek(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(Odbrojac(5).ToString());
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



		private int Odbrojac(int x)
		{
			if (--x > 0)
			{
				return Odbrojac(x);
				
			} else
			{
				return 0;
			}
		}
	}
}
