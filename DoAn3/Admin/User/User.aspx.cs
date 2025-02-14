using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoAn3.Admin.Product
{
    public partial class User : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUsersFromDataBase();
            }
        }

        public void getUsersFromDataBase()
        {
            string sql = "select * from NGUOIDUNG";
            grvUser.DataSource = connect.docDuLieu(sql);
            grvUser.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageUser/CreateUser.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int usedId = Int32.Parse(((LinkButton)sender).CommandArgument);
            Response.Redirect("ManageUser/UpdateUser.aspx?userId=" + usedId);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(((LinkButton)sender).CommandArgument);
            string sqlDelete = "delete from NGUOIDUNG where Id=" + id;
            int result = connect.capNhat(sqlDelete);
            if (result > 0)
            {
                getUsersFromDataBase();
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Xóa người dùng thành công!');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Xóa người dùng thất bại!');", true);
            }
        }
    }
}