using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using MaterialDesignThemes.Wpf;

namespace dentalConnectWPF.Functions
{
    /// <summary>
    /// Lógica de interacción para winProduct.xaml
    /// </summary>
    public partial class winProduct : Window
    {
        byte opt;
        Product product;
        ProductImpl productImpl;
        private readonly SnackbarMessageQueue _messageQueue;
        private byte idCateg = 0, idSuppl = 0;
        private string categ = "", suppl = "";

        public winProduct()
        {
            InitializeComponent();
            QuerysImpl query = new QuerysImpl();
            diseable();
            _messageQueue = snackbar.MessageQueue;
            cbCateg.ItemsSource = query.comboCateg();
            cbSupplier.ItemsSource = query.comboSuppl();

            ValidationsImpl.TextNameP(txbName);
            ValidationsImpl.TextNameP1(txbName);

            ValidationsImpl.TextForDescription(txbDesc);
            ValidationsImpl.TextForCaracter(txbDesc);

            ValidationsImpl.TextPriceP(txbPrice);
            ValidationsImpl.TextPriceP1(txbPrice);

            ValidationsImpl.TextStockP(txbStock);
            ValidationsImpl.TextStockP1(txbStock);
        }
        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtMessage.Foreground = Brushes.Red;

            else if (opt == 2)
                txtMessage.Foreground = Brushes.Green;

            txtMessage.Text = message;
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
        private void enable()
        {
            btnInsert.IsEnabled = false;
            //btnDelete.IsEnabled = false;
            //btnModify.IsEnabled = false;

            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;

            txbName.IsEnabled = true;
            txbDesc.IsEnabled = true;
            txbPrice.IsEnabled = true;
            txbStock.IsEnabled = true;

            cbCateg.IsEnabled = true;
            cbSupplier.IsEnabled = true;

            txbName.Focus();
        }
        private void diseable()
        {
            txbName.Text = "";
            txbDesc.Text = "";
            txbPrice.Text = "";
            txbStock.Text = "";

            cbCateg.SelectedItem= null;
            cbSupplier.SelectedItem= null;

            btnInsert.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnModify.IsEnabled = true;

            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;

            txbName.IsEnabled = false;
            txbDesc.IsEnabled = false;
            txbPrice.IsEnabled = false;
            txbStock.IsEnabled = false;

            cbCateg.IsEnabled = false;
            cbSupplier.IsEnabled = false;
        }
        private void diseable2()
        {
            dgDatos.IsEnabled = false;
            enable();
        }
        private void clean()
        {
            txbName.Text = "";
            txbDesc.Text = "";
            txbPrice.Text = "";
            txbStock.Text = "";
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
                    UserWindows.winSalesManager manager = new UserWindows.winSalesManager();
                    manager.Show();
                    break;
                case "Gerente de inventario":
                    UserWindows.winInventoryManager win = new UserWindows.winInventoryManager();
                    win.Show();
                    break;
            }
            this.Close();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            cbCateg.SelectedItem = null;
            cbSupplier.SelectedItem = null;
            enable();
            dgDatos.IsEnabled = false;
            txtMessage.Text = "";
            clean();
            dgDatos.SelectedItem = null;
            product = null;
            opt = 1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            dgDatos.IsEnabled = true;
            string name = txbName.Text;
            string descrip = txbDesc.Text;
            double price;
            try
            {
                price = double.Parse(txbPrice.Text);
            }
            catch
            {
                sendMessages(1, "Verifique que los datos de entrada en el campo PRECIO sean numeros enteros o decimales");
                diseable2();
                return;
            }

            int stock = int.Parse(txbStock.Text);

            if (idCateg == 0)
            {
                sendMessages(1, "Debe elegir una Categoria");
                diseable2();
                return;
            }
            if (idSuppl == 0)
            {
                sendMessages(1, "Debe elegir un Proveedor");
                diseable2();
                return;
            }
            if (price == 0)
            {
                sendMessages(1, "El precio debe ser mayor a 0");
                diseable2();
                return;
            }
            //MessageBox.Show(idCateg + " "+idSuppl);



            name = DeleteSpace(name);

            txbName.Text = name;

