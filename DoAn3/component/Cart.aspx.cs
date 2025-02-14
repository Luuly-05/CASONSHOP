using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.component
{
    public partial class Cart : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            getAllOrders();
        }

        public void getAllOrders()
        {
            int userId;
            if (int.TryParse(Session["userId"] + "", out userId));
            DataTable dt = new DataTable();
            string sql = "select Product.ProductId, Product.name, image, typeStatus, price, quanlityBuy, price * quanlityBuy AS THANHTIEN from DONHANG, Product where " +
             "DONHANG.userId=" + userId + " and Product.ProductId=DONHANG.productId and DONHANG.typeStatus='S2'";
            dt = connect.docDuLieu(sql);
            if (dt.Rows.Count > 0)
            {
                gvrCart.DataSource = dt;
                gvrCart.DataBind();
                buy.Visible = true;
                noBuy.Visible = false;
            }
            else
            {
                buy.Visible = false;
                noBuy.Visible = true;
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(Session["userId"] + "", out userId)) ;
            int productId = Int32.Parse(((Button)sender).CommandArgument);

            Button bt_sua = (Button)sender;
            GridViewRow grvCart = (GridViewRow)bt_sua.Parent.Parent;
            TextBox txtQuanlity = (TextBox)grvCart.FindControl("txtSoLuong");
            int quanlity = Int32.Parse(txtQuanlity.Text);
            string sqlUpdate = "update DONHANG set quanlityBuy=" + quanlity + " WHERE productId=" + productId + " and userId=" + userId;

            int result = connect.capNhat(sqlUpdate);
            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Cập nhật thành công!');", true);
                string sqlUpdateQuanlityProduct = "update Product set quanlity=quanlity - " + quanlity + " where ProductId=" + productId;
                getAllOrders();
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Cập nhật thất bại!');", true);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(Session["userId"] + "", out userId)) ;
            int productId = Int32.Parse(((Button)sender).CommandArgument);
            string sqlDelete = "update DONHANG set typeStatus='S3' WHERE productId=" + productId + " and userId=" + userId
                + " and typeStatus='S2'";

            Button bt_sua = (Button)sender;
            GridViewRow grvCart = (GridViewRow)bt_sua.Parent.Parent;
            TextBox txtQuanlity = (TextBox)grvCart.FindControl("txtSoLuong");
            int quanlity = Int32.Parse(txtQuanlity.Text);


            int result = connect.capNhat(sqlDelete);
            if (result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Xóa sản phẩm thành công!');", true);
                string sqlUpdateQuanlityProduct = "update Product set quanlity=quanlity + " + quanlity + " where ProductId=" + productId;
                getAllOrders();
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Xóa sản phẩm thất bại!');", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomePage/Default.aspx");
        }

        protected void btnXacNhan_Click(object sender, EventArgs e)
        {
            int userId;
            if (int.TryParse(Session["userId"] + "", out userId)) ;
            int productId = Int32.Parse(((Button)sender).CommandArgument);
            string sqlUpdate = "update DONHANG set typeStatus='S1' WHERE productId=" + productId + " and userId=" + userId 
                + " and typeStatus='S2'";

            int result = connect.capNhat(sqlUpdate);
            if(result > 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Xác nhận thành công!');", true);
                getAllOrders();
            }else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Xác nhận thất bại!');", true);
            }

        }
    }
}