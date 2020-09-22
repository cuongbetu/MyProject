<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AccountPasswordChange.aspx.cs" Inherits="Admin_AccountPasswordChange" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Đổi Mật Khẩu</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="workplace">
                    <!--Tiêu đề-->
                    <div class="page-header">
                        <h1>
                            Đổi mật khẩu
                        </h1>
                    </div>
                    <!--Nội dung-->
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="head clearfix">
                                <div class="isw-list">
                                </div>
                                <h1>
                                    Mời nhập mật khẩu mới
                                </h1>
                            </div>
                            <div class="block-fluid">
                                <!--Username-->
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Tên đăng nhập:
                                    </div>
                                    <div class="span2">
                                        <input runat="server" id="input_Username" type="text" class="tip" />
                                    </div>
                                    <div class="span8">
                                        <span class="warning-mess">Bạn đang đổi mật khẩu cho tài khoản này</span>
                                    </div>
                                </div>
                                <!--Mật khẩu-->
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Mật khẩu mới:
                                    </div>
                                    <div class="span2">
                                        <input runat="server" id="input_Password" type="password" />
                                    </div>
                                    <div class="span1">
                                        Nhập lại:
                                    </div>
                                    <div class="span2">
                                        <input runat="server" id="input_RePassword" type="password" />
                                    </div>
                                    <div class="span5">
                                        <span class="warning-mess">
                                            Mật khẩu mới dùng để đăng nhập, cần nhập 2 lần giống nhau.
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Button-->
                    <div class="row-fluid">
                        <div class="span12" style="margin-top: -20px; background-color: #F2F2F2;">
                            <div class="block-fluid  customize">
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        <asp:LinkButton ID="LinkButton_Save" runat="server" class="btn mybtn"
                                            OnClick="LinkButton_Save_Click"
                                            >
                                            <i class="isw-save"></i>Lưu
                                        </asp:LinkButton>
                                    </div>
                                    <div class="span10">
                                        <!--Thông báo-->
                                        <uc1:ucMessage runat="server" ID="ucMessage" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Link trở về-->
                    <div class="tar">
                        <a href="Default.aspx" type="button" class="btn active">
                            <i class="icon-arrow-left"></i> Trở về trang chủ
                        </a>
                    </div>

                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" Runat="Server">
</asp:Content>

