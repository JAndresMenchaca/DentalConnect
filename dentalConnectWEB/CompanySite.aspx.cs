using dentalConnectDAO.Implementation;
using dentalConnectDAO.Interfaces;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace dentalConnectWEB
{
    public partial class CompanySite : System.Web.UI.Page
    {
        Company company;
        CompanyImpl companyImpl;

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    //QuerysImpl querys = new QuerysImpl();
        //    //person.DataSource = querys.comboPerson();
        //    //person.DataTextField = "Content";
        //    //person.DataValueField = "Tag";
        //    //person.DataBind();
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuerysImpl querys = new QuerysImpl();
                person.DataSource = querys.comboPerson();
                person.DataTextField = "Content";
                person.DataValueField = "Tag";
                person.DataBind();

            }


            select();
            Button3.Visible = false;
            Button2.Visible = false;
            idLabel.Visible = false;
            idDiv.Visible = true;
            opt.Visible = false;
            idContact.Visible = false;
        }
        protected int SelectedValue
        {
            get { return (int)(ViewState["SelectedValue"] ?? 0); }
            set { ViewState["SelectedValue"] = value; }
        }
        protected string lat1
        {
            get { return (string)(ViewState["lat1"] ?? 0); }
            set { ViewState["lat1"] = value; }
        }
        protected string lon1
        {
            get { return (string)(ViewState["lon1"] ?? 0); }
            set { ViewState["lon1"] = value; }
        }
        void select()
        {
            try
            {
                companyImpl = new CompanyImpl();
                gridData.DataSource = companyImpl.Select().DefaultView;
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

            nameC.BackColor = Color.White;
            nitC.BackColor = Color.White;
            phoneC.BackColor = Color.White;
            person.BackColor = Color.White;


            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0

            string itemValue = row.Cells[columnIndex].Text;
            string ci = row.Cells[4].Text;
            //sendMessages(2, "id: " + ci);
            company = null;


            // Obtener el valor del identificador de la fila seleccionada


            byte id = byte.Parse(itemValue);

            idLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7C9C90");

            idLabel.Text = id.ToString();

            try
            {
                companyImpl = new CompanyImpl();
                company = companyImpl.Get(id);

                nitC.Text = company.Nit.Trim();
                nameC.Text = company.BusinessName.Trim();
                phoneC.Text = company.Phone.ToString();

                Session["SelectedValue"] = company.ContactID;

                string tagValue = company.ContactID.ToString(); // Valor del Tag que deseas buscar

                ListItem item = person.Items.FindByValue(tagValue); // Buscar el elemento por valor

                if (item != null)
                {
                    searchInput.Text = item.Text; // Asignar el texto del elemento encontrado al TextBox
                }

                string latitudStr = company.Latitude.ToString().Replace(",", ".");

                string longitudStr = company.Longitude.ToString().Replace(",", ".");




                string script = string.Format(@"
                        var map;
                        var marker;

                        function initializeMap() {{
                            var myLatLng = {{ lat: {0}, lng: {1} }};
        
                            map = new google.maps.Map(document.getElementById('map'), {{
                                zoom: 10,
                                center: myLatLng
                            }});

                            marker = new google.maps.Marker({{
                                position: myLatLng,
                                map: map,
                                draggable: true // Permite arrastrar el marcador después de agregarlo
                            }});

                            // Evento para capturar la ubicación seleccionada al arrastrar el marcador
                            google.maps.event.addListener(marker, 'dragend', function (event) {{
                                var latitude = event.latLng.lat();
                                var longitude = event.latLng.lng();
                                console.log('Ubicación seleccionada - Latitud: ' + latitude + ', Longitud: ' + longitude);
                                sendCoordinates(latitude, longitude);
                            }});

                            // Evento para agregar un marcador al hacer doble clic en el mapa
                            google.maps.event.addListener(map, 'dblclick', function (event) {{
                                var latitude = event.latLng.lat();
                                var longitude = event.latLng.lng();
                                console.log('Ubicación seleccionada - Latitud: ' + latitude + ', Longitud: ' + longitude);
                                addMarker(event.latLng);
                                sendCoordinates(latitude, longitude);
                            }});
                        }}

                        function addMarker(location) {{
                            if (marker) {{
                                marker.setMap(null); // Elimina el marcador existente si lo hay
                            }}

                            marker = new google.maps.Marker({{
                                position: location,
                                map: map,
                                draggable: true // Permite arrastrar el marcador después de agregarlo
                            }});

                            // Evento para capturar la ubicación seleccionada al arrastrar el marcador
                            google.maps.event.addListener(marker, 'dragend', function (event) {{
                                var latitude = event.latLng.lat();
                                var longitude = event.latLng.lng();
                                console.log('Ubicación seleccionada - Latitud: ' + latitude + ', Longitud: ' + longitude);
                                sendCoordinates(latitude, longitude);
                            }});
                        }}

                        function sendCoordinates(latitude, longitude) {{
                            $.ajax({{
                                type: 'POST',
                                url: 'CompanySite.aspx/SetCoor',
                                data: JSON.stringify({{ lat1: latitude.toString(), lon1: longitude.toString() }}),
                                contentType: 'application/json; charset=utf-8',
                                dataType: 'json',
                                success: function (response) {{
                                    console.log('Valor seleccionado enviado al servidor: ' + latitude + ', ' + longitude);
                                }},
                                error: function (xhr, status, error) {{
                                    console.log('Error al enviar el valor seleccionado al servidor.  ' + xhr);
                                }}
                            }});
                        }}

                        // Llama a la función initializeMap cuando se haya cargado la biblioteca de Google Maps
                        google.maps.event.addDomListener(window, 'load', initializeMap);
                    ", latitudStr, longitudStr);

                // Registra el script para ser ejecutado en el lado del cliente
                ClientScript.RegisterStartupScript(this.GetType(), "CodigoJavaScript", script, true);


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

            nameC.BackColor = Color.White;
            nitC.BackColor = Color.White;
            phoneC.BackColor = Color.White;
            person.BackColor = Color.White;


            string script = @"<script type='text/javascript'>
                            $(document).ready(function() {
                                mostrarModalConfirmacion();
                            });
                          </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MostrarModalConfirmacion", script);


            string itemValue = row.Cells[columnIndex].Text;

            int id = byte.Parse(itemValue);
            idLabel.Text = id.ToString();

            companyImpl = new CompanyImpl();
            company = companyImpl.Get(id);


            nitC.Text = company.Nit.Trim();
            nameC.Text = company.BusinessName.Trim();
            phoneC.Text = company.Phone.Trim();
            //person.Text = company.ContactID.ToString(); //OJO


            //opt.Visible = true;

            Button1.Enabled = false;
            message.Text = "";
        }

        [System.Web.Services.WebMethod]
        public static void SetSelectedValue(int selectedValue)
        {
            // Guardar el valor seleccionado en una variable de estado de vista
            HttpContext.Current.Session["SelectedValue"] = selectedValue;

        }

        [System.Web.Services.WebMethod]
        public static void SetCoor(string lat1, string lon1)//, double lon1)
        {

            HttpContext.Current.Session["latitude"] =  lat1;
            HttpContext.Current.Session["longitude"] = lon1;

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                message.Text = "";
                string nit = nitC.Text;
                string name = nameC.Text;
                string phone = phoneC.Text;
                int person1;
                string latitudeString;
                string longitudString;
                double lat;
                double lon;

                if (Session["SelectedValue"] != null)
                {
                 person1 = (int)Session["SelectedValue"];
                }
                else
                {
                    sendMessages(2, "Debe seleccionar un CI de la base de datos");
                    searchInput.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                if (Session["longitude"] != null && Session["latitude"] != null)
                {
                    latitudeString = Session["latitude"].ToString();

                    double.TryParse(latitudeString, NumberStyles.AllowThousands | NumberStyles.Float, CultureInfo.InvariantCulture, out lat);

                    longitudString = Session["longitude"].ToString();

                    double.TryParse(longitudString, NumberStyles.AllowThousands | NumberStyles.Float, CultureInfo.InvariantCulture, out lon);
                }
                else
                {
                    sendMessages(2, "Debe seleccionar una ubicacion en el mapa");
                    return;
                }



                string personValue = person.Text.Trim();


                nameC.BackColor = Color.White;
                nitC.BackColor = Color.White;
                phoneC.BackColor = Color.White;
                searchInput.BackColor = Color.White;
                sendMessages(1, idContact.Text);

                #region verify
                if (string.IsNullOrEmpty(nit))
                {
                    sendMessages(2, "El campo de NIT no puede estar vacío");
                    nitC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;

                }
                if (string.IsNullOrEmpty(name))
                {

                    sendMessages(2, "El campo de nombre de empresa no puede estar vacío");
                    nameC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    sendMessages(2, "El campo de teléfono apellido no puede estar vacío");
                    phoneC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(personValue))
                {
                    sendMessages(2, "El campo de contacto no puede estar vacío");
                    person.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }


                bool isNITValid = ValidationsImpl.ValidateNitComp(nit);
                if (!isNITValid || nitC.Text.Length <= 7)
                {
                    sendMessages(2, "El NIT debe cumplir con el formato válido: solo números y letras mayúsculas, y/o signos '-'; debe contener al menos 8 números; longitud permitida de 0 a 30 caracteres");
                    nitC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isLNameValid = ValidationsImpl.ValidateNameComp(name);
                if (!isLNameValid)
                {
                    sendMessages(2, "El nombre de empresa debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres");
                    nameC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneComp(phone);
                if (!isPhoneValid || phoneC.Text.Length <= 7)
                {
                    sendMessages(2, "El teléfono debe cumplir con el formato válido: solo números y/o signos '+' (siempre al inicio) o '-'; debe contener al menos 8 números; longitud permitida de 0 a 20 caracteres");
                    phoneC.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isContactValid = ValidationsImpl.ValidateContactComp(person1.ToString());
                if (!isContactValid)
                {
                    sendMessages(2, "El contacto no existe");
                    person.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                
                #endregion

                company = new Company(nit, name, phone, lat, lon, person1);

                companyImpl = new CompanyImpl();


                companyImpl.Insert(company, (int)HttpContext.Current.Session["SessionID"]);



                select();
                sendMessages(1, "Registro insertado con exito");

                nameC.Text = "";
                nitC.Text = "";
                phoneC.Text = "";
                person.Text = null;
                person.SelectedValue = null;
                Session["SelectedValue"] = null;
                Session["longitude"] = null;
                Session["latitude"] = null;
                //nameC.BackColor = Color.White;
                //nitC.BackColor = Color.White;
                //phoneC.BackColor = Color.White;
                //person.BackColor = Color.White;


            }
            catch (Exception ex)
            {
                sendMessages(2, "id: "+ ex);
                
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            message.Text = "";

            nameC.BackColor = Color.White;
            nitC.BackColor = Color.White;
            phoneC.BackColor = Color.White;
            searchInput.BackColor = Color.White;

            

            string nit = nitC.Text.Trim();
            string name = nameC.Text.Trim();
            string phone = phoneC.Text.Trim();
            int person1;
            if (Session["SelectedValue"] != null)
            {
                person1 = (int)Session["SelectedValue"];
            }
            else
            {
                sendMessages(2, "Debe seleccionar un CI de la base de datos");
                searchInput.BackColor = ColorTranslator.FromHtml("#f76262");
                return;
            }
            string latitudeString;
            string longitudString;

            double lat, lon;

            if (Session["longitude"] != null && Session["latitude"] != null)
            {
                latitudeString = Session["latitude"].ToString();

                double.TryParse(latitudeString, NumberStyles.AllowThousands | NumberStyles.Float, CultureInfo.InvariantCulture, out lat);

                longitudString = Session["longitude"].ToString();

                double.TryParse(longitudString, NumberStyles.AllowThousands | NumberStyles.Float, CultureInfo.InvariantCulture, out lon);
            }
            else
            {
                sendMessages(2, "Debe seleccionar una ubicacion en el mapa");
                return;
            }


            try
            {
                #region validaciones

                int id = byte.Parse(idLabel.Text);

                if (string.IsNullOrEmpty(nit))
                {
                    message.Text = "El campo de NIT no puede estar vacío";
                    message.CssClass = "error-message";
                    nitC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(name))
                {
                    message.Text = "El campo de nombre de empresa no puede estar vacío";
                    message.CssClass = "error-message";
                    nameC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    message.Text = "El campo de teléfono apellido no puede estar vacío";
                    message.CssClass = "error-message";
                    phoneC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(person.SelectedValue))
                {
                    message.Text = "El campo de contacto no puede estar vacío";
                    message.CssClass = "error-message";
                    person.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }



                bool isCIValid = ValidationsImpl.ValidateCiC(nit);
                if (!isCIValid || nitC.Text.Length <= 7)
                {
                    message.Text = "El NIT debe cumplir con el formato válido: solo números y letras mayúsculas, y/o signos '-'; debe contener al menos 8 números; longitud permitida de 0 a 30 caracteres";
                    message.CssClass = "error-message";
                    nitC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isNameValid = ValidationsImpl.ValidateNameS(name);
                if (!isNameValid)
                {
                    message.Text = "El nombre de empresa debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    nameC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phone);
                if (!isPhoneValid || phoneC.Text.Length <= 7)
                {
                    message.Text = "El teléfono debe cumplir con el formato válido: solo números y/o signos '+' (siempre al inicio) o '-'; debe contener al menos 8 números; longitud permitida de 0 a 20 caracteres";
                    message.CssClass = "error-message";
                    phoneC.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isContactValid = ValidationsImpl.ValidateContactComp(person1.ToString());
                if (!isContactValid)
                {
                    message.Text = "El contacto no existe";
                    message.CssClass = "error-message";
                    person.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }



                #endregion

                company = new Company(nit, name, phone, lat, lon, person1);

                company.Id = id;
                company.Nit = nit;
                company.BusinessName = name;
                company.Phone = phone;
                company.Longitude = lon;
                company.Latitude = lat;
                company.ContactID = (int)Session["SelectedValue"]; //OJO

                idLabel.Text = company.Id.ToString();

                companyImpl = new CompanyImpl();
                companyImpl.Update(company, (int)HttpContext.Current.Session["SessionID"]);

                select();
                //clean();
                message.Text = "";
                sendMessages(1, "El registro se modifico con exito");
                Button1.Visible = true;
                Button3.Visible = false;
                Button2.Visible = false;


                nameC.Text = "";
                nitC.Text = "";
                phoneC.Text = "";
                person.SelectedValue = null;
                searchInput.Text = string.Empty;

                nameC.BackColor = Color.White;
                nitC.BackColor = Color.White;
                phoneC.BackColor = Color.White;
                person.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                sendMessages(2, ex + "");
            }
            //gridData.SelectedItem = null;
            company = null;
            Session["SelectedValue"] = null;
            



        }
        protected void Button3_Click(object sender, EventArgs e)
        {


            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;

            message.Text = "";
            nameC.Text = "";
            nitC.Text = "";
            phoneC.Text = "";
            searchInput.Text = string.Empty;

            person.SelectedValue = null;
            Session["SelectedValue"] = null;
            nameC.BackColor = Color.White;
            nitC.BackColor = Color.White;
            phoneC.BackColor = Color.White;
            searchInput.BackColor = Color.White;
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idLabel.Text);
            company = companyImpl.Get(id);

            try
            {
                companyImpl = new CompanyImpl();
                int test = companyImpl.Delete(company, (int)HttpContext.Current.Session["SessionID"]);
                sendMessages(1, "Registro Eliminado");
                if (test > 0)
                {

                    select();


                    Button1.Enabled = true;
                    nameC.Text = "";
                    nitC.Text = "";
                    phoneC.Text = "";
                    person.SelectedValue = null;
                    Session["SelectedValue"] = null;
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

            message.Text = "";
            nameC.Text = "";
            nitC.Text = "";
            phoneC.Text = "";
            person.SelectedValue = null;
            Session["SelectedValue"] = null;
            Button1.Visible = true;
            Button1.Enabled = true;
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
    }
}