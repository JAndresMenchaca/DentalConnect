using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dentalConnectWEB
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["SessionRole"] != null && HttpContext.Current.Session["SessionRole"].ToString() == "Administrador")
            {
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        }
    }
}