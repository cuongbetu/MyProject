using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.HideAll();
            ucMessage.ShowInfo("Xin mời đăng nhập ");
        }
    }

    protected void Button_Login_Click(object sender, EventArgs e)
    {
        string username = input_Username.Value.Trim();
        string password = input_Password.Value.Trim();
        DBEntities db = new DBEntities();
        var data = db.Accounts.Where(x => x.UserName == username && x.PassWord == password && x.Status == true).FirstOrDefault();
        if(data != null)
        {
            ucMessage.ShowSuccess("Đăng nhập thành công");
            SessionUility.AdminUsername = data.UserName;
            SessionUility.AdminFullName = data.FullName;
            SessionUility.AdminAvatar = data.Avatar;
            Response.Redirect("/Admin/Default.aspx");
        }
        else
        {
            ucMessage.ShowError("Tài khoản không hợp lệ");
        }
           
    }
}