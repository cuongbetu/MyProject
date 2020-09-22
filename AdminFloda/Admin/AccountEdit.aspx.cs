using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CodeUtility;

public partial class Admin_AccountEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.ShowInfo("Chỉnh sửa thông tin tài khoản");
            LoadCategory();
            LoadData();
        }
    }

    public void LoadCategory()
    {
        DBEntities db = new DBEntities();
        var data = db.AccountCategories.OrderBy(x => x.Position)
            .Select(x => new
            {
                x.AccountCategoryID,
                x.Title
            }).ToList();

        DropDownList_Category.DataValueField = "AccountCategoryID";
        DropDownList_Category.DataTextField = "Title";


        DropDownList_Category.DataSource = data;
        DropDownList_Category.DataBind();


    }
    public void LoadData()
    {
        //Nếu có id trên url, thì load dữ liệu hiện có để hiệu chỉnh
        string username = Request.QueryString["id"].ToSafetyString();
        if (username == string.Empty)
        {
            return;
        }
        DBEntities db = new DBEntities();
        var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();

        //nếu không có,thì báo lỗi 
        if (item == null)
        {
            ucMessage.ShowError("tài khoản này không tồn tại. <a href='/Admin/AccountList.aspx'>Xem danh sách</a>");
            return;
        }

        //đổ categoryID
        DropDownList_Category.SelectedValue = item.AccountCategoryID.ToSafetyString();
        //đổ những thông tin khác

        input_Username.Value = item.UserName;
        input_Password.Value = item.PassWord;
        input_Repassword.Value = item.PassWord;
        if (item.Status == true)
        {
            radio_Lock.Checked = false;
            radio_Active.Checked = true;
        }
        else
        {
            radio_Active.Checked = false;
            radio_Lock.Checked = true;
        }

        input_FullName.Value = item.FullName;
        input_Email.Value = item.Email;
        input_Mobi.Value = item.Mobi;
        textarea_Adress.Value = item.Address;
        a_Avatar.HRef = item.Avatar;
        img_Avatar.Src = item.Avatar;
        if (item.Gender == true)
        {
            radio_Female.Checked = false;
            radio_Male.Checked = true;
        }
        else
        {
            radio_Male.Checked = false;
            radio_Female.Checked = true;
        }

    }

    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        // lấy id url
        string username = Request.QueryString["id"].ToSafetyString();
        DBEntities db = new DBEntities();


        //nếu có id, thì kiểm tra tồn tại rồi UPDATE
        if (username != string.Empty)
        {
            var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();

            if (item == null)
            {
                ucMessage.ShowError("tài khoản này không tồn tại. <a href='/Admin/AccountList.aspx'>Xem danh sách</a>");
                return;
            }
            //nhập các thông tin mới
            item.AccountCategoryID = DropDownList_Category.SelectedValue;

            if (input_Password.Value == input_Repassword.Value
                && input_Password.Value.Trim() != string.Empty)
                item.PassWord = input_Password.Value.Trim();

            item.Status = radio_Active.Checked ? true : false;
            item.FullName = input_FullName.Value.Trim();
            item.Email = input_Email.Value.Trim();
            item.Mobi = input_Mobi.Value.Trim();
            item.Address = textarea_Adress.Value.Trim();
            item.Gender = radio_Male.Checked ? true : false;

            //upload hình ảnh
            //kiêm tra có file được chọn thì mới upload
            if (FileUpload_Avatar.HasFile)
            {
                //kiểm tra cái file có cái đuôi hợp lệ: .jpg.png.gif.jpeg
                string validFile = ".jpg.png.gif.jpeg";
                string filename = FileUpload_Avatar.FileName;
                string extension = Path.GetExtension(filename).ToLower();
                if (!validFile.Contains(extension))
                {
                    ucMessage.ShowError("vui lòng chọn ảnh có đuôi: .jpg.png.gif.jpeg");
                    return;
                }
                //chọn thư mục lưu trữ
                string folderUrl = "/Images/Account/";
                //tạo tên file ngẫu nhiên để lưu trữ
                string randomName = Guid.NewGuid().ToString();
                //tạo url lưu trữ = folder + tên ngẫu nhiên + đuôi upload
                string saveUrl = folderUrl + randomName + extension;
                //upload vào saveUrl
                FileUpload_Avatar.SaveAs(Server.MapPath(saveUrl));
                //cập nhập vào item của db
                item.Avatar = saveUrl;
                item.Thumb = saveUrl;
            }



            //lưu db
            db.SaveChanges();
            ucMessage.ShowSuccess("Đã lưu. <a href='/Admin/AccountList.aspx'>Xem danh sách</a>");
            //update session
            SessionUility.AdminFullName = item.FullName;
            SessionUility.AdminAvatar = item.Avatar;
        }

        //Ngược lại.thì INSERT
        else
        {
            //kiểm tra hợp lệ tự làm
            //tạo 1 account mới
            Account item = new Account();

            //nhập thông tin vào
            item.UserName = input_Username.Value.Trim();
            item.AccountCategoryID = DropDownList_Category.SelectedValue;

            if (input_Password.Value != input_Repassword.Value
                || input_Password.Value.Trim() == string.Empty)
            {
                ucMessage.ShowError("hãy nhập mật khẩu 2 lần giống nhau");
                return;
            }
            item.PassWord = input_Password.Value.Trim();

            item.Status = radio_Active.Checked ? true : false;
            item.FullName = input_FullName.Value.Trim();
            item.Email = input_Email.Value.Trim();
            item.Mobi = input_Mobi.Value.Trim();
            item.Address = textarea_Adress.Value.Trim();
            item.Gender = radio_Male.Checked ? true : false;


            //upload hình ảnh
            //kiêm tra có file được chọn thì mới upload
            if (FileUpload_Avatar.HasFile)
            {
                //kiểm tra cái file có cái đuôi hợp lệ: .jpg.png.gif.jpeg
                string validFile = ".jpg.png.gif.jpeg";
                string filename = FileUpload_Avatar.FileName;
                string extension = Path.GetExtension(filename).ToLower();
                if (!validFile.Contains(extension))
                {
                    ucMessage.ShowError("vui lòng chọn ảnh có đuôi: .jpg.png.gif.jpeg");
                    return;
                }
                //chọn thư mục lưu trữ
                string folderUrl = "/Images/Account/";
                //tạo tên file ngẫu nhiên để lưu trữ
                string randomName = Guid.NewGuid().ToString();
                //tạo url lưu trữ = folder + tên ngẫu nhiên + đuôi upload
                string saveUrl = folderUrl + randomName + extension;
                //upload vào saveUrl
                FileUpload_Avatar.SaveAs(Server.MapPath(saveUrl));
                //cập nhập vào item của db
                item.Avatar = saveUrl;
                item.Thumb = saveUrl;



            }
            else
            {
                //nếu không chọn hình thì lấy hình mặc định
                item.Avatar = "/Admin/css/img/no_image.png";
                item.Thumb = "/Admin/css/img/no_image.png";
            }
            //cập nhật ngày giờ tạo
            item.CreateTime = DateTime.Now;
            //thêm vào bảng
            db.Accounts.Add(item);

            //lưu db
            db.SaveChanges();

            //thông báo đã lưu
            ucMessage.ShowSuccess("Đã lưu. <a href='/Admin/AccountList.aspx'>Xem danh sách</a>");
        }
    }
}