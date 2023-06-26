
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Documents;
using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;

namespace dentalConnectWEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Puedes realizar cualquier lógica adicional necesaria en el evento Page_Load si es necesario

            HttpContext.Current.Session["SessionID"] = null;
            HttpContext.Current.Session["SessionUserName"] = null;
            HttpContext.Current.Session["SessionRole"] = null;
            HttpContext.Current.Session["SessionChangePassword"] = null;
        }

        [WebMethod]
        public static string VerificarDatos(string username, string password)
        {

            try
            {
                UserImpl userImpl = new UserImpl();

                DataTable table = userImpl.Login(username, password);
                if (table.Rows.Count > 0)
                {
                    HttpContext.Current.Session["SessionID"] = int.Parse(table.Rows[0][0].ToString());
                    HttpContext.Current.Session["SessionUserName"] = table.Rows[0][1].ToString();
                    HttpContext.Current.Session["SessionRole"] = table.Rows[0][2].ToString();
                    HttpContext.Current.Session["SessionChangePassword"] = int.Parse(table.Rows[0][3].ToString());


                    
                    return table.Rows[0][2].ToString();
                }
                else
                {

                    return "";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}