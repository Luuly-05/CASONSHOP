using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DoAn3.HomePage
{
    public partial class AllProductsType : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            string typeProduct = Request.QueryString["typeProduct"];
            getAllProductsClothes(typeProduct);
        }

        public void getAllProductsClothes(string typeProduct)
        {
            string sql = "select * from Product where typeProduct='" + typeProduct + "'";
            DataTable dt = connect.docDuLieu(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                    ltrAllProduct.Text += @"
                         <div class='col-2 my-2'>
                          <a href='./DetailProduct.aspx?productId=" + dt.Rows[i]["ProductId"] + @"' class='product-link'>
                          <div class='product-item' style='padding: 0; min-height: 280px; box-shadow: rgba(0, 0, 0, 0.24) 0px 3px 8px'>
                            <div class='image-product'>
                                <img class='image-product' src=../images/Products/" + dt.Rows[i]["image"] + @" alt='ảnh sản phẩm'/>
                            </div>
                            <div class='description-product'>
                                <span>" + dt.Rows[i]["name"] + @"</span>
                            </div>
                            <div class='price-product'>
                                <span class='price'>" + dt.Rows[i]["price"] + @"</span>
                                <span class='quanlity'>Số lượng: " + dt.Rows[i]["quanlity"] + @"</span>
                            </div>
                        </div>
                        </a>
                    </div>
                ";
            }
        }
    }
}