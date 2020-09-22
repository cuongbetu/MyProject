using CodeUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProductEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ucMessage.ShowInfo("type something");
            LoadCategory();
            LoadDetail();
            //LoadData();
        }
    }
    public void LoadCategory()
    {
        DBEntities db = new DBEntities();
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
    }

    public void LoadDetail()
    {
        ucMessage.ShowInfo("Mời nhập thông tin");
        int id = Request.QueryString["id"].ToInt();
        if (id <= 0)
            return;
        //vào db lấy 1 item có id phù hợp
        DBEntities db = new DBEntities();
        var item = db.Products
            .Where(x => x.ProductID == id).FirstOrDefault();

        //kiểm tra tồn tại
        if (item == null)
        {
            return;
        }

        //khóa ô ID, không cho nhập
        input_ID.Disabled = true;

        //đổ vào form chi tiết
        DropDownList_Category.SelectedValue = item.ProductCategoryID.ToString();
        input_ID.Value = item.ProductID.ToString();
        input_Position.Value = item.Position.ToString();
        input_Code.Value = item.Code;
        input_Title.Value = item.Title;
        textarea_Descripstion.Value = item.Description;


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
    protected void LinkButton_Save_Click(object sender, EventArgs e)
    {
        //lấy id đang chọn
        int id = Request.QueryString["id"].ToInt();

        DBEntities db = new DBEntities();

        //nếu có id, thì kiểm tra tồn tại rồi UPDATE
        if (id > 0)
        {
            var item = db.Products.Where(x => x.ProductID == id).FirstOrDefault();

            if (item == null)
            {
                ucMessage.ShowError("Dữ liệu này không tồn tại.");
                return;
            }
            string title = input_Title.Value.Trim();

            //tiêu đề không rỗng
            if (title == string.Empty)
            {
                ucMessage.ShowError("vui lòng nhập tiêu đề");
                input_Title.Focus();
                return;
            }

            //nhập các thông tin mới
            item.ProductCategoryID = DropDownList_Category.SelectedValue.ToInt();
            item.Position = input_Position.Value.ToInt();
            item.Code = input_Code.Value.Trim();
            item.Title = input_Title.Value.Trim();
            item.Description = textarea_Descripstion.Value.Trim();



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
                string folderUrl = "/fileuploads/ProductCategory/";
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
            item.CreateBy = SessionUility.AdminUsername;

            //lưu db
            db.SaveChanges();
            Response.Redirect("/Admin/ProductList.aspx?message=1");
        }

        //Ngược lại.thì INSERT
        else
        {

            Product item = new Product();
            string title = input_Title.Value.Trim();

            //tiêu đề không rỗng
            if (title == string.Empty)
            {
                ucMessage.ShowError("vui lòng nhập tiêu đề");
                input_Title.Focus();
                return;
            }


            //nhập thông tin
            item.ProductCategoryID = DropDownList_Category.SelectedValue.ToInt();
            item.Code = input_Code.Value.Trim();
            item.Position = input_Position.Value.ToInt();
            item.Title = input_Title.Value.Trim();
            item.Description = textarea_Descripstion.Value.Trim();


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
                string folderUrl = "/fileuploads/Product/";
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
            item.CreateBy = SessionUility.AdminUsername;

            //lưu db
            db.Products.Add(item);
            db.SaveChanges();

            Response.Redirect("/Admin/ProductList.aspx?message=2");
        }
    }
}