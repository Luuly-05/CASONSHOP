<%@ Page Title="" Language="C#" MasterPageFile="~/master/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="DoAn3.Admin.Product.User" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/User.css" rel="stylesheet" />
    <div class="manage-user-container">
        <div class="manage-user-heading">
            <h3>Quản lý người dùng</h3>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">+ Thêm mới người dùng</asp:LinkButton>
        </div>
        <asp:GridView ID="grvUser" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="name" HeaderText="Họ và tên" />
                <asp:BoundField DataField="address" HeaderText="Địa chỉ" />
                <asp:BoundField DataField="phoneNumber" HeaderText="Số điện thoại" />
                <asp:BoundField DataField="DateOfBirth" HeaderText="Ngày sinh" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="update" ID="LinkButton2" runat="server" CommandArgument='<%# Eval("id") + "" %>' OnClick="LinkButton2_Click">Sửa</asp:LinkButton>
                        <asp:LinkButton CssClass="delete" ID="LinkButton3" runat="server" CommandArgument='<%# Eval("id") + "" %>' OnClick="LinkButton3_Click">Xóa</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
