using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace DoAn3.component
{
    public partial class Register : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
        }

        public bool IsPhoneNumber(string number)
        {
            // This pattern matches exactly 10 digits
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(number, pattern);
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
            if (!IsPhoneNumber(phoneNumber))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Số điện thoại không đúng định dạng!');", true);
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
            if (dt.Rows.Count > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Email đã tồn tại!');", true);
                return;
            }


            if (password.Equals(confirmPassword) == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Mật khẩu không trùng khớp!');", true);
                return;
            }

            if (password.Length < 8 || password.Length > 16 ||
                 !password.Any(char.IsUpper) ||                // ít nhất một ký tự viết hoa
                !password.Any(char.IsDigit) ||                // ít nhất một số
                password.Intersect("!@#$%^&*()".ToCharArray()).Count() == 0)  // ít nhất một ký tự đặc biệt
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Mật khẩu tối thiểu từ 8 đến tối đa là 16 ký tự, phải chứa một ký tự đặc biệt, ít nhất một ký tự viết hoa và có một số!');", true);
                return;
            }

            string sqlCreateUser = "insert into NGUOIDUNG values('" + email + "', '" + password + "', N'" + name + "', N'" +
                    address + "', '" + phoneNumber + "', '" + typeUser + "', '" + dateOfBirth + "')";

            int result = connect.capNhat(sqlCreateUser);
            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Đăng ký thành công!');", true);
                txtEmail.Text = "";
                txtName.Text = "";
                txtPassword.Text = "";
                txtComfirmPassword.Text = "";
                txtAddress.Text = "";
                txtPhoneNumber.Text = "";
                txtDate.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Đăng ký thất bại!');", true);
            }

            string sqlKiemTraPhoneNumber = "SELECT * FROM NGUOIDUNG WHERE phoneNumber='" + phoneNumber + "'";
            DataTable dtPhoneNumber = connect.docDuLieu(sqlKiemTraPhoneNumber);
            if (dtPhoneNumber.Rows.Count > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Số điện thoại đã tồn tại!');", true);
                return;
            }
        }
    }
}