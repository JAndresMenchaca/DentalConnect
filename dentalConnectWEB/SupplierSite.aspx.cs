using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dentalConnectWEB
{
    public partial class SupplierSite : System.Web.UI.Page
    {
        Supplier supplier;
        SupplierImpl supplierImpl;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["SessionRole"] == null )
            {
                Response.Redirect("Default.aspx");
            }

            select();
            Button3.Visible = false;
            Button2.Visible = false;
            idLabel.Visible = false;
            idDiv.Visible = true;
            opt.Visible = false;

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
            phone.BackColor = Color.White;
            mail.BackColor = Color.White;
            sitio.BackColor = Color.White;
            calleP.BackColor = Color.White;
            calleS.BackColor = Color.White;
            ciudad.BackColor = Color.White;

            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0

            string itemValue = row.Cells[columnIndex].Text;

            supplier = null;


            // Obtener el valor del identificador de la fila seleccionada


            byte id = byte.Parse(itemValue);

            idLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7C9C90");

            idLabel.Text = id.ToString();




            try
            {
                supplierImpl = new SupplierImpl();
                supplier = supplierImpl.Get(id);
                name.Text = supplier.Name.Trim();
                phone.Text = supplier.Phone.Trim();
                mail.Text = supplier.Email.Trim();
                
                
                ciudad.SelectedIndex = supplier.IdCity;
                sitio.Text = supplier.Website.Trim();
                calleP.Text = supplier.MainStreet.Trim();
                calleS.Text = supplier.AdjacentStreet.Trim();
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
            phone.BackColor = Color.White;
            mail.BackColor = Color.White;
            sitio.BackColor = Color.White;
            calleP.BackColor = Color.White;
            calleS.BackColor = Color.White;
            ciudad.BackColor = Color.White;



            string itemValue = row.Cells[columnIndex].Text;

            byte id = byte.Parse(itemValue);
            idLabel.Text = id.ToString();

            supplierImpl = new SupplierImpl();
            supplier = supplierImpl.Get(id);
            name.Text = supplier.Name;
            phone.Text = supplier.Phone;
            mail.Text = supplier.Email;


            ciudad.SelectedIndex = supplier.IdCity - 1;
            sitio.Text = supplier.Website;
            calleP.Text = supplier.MainStreet;
            calleS.Text = supplier.AdjacentStreet;


            //opt.Visible = true;

            string script = @"<script type='text/javascript'>
                            $(document).ready(function() {
                                mostrarModalConfirmacion();
                            });
                          </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MostrarModalConfirmacion", script);

            Button1.Enabled = false;
        }

        void select()
        {
            try
            {
                supplierImpl = new SupplierImpl();
                gridData.DataSource = supplierImpl.Select().DefaultView;
                gridData.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                message.Text = "";
                string nameS = name.Text; 
                string phoneS = phone.Text; 
                string mailS = mail.Text;   
                string webS = sitio.Text;
                string streetPS = calleP.Text;
                string streetSS = calleS.Text;

                name.BackColor = Color.White;
                phone.BackColor = Color.White;
                mail.BackColor = Color.White;
                sitio.BackColor = Color.White;
                calleP.BackColor = Color.White;
                calleS.BackColor = Color.White;
                ciudad.BackColor = Color.White;

                if (string.IsNullOrEmpty(nameS))
                {
                    
                    sendMessages(2, "El campo de nombre no puede estar vacío");
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(phoneS))
                {
                    sendMessages(2, "El campo de teléfono no puede estar vacío");
                    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;

                }
                if (string.IsNullOrEmpty(mailS))
                {
                    sendMessages(2, "El campo de Email no puede estar vacío");
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(ciudad.Text))
                {
                    sendMessages(2, "El campo ciudad no puede estar vacío");
                    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(streetPS))
                {
                    sendMessages(2, "El campo de la calle principal no puede estar vacía");
                    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                QuerysImpl query = new QuerysImpl();

                int count = query.verifyNameSupplier(nameS);
                if (count > 0)
                {
                    sendMessages(2, "El NOMBRE DEL PROVEEDOR que ingreso ya existe en la Base de Datos");
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                bool isNameValid = ValidationsImpl.ValidateNameS(nameS);
                if (!isNameValid)
                {
                    sendMessages(2, "El NOMBRE no cumple con el formato válido, asegurese de que el nombre NO tenga números, caracteres especiales ni espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres (número de caracteres permitidos 0-50)");
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phoneS);
                if (!isPhoneValid || !ValidarTelefono(phoneS) || phoneS.Length<=7)
                {
                    sendMessages(2, "El teléfono no cumple con el formato válido, asegurese de que solo lleve números y/o signos '+'(siempre debe estar al inicio) o '-', debe contener minimo 8 números (número de caracteres permitidos 0-20)");
                    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                bool isEmailValid = ValidationsImpl.ValidateEmailS(mail.Text);
                if (!isEmailValid)
                {
                    sendMessages(2, "El Email no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.' o '@' (número de caracteres permitidos 0-30)");
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (ciudad.SelectedValue == null) 
                {
                    sendMessages(2, "Debe seleccionar una ciudad");
                    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isWebValid = ValidationsImpl.ValidateWebS(webS);
                if (!isWebValid)
                {
                    sendMessages(2, "El sitio web no cumple con el formato válido, asegurese de que solo SOLO lleve letras, números y/o signos '.' o '-' (número de caracteres permitidos 0-60)");
                    sitio.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isStreetPValid = ValidationsImpl.ValidateStreetS(streetPS);
                if (!isStreetPValid)
                {
                    sendMessages(2, "La calle principal no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)");
                    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isStreetAValid = ValidationsImpl.ValidateStreetS(streetSS);
                if (!isStreetAValid)
                {
                    sendMessages(2, "La calle adyacente no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)");
                    calleS.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }


                supplier = new Supplier(name.Text, phone.Text, mail.Text, sitio.Text, calleP.Text, calleS.Text, int.Parse(ciudad.SelectedValue));
                supplierImpl = new SupplierImpl();
                int n = supplierImpl.Insert(supplier);

                if (n > 0)
                {
                    select();
                    sendMessages(1,"Registro insertado con exito");
                    name.BackColor = Color.White;
                    phone.BackColor = Color.White;
                    mail.BackColor = Color.White;
                    sitio.BackColor = Color.White;
                    calleP.BackColor = Color.White;
                    calleS.BackColor = Color.White;
                    ciudad.BackColor = Color.White;
                    clean();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            message.Text = "";

            name.BackColor = Color.White;
            phone.BackColor = Color.White;
            mail.BackColor = Color.White;
            sitio.BackColor = Color.White;
            calleP.BackColor = Color.White;
            calleS.BackColor = Color.White;
            ciudad.BackColor = Color.White;

            try
            {

                string nameS = name.Text.Trim();
                string phoneS = phone.Text.Trim();
                string mailS = mail.Text.Trim();
                string webS = sitio.Text.Trim();
                string streetPS = calleP.Text.Trim();
                string streetSS = calleS.Text.Trim();

                if (string.IsNullOrEmpty(nameS))
                {
                    message.Text = "El nombre no puede estar vacío";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(phoneS))
                {
                    message.Text = "El teléfono no puede estar vacío";
                    message.CssClass = "error-message";
                    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(mailS))
                {
                    message.Text = "El Email no puede estar vacío";
                    message.CssClass = "error-message";
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(ciudad.Text))
                {
                    sendMessages(2, "El campo ciudad no puede estar vacío");
                    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(streetPS))
                {
                    message.Text = "La calle principal no puede estar vacía";
                    message.CssClass = "error-message";
                    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                bool isNameValid = ValidationsImpl.ValidateNameS(nameS);
                if (!isNameValid)
                {
                    message.Text = "El nombre no cumple con el formato válido, asegurese de que el nombre NO tenga números, caracteres especiales ni espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres (número de caracteres permitidos 0-50)";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phoneS);
                if (!isPhoneValid || !ValidarTelefono(phoneS) || phoneS.Length <= 7)
                {
                    message.Text = "El teléfono no cumple con el formato válido, asegurese de que solo lleve números y/o signos '+'(siempre debe estar al inicio) o '-', debe contener minimo 8 números (número de caracteres permitidos 0-20)";
                    message.CssClass = "error-message";
                    phone.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }


                bool isEmailValid = ValidationsImpl.ValidateEmailS(mailS);
                if (!isEmailValid)
                {
                    message.Text = "El Email no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.' o '@' (número de caracteres permitidos 0-30)";
                    message.CssClass = "error-message";
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (ciudad.SelectedValue == null)
                {
                    message.Text = "Debe seleccionar una ciudad";
                    message.CssClass = "error-message";
                    ciudad.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                }
                bool isWebValid = ValidationsImpl.ValidateWebS(webS);
                if (!isWebValid)
                {
                    message.Text = "El sitio web no cumple con el formato válido, asegurese de que solo SOLO lleve letras, números y/o signos '.' o '-' (número de caracteres permitidos 0-60)";
                    message.CssClass = "error-message";
                    sitio.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isStreetPValid = ValidationsImpl.ValidateStreetS(streetPS);
                if (!isStreetPValid)
                {
                    message.Text = "La calle principal no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)";
                    message.CssClass = "error-message";
                    calleP.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isStreetAValid = ValidationsImpl.ValidateStreetS(streetSS);
                if (!isStreetAValid)
                {
                    message.Text = "La calle adyacente no cumple con el formato válido, asegurese de que SOLO lleve letras, números y/o signos '.', '#', '/', '-' (número de caracteres permitidos 0-30)";
                    message.CssClass = "error-message";
                    calleS.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                Supplier supplier = new Supplier(name.Text, phone.Text, mail.Text, sitio.Text, calleP.Text, calleS.Text, int.Parse(ciudad.SelectedValue));

                supplier.Name = name.Text;
                supplier.Phone = phone.Text;
                supplier.Email = mail.Text;
                supplier.IdCity = int.Parse(ciudad.SelectedValue);
                supplier.Website = sitio.Text;
                supplier.MainStreet = calleP.Text;
                supplier.AdjacentStreet = calleS.Text;

                supplier.Id = byte.Parse(idLabel.Text);

                QuerysImpl query = new QuerysImpl();

                int count = query.verifyNameSupplierUpdate(nameS, supplier.Id);
                if (count > 0)
                {
                    message.Text = "El NOMBRE DEL PROVEEDOR que ingreso ya existe en la Base de Datos";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                //QuerysImpl query = new QuerysImpl();

                //int count = query.verifyNameCategoryUpdate(name, category.Id);
                //if (count > 0)
                //{
                //    sendMessages(1, "La CATEGORIA que ingreso ya existe en la Base de Datos");
                //    dgDatos.SelectedItem = null;
                //    //category = null;
                //    diseable2();
                //    return;
                //}

                //idLabel.Text = category.Id.ToString();
                supplierImpl = new SupplierImpl();
                int test = supplierImpl.Update(supplier);

                if (test > 0)
                {
                 
                    select();
                    clean();
                    message.Text = "";
                    sendMessages(1, "El registro se modifico con exito");
                    Button1.Visible = true;
                    Button3.Visible = false;
                    Button2.Visible = false;

                    name.BackColor = Color.White;
                    phone.BackColor = Color.White;
                    mail.BackColor = Color.White;
                    sitio.BackColor = Color.White;
                    calleP.BackColor = Color.White;
                    calleS.BackColor = Color.White;
                    ciudad.BackColor = Color.White;

                }

            }
            catch (Exception ex)
            {
                
            }
            //gridData.SelectedItem = null;
            supplier = null;

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;
            name.Text = "";
            phone.Text = "";
            mail.Text = "";
            sitio.Text = "";
            calleP.Text = "";
            calleS.Text = "";
            ciudad.Text = "";
            ciudad.SelectedValue = null;
            message.Text = "";

            name.BackColor = Color.White;
            phone.BackColor = Color.White;
            mail.BackColor = Color.White;
            sitio.BackColor = Color.White;
            calleP.BackColor = Color.White;
            calleS.BackColor = Color.White;
            ciudad.BackColor = Color.White;
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            byte id = byte.Parse(idLabel.Text);
            supplier = supplierImpl.Get(id);
            try
            {
                supplierImpl = new SupplierImpl();
                int test = supplierImpl.Delete(supplier);
                if (test > 0)
                {

                    select();
                    Button1.Enabled = true;
                    name.Text = "";
                    phone.Text = "";
                    mail.Text = "";
                    sitio.Text = "";
                    calleP.Text = "";
                    calleS.Text = "";
                    ciudad.Text = "";
                    ciudad.SelectedValue = null;
                    
                }
            }
            catch
            {

            }
        }
        protected void no_Click(object sender, EventArgs e)
        {
            idLabel.Visible = false;
            idLabel.Text = string.Empty;
        

            Button1.Visible = true;
            Button1.Enabled = true;
        }
        private void getData()
        {
            if (gridData.Items.Count > 0 && gridData.SelectedItem != null)
            {
                supplier = null;
                DataGridItem selectedItem = gridData.SelectedItem;

                // Obtener el valor del identificador de la fila seleccionada
                byte id = Convert.ToByte(selectedItem.Cells[0].Text);

                try
                {
                    supplierImpl = new SupplierImpl();
                    supplier = supplierImpl.Get(id);
                    name.Text = supplier.Name;
                    phone.Text = supplier.Phone;
                    mail.Text = supplier.Email;
                    ciudad.SelectedIndex = supplier.IdCity;
                    sitio.Text = supplier.Website;
                    calleP.Text = supplier.MainStreet;
                    calleS.Text = supplier.AdjacentStreet;
                }
                catch
                {

                }
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

        private void clean()
        {
            name.Text = "";
            phone.Text = "";
            mail.Text = "";
            sitio.Text = "";
            calleP.Text = "";
            calleS.Text = "";
            ciudad.Text = "";
            ciudad.SelectedValue = null;
        }
        private bool ValidarTelefono(string telefono)
        {
            // Expresión regular para validar el formato del número de teléfono
            string patron = @"^(\+[0-9]{7,})?[\d-]+$";

            // Verificar si el número de teléfono cumple con el formato
            bool esValido = Regex.IsMatch(telefono, patron);

            return esValido;
        }

    }
}