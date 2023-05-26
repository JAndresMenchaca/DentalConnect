﻿using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace dentalConnectWPF.Functions
{
    /// <summary>
    /// Interaction logic for winSupplier.xaml
    /// </summary>
    public partial class winSupplier : Window
    {
        byte opt;
        Supplier supplier;
        SupplierImpl supplierImpl;
        string[] ciudades = { "Cochabamba", "Santa Cruz", "La Paz" };
        private readonly SnackbarMessageQueue _messageQueue;

        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtMessage.Foreground = Brushes.Red;

            else if (opt == 2)
                txtMessage.Foreground = Brushes.Green;

            txtMessage.Text = message;
        }

        public winSupplier()
        {
            InitializeComponent();
            diseable();
            cbCity.ItemsSource = ciudades;

            Validations.TextNameS(txbName);
            Validations.TextNameS1(txbName);

            Validations.TextPhoneS(txbPhone);
            Validations.TextPhoneS1(txbPhone);

            Validations.TextEmailS(txbEmail);
            Validations.TextEmailS1(txbEmail);

            Validations.TextWebS(txbWeb);
            Validations.TextWebS1(txbWeb);


            Validations.TextStreetS(txbMain);
            Validations.TextStreetS1(txbMain);

            Validations.TextStreetS(txbAd);
            Validations.TextStreetS1(txbAd);

            _messageQueue = snackbar.MessageQueue;
        }
        private void enable()
        {
            btnInsert.IsEnabled = false;
            //btnDelete.IsEnabled = false;
            //btnModify.IsEnabled = false;

            btnCancel.IsEnabled = true;
            btnSave.IsEnabled   = true;

            txbName.IsEnabled  = true;
            txbPhone.IsEnabled = true;
            txbEmail.IsEnabled = true;
            txbWeb.IsEnabled   = true;
            cbCity.IsEnabled   = true;
            txbMain.IsEnabled  = true;
            txbAd.IsEnabled    = true;

            txbName.Focus();
        }
        private void diseable()
        {
            txbName.Text  = "";
            txbPhone.Text = "";
            txbEmail.Text = "";
            txbWeb.Text   = "";
            txbMain.Text  = "";
            txbAd.Text    = "";
            cbCity.Text   = "";
            

            btnInsert.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnModify.IsEnabled = true;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;

            txbName.IsEnabled  = false;
            txbPhone.IsEnabled = false;
            txbEmail.IsEnabled = false;
            txbWeb.IsEnabled   = false;
            cbCity.IsEnabled   = false;
            txbMain.IsEnabled  = false;
            txbAd.IsEnabled    = false;


            
        }
        private void clean()
        {
            txbName.Text = "";
            txbPhone.Text = "";
            txbEmail.Text = "";
            txbWeb.Text = "";
            txbMain.Text = "";
            txbAd.Text = "";
            cbCity.Text = "";
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
            UserWindows.winMenu menu = new UserWindows.winMenu();
            menu.Show();
            this.Close();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            enable();
            dgDatos.IsEnabled = false;
            txtMessage.Text = "";
            clean();
            dgDatos.SelectedItem = null;
            supplier = null;
            opt = 1;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            if (dgDatos.SelectedItem == null &&  supplier == null)
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txbName.Text;
            dgDatos.IsEnabled = true;
            string phone = txbPhone.Text;
            string email = txbEmail.Text;
            string web = txbWeb.Text;

            int city = selectCity();
            if (city == 0)
                return;

            string main = txbMain.Text;
            string adja = txbAd.Text;

           
            switch (opt)
            {
                case 1:
                    insertData(name, phone, email, web, main, adja, city);
                    break;
                case 2:
                    updateData(name, phone, email, web, main, adja, city);
                    break;
            }
            diseable();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            dgDatos.IsEnabled = true;
            diseable();

            getData();

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            enable();

            if (dgDatos.SelectedItem != null && supplier != null)
            {
                string respuesta = Microsoft.VisualBasic.Interaction.InputBox("Escribe 'seguro' para confirmar:", "Confirmación", "");
                if (respuesta == "seguro")
                {
                    try
                    {
                        supplierImpl = new SupplierImpl();
                        int test = supplierImpl.Delete(supplier);
                        if (test > 0)
                        {
                            sendMessages(2, "Registro eliminado con exito");
                            select();
                            diseable();
                        }
                    }
                    catch
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
            supplier = supplier = null;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            select();
        }

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getData();
        }

        private void insertData(string name, string phone, string email, string website, string main, string adjacent, int idCity)
        {
            if (name == "" || phone == "" || email == "" || main == "")
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                return;
            }

            if (Regex.IsMatch(phone, @"^[0-9+]+$") && email.Contains("@"))
            {
                try
                {
                    supplier = new Supplier(name, phone, email, website, main, adjacent, idCity);
                    supplierImpl = new SupplierImpl();
                    int test = supplierImpl.Insert(supplier);

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
            }
            else
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
            }

          
            dgDatos.SelectedItem = null;
            supplier = null;
        }
        private void updateData(string name, string phone, string email, string website, string main, string adjacent, int idCity)
        {
            if (Regex.IsMatch(phone, @"^[0-9+]+$") && email.Contains("@"))
            {
                try
                {
                    if (name == "" || phone == "" || email == "" || main == "")
                    {
                        sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                        return;
                    }

                    supplier.Name = name;
                    supplier.Phone = phone;
                    supplier.Email = email;
                    supplier.Website = website;
                    supplier.Email = email;
                    supplier.MainStreet = main;
                    supplier.AdjacentStreet = adjacent;
                    supplier.IdCity = idCity;

                    supplierImpl = new SupplierImpl();
                    int test = supplierImpl.Update(supplier);

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
            }
            else
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
            }

            dgDatos.SelectedItem = null;
            supplier = null;
        }
        private void select()
        {
            try
            {
                supplierImpl = new SupplierImpl();
                dgDatos.ItemsSource = null;
                dgDatos.ItemsSource = supplierImpl.Select().DefaultView;

                comprobarBtns();

                generarBtns();

                dgDatos.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch
            {
                sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
            }
        }
        private int selectCity()
        {
            int city = 0;
            switch (cbCity.Text)
            {
                case "":
                    sendMessages(1, "Verifique los datos");
                    diseable();
                    return 0;
                    break;
                case "Cochabamba":
                    city = 1;
                    break;

                case "Santa Cruz":
                    city = 2;
                    break;

                case "La Paz":
                    city = 3;
                    break;
            }
            return city;
        } // string -> int -/- Cbba -> 1
        private string showCity(int idCity)
        {
            string city = "";
            switch (idCity)
            {
                case 1:
                    city = "Cochabamba";
                    break;

                case 2:
                    city = "Santa Cruz";
                    break;

                case 3:
                    city = "La Paz";
                    break;
            }
            return city;
        } // int -> string -/- 1 -> Cbba
        private void getData()
        {
            if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                supplier = null;
                DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    supplierImpl = new SupplierImpl();
                    supplier = supplierImpl.Get(id);
                    txbName.Text = supplier.Name;
                    txbPhone.Text = supplier.Phone;
                    txbEmail.Text = supplier.Email;
                    txbWeb.Text = supplier.Website;
                    txbMain.Text = supplier.MainStreet;
                    txbAd.Text = supplier.AdjacentStreet;
                    cbCity.Text = showCity(supplier.IdCity);
                }
                catch
                {
                    sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
                }
            }
        }
        public void comprobarBtns()
        {
            DataGridColumn columna = dgDatos.Columns.SingleOrDefault(c => c.Header.ToString() == "Editar");
            if (columna != null)
            {
                dgDatos.Columns.Remove(columna);
            }

            DataGridColumn columna1 = dgDatos.Columns.SingleOrDefault(c => c.Header.ToString() == "Eliminar");
            if (columna != null)
            {
                dgDatos.Columns.Remove(columna1);
            }
        }
        public void generarBtns()
        {
            // Crear las columnas de botones
            DataGridTemplateColumn editarColumna = new DataGridTemplateColumn();
            DataGridTemplateColumn eliminarColumna = new DataGridTemplateColumn();

            // Crear las plantillas de las celdas con los botones
            editarColumna.Header = "Editar";
            FrameworkElementFactory editarButtonFactory = new FrameworkElementFactory(typeof(Button));
            editarButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Editar_Click));

            string colorHexadecimal = "#2367E6"; // Valor hexadecimal del color
            BrushConverter brushConverter = new BrushConverter();
            Brush colorBrush = (Brush)brushConverter.ConvertFrom(colorHexadecimal);

            editarButtonFactory.SetValue(Button.BackgroundProperty, colorBrush);

            editarButtonFactory.SetValue(Button.ContentProperty, "✏️");

            eliminarColumna.Header = "Eliminar";
            FrameworkElementFactory eliminarButtonFactory = new FrameworkElementFactory(typeof(Button));
            eliminarButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(Eliminar_Click));

            string colorHexadecimal1 = "#F0272E"; // Valor hexadecimal del color
            BrushConverter brushConverter1 = new BrushConverter();
            Brush colorBrush1 = (Brush)brushConverter.ConvertFrom(colorHexadecimal1);

            eliminarButtonFactory.SetValue(Button.BackgroundProperty, colorBrush1);

            eliminarButtonFactory.SetValue(Button.ContentProperty, "🗑");

            // Asignar las plantillas a las columnas
            editarColumna.CellTemplate = new DataTemplate { VisualTree = editarButtonFactory };
            eliminarColumna.CellTemplate = new DataTemplate { VisualTree = eliminarButtonFactory };

            // Añadir las columnas al DataGrid
            dgDatos.Columns.Add(editarColumna);
            dgDatos.Columns.Add(eliminarColumna);
        }
        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            if (dgDatos.SelectedItem == null && supplier == null)
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
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            enable();

            if (dgDatos.SelectedItem != null && supplier != null)
            {

                Tools.winDelete confirmarVentana = new Tools.winDelete();
                confirmarVentana.Owner = this; // Establecer la ventana principal como propietaria
                bool? resultado = confirmarVentana.ShowDialog();

                if (resultado.HasValue && resultado.Value)
                {
                    // Realizar la acción de eliminación
                    try
                    {
                        supplierImpl = new SupplierImpl();
                        int test = supplierImpl.Delete(supplier);
                        if (test > 0)
                        {
                            sendMessages(2, "Registro eliminado con exito");
                            select();
                            diseable();
                        }
                    }
                    catch (Exception ex)
                    {
                        sendMessages(1, "Hubo un error al ELIMINAR el registro, comuniquese con el Administrador");
                        diseable();
                    }
                }
                else
                {
                    sendMessages(2, "Se cancelo la acción de ELIMINAR el registro");
                    select();
                    diseable();
                }
            }
        }

        private void btn_help_name_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números y letras");
        }

        private void btn_help_phone_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo pueden colocar números, - ,  y un signo +");
        }

        private void btn_help_email_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números, puntos, @, letras mayúsculas y minúsculas");
        }

        private void btn_help_web_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números, puntos, @, letras mayúsculas y minúsculas");
        }

        private void btn_help_main_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números, puntos, espacios y letras");
        }

        private void btn_help_ad_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números, puntos, espacios y letras");
        }
    }
}