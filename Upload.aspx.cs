using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Upload : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object u = Session["userid"];
        if (u == null)
        {
            Response.Write("<script languge='javascript'>alert('please login')</script>");
            Response.Redirect("Login.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Object user = Session["userid"];
        Object uid = Session["uid"];
        if (user != null)
        {
            if (FileUpload1.HasFile)
            {
                string fileContentType = FileUpload1.PostedFile.ContentType;
                if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/jpeg")
                {
                    string name = FileUpload1.PostedFile.FileName;                  
                    FileInfo file = new FileInfo(name);
                    string fileName = file.Name;                                    
                    string fileName_s = "s_" + file.Name;                          
                    string webFilePath = Server.MapPath("User_Images/" + fileName);        
                    string webFilePath_s = Server.MapPath("User_Images/" + fileName_s);
                    string newfile = fileName.Substring(0, fileName.LastIndexOf("."));
                    string newfile_s = "s_" + newfile;

                    if (!File.Exists(webFilePath))
                    {
                        try
                        {
                  
                            String sql = "insert into Photos(WhenPosted,title,photo,PostersId) values (GetDate(),'" + newfile + "','" + "User_Images/s_" + fileName + "','" + uid + "')";
                            ExecuteSQl es = new ExecuteSQl();
                            int a = es.ExcuteSql(sql);
                            if (a != 0)
                            {
                                FileUpload1.SaveAs(webFilePath);
                                MakeThumbnail(webFilePath, webFilePath_s, 130, 130, "Cut");     
                                Label1.Text = "image: " + fileName + " upload sucessfully";
                                String imageurl = "~/User_Images/" + fileName_s;
                                Image.ImageUrl = imageurl;
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Label1.Text = "upload failed, the reaseon is ：" + ex.Message;
                        }
                    }
                    else
                    {
                        Label1.Text = "image already exist";
                    }
                }
                else
                {
                    Label1.Text = " please input correct type";
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    /**/
    /// <summary>
    /// </summary>
    /// <param name="originalImagePath"></param>
    /// <param name="thumbnailPath"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="mode"></param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);
        int towidth = width;
        int toheight = height;
        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;
        switch (mode)
        {
            case "HW":                
                break;
            case "W":                  
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H":
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut":
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }
        
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
        
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        
        g.Clear(System.Drawing.Color.Transparent);
        
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);
        try
        {
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        Object isAda = Session["ada"];
        if (isAda != null)
        {
            Boolean ada = (Boolean)isAda;
            if (ada)
                Page.Theme = "ADA";
        }

    }
}