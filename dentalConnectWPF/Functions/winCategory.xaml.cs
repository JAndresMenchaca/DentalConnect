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
using MaterialDesignThemes.Wpf;



namespace dentalConnectWPF.Functions
{
    /// <summary>
    /// Interaction logic for winCategory.xaml
    /// </summary>
    public partial class winCategory : Window
    {
        byte opt;
        Category category;
        CategoryImpl categoryImpl;
        private readonly SnackbarMessageQueue _messageQueue;


        public winCategory()
        {
            InitializeComponent();
            diseable();


            ValidationsImpl.TextForNameCategory(txbName);
            ValidationsImpl.TextIntputText(txbName);

            ValidationsImpl.TextForDescription(txbDescrip);
            ValidationsImpl.TextForCaracter(txbDescrip);


            _messageQueue = snackbar.MessageQueue;
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


            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;

            txbDescrip.IsEnabled = true;
            txbName.IsEnabled = true;
            txbName.Focus();
        }
        private void diseable()
        {
            txbName.Text = "";
            txbDescrip.Text = "";

            btnInsert.IsEnabled = true;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;

            txbDescrip.IsEnabled = false;
            txbName.IsEnabled = false;
        }
        private void clean()
        {
            txbName.Text = "";
            txbDescrip.Text = "";
        }
        private void diseable2()
        {
            dgDatos.IsEnabled = false;
            enable();
        }

        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtMessage.Foreground = Brushes.Red;

            else if (opt == 2)
                txtMessage.Foreground = Brushes.Green;

            txtMessage.Text = message;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            enable();
            dgDatos.SelectedItem = null;
            category = null;

            dgDatos.IsEnabled = false;

            //string colorHexadecimal = "#000000"; // Valor hexadecimal del color
            //BrushConverter brushConverter = new BrushConverter();
            //Brush colorBrush = (Brush)brushConverter.ConvertFrom(colorHexadecimal);

            //dgDatos.Background = colorBrush;

            clean();
            opt = 1;
        }
        private string DeleteSpace(string texto)
        {
            if (!string.IsNullOrEmpty(texto) && texto[0] == ' ')
            {
                // Eliminar el primer carácter (espacio)
                texto = texto.Substring(1);
            }

            if (!string.IsNullOrEmpty(texto) && texto[texto.Length - 1] == ' ')
            {
                // Eliminar el último carácter (espacio)
                texto = texto.Substring(0, texto.Length - 1);
            }

            return texto;
        }


        private void insertData(string name, string descrip)
        {

            if (name == "")
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                diseable2();
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
                diseable2();
            }
            dgDatos.SelectedItem = null;
            category = null;
        }
        private void updateData(string name, string descrip)
        {
            txtMessage.Text = "";
            try
            {
                if (name == "")
                {
                    sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                    diseable2();
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
                diseable2();
            }
            dgDatos.SelectedItem = null;
            category = null;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txbName.Text;
            string descrip = txbDescrip.Text;

            name = DeleteSpace(name);
            txbName.Text = name;
            descrip = DeleteSpace(descrip);
            txbDescrip.Text = descrip;

            if (name == "")
            {
                sendMessages(1, "Verifique los datos de entrada en el campo NOMBRE");
                diseable2();
                return;
            }


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

                comprobarBtns();

                generarBtns();

                dgDatos.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch (Exception ex) 
            {
                sendMessages(1, ex.Message);
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
            switch (Session.SessionRole)
            {
                case "Administrador":
                    UserWindows.winMenu menu = new UserWindows.winMenu();
                    menu.Show();
                    break;
                case "Gerente de ventas":
                    UserWindows.winSalesManager manager= new UserWindows.winSalesManager();
                    manager.Show();
                    break;
                case "Gerente de inventario":
                    UserWindows.winInventoryManager win = new UserWindows.winInventoryManager();
                    win.Show();
                    break;
            }
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

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            enable();

            if (dgDatos.SelectedItem != null && category != null)
            {

                Tools.winDelete confirmarVentana = new Tools.winDelete();
                confirmarVentana.Owner = this; // Establecer la ventana principal como propietaria
                bool? resultado = confirmarVentana.ShowDialog();

                if (resultado.HasValue && resultado.Value)
                {
                    // Realizar la acción de eliminación
                    try
                    {
                        categoryImpl = new CategoryImpl();
                        int test = categoryImpl.Delete(category);
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

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
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

        private void txbName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btn_help_name_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar letras mayúsculas y minúsculas");
        }

        private void btn_help_Descr_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Se pueden colocar letras, numeros y algunos caracteres especiales");
        }
    }
}