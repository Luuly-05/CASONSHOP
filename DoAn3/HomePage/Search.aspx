<%@ Page Title="" Language="C#" MasterPageFile="~/master/HomePage.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="DoAn3.HomePage.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <div class="container" style="margin: 30px auto">
        <h3>Sản phẩm</h3>
        <div class="row">
            <asp:Literal ID="ltrSearch" runat="server"></asp:Literal>
        </div>
    </div>
    <asp:PlaceHolder ID="noProduct" runat="server">

    </asp:PlaceHolder>
</asp:Content>
