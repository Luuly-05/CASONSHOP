using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.Admin.Order
{
    public partial class Order : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAllOrderFromDataBase();
                //getSumPrice();
                getCountOrderSuccess();
                getCountOrderPending();
                getCountOrderCancel();
            }
        }


        public void getSumPrice()
        {
            string sql = "select sum(DONHANG.quanlityBuy * Product.price) from Product, DONHANG where DONHANG.typeStatus='S1'";
            double result = connect.demDuLieu(sql);
            lblSale.Text = result.ToString("#,##0.00") + " vnđ";
        }

        public void getCountOrderSuccess()
        {
            string sql = "select count(typeStatus) from DONHANG where typeStatus='S1'";
            int result = connect.count(sql);
            lblCountOrderSuccess.Text = result.ToString();
        }

        public void getCountOrderPending()
        {
            string sql = "select count(typeStatus) from DONHANG where typeStatus='S2'";
            int result = connect.count(sql);
            lblCountOrderPending.Text = result.ToString();
        }

        public void getCountOrderCancel()
        {
            string sql = "select count(typeStatus) from DONHANG where typeStatus='S3'";
            int result = connect.count(sql);
            lblCountOrderCancel.Text = result.ToString();
        }

        public void getAllOrderFromDataBase()
        {
            string sql = "select DONHANG.productId, DONHANG.userId, DONHANG.typeStatus, TYPESTATUS.value, email, Product.name, price, quanlityBuy, price * quanlityBuy AS THANHTIEN " +
                "from NGUOIDUNG, DONHANG, Product, TYPESTATUS where " +
                "DONHANG.userId=NGUOIDUNG.Id and Product.ProductId=DONHANG.productId and  DONHANG.typeStatus=TYPESTATUS.typeStatus";
            DataTable dt = new DataTable();
            dt = connect.docDuLieu(sql);
            double sum = 0;
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((dt.Rows[i]["typeStatus"] + "").Trim() == "S1") {
                        sum += Double.Parse(dt.Rows[i]["THANHTIEN"] + "");
                     }
                }
            }
            lblSale.Text = sum.ToString("#,##0.00") + " vnđ";


            grvOrder.DataSource = connect.docDuLieu(sql);
            grvOrder.DataBind();
        }

        protected void lblDeleteOrder_Click(object sender, EventArgs e)
        {
            string commargs = ((LinkButton)sender).CommandArgument;
            string[] arr = commargs.Split(',');
            string userId = arr[0];
            string productId = arr[1];

            if (userId == "" || productId == "")
            {
                Response.Write("CHƯA ĐỦ");
            }
            else
            {
                string sqlDelete = "delete from DONHANG where productId=" + Int32.Parse(productId) + " and userId=" + Int32.Parse(userId);
                int result = connect.capNhat(sqlDelete);
                if (result > 0)
                {
                    getAllOrderFromDataBase();
                    this.ClientScript.RegisterStartupScript(this.GetType(), "SweetAlert1", "Success('Xóa đơn hàng thành công!');", true);
                }
            }
        }
    }
}
