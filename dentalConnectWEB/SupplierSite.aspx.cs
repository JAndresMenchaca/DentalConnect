using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Button1.Visible = false;
            Button3.Visible = true;
            Button2.Visible = true;

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
                name.Text = supplier.Name;
                phone.Text = supplier.Phone;
                mail.Text = supplier.Email;
                
                
                ciudad.SelectedIndex = supplier.IdCity-1;
                sitio.Text = supplier.Website;
                calleP.Text = supplier.MainStreet;
                calleS.Text = supplier.AdjacentStreet;
            }
            catch
            {

            }


        }
        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Button btnEditar = (Button)sender;
            DataGridItem row = (DataGridItem)btnEditar.NamingContainer;
            int columnIndex = 0; // Índice de la columna 0



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


            opt.Visible = true;
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
                supplier = new Supplier(name.Text, phone.Text, mail.Text, sitio.Text, calleP.Text, calleS.Text, int.Parse(ciudad.SelectedValue));
                supplierImpl = new SupplierImpl();
                int n = supplierImpl.Insert(supplier);

                if (n > 0)
                {
                    select();
                }

                name.Text = "";
                phone.Text = "";
                mail.Text = "";
                sitio.Text = "";
                calleP.Text = "";
                calleS.Text = "";
                ciudad.Text = "";
                ciudad.SelectedValue = null;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            Button3.Visible = false;
            Button2.Visible = false;


            try
            {
                //if (name == "")
                //{
                //    sendMessages(1, "Hubo un error al INSERTAR el registro, verifique los datos");
                //    diseable2();
                //    return;
                //}


                Supplier supplier = new Supplier(name.Text, phone.Text, mail.Text, sitio.Text, calleP.Text, calleS.Text, int.Parse(ciudad.SelectedValue));

                supplier.Name = name.Text;
                supplier.Phone = phone.Text;
                supplier.Email = mail.Text;
                supplier.IdCity = int.Parse(ciudad.SelectedValue);
                supplier.Website = sitio.Text;
                supplier.MainStreet = calleP.Text;
                supplier.AdjacentStreet = calleS.Text;

                supplier.Id = byte.Parse(idLabel.Text);


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
                    //    sendMessages(2, "Se modifico el registro con exito");
                    select();
                    //    diseable();
                }
            }
            catch
            {
                //sendMessages(1, "Hubo un error al MODIFICAR el registro, contacte al administrador");
                //diseable2();
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
    }
}