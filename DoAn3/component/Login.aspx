 <%@ Page Title="" Language="C#" MasterPageFile="~/master/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoAn3.component.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Login.css" rel="stylesheet" />
    <div class="form-register">
        <div class="text-center">
        <span class="heading">Đăng nhập</span>
        </div>
        <diV>
            <div class="register-item">
                <label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </div>
            <div class="register-item">
                <label>Mật khẩu</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server">Quên mật khẩu?</asp:LinkButton>
            </div>
            <asp:LinkButton CssClass=" btn btn-submit" ID="lbtLogin" runat="server" OnClick="lbtLogin_Click" Width="121px">Đăng nhập</asp:LinkButton>
        </diV>
    </div>
</asp:Content>
