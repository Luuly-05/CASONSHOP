using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn3.master
{
    public partial class Login : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtLogoLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage/Default.aspx");
        }

        protected void lblRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/component/Register.aspx");
        }

        protected void lblLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/component/Login.aspx");
        }
    }
}