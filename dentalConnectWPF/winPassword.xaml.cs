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
using System.Text.RegularExpressions;
using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System.Data;

namespace dentalConnectWPF
{
    /// <summary>
    /// Lógica de interacción para winPassword.xaml
    /// </summary>
    public partial class winPassword : Window
    {
        public winPassword()
        {
            InitializeComponent();
            pbOriginal.Focus();
        }
        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtError.Foreground = Brushes.Red;

            else if (opt == 2)
                txtError.Foreground = Brushes.Green;

            txtError.Text = message;
        }
        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserImpl userImpl = new UserImpl();

                DataTable table = userImpl.Login(Session.SessionUserName, pbOriginal.Password);
                if (table.Rows.Count > 0)
                {
                    
                    if (Regex.IsMatch(pbNew.Password, @"^(?=.*[A-Z])(?=.*\d).{8,}$"))
                    {
                        if (pbNew.Password == pbNew2.Password)
                        {
                            userImpl.change(pbNew.Password);
                            //MessageBox.Show(""+pbNew.Password);
                            sendMessages(2, "Se actualizo la contraseña");
                            //MessageBox.Show(Session.SessionID + "");
                            //Session.SessionRole = "";
                        }
                        else
                        {
                            pbOriginal.Password = "";
                            pbNew.Password = "";
                            pbNew2.Password = "";
                            pbOriginal.Focus();
                            sendMessages(1, "Las contraseñas no coinciden");
                        }
                    }
                    else
                    {
                        sendMessages(1, "Ponga una contraseña mas segura");
                    }

                }
                else
                {
                    sendMessages(1, "Contraseña anterior incorrecta");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
