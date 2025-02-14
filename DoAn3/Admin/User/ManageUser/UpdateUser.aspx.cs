using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;


namespace DoAn3.Admin.User.ManageUser
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            int id = Int32.Parse(Request.QueryString["userId"]);

            string sql = "select * from NGUOIDUNG WHERE Id=" + id;

            DataTable dt = connect.docDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                txtEmail.Text = dt.Rows[0][1] + "";
                txtPassword.Attributes["value"] = dt.Rows[0][2] + "";
                txtName.Text = dt.Rows[0][3] + "";
                txtAddress.Text = dt.Rows[0][4] + "";
                txtPhoneNumber.Text = dt.Rows[0][5] + "";
            }

        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (IsValid(email) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Email không đúng định dạng!');", true);
                return;
            }

            int userId = Int32.Parse(Request.QueryString["userId"]);
            if (txtDate.Text == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Ngày sinh bạn đang trống!');", true);
                return;
            }

            DateTime dateOfBirth = Convert.ToDateTime(txtDate.Text);
            string sqlUpdate = "update NGUOIDUNG set email='" + email + "', password='" +
                txtPassword.Text + "', name=N'" + txtName.Text + "', address=N'" + txtAddress.Text
                + "', phoneNumber='" + txtPhoneNumber.Text + "', typeUser='R2', DateOfBirth='" + dateOfBirth + "' WHERE Id=" + userId;

            int result = connect.capNhat(sqlUpdate);

            if(result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Bạn đã cập nhật thành công!');", true);
                Response.Redirect("../User.aspx");
            }else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Cập nhật thất bại!');", true);
            }
        }

        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}