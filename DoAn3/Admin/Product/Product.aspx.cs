using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.Admin.Product
{
    public partial class Product : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sql = "select * from Product";
                getProductsFromDataBase(sql);
            }
        }

        
        public void getProductsFromDataBase(string sql)
        {
            grvProduct.DataSource = connect.docDuLieu(sql);
            grvProduct.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageProduct/CreateProduct.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string productId = ((LinkButton)sender).CommandArgument;
            Response.Redirect("ManageProduct/UpdateProduct.aspx?productId=" + productId);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int productId = Int32.Parse(((LinkButton)sender).CommandArgument);
            string sqlDelete = "DELETE FROM Product WHERE ProductId=" + productId;
            int result = connect.capNhat(sqlDelete);
            string sql = "select * from Product";

            if (result > 0)
            {
                getProductsFromDataBase(sql);
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Xóa sản phẩm thành công!');", true);
            }else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Xóa sản phẩm thất bại!');", true);
            }
        }
    }
}