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
using dentalConnectDAO;
using dentalConnectDAO.Model;
using dentalConnectDAO.Implementation;

namespace dentalConnectWPF
{
    /// <summary>
    /// Interaction logic for winCategory.xaml
    /// </summary>
    public partial class winCategory : Window
    {
        byte opt;

        Category category;
        CategoryImpl categoryImpl;

        public winCategory()
        {
            InitializeComponent();
            disenable();

        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void enable()
        {
            btnInsert.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnModify.IsEnabled = false;

            btnCancel.IsEnabled = true;
            btnSave.IsEnabled   = true;

            txbDescrip.IsEnabled = true;
            txbName.IsEnabled    = true;
            txbName.Focus();
        }
        private void disenable()
        {
            txbName.Text    = "";
            txbDescrip.Text = "";

            btnInsert.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnModify.IsEnabled = true;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled   = false;

            txbDescrip.IsEnabled = false;
            txbName.IsEnabled    = false;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            enable();
            opt = 1;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            enable();
            opt = 2;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            enable();
            opt = 3;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txbName.Text;
            string descrip = txbDescrip.Text;

            if (name == "")
            {
                txtMessage.Foreground = Brushes.Red;
                txtMessage.Text = "Hubo un error al INSERTAR el registro, verifique los datos";
                return;
            }

            disenable();
            switch (opt)
            {
                case 1:
                    category = new Category(name, descrip);

                    try
                    {
                        category = new Category(name, descrip);
                        categoryImpl = new CategoryImpl();
                        int test = categoryImpl.Insert(category);
                        if(test > 0)
                        {
                            txtMessage.Foreground = Brushes.Green;
                            txtMessage.Text = "Se inserto el registro con exito";
                            select();
                            disenable();
                        }
                    }
                    catch(Exception ex)
                    {
                        txtMessage.Foreground = Brushes.Red;
                        txtMessage.Text = "Hubo un error al INSERTAR el registro, verifique los datos";
                    }


                    break; 
                case 2:
                    break;
                case 3:
                    break;
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            disenable();
        }
        private void select()
        {
            try
            {
                categoryImpl = new CategoryImpl();
                dgDatos.ItemsSource = null;
                dgDatos.ItemsSource = categoryImpl.Select().DefaultView;
            }
            catch(Exception ex)
            {
                txtMessage.Foreground = Brushes.Red;
                txtMessage.Text = "No se pudo acceder a los datos, comuniquese con el Administrador";
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            select();
        }
    }
}
