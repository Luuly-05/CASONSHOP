<%@ Page Title="" Language="C#" MasterPageFile="~/master/HomePage.Master" AutoEventWireup="true" CodeBehind="DetailProduct.aspx.cs" Inherits="DoAn3.HomePage.DetailProduct" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/DetailProduct.css" rel="stylesheet" />
    <style>
        table {
            width: 100%;
        }

        .detail-product-container {
            min-height: 100vh;
            box-shadow: rgba(99, 99, 99, 0.2) 0px 2px 8px 0px;
        }

        .name-product {
            font-weight: 600;
            font-size: 30px;
        }

        .detail-product-image img {
            box-shadow: rgba(50, 50, 93, 0.25) 0px 6px 12px -2px, rgba(0, 0, 0, 0.3) 0px 3px 7px -3px;
        }

        .item {
            margin-bottom: 20px;
        }

            .item label {
                color: #757575;
                width: 130px;
            }

            .image-product-detail {
                height: 100%;
                object-fit: cover;
            }

            .heading-detail {
                 margin-bottom: 30px;
                 font-size: 35px;
            }
    </style>
    <div class="detail-product-container">
        <h3 class="heading-detail">Chi tiết sản phẩm</h3>
        <div class="detail-product-content">
            <%--<asp:Literal ID="ltrChiTiet" runat="server"></asp:Literal>--%>
            <asp:DataList ID="ddlProduct" runat="server">
                <ItemTemplate>
                    <div class="row">

                        <div class="col-4 detail-product-image">
                            <asp:Image CssClass="image-product-detail" ID="Image1" runat="server" ImageUrl='<%# "/images/Products/" + Eval("image") %>' />
                        </div>
                        <div class="col-8 detail-product-information">
                            <asp:Label CssClass="name-product" ID="Lable2" runat="server" Text='<%# Eval("name") + "" %>'></asp:Label>
                                <div class="item">
                                    <label>Mô tả: </label>
                                    <asp:Label ID="Label1" CssClass="detail-product-description" runat="server" Text='<%# Eval("description") + "" %>'></asp:Label>
                                </div>
                                <div class="item">
                                    <label>Giá: </label>
                                    <asp:Label ID="Label2" CssClass="detail-product-price" runat="server" Text='<%# Eval("price") + "" %>'></asp:Label>
                                </div>
                                <div class="item">
                                    <label>Size: </label>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="1">S</asp:ListItem>
                                        <asp:ListItem Value="2">M</asp:ListItem>
                                        <asp:ListItem Value="3">L</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                </div>
                                <div class="item">
                                    <label>Số lượng có sẵn: </label>
                                    <asp:Label ID="Label3" CssClass="detail-product-price" runat="server" Text='<%# Eval("quanlity") + "" %>'></asp:Label>
                                </div>
                                <div class="item">
                                    <label>Số lượng đặt: </label>
                                    <asp:TextBox ID="txtQuanlity" runat="server" min="1" CssClass="detail-product-quanlity" TextMode="number"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnMua" runat="server" CssClass="btn btn-danger detail-product-submit" Text="Mua ngay" OnClick="btnMua_Click" CommandArgument='<%# Eval("ProductId") + "," +  Eval("quanlity") %>'></asp:Button>
                            </div>
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblNotifyDetail" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </div>
</asp:Content>
