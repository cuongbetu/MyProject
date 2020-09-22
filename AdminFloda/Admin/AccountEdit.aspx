<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AccountEdit.aspx.cs" Inherits="Admin_AccountEdit" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="workplace">
        <!--Tiêu đề-->
        <div class="page-header">
            <h1>Thêm / Chỉnh sửa thông tin tài khoản
            </h1>
        </div>
        <!--Nội dung-->
        <div class="row-fluid">
            <div class="span12">
                <div class="head clearfix">
                    <div class="isw-list">
                    </div>
                    <h1>Đăng / cập nhật tin tức
                    </h1>
                </div>
                <div class="block-fluid  customize accordion">
                    <h3>Thông tin đăng nhập
                    </h3>
                    <div class="account-category-post">

                        <div class="row-form clearfix">
                            <div class="span2">
                                Chọn Loại tài khoản:
                            </div>
                            <div class="span2">
                                <asp:DropDownList ID="DropDownList_Category" runat="server"  />
                            </div>
                        </div>
                        <!--Username-->
                        <div class="row-form clearfix">
                            <div class="span2">
                                Tên đăng nhập:
                            </div>
                            <div class="span2">
                                <input runat="server" id="input_Username" type="text" class="tipb" />
                            </div>
                            <div class="span8">
                                <span>Tên đăng nhập và mật khẩu vui lòng không chứa dấu, không cách và không ký hiệu đặc biệt như: !@#$%^&*...</span>
                            </div>
                        </div>
                        <!--Mật khẩu-->
                        <div class="row-form clearfix">
                            <div class="span2">
                                Mật khẩu:
                            </div>
                            <div class="span2">
                                <input runat="server" id="input_Password" type="password" />
                            </div>
                            <div class="span1">
                                Nhập lại:
                            </div>
                            <div class="span2">
                                <input runat="server" id="input_Repassword" type="password" />
                            </div>
                            <div class="span5">
                                <span>Để trống nếu không muốn đổi mật khẩu. Nhập 2 lần giống nhau</span>

                            </div>
                        </div>
                        <!--Trạng thái-->
                        <div class="row-form clearfix">
                            <div class="span2">
                                Trạng thái:
                            </div>
                            <div class="span10">
                                <label class="checkbox inline">
                                    <input runat="server" id="radio_Active" name="radio_Status" type="radio" checked />
                                    Kích hoạt
                                </label>
                                <label class="checkbox inline">
                                    <input runat="server" id="radio_Lock" name="radio_Status" type="radio" />
                                    Tạm khóa
                                </label>
                            </div>
                        </div>
                        <!--Họ tên-->
                        <div class="row-form clearfix">
                            <div class="span2">
                                Họ tên:
                            </div>
                            <div class="span5">
                                <input runat="server" id="input_FullName" type="text" />
                            </div>
                            <div class="span5">
                                <span>Nhập họ tên đầy đủ của tài khoản. Gõ tiếng Việt có dấu. VD: Lê Minh Hiếu</span>
                            </div>
                        </div>
                        <!--Email-->
                        <div class="row-form clearfix">
                            <div class="span2">
                                Email:
                            </div>
                            <div class="span5">
                                <input runat="server" id="input_Email" type="text" />
                            </div>
                            <div class="span5">
                                <span>Email dùng để liên lạc hoặc nhận lại mật khẩu (nếu bị mất).
                                                VD: mrhieuit@gmail.com
                                </span>
                            </div>
                        </div>
                    </div>
                    <h3>Thông tin liên hệ
                    </h3>
                    <div class="account-contact-info">
                        <div>
                            <!--Số điện thoại-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Số điện thoại:
                                </div>
                                <div class="span5">
                                    <input runat="server" id="input_Mobi" type="text" />
                                </div>
                                <div class="span5">
                                    <span>Số điện thoại liên lạc của tài khoản. VD: 0979 876 678
                                    </span>
                                </div>
                            </div>
                            <!--Địa chỉ-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Địa chỉ liên hệ:
                                </div>
                                <div class="span10">
                                    <textarea runat="server" id="textarea_Adress"></textarea>
                                    <span>Bạn có thể nhập địa chỉ nhà hoặc tên phòng ban nơi tài khoản làm việc hoặc thông tin mô tả thêm...</span>
                                </div>
                            </div>
                            <!--Hình đại diện-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Hình đại diện:
                                </div>
                                <div class="span10">
                                    <a runat="server" href="../css/img/no_image.jpg" id="a_Avatar" class="fancybox lightbox-preview" rel="group">
                                        <img runat="server" src="../css/img/no_image.jpg" id="img_Avatar" alt="avatar" class="default-image img-polaroid avatar-preview" style="width: 180px; height: 135px;" />
                                    </a>
                                    <br />
                                    <asp:FileUpload  runat="server" ID="FileUpload_Avatar" class="skip" preview="avatar-preview" />
                                    <br />
                                    <span>Hình đại diện cho bài báo. Bạn có thể upload hình mới nếu muốn.
                                                    Các Loại file hỗ trợ: *.jpg, *.jpeg, *.gif, *.png
                                    </span>
                                </div>
                            </div>
                            <!--Giới tính-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Giới tính:
                                </div>
                                <div class="span10">
                                    <label class="checkbox inline">
                                        <input runat="server" id="radio_Male" name="gender" type="radio" checked />
                                        Nam
                                    </label>
                                    <label class="checkbox inline">
                                        <input runat="server" id="radio_Female" name="gender" type="radio" />
                                        Nữ
                                    </label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h3>Thông tin khác
                    </h3>
                    <div class="account-other-info">
                        <div class="row-form clearfix">
                            <div class="span2">
                                Ngày giờ tạo tài khoản:
                            </div>
                            <div class="span2">
                                <input runat="server" id="input_CreateTime" type="text" readonly/>
                            </div>
                            <div class="span8">
                                <span>Tự động lưu ngày giờ tạo tài khoản theo giờ hệ thống. Không cho phép chỉnh sửa
                                </span>
                            </div>
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
                            <asp:LinkButton class="btn mybtn" ID="LinkButton_Save"  runat="server"
                                OnClick="LinkButton_Save_Click">
                                <i class="isw-save"></i>
                            </asp:LinkButton>
                        </div>
                        <div class="span10">

                            <!--Thông báo-->
                            <div class="alert alert-info inline-msg">
                                <uc1:ucMessage runat="server" ID="ucMessage" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Link trở về-->
        <div class="tar">
            <a href="AccountList.aspx" type="button" class="btn active">
                <i class="icon-arrow-left"></i>Trở về trang danh sách tài khoản
            </a>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
</asp:Content>

