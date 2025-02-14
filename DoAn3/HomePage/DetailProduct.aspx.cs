using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.HomePage
{
    public partial class DetailProduct : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            int productId = Int32.Parse(Request.QueryString["productId"].Trim());
            string sql = "select * from Product where ProductId='" + productId + "'";
            ddlProduct.DataSource = connect.docDuLieu(sql);
            ddlProduct.DataBind();
        }

        protected void btnMua_Click(object sender, EventArgs e)
        {
            string email = Session["email"] + "";
            string userId = Session["userId"] + "";
            if (email != "")
            {
                string commandArgument = ((Button)sender).CommandArgument;
                string[] arr = commandArgument.Split(',');
                string productId = arr[0];
                int quanlityRemain = Int32.Parse(arr[1]);

                Button bt_mua = (Button)sender;
                DataListItem item = (DataListItem)bt_mua.Parent;
                TextBox txtSL = (TextBox)item.FindControl("txtQuanlity");
                DateTime date = new DateTime();
                date = DateTime.Now;
                if(txtSL.Text == "")
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Bạn chưa điền số lượng!');", true);
                    return;
                }
                string quanlity = txtSL.Text;
                if(Int32.Parse(quanlity) > quanlityRemain)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Số lượng còn lại không đủ để bạn mua!');", true);
                    return;
                }

                string sql_kiemtra = "select * from DONHANG where userId=" + Int32.Parse(userId) + " and productId=" + Int32.Parse(productId)
                    + " and typeStatus='S2'";
                DataTable dt = connect.docDuLieu(sql_kiemtra);
                string sql;
                if (dt.Rows.Count > 0)
                {
                    sql = "update DONHANG set quanlityBuy=quanlityBuy + " + Int32.Parse(quanlity) + " where userId=" + Int32.Parse(userId) +
                        " and productId=" + Int32.Parse(productId);
                }
                else
                {
                    sql = "insert into DONHANG values(" + Int32.Parse(userId) + ", " + Int32.Parse(productId) + ", 'S2', "  + Int32.Parse(quanlity) + 
                     ", '" +  date + "')";

                }

                int ketqua = connect.capNhat(sql);

                if (ketqua > 0)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Bạn đã mua thành công!');", true);
                    string sqlUpdateQuanlityProduct = "update Product set quanlity=quanlity - " + Int32.Parse(quanlity) + " where ProductId=" + Int32.Parse(productId);
                    int update = connect.capNhat(sqlUpdateQuanlityProduct);
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Mua hàng thất bại!');", true);
                }
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Error('Bạn phải đăng nhập mới có thể mua hàng!');", true);
            }
        }
    }
}