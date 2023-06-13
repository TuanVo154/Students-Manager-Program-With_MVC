using System;
using System.Collections.Generic;
using System.Data;
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

namespace qlsvMVC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Lop> ListLop;
        private Controller_Lop ctrlLop;

        private List<SinhVien> ListSinhVien;
        private Controller_SinhVien ctrlSinhVien;


        public MainWindow()
        {
            InitializeComponent();

            ListLop = new List<Lop>();
            ctrlLop = new Controller_Lop();

            ListLop = ctrlLop.getDSLop();
            lstLop.ItemsSource = ListLop;

            ListSinhVien = new List<SinhVien>();
            ctrlSinhVien = new Controller_SinhVien();
        }

        private void lstLop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstLop.SelectedIndex == -1) lstLop.SelectedIndex = 0;
            if (lstLop.SelectedIndex != -1)
            {
                Lop lop = new Lop();
                lop = (Lop)lstLop.SelectedItem;

                ListSinhVien = ctrlSinhVien.DSSinhVien(lop);
                lstSinhVien.ItemsSource = null;
                lstSinhVien.ItemsSource = ListSinhVien;

                lblSiSo.Content = lop.SiSo.ToString();
            }
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            Lop lop = new Lop();
            lop.MaLop = txtMaLop.Text;
            lop.TenLop = txtTenLop.Text;
            lop.SiSo = 0;
            ListLop.Add(lop);

            lstLop.ItemsSource = null;
            lstLop.ItemsSource = ListLop;

            ctrlLop.ThemLop(lop);
        }
    }
}
