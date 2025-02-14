using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.HomePage
{
    public partial class Search : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            string keySearch = Request.QueryString["valueSearch"];
            keySearch = keySearch.Trim();
            string sql = "SELECT * FROM Product WHERE (name LIKE  '%" + @keySearch + "%')";
            DataTable dt = new DataTable();
            dt = connect.docDuLieu(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ltrSearch.Text += @"
                         <div class='col-2'>
                          <a href='./DetailProduct.aspx?productId=" + dt.Rows[i]["ProductId"] + @"' class='product-link'>
                          <div class='product-item' style='padding: 0; min-height: 280px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px'>
                            <div class='image-product'>
                                <img src=../images/Products/" + dt.Rows[i]["image"] + @" alt='ảnh sản phẩm'/>
                            </div>
                            <div class='description-product'>
                                <span>" + dt.Rows[i]["name"] + @"</span>
                            </div>
                            <div class='price-product'>
                                <span class='price'>" + dt.Rows[i]["price"] + @"</span>
                                <span class='quanlity'>3</span>
                            </div>
                        </div>
                        </a>
                    </div>
                ";
                }
            }
            else
            {

            }
        }
    }
}