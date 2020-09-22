<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenu.ascx.cs" Inherits="ucMenu" %>

<ul class="navigation">
    <!--Dasboard-->
    <li class="active">
        <a href="/Admin/Default.aspx">
            <span class="isw-grid"></span>
            <span class="text">Bàn Làm Việc</span>
        </a>
        <div class="dr"><span></span></div>
    </li>

    <!--AccountCategory-->
    <li>
        <a href="/Admin/AccountCategoryList.aspx">
            <span class="isw-archive"></span>
            <span class="text">Loại Tài Khoản</span>
        </a>
    </li>

    <!--Account-->
    <li>
        <a href="/Admin/AccountList.aspx">
            <span class="isw-users"></span>
            <span class="text">Tài Khoản</span>
        </a>
        <div class="dr"><span></span></div>
    </li>

    <!--ProductMainCategory-->
    <li>
        <a href="/Admin/ProductMainCategoryList.aspx">
            <span class="isw-folder"></span>
            <span class="text">Sản Phẩm - Cấp Cha</span>
        </a>
    </li>
    <!--ProductCategory-->
    <li>
        <a href="ProductCategoryList.aspx">
            <span class="isw-archive"></span>
            <span class="text">Sản Phẩm - Cấp Con</span>
        </a>
    </li>

    <!--Product-->
    <li>
        <a href="ProductList.aspx">
            <span class="isw-documents"></span>
            <span class="text">Sản Phẩm </span>
        </a>
        <div class="dr"><span></span></div>
    </li>
</ul>
