using dentalConnectDAO.Model;
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

namespace dentalConnectWPF.UserWindows
{
    /// <summary>
    /// Interaction logic for winMenu.xaml
    /// </summary>
    public partial class winMenu : Window
    {
        public winMenu()
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Functions.winCategory winCategory = new Functions.winCategory();
            winCategory.Show();
            this.Close();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Login.MainWindow main = new Login.MainWindow();
            main.Show();
            this.Close();
            Session.SessionRole = "";
            Session.SessionUserName = "";
            Session.SessionID = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Functions.winSupplier supplier = new Functions.winSupplier();
            supplier.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Functions.winUser user = new Functions.winUser();
            user.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Tools.winPassword pass = new Tools.winPassword();
            pass.ShowDialog();

        }
    }
}










