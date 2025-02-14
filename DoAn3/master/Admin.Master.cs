using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn3.master
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/User/User.aspx");
        }

        protected void lbtProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Product/Product.aspx");
        }

        protected void lblOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Order/Order.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Admin.aspx");
        }

        protected void lbtLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Session.Remove("userId");
            Session.Remove("name");
            Response.Redirect("../HomePage/Default.aspx");
        }
    }
    
}