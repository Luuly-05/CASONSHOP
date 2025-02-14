using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DoAn3.component
{
    public partial class DetailUser : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            int id;
            if (int.TryParse(Request.QueryString["userId"] + "", out id));
            string sql = "select * from NGUOIDUNG WHERE Id=" + id;

            DataTable dt = connect.docDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                txtEmail.Text = dt.Rows[0][1] + "";
                txtPassword.Attributes["value"] = dt.Rows[0][2] + "";
                txtName.Text = dt.Rows[0][3] + "";
                txtAddress.Text = dt.Rows[0][4] + "";
                txtPhoneNumber.Text = dt.Rows[0][5] + "";
                txtDate.Text = dt.Rows[0][5] + "";
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
        public bool IsPhoneNumber(string number)
        {
            // This pattern matches exactly 10 digits
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(number, pattern);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string phoneNumber = txtPhoneNumber.Text;
            if (IsValid(email) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Email không đúng định dạng!');", true);
                return;
            }

            int userId = Int32.Parse(Request.QueryString["userId"]);
            if(txtDate.Text == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Ngày sinh không được để trống!');", true);
                return;
            }
            
            if (!IsPhoneNumber(phoneNumber))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Số điện thoại không đúng định dạng!');", true);
                return;
            }
            DateTime dateOfBirth = Convert.ToDateTime(txtDate.Text);
            string sqlUpdate = "update NGUOIDUNG set email='" + email + "', password='" +
                txtPassword.Text + "', name='" + txtName.Text + "', address='" + txtAddress.Text
                + "', phoneNumber='" + txtPhoneNumber.Text + "', typeUser='R2', DateOfBirth='" + dateOfBirth + "' WHERE Id=" + userId;

            int result = connect.capNhat(sqlUpdate);

            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Bạn đã cập nhật thành công!');", true);
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Cập nhật thất bại!');", true);
            }
        }

        protected void lbtDangXuat_Click(object sender, EventArgs e)
        {
            Session.Remove("email");
            Session.Remove("userId");
            Session.Remove("name");
            Response.Redirect("../HomePage/Default.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage/Default.aspx");
        }
    }
}