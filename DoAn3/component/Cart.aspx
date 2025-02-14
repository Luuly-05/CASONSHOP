<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="DoAn3.component.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <link rel="stylesheet"
        href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css">
     <script type="text/javascript" src="//cdn.jsdelivr.net/jquery/1/jquery.min.js"></script>
    <link media="screen" rel="stylesheet" type="text/css" href="//cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/css/toastr.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.1/js/toastr.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/toastr.js/latest/js/toastr.min.js"></script>
    <script>
        $(document).ready(function () {
            toastr.options = {
                'closeButton': true,
                'debug': false,
                'newestOnTop': false,
                'progressBar': false,
                'positionClass': 'toast-top-right',
                'preventDuplicates': false,
                'showDuration': '1000',
                'hideDuration': '1000',
                'timeOut': '5000',
                'extendedTimeOut': '1000',
                'showEasing': 'swing',
                'hideEasing': 'linear',
                'showMethod': 'fadeIn',
                'hideMethod': 'fadeOut',
            }
        });

        function Success(msg, Redirect = 1) {
            toastr.success(msg);
            if (Redirect != 1) {
                window.location.href = Redirect;
            }
            return false;
        }
        function Error(msg) {
            toastr.error(msg)
            return false;
        }
        function Warning(msg) {
            toastr.warning(msg)
            return false;
        }


        // Toast Position
        $('#position').click(function (event) {
            var pos = $('input[name=position]:checked', '#positionForm').val();
            toastr.options.positionClass = "toast-" + pos;
            toastr.options.preventDuplicates = false;
            toastr.info('This sample position', 'Toast Position')
        });
    </script>
    <script>
        Public Shared Sub ShowToastr(ByVal page As Page, ByVal message As String, ByVal title As String, Optional ByVal type As String = "info", Optional ByVal clearToast As Boolean = False, Optional ByVal pos As String = "toast-top-left", Optional ByVal Sticky As Boolean = False)
        Dim toastrScript As String = [String].Format("Notify('{0}','{1}','{2}', '{3}', '{4}', '{5}');", message, title, type, clearToast, pos, Sticky)
        page.ClientScript.RegisterStartupScript(page.[GetType](), "toastr_message", toastrScript, addScriptTags:=True)
        End Sub
    </script>
    <style>
        body {
            margin: 0;
            padding: 0;
        }

        .cart-header {
            padding: 0 120px;
            height: 120px;
            width: 100%;
            display: flex;
            align-items: center;
            background-color: #d68787;
        }

        .cart-name-shop {
            color: white;
            text-transform: uppercase;
            font-weight: 600;
            margin-left: 5px;
            font-size: 20px;
            padding-right: 15px;
            border-right: 1px solid gray;
        }

        .information {
            margin: 0 10px;
        }


            .information span {
                font-weight: 500;
                font-size: 18px;
            }

        .cart-content {
            background-color: #f5f5f5;
            padding: 0 120px;
            min-height: 100vh;
        }

        .list {
            padding: 30px 0;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            text-align: center;
        }

            table tr td {
                border: 1px solid black;
                padding: 10px 0px;
                font-size: 18px;
            }

            table tr th {
                border: 1px solid black;
                padding: 10px 0px;
                font-size: 20px;
            }

        .update {
            text-decoration: none;
            background-color: #ffc107;
            color: black;
            padding: 6px 20px;
            border-radius: 5px;
            margin-right: 10px;
        }

        .delete {
            text-decoration: none;
            background-color: #dc3545;
            color: black;
            padding: 6px 20px;
            border-radius: 5px;
        }

        .cart {
            padding-left: 15px;
        }

        .cart-iamge {
            width: 100px;
            height: 100px;
            object-fit: cover;
        }

        .create-product-success {
            color: #d68787;
            font-weight: bold;
        }

        .create-product-error {
            color: red;
            font-weight: bold;
        }

        .content-heading {
            margin-bottom: 20px;
        }

            .content-heading i {
                color: #d68787;
                font-size: 22px;
                margin-left: 8px;
            }

        .logo-link {
            text-decoration: none;
            color: black;
            font-weight: 700;
        }

        .noOder {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 30px;
        }

         .noOder i{
             font-size: 40px;
             color: red;
        }

         .noOder span {
             font-weight: 600;
             margin-top: 20px;
             font-size: 30px;
         }

          #toast-container > .toast-success {
            background-color: rgba(230, 11, 11, 0.92);
        }

        #toast-container > .toast-error {
            background-color: rgba(230, 11, 11, 0.92);
        }

        #toast-container > .toast-warning {
            background-color: rgba(230, 11, 11, 0.92);
        }

        table tr td {
            max-width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="cart-header">
                <asp:LinkButton CssClass="logo-link" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                      <span class="cart-name-shop">CASON</span>
                <div class="information">
                </div>
                </asp:LinkButton>
                <span class="cart"><strong>Giỏ hàng</strong></span>

            </div>
            <div class="cart-content">
                <div class="list">
                    <asp:PlaceHolder ID="buy" runat="server">
                        <h3 class="my-3 content-heading">Tất cả sản phẩm<i class="fa-solid fa-cart-shopping"></i></h3>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="noBuy" runat="server">
                        <div class="noOder">
                            <i class="fa-solid fa-cart-shopping"></i>
                            <span>Bạn chưa có sản phẩm nào!</span>
                        </div>
                    </asp:PlaceHolder>
                    <asp:GridView ID="gvrCart" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Hình ảnh">
                                <ItemTemplate>
                                    <asp:Image CssClass="cart-iamge" ID="Image1" runat="server" ImageUrl='<%# "../images/Products/" + Eval("image") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="name" HeaderText="Tên sản phẩm" />
                            <asp:BoundField DataField="price" HeaderText="Giá" />
                            <asp:TemplateField HeaderText="Số lượng">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSoLuong" runat="server" Text='<%# Eval("quanlityBuy") + "" %>'></asp:TextBox>
                                    <asp:Button ID="Button1" runat="server" Text="Sửa" CssClass="update" OnClick="Button1_Click"
                                        CommandArgument='<%# Eval("ProductId") + "" %>' Height="32px" Width="83px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="THANHTIEN" HeaderText="Thành tiền" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:Button ID="btnXacNhan" runat="server" Text="Xác nhận" CssClass="update"
                                        CommandArgument='<%# Eval("productId") + "" %>' OnClick="btnXacNhan_Click"
                                        />
                                    <asp:Button ID="Button2" runat="server" Text="Xóa" CssClass="delete"
                                        CommandArgument='<%# Eval("productId") + "" %>'
                                        OnClick="Button2_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
