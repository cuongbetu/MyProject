﻿using CodeUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AccountCategoryList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.ShowInfo("Xin mời nhập thông tin");
            LoadData();
        }
    }

    public void LoadData()
    {
        DBEntities db = new DBEntities();
        var data = db.AccountCategories.OrderBy(x => x.Position).Select(x => new
        {
            x.AccountCategoryID,
            Title = x.AccountCategoryID + "-" + x.Title
        });

        DropDownList_Main.DataValueField = "AccountCategoryID";
        DropDownList_Main.DataTextField = "Title";



        DropDownList_Main.DataSource = data.ToList();
        DropDownList_Main.DataBind();

        //thêm 1 item mặc định trong dropdown
        ListItem defaultitem = new ListItem("Mời chọn thể loại", string.Empty);
        DropDownList_Main.Items.Insert(0, defaultitem);
    }

    public void LoadDetail()
    {
        ucMessage.ShowInfo("Mời nhập thông tin");
        //lấy id đang chọn
        string id = DropDownList_Main.SelectedValue;

        //vào db lấy 1 item có id phù hợp
        DBEntities db = new DBEntities();
        var item = db.AccountCategories
            .Where(x => x.AccountCategoryID == id).FirstOrDefault();

        //kiểm tra tồn tại
        if (item == null)
        {
            ucMessage.ShowError("dữ liệu không tồn tại");
            LoadData();
            return;
        }

        //khóa ô ID, không cho nhập
        input_ID.Disabled = true;

        //đổ vào form chi tiết
        input_ID.Value = item.AccountCategoryID;
        input_Position.Value = item.Position.ToString();
        input_Title.Value = item.Title;
        textarea_Description.Value = item.Description;
        //upload file hình
        a_Avatar.HRef = item.Avatar;
        img_Avatar.Src = item.Avatar;

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
    }

    public void ClearFrom()
    {
        ucMessage.ShowInfo("mời nhập thông tin");
        DropDownList_Main.SelectedValue = string.Empty;
        //mở khóa ô ID
        input_ID.Disabled = false;

        input_ID.Value = string.Empty;
        input_Position.Value = string.Empty;
        input_Title.Value = string.Empty;
        textarea_Description.Value = string.Empty;

        a_Avatar.HRef = "/Admin/css/img/no_image.jpg";
        img_Avatar.Src = "/Admin/css/img/no_image.jpg";
        radio_Lock.Checked = false;
        radio_Active.Checked = true;


    }
    protected void DropDownList_Main_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDetail();
    }

    protected void LinkButton_Add_Click(object sender, EventArgs e)
    {
        ClearFrom();
    }

    protected void LinkButton_Delete_Click(object sender, EventArgs e)
    {
        //lấy id cần xóa
        string id = DropDownList_Main.SelectedValue;

        //nếu chưa chọn thì nhắc chọn 1 item để xóa

        if (id == string.Empty)
        {
            ucMessage.ShowError("Mời chọn 1 item để xóa");
            return;
        }

        //tìm item cần xóa
        DBEntities db = new DBEntities();
        var item = db.AccountCategories.Where(x => x.AccountCategoryID == id).FirstOrDefault();
        //nếu không có thì báo lỗi
        if (item == null)
        {
            ucMessage.ShowError("dữ liệu này đã không còn tồn tại");
            LoadData();
            return;
        }

        //thử xóa trong bảng
        db.AccountCategories.Remove(item);
        try
        {
            db.SaveChanges();
        }
        catch (Exception)
        {

            ucMessage.ShowError("không thể xóa loại tài khoản này do có dữ liệu ràng buộc");
            return;
        }

        LoadData();
        ClearFrom();
        ucMessage.ShowSuccess("Đã xóa loại tài khoản thành công");
    }

    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        //lấy id đang chọn
        string id = DropDownList_Main.SelectedValue;

        DBEntities db = new DBEntities();

        //nếu có id, thì kiểm tra tồn tại rồi UPDATE
        if (id != string.Empty)
        {
            var item = db.AccountCategories.Where(x => x.AccountCategoryID == id).FirstOrDefault();

            if (item == null)
            {
                ucMessage.ShowError("tài khoản này không tồn tại. <a href='/Admin/AccountList.aspx'>Xem danh sách</a>");
                return;
            }

            //kiểm tra hợp lệ
            //id không rỗng
            if (input_ID.Value.Trim() == string.Empty)
            {
                ucMessage.ShowError("Vui lòng nhập mã loại");
                input_ID.Focus();
                return;
            }



            //nhập các thông tin mới

            item.Position = input_Position.Value.ToInt();
            item.Title = input_Title.Value.Trim();
            item.Description = textarea_Description.Value.Trim();


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
                string folderUrl = "/fileuploads/AccountCategory/";
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

            item.Status = radio_Active.Checked ? true : false;


            //lưu db
            db.SaveChanges();
            LoadData();
            ClearFrom();
            ucMessage.ShowSuccess("Đã lưu dữ liệu.");
        }

        //Ngược lại.thì INSERT
        else
        {
            AccountCategory item = new AccountCategory();
            //kiểm tra hợp lệ
            //kiểm tra id ko rỗng
            string newID = input_ID.Value.Trim();

            if (newID == string.Empty)
            {
                ucMessage.ShowError("vui lòng nhập ID");
                input_ID.Focus();
                return;
            }

            //id ko trùng
            var validateItem = db.AccountCategories.Where(x => x.AccountCategoryID == newID).FirstOrDefault();
            if (validateItem != null)
            {
                ucMessage.ShowError("Id đã tồn tại");
                input_ID.Focus();
                return;
            }

            //nhập thông tin
            item.AccountCategoryID = input_ID.Value;
            item.Position = input_Position.Value.ToInt();
            item.Title = input_Title.Value.Trim();
            item.Description = textarea_Description.Value.Trim();

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
                string folderUrl = "/fileuploads/AccountCategory/";
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

            item.Status = radio_Active.Checked ? true : false;


            //lưu db
            db.AccountCategories.Add(item);
            db.SaveChanges();
            //load lại dữ liệu
            LoadData();

            // xóa form
            ClearFrom();

            //thông báo
            ucMessage.ShowSuccess("Đã lưu dữ liệu");
        }
    }
}