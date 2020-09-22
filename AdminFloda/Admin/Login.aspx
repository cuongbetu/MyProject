<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Default" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<!DOCTYPE html>
<html>
<head>
    <title>
        Đăng nhập
    </title>
    <!--Cấu hình để chạy trên đa thiết bị: máy tính, máy tính bảng, điện thoại, ...-->
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <!--Icon hiển thị trên trình duyệt-->
    <link rel="icon" type="image/ico" href="favicon.ico" />
    <!--Css chính-->
    <link href="/Admin/css/full-css-import.css" rel="stylesheet" />
    <!--Hack css theo trình duyệt-->
    <!--[if gt IE 8]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <![endif]-->
    <!--[if lt IE 8]>
        <link href="/Admin/css/ie7.css" rel="stylesheet" type="text/css" />
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="loginBlock" style="display: block;">
            <h1>Đăng nhập hệ thống</h1>
            <div class="loginForm">
                <!--Username-->
                <div class="control-group">
                    <div class="input-prepend">
                        <span class="add-on"><span class="icon-user"></span></span>
                        <input runat="server" id="input_Username" type="text" placeholder="Username"/>
                    </div>
                </div>

                <!--Password-->
                <div class="control-group">
                    <div class="input-prepend">
                        <span class="add-on"><span class="icon-lock"></span></span>
                        <input runat="server" id="input_Password" type="password" placeholder="Password" />
                    </div>
                </div>

                <!--Remember + Login button-->
                <div class="row-fluid">
                    <!--Lưu mật khẩu-->
                    <div class="span8">
                        <div class="control-group" style="margin-top: 5px;">
                            <label class="checkbox">
                                <input type="checkbox" />
                                Lưu mật khẩu trên máy này
                            </label>
                             <label class="checkbox">
                                Username : nguyencuong<br />
                                Password : 123456
                            </label>
                        </div>
                    </div>
                    <!--Nút đăng nhập-->
                    <div class="span4">
                        <asp:Button Text="Đăng Nhập" class="btn btn-block" ID="Button_Login" OnClick="Button_Login_Click" runat="server" />
                    </div>
                </div>

                <!--Thông báo-->
                <uc1:ucMessage runat="server" ID="ucMessage" />

                <!--Đường phân cách-->
                <div class="dr"><span></span></div>

                <!--Quên mật khẩu-->
                <div class="controls hidden">
                    <div class="row-fluid">
                        <div class="span12">
                            <button class="btn btn-link btn-block">
                                Quên mật khẩu?
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

