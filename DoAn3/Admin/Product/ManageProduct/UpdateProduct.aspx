<%@ Page Title="" Language="C#" MasterPageFile="~/master/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="DoAn3.Admin.Product.ManageProduct.UpdateProduct" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="../../../css/Product.css" rel="stylesheet" />
<div class="update-product-container">
        <h3>Cập nhật sản phẩm</h3>
       <div class="row">
            <div class="col-6 item my-3">
                <label>Tên sản phẩm</label>
                <asp:TextBox ID="txtTen" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item my-3">
                <label>Mô tả</label>
                <asp:TextBox ID="txtMota" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item my-3">
                <label>Giá</label>
                <asp:TextBox ID="txtGia" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item my-3">
                <label>Số lượng</label>
               <asp:TextBox ID="txtSoLuong" runat="server"></asp:TextBox>
            </div>
            <div class="col-4 item my-3">
                <label>Hình ảnh</label>
                <asp:FileUpload ID="uploadImage" runat="server" />
                <asp:Label ID="lblImage" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-4 item">
                <label>Loại sản phẩm</label>
                <asp:DropDownList ID="ddlTypeProduct" runat="server">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    <asp:Button ID="btnUpdateProduct" CssClass="btn btn-warning" runat="server" Text="Sửa" OnClick="btnUpdateProduct_Click" />
    <asp:Label ID="lblNotifyUpdateProduct" runat="server" Text="" CssClass=""></asp:Label>
    <asp:Button ID="btn_Thoat" CssClass =" btn btn-warning" runat="server" Text="Thoát" OnClick="btn_Thoat_Click" />
</div>
</asp:Content>

