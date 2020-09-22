using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeUtility;

public partial class ucAdminInfo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckLogin();
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void CheckLogin()
    {
        if (SessionUility.AdminUsername == null || SessionUility.AdminUsername == string.Empty)
        {
            Response.Redirect("/Admin/Login.aspx");
        }
    }
    public void LoadData()
    {
        a_FullName.InnerHtml = SessionUility.AdminFullName;
        a_FullName.HRef = "/Admin/AccountEdit.aspx?id=" + SessionUility.AdminUsername;

        img_Avatar.Src = SessionUility.AdminAvatar;
        a_ChangePassword.HRef = "/Admin/AccountPasswordChange.aspx?id=" + SessionUility.AdminUsername;

    }

    protected void LinkButton_Logout_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("/Admin/Login.aspx");
    }
}