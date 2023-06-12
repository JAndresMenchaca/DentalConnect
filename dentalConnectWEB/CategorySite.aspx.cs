using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dentalConnectDAO.Model;
using dentalConnectDAO.Implementation;
using System.Data;
using System.Xml.Linq;
using System.Web.Services.Description;
using System.Drawing;
using System.Reflection.Emit;
using Microsoft.SqlServer.Server;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace dentalConnectWEB
{
    public partial class CategorySite : System.Web.UI.Page
    {
        Category category;
        CategoryImpl categoryImpl;


        protected void Page_Load(object sender, EventArgs e)
        {
            select();
            Button3.Visible = false;
            Button2.Visible = false;
            idLabel.Visible = false;
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

            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0

            string itemValue = row.Cells[columnIndex].Text;

            category = null;


            // Obtener el valor del identificador de la fila seleccionada


            byte id = byte.Parse(itemValue);

            idLabel.ForeColor = System.Drawing.ColorTranslator.FromHtml("#7C9C90");

            idLabel.Text = id.ToString();




            try
            {
                categoryImpl = new CategoryImpl();
                category = categoryImpl.Get(id);
                TextBox1.Text = category.Name;
                TextBox2.Text = category.Description;
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

            string itemValue = row.Cells[columnIndex].Text;

            byte id = byte.Parse(itemValue);
            idLabel.Text = id.ToString();

            opt.Visible = true;

            // Bloquear el botón Button1
            Button1.Enabled = false;
        }

        void select()
        {
            try
            {
                categoryImpl = new CategoryImpl();
                gridData.DataSource = categoryImpl.Select().DefaultView;
                gridData.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.BackColor = Color.White;
            TextBox1.BackColor = Color.White;

            try
            {
                message.Text = "";
                string name = TextBox1.Text;
                string description = TextBox2.Text;

                if (string.IsNullOrEmpty(name))
                {
                    // El nombre está vacío, mostrar un mensaje de error
                    sendMessages(2, "El nombre no puede estar vacío");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                // Validar el nombre utilizando la expresión regular
                bool isNameValid = ValidationsImpl.ValidateName(name);
                if (!isNameValid)
                {
                    // El nombre no cumple con el patrón de la expresión regular, mostrar un mensaje de error
                    // y detener el proceso de inserción
                    // Puedes utilizar un control de mensajes como un Label o mostrar una alerta en JavaScript
                    // Aquí se muestra un ejemplo utilizando un Label llamado "errorLabel"
                    sendMessages(2, "El nombre no cumple con el formato válido, asegurese de que el nombre de la categoria NO tenga números, caracteres especiales ni espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres(número de carcateres permitidos 0 - 50)");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }
                QuerysImpl query = new QuerysImpl();

                int count = query.verifyNameCategory(name);
                if (count > 0)
                {
                    sendMessages(2, "La CATEGORIA que ingreso ya existe en la Base de Datos");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }


                // Validar la descripción utilizando la expresión regular
                bool isDescriptionValid = ValidationsImpl.ValidateDescription(description);
                if (!isDescriptionValid)
                {
                    // La descripción no cumple con el patrón de la expresión regular, mostrar un mensaje de error
                    // y detener el proceso de inserción
                    sendMessages(2, "La descripción no cumple con el formato válido, asegurese de que no hayan espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres (número de caracteres permitidos 0-80)");
                    TextBox2.BackColor = ColorTranslator.FromHtml("#f76262");
                    return;
                }

                // Si el nombre y la descripción son válidos, continuar con el proceso de inserción
                category = new Category(name, description);
                categoryImpl = new CategoryImpl();
                int n = categoryImpl.Insert(category);

                if (n > 0)
                {
                    select();
                    message.Text = "";

                    TextBox2.BackColor = Color.White;
                    TextBox1.BackColor = Color.White;
                }

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            message.Text = "";
            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;

            TextBox2.BackColor = Color.White;
            TextBox1.BackColor = Color.White;

            try
            {
                string name = TextBox1.Text.Trim();
                string description = TextBox2.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    // El nombre está vacío, mostrar un mensaje de error
                    sendMessages(2, "El nombre no puede estar vacío");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible= false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }


                     

                // Validar el nombre utilizando la expresión regular
                bool isNameValid = ValidationsImpl.ValidateName(name);
                if (!isNameValid)
                {
                    // El nombre no cumple con el patrón de la expresión regular, mostrar un mensaje de error
                    // y detener el proceso de modificación

                    sendMessages(2, "El nombre no cumple con el formato válido, asegurese de que el nombre de la categoria NO tenga números, caracteres especiales ni espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres(número de carcateres permitidos 0 - 50)");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                // Validar la descripción utilizando la expresión regular
                bool isDescriptionValid = ValidationsImpl.ValidateDescription(description);
                if (!isDescriptionValid)
                {
                    // La descripción no cumple con el patrón de la expresión regular, mostrar un mensaje de error
                    // y detener el proceso de modificación
                    sendMessages(2, "La descripción no cumple con el formato válido, asegurese de que no hayan espacios al principio y final además de que solo puede haber un espacio entre 2 caracteres (número de caracteres permitidos 0-80)");
                    TextBox2.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                // Obtener el ID de la categoría a modificar
                byte id = byte.Parse(idLabel.Text);


                // Crear un objeto Category con los nuevos valores
                Category category = new Category(name, description);
                category.Id = id;


                QuerysImpl query = new QuerysImpl();

                int count = query.verifyNameCategoryUpdate(name, category.Id);
                if (count > 0)
                {
                    sendMessages(2, "La CATEGORIA que ingreso ya existe en la Base de Datos");
                    TextBox1.BackColor = ColorTranslator.FromHtml("#f76262");
                    Button1.Visible = false;
                    Button2.Visible = true;
                    Button3.Visible = true;
                    return;
                }

                categoryImpl = new CategoryImpl();
                int test = categoryImpl.Update(category);

                if (test > 0)
                {
                    select();
                    message.Text = "";
                    sendMessages(1, "El registro se modifico con exito");

                    TextBox2.BackColor = Color.White;
                    TextBox1.BackColor = Color.White;
                }

                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            catch (Exception ex)
            {

            }

            category = null;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            message.Text = "";
            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;
            TextBox1.Text = "";
            TextBox2.Text = "";

            TextBox2.BackColor = Color.White;
            TextBox1.BackColor = Color.White;
        }

        protected void yes_Click(object sender, EventArgs e)
        {
            byte id = byte.Parse(idLabel.Text);
            category = categoryImpl.Get(id);
            try
            {
                categoryImpl = new CategoryImpl();
                int test = categoryImpl.Delete(category);
                if (test > 0)
                {
                    select();
                    Button1.Enabled = true;
                    TextBox1.Text = "";
                    TextBox2.Text = "";
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

            // Desbloquear el botón Button1
            Button1.Visible = true;
            Button1.Enabled = true;
        }
        private void getData()
        {
            if (gridData.Items.Count > 0 && gridData.SelectedItem != null)
            {
                category = null;
                DataGridItem selectedItem = gridData.SelectedItem;

                // Obtener el valor del identificador de la fila seleccionada
                byte id = Convert.ToByte(selectedItem.Cells[0].Text);

                try
                {
                    categoryImpl = new CategoryImpl();
                    category = categoryImpl.Get(id);
                    TextBox1.Text = category.Name;
                    TextBox2.Text = category.Description;
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
                    break;
            }
        }

    }
}