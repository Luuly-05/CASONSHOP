using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn3.master
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            txtSearch.Attributes.Add("placeholder", "Tìm kiếm sản phẩm");
            string userId = Session["userId"] + "";
            string name = Session["name"] + "";
            if (userId == "")
            {
                plhNoLogin.Visible = true;
                plhLogin.Visible = false;
            } else
            {
                plhNoLogin.Visible = false;
                plhLogin.Visible = true;
                lblUserName.Text = name;
            }
        }

        protected void lblRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("/component/Register.aspx");
        }

        protected void lblLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/component/Login.aspx");
        }

        protected void lbtCart_Click(object sender, EventArgs e)
        {
            string userId = Session["userId"] + "";
            if(userId == "")
            {
                return;
            }
            Response.Redirect("/component/Cart.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/HomePage/Default.aspx");
        }

        protected void handleSearch(object sender, EventArgs e)
        {
            string valueSearch = txtSearch.Text;
            Response.Redirect("/HomePage/Search.aspx?valueSearch=" + valueSearch);
        }

        protected void handleDetailUser(object sender, EventArgs e)
        {
            string userId = Session["userId"] + "";
            Response.Redirect("/component/DetailUser.aspx?userId=" + userId);
        }

        protected void handleCancelSearch(object sender, EventArgs e)
        {
            Response.Redirect("/HomePage/Default.aspx");
        }
        
    }
}