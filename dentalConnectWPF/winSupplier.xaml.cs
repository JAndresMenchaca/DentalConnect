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

namespace dentalConnectWPF
{
    /// <summary>
    /// Interaction logic for winSupplier.xaml
    /// </summary>
    public partial class winSupplier : Window
    {
        public winSupplier()
        {
            InitializeComponent();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            winMenu menu = new winMenu();
            menu.Show();
            this.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
