<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ProductMainCategoryList.aspx.cs" Inherits="Admin_ProductMainCategoryList" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="workplace">
        <div class="page-header">
            <h1>Thể loại sản phẩm (Cấp 1)
            </h1>
        </div>

        <div class="row-fluid">
            <div class="span3">
                <div class="head clearfix">
                    <div class="isw-folder">
                    </div>
                    <h1>Danh sách loại sản phẩm cấp 1
                    </h1>
                </div>
                <div class="block-fluid">
                    <div class="row-form clearfix">
                        <asp:DropDownList size="4" class="category"
                            Style="height: 508px;" ID="DropDownList_Main"
                            OnSelectedIndexChanged="DropDownList_Main_SelectedIndexChanged"
                            AutoPostBack="true"
                            runat="server" />
                    </div>
                </div>
            </div>
            <div class="span9">
                <div class="head clearfix">
                    <div class="isw-list">
                    </div>
                    <h1>Chi tiết loại đang chọn
                    </h1>
                    <ul class="buttons">
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton_Add" OnClick="LinkButton_Add_Click"
                                title="Thêm mới" class="isw-plus tip">
                            </asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" ID="LinkButton_Delete" title="Xóa chọn"
                                OnClick="LinkButton_Delete_Click"
                                class="isw-delete tip">
                            </asp:LinkButton>
                        </li>
                    </ul>
                </div>
                <div class="block-fluid  customize">
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
                            <textarea runat="server" id="textarea_Description" style="min-height: 50px; width: 100%;"></textarea>
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
                    <!--Lưu + thông báo-->
                    <div class="row-form clearfix">
                        <div class="span2">
                            <asp:LinkButton class="btn mybtn" ID="LinkButton_Save" runat="server"
                                OnClick="LinkButton_Save_Click">
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
            <div class="tar">
                <a href="ArticleList.aspx" type="button" class="btn active">
                    <i class="icon-arrow-left"></i>Trở về trang tin tức
                </a>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" Runat="Server">
</asp:Content>

