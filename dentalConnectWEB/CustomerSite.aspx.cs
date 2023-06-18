using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dentalConnectWEB
{
    public partial class CustomerSite : System.Web.UI.Page
    {
        Person person;
        Customer customer;
        CustomerImpl customerImpl;
        protected void Page_Load(object sender, EventArgs e)
        {
            select();
            Button3.Visible = false;
            Button2.Visible = false;
            idLabel.Visible = false;
            idDiv.Visible = true;
            opt.Visible = false;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                message.Text = "";
                string fName = name.Text;
                string ci = ci1.Text;
                string lName = a1.Text;
                string slName = a2.Text;
                string fechaText = fecha.Text;
                DateTime birthDate;
                char gender = char.Parse(sex.Text);
                string mailS = mail.Text;
                string phone = phone1.Text;
                string nit = nit1.Text;
                string bn = bn1.Text;
                string br = br1.Text;
                string shipping = shipping1.Text;

                if (DateTime.TryParse(fechaText, out birthDate))
                {
                    // La fecha se ha convertido correctamente a un objeto DateTime
                    // Ahora puedes usar la variable birthDate
                }
                else
                {
                    // La cadena de fecha no tiene el formato correcto
                    // Maneja el escenario de error aquí
                }

                name.BackColor = Color.White;
                
                mail.BackColor = Color.White;
                

                //if (string.IsNullOrEmpty(nameS))
                //{

                //    sendMessages(2, "El campo de nombre no puede estar vacío");
                //    name.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //if (string.IsNullOrEmpty(phoneS))
                //{
                //    sendMessages(2, "El campo de teléfono no puede estar vacío");
                //    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;

                //}
                //if (string.IsNullOrEmpty(mailS))
                //{
                //    sendMessages(2, "El campo de Email no puede estar vacío");
                //    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //if (string.IsNullOrEmpty(ciudad.Text))
                //{
                //    sendMessages(2, "El campo ciudad no puede estar vacío");
                //    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //if (string.IsNullOrEmpty(streetPS))
                //{
                //    sendMessages(2, "El campo de la calle principal no puede estar vacía");
                //    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}

                QuerysImpl query = new QuerysImpl();

                //int count = query.verifyNameSupplier(nameS);
                //if (count > 0)
                //{
                //    sendMessages(2, "El NOMBRE DEL PROVEEDOR que ingreso ya existe en la Base de Datos");
                //    name.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}

                //bool isNameValid = ValidationsImpl.ValidateNameS(nameS);
                //if (!isNameValid)
                //{
                //    sendMessages(2, "El NOMBRE no cumple con el formato válido, asegurese de que el nombre NO tenga números, caracteres especiales ni espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres (número de caracteres permitidos 0-50)");
                //    name.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phoneS);
                //if (!isPhoneValid || !ValidarTelefono(phoneS) || phoneS.Length <= 7)
                //{
                //    sendMessages(2, "El teléfono no cumple con el formato válido, asegurese de que solo lleve números y/o signos '+'(siempre debe estar al inicio) o '-', debe contener minimo 8 números (número de caracteres permitidos 0-20)");
                //    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}

                //bool isEmailValid = ValidationsImpl.ValidateEmailS(mail.Text);
                //if (!isEmailValid)
                //{
                //    sendMessages(2, "El Email no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.' o '@' (número de caracteres permitidos 0-30)");
                //    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //if (ciudad.SelectedValue == null)
                //{
                //    sendMessages(2, "Debe seleccionar una ciudad");
                //    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //bool isWebValid = ValidationsImpl.ValidateWebS(webS);
                //if (!isWebValid)
                //{
                //    sendMessages(2, "El sitio web no cumple con el formato válido, asegurese de que solo SOLO lleve letras, números y/o signos '.' o '-' (número de caracteres permitidos 0-60)");
                //    sitio.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //bool isStreetPValid = ValidationsImpl.ValidateStreetS(streetPS);
                //if (!isStreetPValid)
                //{
                //    sendMessages(2, "La calle principal no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)");
                //    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}
                //bool isStreetAValid = ValidationsImpl.ValidateStreetS(streetSS);
                //if (!isStreetAValid)
                //{
                //    sendMessages(2, "La calle adyacente no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)");
                //    calleS.BackColor = ColorTranslator.FromHtml("#f76262");
                //    return;
                //}

                person = new Person(ci, fName, lName, slName, birthDate, gender, phone, mailS);
                customer = new Customer(nit, bn, br, shipping);
                customerImpl = new CustomerImpl();
                customerImpl.Insertar(person, customer);

                
                    select();
                    sendMessages(1, "Registro insertado con exito");
                    //name.BackColor = Color.White;
                    //phone.BackColor = Color.White;
                    //mail.BackColor = Color.White;
                    //sitio.BackColor = Color.White;
                    //calleP.BackColor = Color.White;
                    //calleS.BackColor = Color.White;
                    //ciudad.BackColor = Color.White;
                    //clean();
                


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {


        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void yes_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idLabel.Text);
            customer = customerImpl.Get(id);
            
            try
            {
                customerImpl = new CustomerImpl();
                int test = customerImpl.Delete(id);
                sendMessages(1, id + "");
                if (test > 0)
                {
                    
                    select();

                    Button1.Enabled = true;
                    name.Text = "";
                    
                    mail.Text = "";




                }
            }
            catch
            {
                
            }
        }
        public void sendMessages(int opc, string mess)
        {
            switch (opc)
            {
                case 1:
                    message.Text = mess;
                    message.CssClass = "succes-message";
                    break;
                case 2:
                    message.Text = mess;
                    message.CssClass = "error-message";
                    return;
                    break;
            }
        }
        protected void no_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            idLabel.Text = string.Empty;


            Button1.Visible = true;
            Button1.Enabled = true;
        }
        void select()
        {
            try
            {
                customerImpl = new CustomerImpl();
                gridData.DataSource = customerImpl.Select().DefaultView;
                gridData.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void gridData_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.Cells[0].Visible = false;
            }
            else if (e.Item.ItemType == ListItemType.Header)
            {
                e.Item.Cells[0].Visible = false;
            }
        }

        protected void gridData_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                // Crear una nueva celda para el encabezado del botón de editar
                TableCell editarHeaderCell = new TableCell();
                editarHeaderCell.Text = "Editar";

                // Crear una nueva celda para el encabezado del botón de eliminar
                TableCell eliminarHeaderCell = new TableCell();
                eliminarHeaderCell.Text = "Eliminar";

                // Agregar las nuevas celdas al encabezado
                e.Item.Cells.Add(editarHeaderCell);
                e.Item.Cells.Add(eliminarHeaderCell);
            }
            else if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Crear una nueva celda para el botón de editar
                TableCell editarCell = new TableCell();
                Button editarButton = new Button();
                editarButton.Text = "✏️";
                editarButton.CommandName = "Editar";
                editarButton.CommandArgument = e.Item.ItemIndex.ToString();
                editarButton.Click += EditarButton_Click;
                editarButton.CssClass = "btn btn-primary";
                editarButton.ID = "edit";
                editarButton.Font.Size = new FontUnit(20, UnitType.Pixel);
                editarButton.Width = new Unit(55, UnitType.Pixel);

                editarCell.CssClass = "text-center";
                editarCell.Controls.Add(editarButton);

                // Crear una nueva celda para el botón de eliminar
                TableCell eliminarCell = new TableCell();
                Button eliminarButton = new Button();
                eliminarButton.Text = "🗑"; // Utilizar "&times;" para representar el símbolo de eliminación
                eliminarButton.CommandName = "Eliminar";
                editarButton.ID = "elim";
                eliminarButton.CommandArgument = e.Item.ItemIndex.ToString();
                eliminarButton.Click += EliminarButton_Click;
                eliminarButton.CssClass = "btn btn-danger";
                eliminarButton.Font.Size = new FontUnit(25, UnitType.Pixel);
                eliminarButton.Width = new Unit(60, UnitType.Pixel);
                eliminarButton.Height = new Unit(50, UnitType.Pixel);
                eliminarCell.Controls.Add(eliminarButton);

                // Agregar las nuevas celdas a la fila de datos
                e.Item.Cells.Add(editarCell);
                e.Item.Cells.Add(eliminarCell);
            }
        }

        protected void EditarButton_Click(object sender, EventArgs e)
        {
            message.Text = "";
            Button1.Visible = false;
            Button3.Visible = true;
            Button2.Visible = true;

            name.BackColor = Color.White;
            
            mail.BackColor = Color.White;



            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0

            string itemValue = row.Cells[columnIndex].Text;

            customer = null;


            // Obtener el valor del identificador de la fila seleccionada


            byte id = byte.Parse(itemValue);

            idLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7C9C90");

            idLabel.Text = id.ToString();




            try
            {
                customerImpl = new CustomerImpl();
                customer = customerImpl.Get(id);
                name.Text = customer.Name.Trim();
                
                mail.Text = customer.Email.Trim();


                //ciudad.SelectedIndex = customer.IdCity;
                //sitio.Text = customer.Website.Trim();
                //calleP.Text = supplier.MainStreet.Trim();
                //calleS.Text = supplier.AdjacentStreet.Trim();
            }
            catch
            {

            }


        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            message.Text = "";
            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0

            name.BackColor = Color.White;
            
            mail.BackColor = Color.White;





            string itemValue = row.Cells[columnIndex].Text;

            int id = byte.Parse(itemValue);
            idLabel.Text = id.ToString();

            customerImpl = new CustomerImpl();
            customer = customerImpl.Get(id);

            name.Text = customer.Name;
            ci1.Text = customer.Ci;
            a1.Text = customer.LastName;
            a2.Text = customer.SecondLastName;
            fecha.Text = customer.Birthdate.ToString();
            nit1.Text = customer.Nit;
            
            sex.Text = customer.Gender.ToString();
            mail.Text = customer.Email;
            phone1.Text = customer.Phone.ToString();
            bn1.Text = customer.businessName.ToString();
            br1.Text = customer.businessReason.ToString();
            shipping1.Text = customer.shippingAddress.ToString();



            //sitio.Text = supplier.Website;
            //calleP.Text = supplier.MainStreet;
            //calleS.Text = supplier.AdjacentStreet;


            opt.Visible = true;

            Button1.Enabled = false;
        }
    }
}