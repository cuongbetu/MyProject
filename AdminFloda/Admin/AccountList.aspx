<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AccountList.aspx.cs" Inherits="Admin_AccountList" %>

<%@ Register Src="~/Admin/UserControl/ucMessage.ascx" TagPrefix="uc1" TagName="ucMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <div class="workplace">
        <div class="page-header">
            <h1>
                Quản lý tài khoản
            </h1>
        </div>
        <div class="row-fluid">
            <div class="span12">
                <div class="head clearfix">
                    <div class="isw-users">
                    </div>
                    <h1>Danh sách tài khoản 2
                    </h1>
                    <ul class="buttons">
                        <li>
                            <a href="AccountEdit.aspx" class="isw-plus tip" title="Thêm mới"></a>
                        </li>
                        <li>
                            <a href="#" class="isw-delete tip" title="Xóa chọn"></a>
                        </li>
                    </ul>
                </div>
                <div class="block-fluid table-sorting clearfix">
                    <!--Filter-->
                    <div class="dataTables_filter">
                        <asp:Panel runat="server" DefaultButton="LinkButton_Search" class="input-append">
                            <asp:DropDownList Style="margin-right: 10px; border-radius: 4px;" OnSelectedIndexChanged="DropDownList_Category_SelectedIndexChanged" AutoPostBack="true"
                                ID="DropDownList_Category" runat="server" />
                            <input runat="server" id="input_KeyWord" type="text" placeholder="Lọc theo: tên đăng nhập, họ tên, email hoặc SĐT" style="width: 350px" />
                            <asp:LinkButton ID="LinkButton_Search" runat="server" class="btn mybtn input-icon link-search" Style="width: 16px;"
                                OnClick="LinkButton_Search_Click">
                                <i class="isw-zoom"></i>&nbsp;
                            </asp:LinkButton>
                        </asp:Panel>
                    </div>

                    <div class="dataTables_length">
                        <asp:LinkButton runat="server" ID="LinkButton_ClearSearch" class="btn input-icon" Style="width: 80px;"
                            OnClick="LinkButton_ClearSearch_Click">
                            <i class="isw-cancel"></i>Hủy bộ lọc
                        </asp:LinkButton>
                    </div>
                    <!--Content-->
                    <table cellpadding="0" cellspacing="0" width="100%" class="table listAccounts">
                        <tbody>
                            <asp:Repeater ID="Repeater_Main" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td width="102">
                                            <a href='<%# Eval("Avatar") %>' class="fancybox lightbox-preview" rel="group" title='<%# Eval("FullName") %>'>
                                                <img src='<%# Eval("Avatar") %>' alt="avatar" style="width: 92px; height: 92px; margin-bottom: 2px;" class='<%# Eval("Username","default-image img-polaroid avatar-preview-{0}") %>' original="~/FileUploads/Account/thumbs/8761ea0b-776c-4504-a845-58d5617d90f4.png" title="Lê Minh Hiếu" />
                                            </a>
                                            <div class="btn-group">
                                                <button class="btn btn-small btn-success btn-file" style="width: 102px; cursor: pointer;">
                                                    <span class="icon-camera icon-white"></span>
                                                    Thay hình
                                                      <asp:FileUpload class="skip" preview='<%# Eval("Username","avatar-preview-{0}") %>' runat="server" ID="FileUpload_Avatar" />
                                                </button>
                                            </div>
                                            <div class="btn-group none-margin hide save-cancel-function">
                                                <asp:LinkButton ID="LinkButton_SaveAvatar" OnClick="LinkButton_SaveAvatar_Click" runat="server" title="Lưu hình"
                                                    class="btn btn-warning tip save" CommandArgument='<%# Eval("UserName") %>'><i class="isw-save"></i></asp:LinkButton>
                                                <button class="btn btn-inverse tip cancel" title="Hủy lệnh">
                                                    <i class="isw-cancel"></i>
                                                </button>
                                            </div>
                                        </td>
                                        <td width="250">
                                            <a href="#" class="account">
                                                <%# Eval("FullName") %>
                                            </a>
                                            <p class="about">
                                                <span class="tip icon-user" title="Username"></span>
                                                <%# Eval("UserName") %>
                                                <br />
                                                <span class="tip icon-envelope" title="Email"></span>
                                                <%# Eval("Email") %>
                                                <br />
                                                <span class="tip icon-time" title="Ngày khởi tạo tài khoản"></span>
                                                <%# Eval("CreateTime","{0:dd/MM/yyyy}") %>
                                                <br />
                                                <span class="tip icon-bell" title="Số điện thoại"></span>
                                                <%# Eval("Mobi") %>
                                                <br />
                                                <span class="tip icon-adjust" title="Phái"></span>
                                                <%# Eval("Gender").ToBool() == true ? "Nam" : "Nữ" %>
                                                <br />
                                            </p>
                                        </td>
                                        <td>
                                            <p class="about">
                                                <span class="tip icon-warning-sign" title="Vai trò"></span>
                                                <%# Eval("CatTitle") %>
                                                <br />
                                                <span class="tip icon-home" title="Địa chỉ"></span>
                                                <%# Eval("Address") %>
                                            </p>
                                        </td>
                                        <td width="200" class="function">
                                            <p class="info">
                                                <a class="btn btn-small btn-block block tip" href='<%# Eval("UserName", "/Admin/AccountPasswordChange.aspx?id={0}") %>'>
                                                    <span class="icon-refresh icon-white"></span>Đổi mật khẩu mới
                                                </a>

                                                <a class="btn btn-small btn-block block tip" href='<%# Eval("UserName", "/Admin/AccountEdit.aspx?id={0}") %>'>
                                                    <span class="icon-edit icon-white"></span>Chỉnh sửa thông tin
                                                </a>
                                                <asp:LinkButton class="btn btn-small btn-block block tip"
                                                    ID="LinkButton_Delete" runat="server" CommandArgument='<%# Eval("UserName") %>' OnClick="LinkButton_Delete_Click">
                                                    <span class="icon-trash icon-white"></span>Xóa dữ liệu này
                                                </asp:LinkButton>
                                                <asp:LinkButton class='<%# Eval("Status").ToBool() == true ? "btn btn-small btn-success tip" : "btn btn-small btn-warning tip" %>'
                                                    ID="LinkButton_Status" runat="server" CommandArgument='<%# Eval("UserName") %>' OnClick="LinkButton_Status_Click">
                                                    <span class='<%# Eval("Status").ToBool() == true ? "icon-ok icon-white" : "icon-lock icon-white" %>'></span>
                                                    <%# Eval("Status").ToBool() == true ? "Đang kích hoạt,tạm khóa lại" : "Đang tạm khóa,kích hoạt lại" %>i
                                                </asp:LinkButton>
                                            </p>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <!--Pagging-->
                    <uc1:ucMessage runat="server" ID="ucMessage" />
                </div>
            </div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="Server">
</asp:Content>

