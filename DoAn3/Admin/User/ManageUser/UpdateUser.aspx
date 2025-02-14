<%@ Page Title="" Language="C#" MasterPageFile="~/master/Admin.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="DoAn3.Admin.User.ManageUser.UpdateUser" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link href="../../../css/User.css" rel="stylesheet" />
    <div class="update-user-container">
        <div class="row">
            <div class="col-6 item my-3">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item my-3">
                <label>Họ và tên</label>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item my-3">
                <label>Mật khẩu</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="col-6 item">
                <label>Số điện thoại</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
            </div>
            <div class="col-12 item my-3">
                <label>Địa chỉ</label>
               <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            </div>
            <div class="col-6 item">
                <label>Ngày sinh</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
            </div>
        </div>
        <asp:Button ID="btnUpdateUser" CssClass="btn btn-warning my-3" runat="server" Text="Sửa" OnClick="btnUpdateUser_Click" />
    </div>
</asp:Content>

