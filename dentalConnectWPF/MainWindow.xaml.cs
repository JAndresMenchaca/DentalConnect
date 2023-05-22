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
using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;

namespace dentalConnectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                UserImpl userImpl = new UserImpl();

                DataTable table = userImpl.Login(txtUser.Text, txtPass.Password);
                if (table.Rows.Count>0)
                {
                    Session.SessionID = int.Parse(table.Rows[0][0].ToString());
                    Session.SessionUserName = table.Rows[0][1].ToString();
                    Session.SessionRole = table.Rows[0][2].ToString();
                    Session.SessionChangePassword = int.Parse(table.Rows[0][3].ToString());

                    if(Session.SessionChangePassword == 0)
                    {
                        winPassword pass = new winPassword();
                        pass.ShowDialog();
                        txtPass.Password = "";
                        txtPass.Focus();

                    }
                    else if(Session.SessionChangePassword == 1) {
                        switch (Session.SessionRole)
                        {
                            case "Administrador":
                                winMenu winMenu = new winMenu();
                                winMenu.Show();
                                this.Close();
                                break;
                            case "Gerente de ventas":
                                winSalesManager winSalesManager = new winSalesManager();
                                winSalesManager.Show();
                                this.Close();
                                break;
                            case "Gerente de inventario":
                                winInventoryManager winInventoryManager = new winInventoryManager();
                                winInventoryManager.Show();
                                this.Close();
                                break;
                        }
                    }

                    

                }
                else
                {
                    //MessageBox.Show(txtPass.Password);

                    txbError.Foreground = Brushes.Red;
                    txbError.Text = "Los datos no son correctos";

                    if (txtPass.Password == "" || txtUser.Text == "")
                        txbError.Text = "Introduzca las credenciales";
   
                    txtPass.Password = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                }

                
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
