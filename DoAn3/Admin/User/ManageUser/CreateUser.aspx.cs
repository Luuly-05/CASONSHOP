using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

namespace DoAn3.Admin.User.ManageUser
{
    public partial class CreateUser : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
        }

       

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string name = txtName.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtComfirmPassword.Text;
            string address = txtAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string typeUser = "R2";

            if (email == "" || name == "" || password == "" || confirmPassword == "" || address == "" || phoneNumber == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Dữ liệu bạn nhập chưa đầy đủ!');", true);
                return;
            }

            if (txtDate.Text == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Bạn chưa nhập ngày sinh!');", true);
                return;
            }
            DateTime dateOfBirth = Convert.ToDateTime(txtDate.Text.Trim());

           

            if (IsValid(email) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Email không đúng định dạng!');", true);
                return;
            }


            string sqlKiemTra = "select * from NGUOIDUNG where email='" + email + "'";
            DataTable dt = new DataTable();
            dt = connect.docDuLieu(sqlKiemTra);
            if(dt.Rows.Count > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Email đã tồn tại!');", true);
                return;
            }


            if(password.Equals(confirmPassword) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Mật khẩu không trùng khớp!');", true);
                return;
            }

            string sqlCreateUser = "insert into NGUOIDUNG values('" + email + "', '" + password + "', N'" + name + "', N'" +
                    address + "', '" + phoneNumber + "', '" + typeUser + "', '" + dateOfBirth + "')";

            int result = connect.capNhat(sqlCreateUser);
            if(result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Bạn đã thêm người dùng thành công!');", true);
                txtEmail.Text = "";
                txtName.Text = "";
                txtPassword.Text = "";
                txtComfirmPassword.Text = "";
                txtAddress.Text = "";
                txtPhoneNumber.Text = "";
                txtDate.Text = "";
            }else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Thêm người dùng thất bại!');", true);
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