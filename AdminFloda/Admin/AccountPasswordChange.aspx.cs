using CodeUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AccountPasswordChange : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.ShowInfo("xin mời nhập mật khẩu mới");
            string username = Request.QueryString["id"].ToSafetyString();
            input_Username.Value = username;
            input_Username.Disabled = true;
        }
    }

    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        string username = Request.QueryString["id"].ToSafetyString();

        //vào db kiểm tra tài khoản
        DBEntities db = new DBEntities();
        var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();
        if (item == null)
        {
            ucMessage.ShowError("tài khoản này không còn tồn tại. <a href'/Admin/Default.aspx'> về trang chủ</a>");
            return;
        }

        string password = input_Password.Value.Trim();
        string rePassword = input_RePassword.Value.Trim();

        if (password == string.Empty || password != rePassword)
        {
            ucMessage.ShowError("Hãy nhập mật khẩu 2 lần giống nhau");
            return;
        }

        item.PassWord = password;
        db.SaveChanges();

        ucMessage.ShowSuccess("đã lưu mật khẩu mới");
        return;
    }
}