            descrip = DeleteSpace(descrip);
            txbDesc.Text = descrip;



            switch (opt)
            {
                case 1:
                    insertData(name, descrip, price, stock, idCateg, idSuppl);
                    break;
                case 2:
                    updateData(name, descrip, price, stock, idCateg, idSuppl);
                    break;
            }
        }

        private void insertData(string name, string description, double price, int stock, byte categoryId, byte supplierId)
        {
            if (name == "" || description == "")
            {
                sendMessages(1, "Verifique que los campos contengan datos");
                diseable2();
                return;
            }

            if (price == 0 )
            {
                sendMessages(1, "El precio debe ser mayor a 0");
                diseable2();
                return;
            }


            try
            {
                product = new Product(name, description, price, stock, categoryId, supplierId);
                productImpl = new ProductImpl();
                int test = productImpl.Insert(product);

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
            product = null;
        }
        private void updateData(string name, string description, double price, int stock, byte categoryId, byte supplierId)
        {
            try
            {
                if (name == "" || description == "")
                {
                    sendMessages(1, "Verifique que los campos contengan datos");
                    diseable2();
                    return;
                }

                if (price == 0)
                {
                    sendMessages(1, "El precio debe ser mayor a 0");
                    diseable2();
                    return;
                }


                product.Name = name;
                product.Description= description;
                product.Price= price;
                product.Stock = stock;
                product.CategoryId= categoryId;
                product.SupplierId= supplierId;



                productImpl = new ProductImpl();
                int test = productImpl.Update(product);

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
            product = null;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            dgDatos.IsEnabled = true;
            diseable();

            getData();
        }

        #region Messages
        private void btn_help_name_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números y letras");
        }

        private void btn_help_desc_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Se pueden colocar letras, numeros y algunos caracteres especiales");
        }

        private void btn_help_price_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números y ','");
        }

        private void btn_help_stock_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números enteros");
        }
        #endregion

        private void dgDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            DataRowView selectedRow = (DataRowView)dgDatos.SelectedItem;

            if (selectedRow != null)
            {
                // Obtener el valor de la columna deseada
                string columna1 = selectedRow["Categoría"].ToString();
                string columna2 = selectedRow["Proveedor"].ToString();

                // Establecer el valor en el ComboBox
                categ = columna1;
                suppl= columna2;
            }


            getData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            select();
        }

        private void cbCateg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCateg.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cbCateg.SelectedItem;
                byte selectedId = (byte)selectedItem.Tag;
                idCateg = selectedId;
            }
        }

        private void cbSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCateg.SelectedItem != null)
            {
                ComboBoxItem selectedItem = (ComboBoxItem)cbSupplier.SelectedItem;
                byte selectedId = (byte)selectedItem.Tag;
                idSuppl = selectedId;
            }

            
        }
        private void select()
        {
            try
            {
                productImpl = new ProductImpl();
                dgDatos.ItemsSource = null;
                dgDatos.ItemsSource = productImpl.Select().DefaultView;

                comprobarBtns();

                generarBtns();

                dgDatos.Columns[0].Visibility = Visibility.Collapsed;

            }
            catch
            {
                sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
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
            if (dgDatos.SelectedItem == null && product == null)
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

            if (dgDatos.SelectedItem != null && product != null)
            {

                Tools.winDelete confirmarVentana = new Tools.winDelete();
                confirmarVentana.Owner = this; // Establecer la ventana principal como propietaria
                bool? resultado = confirmarVentana.ShowDialog();

                if (resultado.HasValue && resultado.Value)
                {
                    // Realizar la acción de eliminación
                    try
                    {
                        productImpl = new ProductImpl();
                        int test = productImpl.Delete(product);
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
        private void getData()
        {
            if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                product = null;
                DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    productImpl = new ProductImpl();
                    product = productImpl.Get(id);

                    txbName.Text = product.Name;
                    txbDesc.Text = product.Description;
                    txbPrice.Text = product.Price.ToString();
                    txbStock.Text = product.Stock.ToString();

                    cbCateg.Text = categ;
                    cbSupplier.Text = suppl;
                }
                catch
                {
                    sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
                    diseable2();
                }
            }
        }

    }
}
