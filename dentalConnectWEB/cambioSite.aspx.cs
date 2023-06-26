using dentalConnectDAO.Implementation;
using dentalConnectDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace dentalConnectWEB
{
    public partial class cambioSite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["SessionRole"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                UserImpl userImpl = new UserImpl();

                DataTable table = userImpl.Login(HttpContext.Current.Session["SessionUserName"].ToString(), oldP.Text);
                
                if (table.Rows.Count > 0)
                {

                    if (Regex.IsMatch(p1.Text, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@#$%_*^&+=?-]).{8,}$"))
                    {
                        if (p1.Text == p2.Text)
                        {
                            userImpl.changeWEB(p1.Text, (int)HttpContext.Current.Session["SessionID"]);
                            //MessageBox.Show(""+pbNew.Password);
                            sendMessages(1, "Se actualizo la contraseña");
                            //MessageBox.Show(Session.SessionID + "");
                            //Session.SessionRole = "";
                            userImpl.changePassword();
                            //this.Close();
                        }
                        else
                        {
                            //pbOriginal.Password = "";
                            //pbNew.Password = "";
                            //pbNew2.Password = "";
                            //pbOriginal.Focus();
                            sendMessages(2, "Las contraseñas no coinciden");
                            p1.Text = "";
                            p2.Text = "";
                        }
                    }
                    else
                    {

                        sendMessages(2, "Contraseña inválida. Debe tener al menos 8 caracteres\nUna letra mayúscula, un número y un carácter especial.");
                        p1.Text = "";
                        p2.Text = "";
                    }

                }
                else
                {
                    sendMessages(2, "Contraseña anterior incorrecta");
                    oldP.Text = "";
                }

            }
            catch (Exception ex)
            {
               

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            oldP.Text = "";
            p1.Text = "";
            p2.Text = "";
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