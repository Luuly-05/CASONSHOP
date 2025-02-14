<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="DoAn3.component.Footer" %>
<style>
    .footer-wrapper {
        width: 100%;
        background: #d68787;
        min-height: 120px;
        display: flex;
        align-items: center;
        padding: 0 120px;
        flex-direction: column;
        padding: 50px 0;
    }

    .list-item h3 {
        font-size: 18px;
        font-weight: 700;
        color: white;
        margin-bottom: 1.25rem;
        margin-top: 2.5rem;
        text-transform: uppercase;
    }

    .list-item {
        margin-left: 110px;
    }
    ul {
        list-style: none;
        float: left;
        padding: 0;
    }

    ul li {
        color: rgba(0,0,0,.65);
        max-width: 100%;
        overflow: hidden;
        white-space: nowrap;
        text-overflow: ellipsis;
        font-size: 15px;
        margin: 5px 0;
        color: white;
    }
    .cre{
        color: white;
    }
</style>
<div class="footer-wrapper">
    <div class="container">
        <div class="row list-item">
            <div class="col-3">
                <h3>-Thành viên nhóm-</h3>
                <ul>
                    <li>Nguyễn Thị Lưu Ly - 27201240742</li>
                    <li>Đoàn Hải Trân - 27207940630</li>
                    <li>Nguyễn Đinh Kim Trọng - 27211224680</li>
                    <li>Lê Thị Trinh - 27201202314</li>
                    <li>Nguyễn Hồng Minh -
                        <meta charset="utf-8" />
                        27211202426</li>
                </ul>
            </div>           
            <div class="col-3">
                <h3>-Thông tin liên hệ-</h3>
                <ul>
                    <li>Email: cason_nhom@gmail.com</li>
                    <li>Hotline: 0123 456 789</li>
                </ul>
            </div>
            <div class="col-3">
                <h3>-Địa chỉ-</h3>
                <ul>
                    <li>65 Nguyễn Du, Thạch Thang, Hải Châu, Đà Nẵng.</li>                    
                </ul>
            </div>
            <div class="cre">
                <h3>-Nguồn-</h3>
                Mọi thông tin, hình ảnh trên được chính Cason cung cấp.
                <br />
                Cấm sao chép và sử dụng khi chưa có sự đồng ý của Shop!!!
                <br />
                -------------
                <br />
                Xin chân thành cảm ơn cửa hàng Cason 
                <br />
                đã cho nhóm mượn tên và hình ảnh sản phẩm để hoàn thiện đồ án!
            </div>
        </div>
    </div>
</div>
