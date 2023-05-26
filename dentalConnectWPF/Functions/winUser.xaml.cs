using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;
using dentalConnectDAO;
using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System.Net;
using System.Net.Mail;
using MaterialDesignThemes.Wpf;




namespace dentalConnectWPF.Functions
{
    /// <summary>
    /// Lógica de interacción para winUser.xaml
    /// </summary>
    public partial class winUser : Window
    {
        byte opt;
        dentalConnectDAO.Model.User user;
        UserImpl userImpl;

        string[] gender = { "Masculino", "Femenino" };
        string[] role = { "Administrador", "Gerente de ventas", "Gerente de inventario" };
        private readonly SnackbarMessageQueue _messageQueue;

        public winUser()
        {
            InitializeComponent();
            diseable();
            cbGender.ItemsSource = gender;
            cbRole.ItemsSource = role;

            Validations.TextCiU(txbCI);
            Validations.TextCiU1(txbCI);

            Validations.TextNameU(txbName);
            Validations.TextNameU1(txbName);

            Validations.TextNameU(txbLastName);
            Validations.TextNameU1(txbLastName);

            Validations.TextNameU(txbSecLastName);
            Validations.TextNameU1(txbSecLastName);

            Validations.TextEmailS(txbEmail);
            Validations.TextEmailS1(txbEmail);

            Validations.TextPhoneU(txbPhone);
            Validations.TextPhoneU1(txbPhone);

            _messageQueue = snackbar.MessageQueue;
            //Validations.TextIntputDate(dpBirthdate);
        }
        private void sendMessages(int opt, string message)
        {
            if (opt == 1)
                txtMessage.Foreground = Brushes.Red;

            else if (opt == 2)
                txtMessage.Foreground = Brushes.Green;

            txtMessage.Text = message;
        }
        private void enable()
        {
            btnInsert.IsEnabled = false;
            btnCancel.IsEnabled = true;
            btnSave.IsEnabled = true;

            txbCI.IsEnabled = true;
            txbName.IsEnabled = true;
            txbLastName.IsEnabled = true;
            txbSecLastName.IsEnabled = true;
            txbPhone.IsEnabled = true;
            txbEmail.IsEnabled = true;
            dpBirthdate.IsEnabled = true;
            cbGender.IsEnabled = true;
            cbRole.IsEnabled = true;

            txbCI.Focus();
        }
        private void diseable()
        {
            txbName.Text = "";
            txbPhone.Text = "";
            txbEmail.Text = "";
            txbLastName.Text = "";
            txbSecLastName.Text = "";
            txbCI.Text = "";
            dpBirthdate.SelectedDate = null;
            cbRole.SelectedItem = null;
            cbGender.SelectedItem = null;


            btnInsert.IsEnabled = true;
            btnCancel.IsEnabled = false;
            btnSave.IsEnabled = false;


            txbCI.IsEnabled = false;
            txbName.IsEnabled = false;
            txbLastName.IsEnabled = false;
            txbSecLastName.IsEnabled = false;
            txbPhone.IsEnabled = false;
            txbEmail.IsEnabled = false;
            dpBirthdate.IsEnabled = false;
            cbGender.IsEnabled = false;
            cbRole.IsEnabled = false;

        }
        private void clean()
        {
            txbName.Text = "";
            txbPhone.Text = "";
            txbEmail.Text = "";
            txbLastName.Text = "";
            txbSecLastName.Text = "";
            txbCI.Text = "";
            dpBirthdate.SelectedDate = null;
            cbRole.SelectedItem = null;
            cbGender.SelectedItem = null;
        }


        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = "";
            enable();
            dgDatos.SelectedItem = null;
            user = null;
            dgDatos.IsEnabled = false;
            clean();
            opt = 1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txbName.Text;
                string ci = txbCI.Text;
                string lastName = txbLastName.Text;
                string secondLastName = txbSecLastName.Text;
                DateTime dateTime = (DateTime)dpBirthdate.SelectedDate;
                string phone = txbPhone.Text;
                string email = txbEmail.Text;
                string role = cbRole.Text;
                char gender = ' ';
                string username = "";
                string password = "";
                switch (cbGender.Text)
                {
                    case "Masculino":
                        gender = 'M';
                        break;
                    case "Femenino":
                        gender = 'F';
                        break;
                }

                if(txbPhone.Text.Length != 8)
                {
                    sendMessages(1, "Debe ingresar un número de teléfono valido (8 números)");
                    return;
                }

                if(txbEmail.Text.Contains("@") == false)
                {
                    sendMessages(1, "La dirección EMAIL dede contener un @");
                    return;
                }


