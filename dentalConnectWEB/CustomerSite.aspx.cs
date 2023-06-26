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
using System.Text.RegularExpressions;

namespace dentalConnectWEB
{
    public partial class CustomerSite : System.Web.UI.Page
    {
        Person person;
        Customer customer;
        CustomerImpl customerImpl;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["SessionRole"] == null)
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
                ci1.BackColor = Color.White;
                a1.BackColor = Color.White;
                a2.BackColor = Color.White;
                fecha.BackColor = Color.White;
                mail.BackColor = Color.White;
                phone1.BackColor = Color.White;
                nit1.BackColor = Color.White;
                bn1.BackColor = Color.White;
                br1.BackColor = Color.White;
                shipping1.BackColor = Color.White;

                if (string.IsNullOrEmpty(ci))
                {
                    sendMessages(2, "El campo de CI no puede estar vacío");
                    ci1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;

                }
                if (string.IsNullOrEmpty(fName))
                {

                    sendMessages(2, "El campo de nombre no puede estar vacío");
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(lName))
                {
                    sendMessages(2, "El campo de 1er apellido no puede estar vacío");
                    a1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(fechaText))
                {
                    sendMessages(2, "El campo de fecha no puede estar vacío");
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(gender.ToString()))
                {
                    sendMessages(2, "El campo de genero no puede estar vacío");
                    sex.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(mailS))
                {
                    sendMessages(2, "El campo de Email no puede estar vacío");
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    sendMessages(2, "El campo de teléfono no puede estar vacío");
                    phone1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(nit))
                {
                    sendMessages(2, "El campo de NIT no puede estar vacío");
                    nit1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(bn))
                {
                    sendMessages(2, "El campo de nombre de empresa no puede estar vacío");
                    bn1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(br))
                {
                    sendMessages(2, "El campo de razón social no puede estar vacío");
                    br1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (string.IsNullOrEmpty(shipping))
                {
                    sendMessages(2, "El campo de dirección no puede estar vacío");
                    shipping1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                QuerysImpl query = new QuerysImpl();


                bool isCIValid = ValidationsImpl.ValidateCiC(ci);
                if (!isCIValid || ci1.Text.Length <= 7)
                {
                    sendMessages(2, "El CI debe cumplir con el formato válido: solo números y letras mayúsculas, y/o signos '-'; debe contener al menos 8 números; longitud permitida de 0 a 30 caracteres");
                    ci1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }


                QuerysImpl querysImpl = new QuerysImpl();

                int cont5 = querysImpl.verifyCiUser2(ci);

                if (cont5 > 0)
                {
                    sendMessages(2, "El CI que ingreso ya existe en la Base de Datos");
                    ci1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }


                bool isNameValid = ValidationsImpl.ValidateNameC(fName);
                if (!isNameValid)
                {
                    sendMessages(2, "El nombre debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres");
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isLNameValid = ValidationsImpl.ValidateNameC(lName);
                if (!isLNameValid)
                {
                    sendMessages(2, "El 1er apellido debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres");
                    a1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isSLNameValid = ValidationsImpl.ValidateNameC(slName);
                if (!isSLNameValid)
                {
                    sendMessages(2, "El 2do apellido debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres");
                    a2.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                if (fecha == null)
                {
                    sendMessages(2, "Debe seleccionar una fecha");
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                if (DateTime.TryParse(fechaText, out birthDate))
                {
                    DateTime currentDate = DateTime.Now;
                    DateTime minDate = currentDate.AddYears(-85); // Minimum date allowed (85 years ago)
                    DateTime maxDate = currentDate.AddYears(-18); // Maximum date allowed (18 years ago)

                    if (birthDate > currentDate)
                    {
                        // Selected date is in the future
                        sendMessages(2, "No se puede seleccionar una fecha futura");
                        fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                        return;
                    }

                    if (birthDate < minDate || birthDate > maxDate)
                    {
                        // Selected date is outside the allowed range
                        sendMessages(2, "La edad debe ser entre 18 y 85 años");
                        fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                        return;
                    }
                }
                else
                {
                    // Handle invalid date format
                    sendMessages(2, "El campo de fecha tiene un formato inválido");
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                bool isEmailValid = ValidationsImpl.ValidateEmailS(mailS);
                if (!isEmailValid)
                {
                    sendMessages(2, "El Email debe cumplir con el formato válido: solo letras, números y/o los signos '.' o '@'; longitud permitida de 0 a 30 caracteres");
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phone);
                if (!isPhoneValid || phone1.Text.Length <= 7)
                {
                    sendMessages(2, "El teléfono debe cumplir con el formato válido: solo números y/o signos '+' (siempre al inicio) o '-'; debe contener al menos 8 números; longitud permitida de 0 a 20 caracteres");
                    phone1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                bool isNITValid = ValidationsImpl.ValidateSpecificNit(nit);
                if (!isNITValid)
                {
                    sendMessages(2, "El NIT debe tener el formato válido: XXXX-XXXXXX-XXX-X, donde X representa un dígito del 0 al 9");
                    nit1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isBNValid = ValidationsImpl.ValidateNombreEmpresa(bn);
                if (!isBNValid)
                {
                    sendMessages(2, "El nombre de la empresa Debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres");
                    bn1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isBRValid = ValidationsImpl.ValidateRazonSocial(br);
                if (!isBRValid)
                {
                    sendMessages(2, "La razón social Debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 70 caracteres");
                    br1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                bool isStreetAValid = ValidationsImpl.ValidateStreetS(shipping);
                if (!isStreetAValid)
                {
                    sendMessages(2, "La dirección debe cumplir con el formato válido: solo letras, números y/o los signos '.', '#', '/', '-'; longitud permitida de 0 a 30 caracteres");
                    shipping1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                person = new Person(ci, fName, lName, slName, birthDate, gender, phone, mailS);
                customer = new Customer(nit, bn, br, shipping);
                customerImpl = new CustomerImpl();
                customerImpl.Insertar(person, customer, (int)HttpContext.Current.Session["SessionID"]);



                select();
                sendMessages(1, "Registro insertado con exito");

                name.Text = "";
                ci1.Text = "";
                a1.Text = "";
                a2.Text = "";
                fecha.Text = "";
                sex.SelectedValue = null;
                mail.Text = "";
                phone1.Text = "";
                nit1.Text = "";
                bn1.Text = "";
                br1.Text = "";
                shipping1.Text = "";

                name.BackColor = Color.White;
                ci1.BackColor = Color.White;
                a1.BackColor = Color.White;
                a2.BackColor = Color.White;
                fecha.BackColor = Color.White;
                mail.BackColor = Color.White;
                phone1.BackColor = Color.White;
                nit1.BackColor = Color.White;
                bn1.BackColor = Color.White;
                br1.BackColor = Color.White;
                shipping1.BackColor = Color.White;


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
            ci1.BackColor = Color.White;
            a1.BackColor = Color.White;
            a2.BackColor = Color.White;
            fecha.BackColor = Color.White;
            mail.BackColor = Color.White;
            phone1.BackColor = Color.White;
            nit1.BackColor = Color.White;
            bn1.BackColor = Color.White;
            br1.BackColor = Color.White;
            shipping1.BackColor = Color.White;

            string fName = name.Text.Trim();
            string ci = ci1.Text.Trim();
            string lName = a1.Text.Trim();
            string slName = a2.Text.Trim();
            string fechaText = fecha.Text;
            DateTime birthDate;
            char gender = char.Parse(sex.Text);
            string mailS = mail.Text.Trim();
            string phone = phone1.Text.Trim();
            string nit = nit1.Text.Trim();
            string bn = bn1.Text.Trim();
            string br = br1.Text.Trim();
            string shipping = shipping1.Text.Trim();
            int id = byte.Parse(idLabel.Text);

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

            try
            {
                #region validaciones
                //string nameS = name.Text.Trim();
                //string phoneS = phone.Text.Trim();
                //string mailS = mail.Text.Trim();
                //string webS = sitio.Text.Trim();
                //string streetPS = calleP.Text.Trim();
                //string streetSS = calleS.Text.Trim();

                if (string.IsNullOrEmpty(ci))
                {
                    message.Text = "El CI no puede estar vacío";
                    message.CssClass = "error-message";
                    ci1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(fName))
                {
                    message.Text = "El nombre no puede estar vacío";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(lName))
                {
                    message.Text = "El 1er apellido no puede estar vacío";
                    message.CssClass = "error-message";
                    a1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(fechaText))
                {
                    message.Text = "La fecha de nacimiento no puede estar vacía";
                    message.CssClass = "error-message";
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                if (DateTime.TryParse(fechaText, out birthDate))
                {
                    DateTime currentDate = DateTime.Now;
                    DateTime minDate = currentDate.AddYears(-85); // Minimum date allowed (85 years ago)
                    DateTime maxDate = currentDate.AddYears(-18); // Maximum date allowed (18 years ago)

                    if (birthDate > currentDate)
                    {
                        // Selected date is in the future
                        sendMessages(2, "No se puede seleccionar una fecha futura");
                        fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                        Button1.Visible = false;
                        Button2.Visible = true;
                        Button3.Visible = true;
                        return;
                    }

                    if (birthDate < minDate || birthDate > maxDate)
                    {
                        // Selected date is outside the allowed range
                        sendMessages(2, "La edad debe ser entre 18 y 85 años");
                        fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                        Button1.Visible = false;
                        Button2.Visible = true;
                        Button3.Visible = true;
                        return;
                    }
                }
                else
                {
                    // Handle invalid date format
                    sendMessages(2, "El campo de fecha tiene un formato inválido");
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
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
                if (string.IsNullOrEmpty(phone))
                {
                    message.Text = "El campo de teléfono no puede estar vacío";
                    message.CssClass = "error-message";
                    phone1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(nit))
                {
                    message.Text = "El campo de NIT no puede estar vacío";
                    message.CssClass = "error-message";
                    nit1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(bn))
                {
                    message.Text = "El campo de nombre de empresa no puede estar vacío";
                    message.CssClass = "error-message";
                    bn1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(br))
                {
                    message.Text = "El campo de razón social no puede estar vacío";
                    message.CssClass = "error-message";
                    br1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (string.IsNullOrEmpty(shipping))
                {
                    message.Text = "El campo de dirección no puede estar vacío";
                    message.CssClass = "error-message";
                    shipping1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }



                bool isNameValid = ValidationsImpl.ValidateNameS(fName);
                if (!isNameValid)
                {
                    message.Text = "El nombre debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isPhoneValid = ValidationsImpl.ValidatePhoneS(phone);
                if (!isPhoneValid || !ValidarTelefono(phone) || phone.Length <= 7)
                {
                    message.Text = "El teléfono debe cumplir con el formato válido: solo números y/o signos '+' (siempre al inicio) o '-'; debe contener al menos 8 números; longitud permitida de 0 a 20 caracteres";
                    message.CssClass = "error-message";
                    phone1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }


                bool isCIValid = ValidationsImpl.ValidateCiC(ci);
                if (!isCIValid || ci1.Text.Length <= 7)
                {
                    message.Text = "El CI debe cumplir con el formato válido: solo números y letras mayúsculas, y/o signos '-'; debe contener al menos 8 números; longitud permitida de 0 a 30 caracteres";
                    message.CssClass = "error-message";
                    ci1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }


                bool isFNameValid = ValidationsImpl.ValidateNameC(fName);
                if (!isFNameValid)
                {
                    message.Text = "El nombre debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    name.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isLNameValid = ValidationsImpl.ValidateNameC(lName);
                if (!isLNameValid)
                {
                    message.Text = "El 1er apellido debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    a1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isSLNameValid = ValidationsImpl.ValidateNameC(slName);
                if (!isSLNameValid)
                {
                    message.Text = "El 2do apellido debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    a2.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                if (fecha == null)
                {
                    message.Text = "Debe seleccionar una fecha";
                    message.CssClass = "error-message";
                    fecha.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isEmailValid = ValidationsImpl.ValidateEmailS(mailS);
                if (!isEmailValid)
                {
                    message.Text = "El Email debe cumplir con el formato válido: solo letras, números y/o los signos '.' o '@'; longitud permitida de 0 a 30 caracteres";
                    message.CssClass = "error-message";
                    mail.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isphoneValid = ValidationsImpl.ValidatePhoneS(phone);
                if (!isphoneValid || phone1.Text.Length <= 7)
                {
                    message.Text = "El teléfono debe cumplir con el formato válido: solo números y/o signos '+' (siempre al inicio) o '-'; debe contener al menos 8 números; longitud permitida de 0 a 20 caracteres";
                    message.CssClass = "error-message";
                    phone1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isNITValid = ValidationsImpl.ValidateSpecificNit(nit);
                if (!isNITValid)
                {
                    message.Text = "El NIT debe tener el formato válido: XXXX-XXXXXX-XXX-X, donde X representa un dígito del 0 al 9";
                    message.CssClass = "error-message";
                    nit1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isBNValid = ValidationsImpl.ValidateNombreEmpresa(bn);
                if (!isBNValid)
                {
                    message.Text = "El nombre de la empresa Debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 50 caracteres";
                    message.CssClass = "error-message";
                    bn1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isBRValid = ValidationsImpl.ValidateRazonSocial(br);
                if (!isBRValid)
                {
                    message.Text = "La razón social Debe cumplir con el formato válido: sin números, caracteres especiales ni espacios al inicio o final; solo un espacio entre dos caracteres; longitud permitida de 0 a 70 caracteres";
                    message.CssClass = "error-message";
                    br1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                bool isStreetAValid = ValidationsImpl.ValidateStreetS(shipping);
                if (!isStreetAValid)
                {
                    message.Text = "La dirección debe cumplir con el formato válido: solo letras, números y / o los signos '.', '#', '/', '-'; longitud permitida de 0 a 30 caracteres";
                    message.CssClass = "error-message";
                    shipping1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }
                #endregion
                person = new Person(ci, fName, lName, slName, birthDate, gender, phone, mailS);
                customer = new Customer(nit, bn, br, shipping);
                person.Id = id;
                person.Ci = ci;
                person.Name = fName;
                person.LastName = lName;
                person.SecondLastName = slName;
                person.Birthdate = birthDate;
                person.Gender = gender;
                person.Phone = phone;
                person.Email = mailS;
                customer.Nit = nit;
                customer.businessName = bn;
                customer.businessReason = br;
                customer.shippingAddress = shipping;
                sendMessages(2, person.Id + "...");
                QuerysImpl query = new QuerysImpl();

                //int count = query.verifyNameSupplierUpdate(nameS, supplier.Id);
                //if (count > 0)
                //{
                //    message.Text = "El NOMBRE DEL PROVEEDOR que ingreso ya existe en la Base de Datos";
                //    message.CssClass = "error-message";
                //    name.BackColor = ColorTranslator.FromHtml("#f76262");
                //    Button1.Visible = false;
                //    Button2.Visible = true;
                //    Button3.Visible = true;
                //    return;
                //}

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
                customerImpl = new CustomerImpl();
                customerImpl.Update(customer, person, (int)HttpContext.Current.Session["SessionID"]);

                select();
                //clean();
                message.Text = "";
                sendMessages(1, "El registro se modifico con exito");
                Button1.Visible = true;
                Button3.Visible = false;
                Button2.Visible = false;


                name.Text = "";
                ci1.Text = "";
                a1.Text = "";
                a2.Text = "";
                fecha.Text = "";
                sex.SelectedValue = null;
                mail.Text = "";
                phone1.Text = "";
                nit1.Text = "";
                bn1.Text = "";
                br1.Text = "";
                shipping1.Text = "";

                name.BackColor = Color.White;
                ci1.BackColor = Color.White;
                a1.BackColor = Color.White;
                a2.BackColor = Color.White;
                fecha.BackColor = Color.White;
                mail.BackColor = Color.White;
                phone1.BackColor = Color.White;
                nit1.BackColor = Color.White;
                bn1.BackColor = Color.White;
                br1.BackColor = Color.White;
                shipping1.BackColor = Color.White;

            }
            catch (Exception ex)
            {
                sendMessages(2, ex + "");
            }
            //gridData.SelectedItem = null;
            customer = null;

        }
        protected void Button3_Click(object sender, EventArgs e)
        {


            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;

            message.Text = "";
            name.Text = "";
            ci1.Text = "";
            a1.Text = "";
            a2.Text = "";
            fecha.Text = "";
            sex.SelectedValue = null;
            mail.Text = "";
            phone1.Text = "";
            nit1.Text = "";
            bn1.Text = "";
            br1.Text = "";
            shipping1.Text = "";

            name.BackColor = Color.White;
            ci1.BackColor = Color.White;
            a1.BackColor = Color.White;
            a2.BackColor = Color.White;
            fecha.BackColor = Color.White;
            mail.BackColor = Color.White;
            phone1.BackColor = Color.White;
            nit1.BackColor = Color.White;
            bn1.BackColor = Color.White;
            br1.BackColor = Color.White;
            shipping1.BackColor = Color.White;
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            int id = int.Parse(idLabel.Text);
            customer = customerImpl.Get(id);

            try
            {
                customerImpl = new CustomerImpl();
                int test = customerImpl.Delete(customer, (int)HttpContext.Current.Session["SessionID"]);
                sendMessages(1, "Registro Eliminado");
                if (test > 0)
                {

                    select();


                    Button1.Enabled = true;
                    name.Text = "";
                    ci1.Text = "";
                    a1.Text = "";
                    a2.Text = "";
                    fecha.Text = "";
                    sex.SelectedValue = null;
                    mail.Text = "";
                    phone1.Text = "";
                    nit1.Text = "";
                    bn1.Text = "";
                    br1.Text = "";
                    shipping1.Text = "";
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

            message.Text = "";
            name.Text = "";
            ci1.Text = "";
            a1.Text = "";
            a2.Text = "";
            fecha.Text = "";
            sex.SelectedValue = null;
            mail.Text = "";
            phone1.Text = "";
            nit1.Text = "";
            bn1.Text = "";
            br1.Text = "";
            shipping1.Text = "";
            fecha.Text = string.Empty;

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
            ci1.BackColor = Color.White;
            a1.BackColor = Color.White;
            a2.BackColor = Color.White;
            fecha.BackColor = Color.White;
            mail.BackColor = Color.White;
            phone1.BackColor = Color.White;
            nit1.BackColor = Color.White;
            bn1.BackColor = Color.White;
            br1.BackColor = Color.White;
            shipping1.BackColor = Color.White;


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
                ci1.Text = customer.Ci.ToString();
                a1.Text = customer.LastName.Trim();
                a2.Text = customer.SecondLastName.Trim();
                phone1.Text = customer.Phone.Trim();
                br1.Text = customer.businessReason.Trim();
                bn1.Text = customer.businessReason.ToString();

                fecha.Text = customer.Birthdate.ToString("yyyy-MM-dd");

                mail.Text = customer.Email.Trim();
                sex.Text = customer.Gender.ToString();
                shipping1.Text = customer.shippingAddress.Trim();
                nit1.Text = customer.Nit.ToString();



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
            ci1.BackColor = Color.White;
            a1.BackColor = Color.White;
            a2.BackColor = Color.White;
            fecha.BackColor = Color.White;
            mail.BackColor = Color.White;
            phone1.BackColor = Color.White;
            nit1.BackColor = Color.White;
            bn1.BackColor = Color.White;
            br1.BackColor = Color.White;
            shipping1.BackColor = Color.White;


            string script = @"<script type='text/javascript'>
                            $(document).ready(function() {
                                mostrarModalConfirmacion();
                            });
                          </script>";

            Page.ClientScript.RegisterStartupScript(this.GetType(), "MostrarModalConfirmacion", script);


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


            //opt.Visible = true;

            Button1.Enabled = false;
            message.Text = "";
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