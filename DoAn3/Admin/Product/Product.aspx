<%@ Page Title="" Language="C#" MasterPageFile="~/master/Admin.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="DoAn3.Admin.Product.Product" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/Product.css" rel="stylesheet" />
    <style>
        .admin-image-product {
    width: 100px;
    height: 100px;
    object-fit: cover;
    
}
        .manage-product-container {
            margin-bottom: 70px;
        }
        .manage-product-heading {
            margin-bottom: 20px;
        }

        table tr td {
            max-width: 200px;
        }
    </style>
    <div class="manage-product-container">
        <div class="manage-product-heading">
            <h3>Quản lý sản phẩm</h3>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">+ Thêm mới sản phẩm</asp:LinkButton>
        </div>
      
        <asp:GridView ID="grvProduct" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" ControlStyle-CssClass="name"/>
                <asp:TemplateField HeaderText="Hình ảnh">
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" CssClass="admin-image-product" ImageUrl='<%# "../../images/Products/" + Eval("image") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="description" HeaderText="Mô tả" />
                <asp:BoundField DataField="price" HeaderText="Giá " />
                <asp:BoundField DataField="quanlity" HeaderText="Số lượng" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="update" ID="LinkButton2" runat="server" CommandArgument='<%# Eval("ProductId") +"" %>' OnClick="LinkButton2_Click">Sửa</asp:LinkButton>
                        <asp:LinkButton CssClass="delete" ID="LinkButton3" runat="server" CommandArgument='<%# Eval("ProductId") +"" %>' OnClick="LinkButton3_Click">Xóa</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
