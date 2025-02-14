using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.Admin.Product.ManageProduct
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                return;
            }
            int productId = Int32.Parse(Request.QueryString["productId"]);
            string sql = "select * from Product WHERE ProductId=" + productId;

            DataTable dt = connect.docDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                txtTen.Text = dt.Rows[0][1] + "";
                txtMota.Text = dt.Rows[0][2] + "";
                txtGia.Text = dt.Rows[0][3] + "";
                txtSoLuong.Text = dt.Rows[0][4] + "";
                lblImage.Text = dt.Rows[0][5] + "";
                string sqlGetTypeProduct = "select * from TypeProduct";

                DataTable dtTypeProduct = new DataTable();
                dtTypeProduct = connect.docDuLieu(sqlGetTypeProduct);
                if (dtTypeProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTypeProduct.Rows.Count; i++)
                    {
                        ddlTypeProduct.Items.Add(new ListItem(dtTypeProduct.Rows[i]["value"] + "" + "-" + dtTypeProduct.Rows[i]["typeProduct"] + ""));
                    }
                }
            }
        }

        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int productId = Int32.Parse(Request.QueryString["productId"]);
            string image = lblImage.Text;
            if (uploadImage.FileContent.Length > 0)
            {
                if (uploadImage.FileName.EndsWith(".jpeg") || uploadImage.FileName.EndsWith(".jpg") || uploadImage.FileName.EndsWith(".png") || uploadImage.FileName.EndsWith(".gif"))
                {
                    image = uploadImage.FileName;
                    uploadImage.SaveAs(Server.MapPath("/images/Products/") + uploadImage.FileName);
                }
            }
            string typeProduct = (ddlTypeProduct.SelectedValue).Trim().Split('-')[1];
            string sqlUpdate = "update Product set name=N'" + txtTen.Text + "', description=N'" +
                txtMota.Text + "', price=" + Int32.Parse(txtGia.Text) + ", quanlity=" + Int32.Parse(txtSoLuong.Text)
                + ", image='" + image + "', typeProduct='" + typeProduct + "' WHERE ProductId=" + productId;

            int result = connect.capNhat(sqlUpdate);
            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Cập nhật thành công!');", true);
                //Response.Redirect("../Product.aspx");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Cập nhật thất bại!');", true);
            }
        }

        protected void btn_Thoat_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Product/Product.aspx");
        }
    }
}