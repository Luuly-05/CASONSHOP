using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.Admin.Product.ManageProduct
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sqlGetTypeProduct = "select * from TypeProduct";
                DataTable dt = new DataTable();
                dt = connect.docDuLieu(sqlGetTypeProduct);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ddlTypeProduct.Items.Add(new ListItem(dt.Rows[i]["value"] + "" + "-" + dt.Rows[i]["typeProduct"] + ""));
                    }
                }
            }
        }

        protected void btnCreateProduct_Click(object sender, EventArgs e)
        {
            string name = txtTen.Text;
            string description = txtMota.Text;

            if (IsProductNameExist(name))
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert3", "Error('Tên sản phẩm đã tồn tại!');", true);
                return;
            }

            double price = 0;
            bool isPrice = double.TryParse(txtGia.Text, out price);
            if (isPrice == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Giá phải là một số!');", true);
                return;
            }

            if (price <= 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert2", "Error('Giá phải là một số dương!');", true);
                return;
            }

            int quanlity = 0;
            bool isQuanlity = int.TryParse(txtSoLuong.Text, out quanlity);
            if (isQuanlity == false)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Số lượng phải là một con số!');", true);
                return;
            }

            if (quanlity <= 0 )
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert2", "Error('Số lượng phải là một số dương!');", true);
                return;
            }

            if (uploadImage.FileContent.Length > 0)
            {
                if (uploadImage.FileName.EndsWith(".jpeg") || uploadImage.FileName.EndsWith(".jpg") || uploadImage.FileName.EndsWith(".png") || uploadImage.FileName.EndsWith(".gif") || uploadImage.FileName.EndsWith(".jfif") || uploadImage.FileName.EndsWith(".webp"))
                {

                    uploadImage.SaveAs(Server.MapPath("/images/Products/") + uploadImage.FileName);
                }
            }
            string typeProduct = (ddlTypeProduct.SelectedValue).Split('-')[1].Trim();
            if (name == "" || description == "" || price == 0 || quanlity == 0 || uploadImage.FileName == "" || typeProduct == "")
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Điền thiếu thông tin!');", true);
                return;
            }

            string sqlCreateProduct =
                "insert into Product values(N'" + name + "', N'" + description + "'," + price + ", " +
                quanlity + ", '" + uploadImage.FileName + "', '" + typeProduct + "')";

            int ketqua = connect.capNhat(sqlCreateProduct);

            if (ketqua > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Thêm sản phẩm thành công!');", true);
                txtTen.Text = "";
                txtMota.Text = "";
                txtGia.Text = "";
                txtSoLuong.Text = "";
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Thêm sản phẩm thất bại!');", true);
            }

        }
        private bool IsProductNameExist(string productName)
        {
            string sqlCheckName = "select count(*) from Product where name = N'" + productName + "'";
            DataTable dt = connect.docDuLieu(sqlCheckName);

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                return true;
            }
            return false;
        }

        protected void btnThoat_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Product/Product.aspx");
        }
    }
}