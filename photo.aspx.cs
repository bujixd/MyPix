using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class photo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object u = Session["userid"];
        if (u == null)
        {
            Response.Write("<script languge='javascript'>alert('please login')</script>");
            Response.Redirect("Login.aspx");
        }
        Object i = Request["Id"];
        if (i == null) {
            Response.Write("<script languge='javascript'>alert('wrong id')</script>");
            Response.Redirect("Photos.aspx");
        }
        int Id = int.Parse(Request["Id"]);
        String selectStr = "select photo,title,WhenPosted,user_name,PosterId from Photos,Posters where PhotosId = " + Id + "and Photos.PostersId = Posters.PosterId";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(selectStr, conn);
        try
        {
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                String url = sdr.GetString(0);
                Image.ImageUrl = url;
                String t = sdr.GetString(1);
                title.Text = t;
                content.Text ="username:" + sdr.GetString(3) + "</br> posted Time: " + sdr.GetDateTime(2);
                Literal1.Text = Convert.ToString(sdr.GetInt32(4));
            }
        }
        catch (SqlException exn)
        {
            Response.Write("<script languge='javascript'>alert('something wrong')</script>");
        }
        finally {
            conn.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int Id = int.Parse(Request["Id"]);
        String t = ctitle.Text;
        String text = comment.Text;
        int pid = int.Parse(Literal1.Text);
        String sql = "insert into Comments(WhenPosted,Tittle,Text,PhotosId,PosterId) values(GetDate(),'"+t+"','"+text+"',"+Id+","+pid+")";
        ExecuteSQl es = new ExecuteSQl();
        es.ExcuteSql(sql);
        Response.Redirect(Request.Url.ToString());
    }
    protected void ctitle_TextChanged(object sender, EventArgs e)
    {

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
   
    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}