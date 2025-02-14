<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailUser.aspx.cs" Inherits="DoAn3.component.DetailUser" %>

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
            padding: 0;
            margin: 0;
        }

        .header-container {
            height: 100px;
            width: 100%;
            background-color: #d68787;
            display: flex;
            align-items: center;
        }

        .logo-link {
            text-decoration: none;
            color: white;
            display: flex;
            align-items: center;
        }

            .logo-link span {
                font-size: 20px;
                font-weight: 600;
                margin-left: 5px;
                margin-right: 15px;
            }

            .logo-link i {
                font-size: 20px;
            }

        .header-content {
            display: flex;
            align-items: center;
        }

        .text-heading {
            padding-left: 15px;
            border-left: 1px solid gray;
            font-weight: 500;
            font-size: 18px;
        }

        .item {
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

            .item input {
                width: 100%;
            }

        .create-user-success {
            color: #d68787;
            font-weight: bold;
        }

        .create-user-error {
            color: red;
            font-weight: bold;
        }

        .content-heading {
            display: flex;
            align-items: center;
        }

            .content-heading i {
                color: #d68787;
                font-size: 22px;
                margin-left: 8px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="detail-wrrapper">
            <div class="header-container">
                <div class="container">
                    <div class="header-content">
                        <asp:LinkButton CssClass="logo-link" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
                             <span>CASON</span>
                        </asp:LinkButton>
                        <span class="text-heading">Cập nhật thông tin</span>
                    </div>

                </div>
            </div>
            <div class="content">
                <div class="container">
                    <div class="update-user-container">
                        <h3 class="my-3 content-heading">Thông tin cá nhân<i class="fa-solid fa-user-plus"></i></h3>
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
                        <div class="action my-4">
                            <asp:Button ID="btnUpdate" CssClass="btn btn-warning" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click" />
                            <span><asp:LinkButton ID="lbtDangXuat" CssClass="btn btn-danger" runat="server" OnClick="lbtDangXuat_Click">Đăng xuất</asp:LinkButton></span>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