                if (verifyDate(dateTime))
                {
                    switch (opt)
                    {
                        case 1:
                            insertData(name, ci, lastName, secondLastName, dateTime, phone, email, role, gender, username, password);
                            break;
                        case 2:
                            updateData(name, ci, lastName, secondLastName, dateTime, phone, email, role, gender);
                            break;
                    }
                }
             


                dgDatos.IsEnabled = true;
                diseable();
            }
            catch
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
            }
        }

        private bool verifyDate(DateTime dateTime)
        {
            DateTime currentDate = DateTime.Now;

            TimeSpan duracion = currentDate.Subtract(dateTime);
            int diferenciaEnAnios = (int)(duracion.TotalDays / 365);


            if (diferenciaEnAnios >= 18 && diferenciaEnAnios <= 85)
            {

                return true;
            }
            else if (currentDate < dateTime)
            {
                sendMessages(1, "Debe ingresar una fecha valida");
            }
            else if (diferenciaEnAnios < 18)
            {
                sendMessages(1, "Debe ser mayor a 18 años");
            }
            else if (diferenciaEnAnios > 85)
            {
                sendMessages(1, "Debe ser menor a 85 años");
            }
            return false;
        }


        private void insertData(string name, string ci, string lastName, string secondLastName, DateTime date, string phone, string email, string role, char gender, string username, string password)
        {
            
            if (name == "" || ci == "" || lastName == "" || date == DateTime.MinValue || phone == "" || email == "" || role == "" || gender == ' ')
            {
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique que los campos no esten vacios");
                return;
            }
            userImpl = new UserImpl();

            username = GenerarNombreUnico(name, lastName, secondLastName);

            password = GenerarContrasenaAleatoria();


           QuerysImpl query = new QuerysImpl();

            int count = query.verifyEmail(email);
            if(count > 0)
            {
                sendMessages(1, "El EMAIL que ingreso ya existe en la Base de Datos");
                dgDatos.SelectedItem = null;
                user = null;
                return;
            }
            int count1 = query.verifyNumber(phone);
            if (count1 > 0)
            {
                sendMessages(1, "El NUMERO que ingreso ya existe en la Base de Datos");
                dgDatos.SelectedItem = null;
                user = null;
                return;
            }


            btnSave.IsEnabled= false;

            int band = sendEmail(email, username, password, name, lastName, role);

            if (band == 0)
            {
                sendMessages(1, "Error al enviar el correo electrónico: Verifique su correo o contacte al Administrador");
                return;
            }

            btnSave.IsEnabled = true;

            try
            {
                User user = new User(ci, name, lastName, secondLastName, date, gender, phone, email, username, password, role);

                userImpl = new UserImpl();
                int test = userImpl.Insert(user);


                if (test > 0)
                {
                    sendMessages(2, "Se inserto el registro con exito");
                    select();
                    diseable();
                }
            }
            catch(Exception ex)
            {
                
                sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
            }
            dgDatos.SelectedItem = null;
            user = null;
        }

   
        private void updateData(string name, string ci, string lastName, string secondLastName, DateTime date, string phone, string email, string role, char gender)
        {
            txtMessage.Text = "";
            try
            {
                if (name == "" || ci == "" || lastName == "" || date == DateTime.MinValue || phone == "" || email == "" || role == ""|| gender == ' ')
                {
                    sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                    return;
                }

                user.Name = name;
                user.Ci= ci;
                user.LastName= lastName;
                user.SecondLastName= secondLastName;
                user.Birthdate= date;
                user.Phone= phone;
                user.Email= email;
                user.Role= role;
                user.Gender=gender;


                QuerysImpl query = new QuerysImpl();

                int count = query.verifyEmailUpdate(email, user.Id);
                if (count > 0)
                {
                    MessageBox.Show(Session.SessionID + "");
                    sendMessages(1, "El EMAIL que ingreso ya existe en la Base de Datos");
                    dgDatos.SelectedItem = null;
                    user = null;
                    return;
                }
                int count1 = query.verifyNumberUpdate(phone, user.Id);
                if (count1 > 0)
                {
                    sendMessages(1, "El NÚMERO que ingreso ya existe en la Base de Datos");
                    dgDatos.SelectedItem = null;
                    user = null;
                    return;
                }



                userImpl = new UserImpl();
                int test = userImpl.Update(user);


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
            user = null;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            diseable();
            dgDatos.IsEnabled = true;

            getData();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            UserWindows.winMenu menu = new UserWindows.winMenu();
            menu.Show();
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            enable();

            if (dgDatos.SelectedItem != null && user != null)
            {

                Tools.winDelete confirmarVentana = new Tools.winDelete();
                confirmarVentana.Owner = this; // Establecer la ventana principal como propietaria
                bool? resultado = confirmarVentana.ShowDialog();

                if (resultado.HasValue && resultado.Value)
                {
                    // Realizar la acción de eliminación
                    try
                    {
                        userImpl = new UserImpl();
                        int test = userImpl.Delete(user);
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
           
            if (dgDatos.SelectedItem == null && user == null)
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
        private void select()
        {
            try
            {

                userImpl = new UserImpl();
                dgDatos.ItemsSource = null;
                dgDatos.ItemsSource = userImpl.Select().DefaultView;

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
        private void getData()
        {
            if (dgDatos.Items.Count > 0 && dgDatos.SelectedItem != null)
            {
                user = null;
                DataRowView dataRow = (DataRowView)dgDatos.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    userImpl = new UserImpl();
                    user = userImpl.Get(id);

                    txbName.Text = user.Name;
                    txbCI.Text = user.Ci;
                    txbLastName.Text = user.LastName;
                    txbSecLastName.Text = user.SecondLastName;
                    dpBirthdate.SelectedDate = user.Birthdate;
                    cbRole.Text = user.Role;
                    txbEmail.Text = user.Email;
                    txbPhone.Text = user.Phone;

                    string gender = "";
                    switch (user.Gender)
                    {
                        case 'M':
                            gender = "Masculino";
                            break;
                        case 'F':
                            gender = "Femenino";
                            break;
                    }
                    cbGender.Text = gender;

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex+"");
                    sendMessages(1, "No se pudo acceder a los datos, comuniquese con el Administrador");
                }
            }
        }



        public string GenerarNombreUnico(string nombre, string primerApellido, string segundoApellido)
        {
            Random random = new Random();
            char randomLetter = (char)random.Next('A', 'Z' + 1); // Genera una letra mayúscula aleatoria

            if (segundoApellido == "")
            { segundoApellido = randomLetter.ToString(); }

            string primerasLetras = $"{nombre.Substring(0, 1)}{primerApellido.Substring(0, 1)}{segundoApellido.Substring(0, 1)}";
            string nombreUnico = $"{primerasLetras}{new Random().Next(1000)}";
            return nombreUnico.ToUpper();
        }

        public string GenerarContrasenaAleatoria()
        {
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitudContrasena = 8;
            char[] contrasenaArray = new char[longitudContrasena];
            Random random = new Random();
            Regex regex = new Regex("[^a-zA-Z0-9]");

            for (int i = 0; i < longitudContrasena; i++)
            {
                char caracter = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];

                while (regex.IsMatch(caracter.ToString()))
                {
                    caracter = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
                }

                contrasenaArray[i] = caracter;
            }

            return new string(contrasenaArray);
        }

        public int sendEmail(string email, string username, string password, string nombre, string apellido, string rol)
        {
            try
            {
                // Configurar los detalles del correo electrónico
                string remitente = "contacto.codensa@gmail.com";
                string destinatario = email;
                string asunto = "ENVIO DE CREDENCIALES A: "+nombre+" "+apellido;
                string cuerpoMensaje = "Estas son sus credenciales para ingresar al sistema, tenga mucho cuidado y no las comparta con nadie.\n" +
                                        "\nUsted esta registrado como un: "+rol +
                                        "\n\nNombre de usuario: "+username+"\n" +
                                        "\nContraseña: "+password+"\n" +
                                        "\nRecuerde que debera cambiar su contraseña al ingresar al sistema por primera vez" +
                                        "\n\nCualquier duda por favor ponganse en contacto con el administrador";

                // Crear el objeto MailMessage
                MailMessage correo = new MailMessage(remitente, destinatario, asunto, cuerpoMensaje);

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient("smtp.gmail.com", 587);
                clienteSmtp.EnableSsl = true;
                clienteSmtp.UseDefaultCredentials = false;
                clienteSmtp.Credentials = new NetworkCredential("contacto.codensa@gmail.com", "wiabflozvurvzhhp");

                // Enviar el correo electrónico
                clienteSmtp.Send(correo);
                return 1;
            }
            catch 
            {
                return 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números y letras mayúsculas");
        }

        private void btn_help_name_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar letras mayúsculas y minúsculas");
        }

        private void btn_help_Lname_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar letras mayúsculas y minúsculas");
        }

        private void btn_help_SLname_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar letras mayúsculas y minúsculas");
        }

        private void btn_help_date_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se puede ingresar una edad entre 18-85 años");
        }

        private void btn_help_email_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo se pueden colocar números, puntos, @, letras mayúsculas y minúsculas");
        }

        private void btn_help_phone_Click(object sender, RoutedEventArgs e)
        {
            _messageQueue.Enqueue("Solo pueden colocar números, - ,  y un signo +");
        }

    
    }
}
