using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CodeUtility;

public partial class Admin_AccountList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.HideAll();
            LoadCategory();
            LoadData();
        }
    }

    public void LoadCategory()
    {
        DBEntities db = new DBEntities();
        var data = db.AccountCategories.Select(x => new
        {
            x.AccountCategoryID,
            x.Title
        });

        DropDownList_Category.DataValueField = "AccountCategoryID";
        DropDownList_Category.DataTextField = "Title";



        DropDownList_Category.DataSource = data.ToList();
        DropDownList_Category.DataBind();

        //thêm 1 item mặc định trong dropdown
        ListItem defaultitem = new ListItem("Mời chọn thể loại", string.Empty);
        DropDownList_Category.Items.Insert(0, defaultitem);

    }
    public void LoadData()
    {
        DBEntities db = new DBEntities();
        var query = from c in db.AccountCategories
                    from a in c.Accounts
                    orderby a.UserName
                    select new
                    {
                        a.UserName,
                        a.Avatar,
                        a.FullName,
                        a.Email,
                        a.Mobi,
                        a.Address,
                        a.Gender,
                        a.Status,
                        a.CreateTime,
                        CatTitle = c.Title,
                        CatID = c.AccountCategoryID
                    };

        string catID = DropDownList_Category.SelectedValue;
        string keyword = input_KeyWord.Value.Trim();

        //nếu có chọn tìm theo thể loại thì thêm đk


        //nếu có nhập keyword, thì thêm điều kiện
        if (catID != string.Empty)
        {
            query = query.Where(x => x.CatID == catID);
        }

        if (keyword != string.Empty)
        {
            query = query.Where(x => x.UserName.Contains(keyword) ||
            x.FullName.Contains(keyword) ||
            x.Mobi.Contains(keyword) ||
            x.Email.Contains(keyword)
            );
        }

        Repeater_Main.DataSource = query.ToList();
        Repeater_Main.DataBind();
    }

    protected void LinkButton_SaveAvatar_Click(object sender, EventArgs e)
    {
        //tìm username cần đổi hình
        LinkButton LinkButton_SaveAvatar = sender as LinkButton;
        string username = LinkButton_SaveAvatar.CommandArgument;

        //tìm FileUpload đang chọn hình
        FileUpload FileUpload_Avatar = LinkButton_SaveAvatar.NamingContainer.FindControl("FileUpload_Avatar") as FileUpload;

        //lưu hình vào thư mục
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

            //tìm item cần edit hình ảnh
            DBEntities db = new DBEntities();
            var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();

            //nếu không tìm thấy thì báo lỗi
            if (item == null)
            {
                ucMessage.ShowError("Dữ liệu này không tồn tại");
                LoadData();
                return;
            }
            item.Avatar = saveUrl;
            item.Thumb = saveUrl;

            //lưu thay đổi
            db.SaveChanges();

            //update session
            SessionUility.AdminAvatar = saveUrl;

            ucMessage.ShowSuccess("đã cập nhật thành công");
            LoadData();

        }
    }

    protected void LinkButton_Delete_Click(object sender, EventArgs e)
    {
        //lấy username cần xóa
        LinkButton LinkButton_Delete = sender as LinkButton;
        string username = LinkButton_Delete.CommandArgument;

        //nếu là user đang login thì không cho xóa

        if (username == SessionUility.AdminUsername)
        {
            ucMessage.ShowError("không đc xóa tài khoản đang đăng nhập");
            return;
        }

        //tìm item cần xóa
        DBEntities db = new DBEntities();
        var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();
        //nếu không có thì báo lỗi
        if (item == null)
        {
            ucMessage.ShowError("dữ liệu này đã không còn tồn tại");
            LoadData();
            return;
        }

        //thử xóa trong bảng
        db.Accounts.Remove(item);
        try
        {
            db.SaveChanges();
        }
        catch (Exception)
        {

            ucMessage.ShowError("không thể xóa tài khoản này do có dữ liệu ràng buộc");
            return;
        }

        LoadData();
        ucMessage.ShowSuccess("Đã xóa tài khoản thành công");
    }

    protected void LinkButton_Status_Click(object sender, EventArgs e)
    {
        LinkButton LinkButton_Status = sender as LinkButton;
        string username = LinkButton_Status.CommandArgument;
        if (SessionUility.AdminUsername == username)
        {
            ucMessage.ShowWarning("Điên hay gì mà đi xóa chính mình");
            return;
        }

        //VÀo db để tìm 1 cái Account phù hợp

        DBEntities db = new DBEntities();
        var item = db.Accounts.Where(x => x.UserName == username).FirstOrDefault();

        //nếu không tồn tại,thì load lại
        if (item == null)
        {
            LoadData();
            return;
        }

        //cập nhật status
        item.Status = !item.Status;
        db.SaveChanges();

        LoadData();

        //thông báo
        ucMessage.ShowSuccess("đã cập nhật trạng thái");
    }



    protected void LinkButton_Search_Click(object sender, EventArgs e)
    {
        LoadData();
    }

    protected void LinkButton_ClearSearch_Click(object sender, EventArgs e)
    {
        DropDownList_Category.SelectedValue = string.Empty;
        input_KeyWord.Value = string.Empty;
        LoadData();
    }

    protected void DropDownList_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}