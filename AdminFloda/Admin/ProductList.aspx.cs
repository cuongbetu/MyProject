using CodeUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product : System.Web.UI.Page
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
        //var data = db.ProductCategories.Select(x => new
        //{
        //    x.ProductCategoryID,
        //    x.Title
        //});

        var data = from mc in db.ProductMainCategories
                   from c in mc.ProductCategories
                   orderby mc.Position, c.Position
                   select new
                   {
                       c.ProductCategoryID,
                       Title = mc.Title + " - " + c.Title
                   };

        DropDownList_Category.DataValueField = "ProductCategoryID";
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
        //var query = from a in db.Products
        //            from c in db.ProductCategories
        //            from mc in db.ProductMainCategories
        //            where a.ProductCategoryID == c.ProductCategoryID
        //            && c.ProductMainCategoryID == mc.ProductMainCategoryID

        var query = from mc in db.ProductMainCategories
                    from c in mc.ProductCategories
                    from a in c.Products
                    orderby a.CreateTime descending
                    select new
                    {
                        a.ProductID,
                        a.Title,
                        a.Avatar,
                        a.Description,
                        a.CreateTime,
                        a.CreateBy,
                        a.Status,
                        a.ViewTime,
                        CatTitle = c.Title,
                        MainCatTitle = mc.Title,
                        CatID = c.ProductCategoryID
                    };

        int catID = Request.QueryString["catID"].ToInt();
        string keyword = Request.QueryString["keyword"].ToSafetyString();
        int messageCode = Request.QueryString["message"].ToInt();
        if (messageCode == 1)
        {
            ucMessage.ShowSuccess("đã lưu dữ liệu");
        }
        else if (messageCode == 2)
        {
            ucMessage.ShowSuccess("đã thêm dữ liệu");
        }


        //nếu có chọn tìm theo thể loại thì thêm đk


        //nếu có nhập keyword, thì thêm điều kiện
        if (catID > 0)
        {
            DropDownList_Category.SelectedValue = catID.ToString();
            query = query.Where(x => x.CatID == catID);

        }

        if (keyword != string.Empty)
        {
            input_KeyWord.Value = keyword;
            query = query.Where(x => x.Title.Contains(keyword));
        }

        int pageSize = 10; //10 là số phần tử trên mỗi trang
        int maxPage = 5; //5 là số trang tối đã sẽ hiển thị, còn lại là ...
        int page = Request.QueryString["page"].ToInt(); // Trang hiện tại
        if (page <= 0)
            page = 1;
        int totalItems = query.Count();
        // .: Lưu ý sửa lại link cho đúng với trang và điều kiện thực tế của mỗi trang :. \\
        string url = "/Admin/ProductList.aspx?page={0}".StringFormat("{0}");
        ucPagging.TotalItems = totalItems;
        ucPagging.CurrentPage = page;
        ucPagging.PageSize = pageSize;
        ucPagging.MaxPage = maxPage;
        ucPagging.URL = url;
        ucPagging.DataBind();
        Repeater_Main.DataSource = query.Pagging(page, pageSize).ToList();
        Repeater_Main.DataBind();
    }

    public void SearchData()
    {
        string url = "/Admin/ProductList.aspx?";
        int catID = DropDownList_Category.SelectedValue.ToInt();
        string keyword = input_KeyWord.Value.Trim();
        int page = Request.QueryString["page"].ToInt();

        if (catID > 0)
        {
            url += "&catid=" + catID;
        }
        if (keyword != string.Empty)
        {
            url += "&keyword=" + keyword;
        }
        if (page > 0)
        {
            url += "&page=" + page;
        }
        url = url.Replace("?&", "?").Trim('?');

        Response.Redirect(url);
    }

    protected void DropDownList_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void LinkButton_Search_Click(object sender, EventArgs e)
    {
        SearchData();
    }

    protected void LinkButton_ClearSearch_Click(object sender, EventArgs e)
    {
        DropDownList_Category.SelectedValue = string.Empty;
        input_KeyWord.Value = string.Empty;
        SearchData();
    }

    protected void LinkButton_SaveAvatar_Click(object sender, EventArgs e)
    {
        //tìm username cần đổi hình
        LinkButton LinkButton_SaveAvatar = sender as LinkButton;
        int ID = LinkButton_SaveAvatar.CommandArgument.ToInt();

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
            string folderUrl = "/Images/Product/";
            //tạo tên file ngẫu nhiên để lưu trữ
            string randomName = Guid.NewGuid().ToString();
            //tạo url lưu trữ = folder + tên ngẫu nhiên + đuôi upload
            string saveUrl = folderUrl + randomName + extension;
            //upload vào saveUrl
            FileUpload_Avatar.SaveAs(Server.MapPath(saveUrl));

            //tìm item cần edit hình ảnh
            DBEntities db = new DBEntities();
            var item = db.Products.Where(x => x.ProductID == ID).FirstOrDefault();

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


            ucMessage.ShowSuccess("đã cập nhật thành công");
            LoadData();

        }
    }

    protected void LinkButton_Delete_Click(object sender, EventArgs e)
    {
        //lấy username cần xóa
        LinkButton LinkButton_Delete = sender as LinkButton;
        int ID = LinkButton_Delete.CommandArgument.ToInt();


        //tìm item cần xóa
        DBEntities db = new DBEntities();
        var item = db.Products.Where(x => x.ProductID == ID).FirstOrDefault();
        //nếu không có thì báo lỗi
        if (item == null)
        {
            ucMessage.ShowError("dữ liệu này đã không còn tồn tại");
            LoadData();
            return;
        }

        //thử xóa trong bảng
        db.Products.Remove(item);
        try
        {
            db.SaveChanges();
        }
        catch (Exception)
        {

            ucMessage.ShowError("không thể xóa dữ liệu này do có dữ liệu ràng buộc");
            return;
        }

        LoadData();
        ucMessage.ShowSuccess("Đã xóa dữ liệu thành công");
    }

    protected void LinkButton_Status_Click(object sender, EventArgs e)
    {
        LinkButton LinkButton_Status = sender as LinkButton;
        int ID = LinkButton_Status.CommandArgument.ToInt();


        //VÀo db để tìm 1 cái Account phù hợp

        DBEntities db = new DBEntities();
        var item = db.Products.Where(x => x.ProductID == ID).FirstOrDefault();

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
}