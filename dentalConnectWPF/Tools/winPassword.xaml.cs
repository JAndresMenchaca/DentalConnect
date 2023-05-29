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
using MaterialDesignThemes.Wpf;

namespace dentalConnectWPF.Tools
{
    /// <summary>
    /// Lógica de interacción para winPassword.xaml
    /// </summary>
    public partial class winPassword : Window
    {
        private readonly SnackbarMessageQueue _messageQueue;
        public winPassword()
        {
            InitializeComponent();
            pbOriginal.Focus();
            _messageQueue = snackbar.MessageQueue;
        }
        private void sendMessages(int opt, string message)
        {
            txtError.FontSize = 18;
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
                    
                    if (Regex.IsMatch(pbNew.Password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@#$%_*^&+=?-]).{8,}$"))
                    {
                        if (pbNew.Password == pbNew2.Password)
                        {
                            userImpl.change(pbNew.Password);
                            //MessageBox.Show(""+pbNew.Password);
                            sendMessages(2, "Se actualizo la contraseña");
                            //MessageBox.Show(Session.SessionID + "");
                            //Session.SessionRole = "";
                            userImpl.changePassword();
                            this.Close();
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
                        
                        sendMessages(1, "Contraseña inválida. Debe tener al menos 8 caracteres\nUna letra mayúscula, un número y un carácter especial.");
                        txtError.FontSize = 14;
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

        private void btn_help_password_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Debe tener: +8 caracteres, mayúscula(s), número(s) y un carácter especial.");
        }

        private void pbNew2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConfirm_Click(sender, e);
            }
        }
    }
}
