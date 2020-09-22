<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AccountCategoryList.aspx.cs" Inherits="Admin_AccountCategoryList" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="workplace">
                    <div class="page-header">
                        <h1>
                            Loại Tài Khoản
                        </h1>
                    </div>

                    <div class="row-fluid">
                        <div class="span3">
                            <div class="head clearfix">
                                <div class="isw-folder">
                                </div>
                                <h1>
                                    Danh sách loại tài khoản
                                </h1>
                            </div>
                            <div class="block-fluid">
                                <div class="row-form clearfix">
                                    <asp:DropDownList size="4" class="category" style="height:475px;"
                                        ID="DropDownList_Main" OnSelectedIndexChanged="DropDownList_Main_SelectedIndexChanged" AutoPostBack="true"
                                        runat="server"/>
                                        
                                </div>
                            </div>
                        </div>
                        <div class="span9">
                            <div class="head clearfix">
                                <div class="isw-list">
                                </div>
                                <h1>
                                    Chi tiết loại tài khoản đang chọn
                                </h1>
                                <ul class="buttons">
                                    <li>
                                        <asp:LinkButton runat="server" ID="LinkButton_Add" OnClick="LinkButton_Add_Click"
									    title="Thêm mới" class="isw-plus tip">
								        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton Text="text" runat="server"
                                            ID="LinkButton_Delete" OnClick="LinkButton_Delete_Click"
                                            title="Xóa chọn" class="isw-delete tip" >

                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                            <div class="block-fluid  customize">
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Mã loại tài khoản:
                                    </div>
                                    <div class="span7">
                                        <input runat="server" id="input_ID" type="text" class="tip" />
                                        <span>Sử dụng chữ cái (hoặc thêm số). Không gõ dấu và không khoảng trắng. VD: SupperAdmin</span>
                                    </div>
                                    <div class="span1">
                                        Vị trí:
                                    </div>
                                    <div class="span2" style="float: right;">
                                        <input runat="server" id="input_Position" type="text" class="tipb" title="Dùng để sắp xếp thứ tự" />
                                        <span>Nhập số hoặc để trống</span>
                                    </div>
                                </div>
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Tiêu đề:
                                    </div>
                                    <div class="span10">
                                        <input runat="server" id="input_Title" type="text"/>
                                        <span>VD: Quản trị cao cấp, quản trị viên, ...</span>
                                    </div>
                                </div>
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Mô tả:
                                    </div>
                                    <div class="span10">
                                        <textarea runat="server" id="textarea_Description" style="min-height: 50px; width: 100%;"></textarea>
                                        <span>Nên mô tả chi tiết về các quyền hoặc các giới hạn của loại tài khoản này.</span>
                                    </div>
                                </div>
                                <!--Hình đại diện-->
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Hình đại diện:
                                    </div>
                                    <div class="span10">
                                        <a runat="server" href="../css/img/no_image.jpg" id="a_Avatar" class="fancybox lightbox-preview" rel="group">
                                            <img runat="server"  src="../css/img/no_image.jpg" id="img_Avatar" alt="avatar" class="default-image img-polaroid avatar-preview" style="width: 180px; height: 135px;" />
                                        </a>
                                        <br />
                                        <asp:FileUpload runat="server" ID="FileUpload_Avatar" type="file" class="skip" preview="avatar-preview"/>
                                        <br />
                                        <span>
                                            Hình đại diện cho loại tài khoản. Bạn có thể upload hình mới nếu muốn.
                                            Các Loại file hỗ trợ: *.jpg, *.jpeg, *.gif, *.png
                                        </span>
                                    </div>
                                </div>
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        Trạng thái:
                                    </div>
                                    <div class="span10">
                                        <label class="checkbox inline">
                                            <input runat="server" id="radio_Active" value="radio_Status_On" type="radio" checked />
                                            Hiển thị
                                        </label>
                                        <label class="checkbox inline">
                                            <input runat="server" id="radio_Lock" value="radio_Status_Off" type="radio" />
                                            Tạm ẩn
                                        </label>
                                    </div>
                                </div>
                                <div class="row-form clearfix">
                                    <div class="span2">
                                        <asp:LinkButton class="btn mybtn" ID="LinkButton_Save"
                                            OnClick="LinkButton_Save_Click"
                                            Text="text" runat="server" >
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
                            <a href="AccountList.aspx" type="button" class="btn active">
                                <i class="icon-arrow-left"></i> Trở về trang danh sách tài khoản
                            </a>
                        </div>
                    </div>

                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" Runat="Server">
</asp:Content>

