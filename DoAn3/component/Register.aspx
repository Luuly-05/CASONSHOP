<%@ Page Title="" Language="C#" MasterPageFile="~/master/Login.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DoAn3.component.Register" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/Login.css" rel="stylesheet" />
    <div class="form-register">
        <div class="text-center">
        <span class="heading">Đăng ký</span>
        </div>
        <div class="create-user-content">
        <div class="row">
            <div>
                <span><label>Email</label>
                <asp:TextBox ID="txtEmail" runat="server" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Họ và tên</label>
                <asp:TextBox ID="txtName" runat="server" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Mật khẩu</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Nhập lại mật khẩu</label>
               <asp:TextBox ID="txtComfirmPassword" runat="server" TextMode="Password" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Địa chỉ</label>
               <asp:TextBox ID="txtAddress" runat="server" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Số điện thoại</label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Width="350px"></asp:TextBox></span>
            </div>
            <div>
                <span><label>Ngày sinh</label>
                <asp:TextBox ID="txtDate" runat="server" TextMode="Date" Width="350px"></asp:TextBox></span>
            </div>
        </div>
        <asp:Button ID="btnCreateUser" CssClass="btn btn-primary my-3" runat="server" Text="Đăng Ký" On OnClick="btnCreateUser_Click" BackColor="#D68787" />
    </div>
    </div>
</asp:Content>
