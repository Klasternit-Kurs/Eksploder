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
				particija.Tag = drajv;
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
					podD.Expanded += ZaExpand;
					gde.Items.Add(podD);
					try
					{
						if (d.GetDirectories().Length > 0 || d.GetFiles().Length > 0)
							podD.Items.Add("*");
					}
					catch { }
				}
				foreach (FileInfo fajl in dir.GetFiles())
				{
					var fTVi = NapraviTVi(fajl.Name);
					fTVi.Tag = fajl.FullName;
					gde.Items.Add(fTVi);
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

		private void ZaExpand(object KoSalje, RoutedEventArgs zklj)
		{
			var tvI = KoSalje as TreeViewItem;
			if (tvI.Items.Contains("*"))
			{
				tvI.Items.Remove("*");
				UcitajFajlove(tvI);
			}
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

		private void SelektovanoNesto(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var treeV = sender as TreeView;
			if (treeV.SelectedItem != null)
			{
				var tvI = treeV.SelectedItem as TreeViewItem;
				if (Directory.Exists(tvI.Tag.ToString()))
				{
					DirectoryInfo d = new DirectoryInfo(tvI.Tag.ToString());
					lblExt.Content = "-";
					lblFname.Content = d.FullName;
					lblKreiran.Content = d.CreationTime;
				} else if (File.Exists(tvI.Tag.ToString()))
				{
					FileInfo f = new FileInfo(tvI.Tag.ToString());
					lblExt.Content = f.Extension;
					lblFname.Content = f.FullName;
					lblKreiran.Content = f.CreationTime;
				}
			}
			
		}
	}
}
