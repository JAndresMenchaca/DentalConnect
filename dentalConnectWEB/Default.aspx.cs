using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dentalConnectDAO.Model;
using dentalConnectDAO.Implementation;

namespace dentalConnectWEB
{
    public partial class Default : System.Web.UI.Page
    {
        Category category;
        CategoryImpl categoryImpl;
        protected void Page_Load(object sender, EventArgs e)
        {
            select();
        }
        protected void gridData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
            else if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                category = new Category(TextBox1.Text, TextBox2.Text);
                categoryImpl = new CategoryImpl();
                int n = categoryImpl.Insert(category);

                if(n>0) { 
                    select();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}