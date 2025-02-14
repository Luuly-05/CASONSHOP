<%@ Page Title="" Language="C#" MasterPageFile="~/master/Admin.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="DoAn3.Admin.Order.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/Order.css" rel="stylesheet" />
    <style>
        table {
    width: 100%;
    border-collapse: collapse;
    text-align: center;
    margin-top: 10px;
    margin-bottom: 30px;
}

    table tr td {
        border: 1px solid black;
        padding: 10px 0px;
        font-size: 18px;
        max-width: 200px;
    }

    table tr th {
        border: 1px solid black;
        padding: 10px 0px;
        font-size: 20px;
    }

    .success {
        color: blue;
        font-weight: 600;
    }

    .pending {
          color:  #ffc107;
        font-weight: 600;
       
    }

    .sale {
        display: flex;
        margin: 15px 0;
        align-items: center;
    }

    .sale .text{
        font-weight: 600;
        font-size: 24px;
    }

    .sale .data{
        font-size: 20px;
    color: red;
    margin-left: 10px;
    margin-top: 3px;
    }

    .status {
        font-weight: 600;
    }

    </style>
    <div class="manage-order-container">
        <div class="manage-order-heading">
            <h3>Quản lý đơn hàng</h3>
        </div>
        <asp:GridView ID="grvOrder" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
                <asp:BoundField DataField="price" HeaderText="Giá" />
                <asp:BoundField DataField="quanlityBuy" HeaderText="Số lượng" />
                <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền" />
                <asp:TemplateField HeaderText="Trạng thái">
                    <ItemTemplate>
                        <asp:Label CssClass="status" ID="lblStatus" runat="server" Text='<%# Eval("value") + "" %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblDeleteOrder" CssClass="delete" runat="server" CommandArgument='<%# Eval("userId") + "," + Eval("productId")+ "" %>' OnClick="lblDeleteOrder_Click">Xóa</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="sale">
            <span class="text">Doanh thu: </span>
            <asp:Label CssClass="data" ID="lblSale" runat="server" Text=""></asp:Label>
        </div>
        <div class="sale">
            <span class="text">Tổng số đơn thành công: </span>
            <asp:Label CssClass="data" ID="lblCountOrderSuccess" runat="server" Text=""></asp:Label>
        </div>
        <div class="sale">
            <span class="text">Tổng số đơn đang chờ: </span>
            <asp:Label CssClass="data" ID="lblCountOrderPending" runat="server" Text=""></asp:Label>
        </div>
        <div class="sale">
            <span class="text">Tổng số đơn đã hủy: </span>
            <asp:Label CssClass="data" ID="lblCountOrderCancel" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
