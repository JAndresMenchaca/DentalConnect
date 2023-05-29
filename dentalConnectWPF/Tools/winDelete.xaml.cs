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

namespace dentalConnectWPF.Tools
{
    /// <summary>
    /// Lógica de interacción para winDelete.xaml
    /// </summary>
    public partial class winDelete : Window
    {
        public winDelete()
        {
            InitializeComponent();
           txtConfirm.Focus();
        }

        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtError.Foreground = Brushes.Red;

            else if (opt == 2)
                txtError.Foreground = Brushes.Green;

            txtError.Text = message;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            string palabraConfirmacion = txtConfirm.Text/*.ToLower()*/;

            if (palabraConfirmacion == "seguro")
            {
                DialogResult = true;
                this.Close();
            }
            else
            {
                txtConfirm.Text = "";
                txtConfirm.Focus();
                sendMessages(1, "Palabra Incorrecta");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void txtConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConfirm_Click (sender, e);
            }
        }
    }
}
