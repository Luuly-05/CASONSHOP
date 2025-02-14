using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace DoAn3.HomePage
{
    public partial class HomePage : System.Web.UI.Page
    {
        ConnectDatabase connect = new ConnectDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            getAllProductsClothes("P1");
            getAllProductsClothes("P2");
            getAllProductsClothes("P3");
            getAllProductsClothes("P4");
            getAllProductsClothes("P5");
        }

       
        public void getAllProductsClothes(string typeProduct)
        {
            string sql = "select top 6 * from Product where typeProduct='" + typeProduct + "'" ;
            DataTable dt = connect.docDuLieu(sql);
            if(dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
            {
                    if (typeProduct == "P1")
                {
                    ltrAo.Text += @"
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
                }else if(typeProduct == "P3")
                {
                    ltrChanvay.Text += @"
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
                else if (typeProduct == "P2")
                {
                    ltrQuan.Text += @"
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
                else if(typeProduct == "P4")
                {
                    ltrDam.Text += @"
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
                else if (typeProduct == "P5")
                {
                        ltrPhukien.Text += @"
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

        protected void lbtMore_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AllProductsType.aspx?typeProduct=P1");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AllProductsType.aspx?typeProduct=P2");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AllProductsType.aspx?typeProduct=P4");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AllProductsType.aspx?typeProduct=P5");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("./AllProductsType.aspx?typeProduct=P3");
        }
    }
}