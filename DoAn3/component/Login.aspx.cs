using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.component
{
    public partial class Login : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
        }

        protected void lbtLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            if(email == "" || password == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Vui lòng nhập đầy đủ thông tin!');", true);
                return;
            }

            string sql = "select * from NGUOIDUNG Where email='" + email + "' and password='" + password + "'";
            DataTable dt = new DataTable();
            dt = connect.docDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Đăng nhập thành công!');", true);
                Session["email"] = email;
                Session["userId"] = dt.Rows[0]["Id"];
                Session["name"] = dt.Rows[0]["name"];

                if (dt.Rows[0]["typeUser"].ToString().Trim().Equals("R1"))
                {
                    Response.Redirect("../Admin/Admin.aspx");
                }
                else
                {
                    Response.Redirect("../HomePage/Default.aspx");
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Tên đăng nhập hoặc mật khẩu không chính xác!');", true);
            }
        }
    }
}