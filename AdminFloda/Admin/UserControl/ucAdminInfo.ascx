<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAdminInfo.ascx.cs" Inherits="ucAdminInfo" %>

<div class="breadLine">
    <div class="arrow"></div>
    <div class="adminControl active">
        Xin chào, <b>admin</b>
    </div>
</div>

<div class="admin">
    <div class="image">
        <img runat="server" id="img_Avatar" src="~/Images/Account/jude-beck-oXDGjyr2LfI-unsplash.jpg" class="use-avatar" />
    </div>
    <ul class="control">
        <li>
            <span class="icon-user"></span>
            <a runat="server" id="a_FullName" href="AccountEdit.aspx?id=admin">Lê Minh Hiếu</a>
        </li>
        <li>
            <span class="icon-cog"></span>
            <a runat="server" id="a_ChangePassword" href="AccountPasswordChange.aspx?id">Đổi mật khẩu</a>
        </li>
        <li>
            <span class="icon-off"></span>
            <asp:LinkButton ID="LinkButton_Logout" Text="Thoát" runat="server" OnClick="LinkButton_Logout_Click" />
        </li>
    </ul>
</div>
