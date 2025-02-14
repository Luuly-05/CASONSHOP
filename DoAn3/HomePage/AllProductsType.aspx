<%@ Page Title="" Language="C#" MasterPageFile="~/master/HomePage.Master" AutoEventWireup="true" CodeBehind="AllProductsType.aspx.cs" Inherits="DoAn3.HomePage.AllProductsType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .image-product {
            max-height : 200px;
            object-fit: cover;
        }
    </style>
    <div style="min-height: 100vh; padding-bottom: 50px">
         <div class="container my-3">
        <h3 class="my-4">Tất cả sản phẩm</h3>
        <div class="row">
            <asp:Literal ID="ltrAllProduct" runat="server"></asp:Literal>
        </div>
        </div>
    </div>
</asp:Content>
