  <%@ Page Title="" Language="C#" MasterPageFile="~/master/HomePage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DoAn3.HomePage.HomePage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/HomePage.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <style>
        .homepage-container {
            padding-bottom: 50px;
        }
        .content-heading h3 {
            margin: 10px 0;
        }

        .lbtMore {
            color: blue;
            font-weight: 600;
        }

        .image-product {
            max-height: 200px;
            object-fit: cover;
        }

        .price-list {
            position: relative;
        }

        .price-product .price {
            font-size: 17px;
        }
        .donvi {
            position: absolute;
            color: rgb(238, 77, 45);
            top: 1px;
            right: -11px;
        }

       
    </style>
    <div class="homepage-container">
        <div class="banner row">
             <img src="../images/Banner.jpg" alt="Image Slider"/>          
        </div>
        <div class="homepage-content">
            <%--ÁO--%>
            <div class="content-list" style="margin: 0">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>

                <div class="content-heading">
                    <h3>ÁO</h3>
                    <asp:LinkButton CssClass="lbtMore" ID="lbtMore" runat="server" OnClick="lbtMore_Click">Xem thêm</asp:LinkButton>
                </div>

                <div class="row list-product" style="margin: 30px 0">
                     <asp:Literal ID="ltrAo" runat="server"></asp:Literal>
                </div>
            </div>
            <%--QUẦN--%>
            <div class="content-list" style="margin: 0">
                <div class="content-heading">
                    <h3>QUẦN</h3>
                    <asp:LinkButton CssClass="lbtMore" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Xem thêm</asp:LinkButton>
                </div>
                <div class="row list-product" style="margin: 30px 0">
                     <asp:Literal ID="ltrQuan" runat="server"></asp:Literal>
                </div>
            </div>
            <%--ĐẦM--%>
            <div class="content-list" style="margin: 0">
                <div class="content-heading">
                    <h3>ĐẦM</h3>
                    <asp:LinkButton CssClass="lbtMore" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Xem thêm</asp:LinkButton>
                </div>
                <div class="row list-product" style="margin: 30px 0">
                     <asp:Literal ID="ltrDam" runat="server"></asp:Literal>
                </div>
            </div>
            <%--CHÂN VÁY--%>
            <div class="content-list" style="margin: 0">
                <div class="content-heading">
                    <h3>CHÂN VÁY</h3>
                    <asp:LinkButton CssClass="lbtMore" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Xem thêm</asp:LinkButton>
                </div>
                <div class="row list-product" style="margin: 30px 0">
                    <asp:Literal ID="ltrChanvay" runat="server"></asp:Literal>
                </div>
            </div>
            <%--PHỤ KIỆN--%>
            <div class="content-list" style="margin: 0;">
                <asp:PlaceHolder ID="plhPhukien" runat="server">
                    <div class="content-heading">
                        <h3>PHỤ KIỆN</h3>
                        <asp:LinkButton CssClass="lbtMore" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Xem thêm</asp:LinkButton>
                    </div>
                </asp:PlaceHolder>
                
                <div class="row list-product" style="margin: 30px 0">
                     <asp:Literal ID="ltrPhukien" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
 </asp:Content>
