<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductEdit.aspx.cs" Inherits="Admin_ProductEdit" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="workplace">
        <!--Tiêu đề-->
        <div class="page-header">
            <h1>Thêm / Chỉnh sửa bản tin
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
                <div class="block-fluid customize accordion">
                    <h3>Thông tin cơ bản
                    </h3>
                    <div class="article-basic-info">
                        <div>
                            <!--Chọn Loại Cấp Cha-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Loại Cấp Cha:
                                </div>
                                <div class="span10">
                                    <asp:DropDownList ID="DropDownList_Category"
                                        runat="server" />
                                    <span>Chọn Loại Cấp Cha của loại này.</span>
                                </div>
                            </div>
                            <!--Mã số + vị trí-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Mã Loại:
                                </div>
                                <div class="span2">
                                    <input runat="server" id="input_ID" type="text" class="tipb" readonly="readonly" title="Mã số tự động (không cần nhập)" />
                                </div>
                                <div class="span1">
                                    Vị trí:
                                </div>
                                <div class="span1" style="margin-left: 2px;">
                                    <input runat="server" id="input_Position" type="text" class="tipb" title="Dùng để sắp xếp thứ tự" />
                                </div>
                                <div class="span1">
                                    Code:
                                </div>
                                <div class="span2">
                                    <input runat="server" id="input_Code" type="text" class="tipb" title="Dùng để tìm kiếm hoặc phân loại" />
                                </div>
                                <div class="span3">
                                    <span>(Vị trí và Code: được phép để trống)</span>
                                </div>
                            </div>
                            <!--Tiêu đề-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Tiêu đề:
                                </div>
                                <div class="span10">
                                    <input runat="server" id="input_Title" type="text" />
                                    <span>VD: Tin bất động sản trong nước </span>
                                </div>
                            </div>
                            <!--Mô tả-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Mô tả:
                                </div>
                                <div class="span10">
                                    <textarea runat="server" id="textarea_Descripstion" style="min-height: 50px; width: 100%;"></textarea>
                                    <span>Mô tả thêm. Phần mô tả sẽ hiển thị khi rê chuột vào tiêu đề Loại </span>
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
                                    <asp:FileUpload runat="server" ID="FileUpload_Avatar" class="skip" preview="avatar-preview" />
                                    <br />
                                    <span>Hình đại diện cho bài báo. Bạn có thể upload hình mới nếu muốn.
                                                    Các Loại file hỗ trợ: *.jpg, *.jpeg, *.gif, *.png
                                    </span>
                                </div>
                            </div>
                            <!--Trạng thái-->
                            <div class="row-form clearfix">
                                <div class="span2">
                                    Trạng thái:
                                </div>
                                <div class="span10">
                                    <label class="checkbox inline">
                                        <input runat="server" id="radio_Active" type="radio" checked />
                                        Cho phép hiển thị
                                    </label>
                                    <label class="checkbox inline">
                                        <input runat="server" id="radio_Lock" type="radio" />
                                        Tạm ẩn
                                    </label>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!--Button-->
        <div class="row-fluid">
            <div class="span12" style="margin-top: -20px; background-color: #F2F2F2;">
                <div class="block-fluid customize">
                    <div class="row-form clearfix">
                        <div class="span2">
                            <asp:LinkButton runat="server" ID="LinkButton_Save" class="btn mybtn" OnClick="LinkButton_Save_Click">
<i class="isw-save"></i>
Lưu
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
            <a href="ProductList.aspx" type="button" class="btn active">
                <i class="icon-arrow-left"></i>Trở về trang tin tức
            </a>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" Runat="Server">
</asp:Content>

