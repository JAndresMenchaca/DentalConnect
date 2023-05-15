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
using System.Data;
using Microsoft.VisualBasic;
using System.Xml.Linq;


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
            diseable();

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
        private void diseable()
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
        private void clean()
        {
            txbName.Text = "";
            txbDescrip.Text = "";
        }
        private void sendMessages(int opt, string message)
        {
            if(opt == 1)
                txtMessage.Foreground = Brushes.Red;    

            else if(opt == 2)
                txtMessage.Foreground = Brushes.Green;

            txtMessage.Text = message;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            enable();
            dgDatos.IsEnabled= false;
            clean();
            opt = 1;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            

            if (dgDatos.SelectedItem == null && category == null)
            {
                sendMessages(1, "Debe seleccionar un registro");
                diseable();
            }
            else
            {
                enable();
                opt = 2;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            enable();

            if (dgDatos.SelectedItem != null && category != null)
            {
                string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Escribe 'seguro' para confirmar:", "Confirmación", "");
                if (respuesta == "seguro")
                {
                    try
                    {
                       categoryImpl = new CategoryImpl();
                        int test = categoryImpl.Delete(category);
                        if(test>0)
                        {
                            sendMessages(2, "Registro eliminado con exito");
                            select();
                            diseable();
                        }
                    }
                    catch(Exception ex)
                    {
                        sendMessages(1, "Hubo un error al ELIMINAR el registro, comuniquese con el Administrador");
                        diseable();
                    }
                }
                else
                {
                    sendMessages(2, "Se cancelo la accion de ELIMINAR el registro");
                    select();
                    diseable();
                }
            }
            else
            {
                sendMessages(1, "Debe seleccionar un registro");
                diseable();
            }

            dgDatos.SelectedItem = null;
            category = category = null;


        }

        private void insertData(string name, string descrip)
        {
            
            if (name == "")
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                return;
            }

            try
            {
                category = new Category(name, descrip);
                categoryImpl = new CategoryImpl();
                int test = categoryImpl.Insert(category);
                if (test > 0)
                {
                    sendMessages(2, "Se inserto el registro con exito");
                    select();
                    diseable();
                }
            }
            catch
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
            }
            dgDatos.SelectedItem = null;
            category = null;
        }
        private void updateData(string name , string descrip)
        {
            txtMessage.Text = "";
            try
            {
                if (name == "")
                {
                    sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                    return;
                }

                category.Name = name;
                category.Description = descrip;

                categoryImpl = new CategoryImpl();
                int test = categoryImpl.Update(category);

                if (test > 0)
                {
                    sendMessages(2, "Se modifico el registro con exito");
                    select();
                    diseable();
                }
            }
            catch
            {
                sendMessages(1, "Hubo un error al MODIFICAR el registro, contacte al administrador");
            }
            dgDatos.SelectedItem = null;
            category = null;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txbName.Text;
            string descrip = txbDescrip.Text;
            dgDatos.IsEnabled = true;
            diseable();
            switch (opt)
            {
                case 1:
                    insertData(name, descrip);
                    break; 
                case 2:
                    updateData(name, descrip);
                    break;
            }
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            diseable();
            dgDatos.IsEnabled = true;

            getData();

        }
        private void select()
        {
            try
            {
                categoryImpl = new CategoryImpl();
                dgDatos.ItemsSource = null;
                dgDatos.ItemsSource = categoryImpl.Select().DefaultView;
                dgDatos.Columns[0].Visibility = Visibility.Collapsed;
              
            }
            catch
            {
                sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            select();
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getData();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            winMenu menu = new winMenu();
            menu.Show();
            this.Close();
        }

        private void getData()
        {
            if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                category = null;
                DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    categoryImpl = new CategoryImpl();
                    category = categoryImpl.Get(id);
                    txbName.Text = category.Name;
                    txbDescrip.Text = category.Description;
                }
                catch
                {
                    sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
                }
            }
        }
    }
}