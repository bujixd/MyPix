using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Comment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object u = Session["userid"];
        if (u == null)
        {
            Response.Write("<script languge='javascript'>alert('please login')</script>");
            Response.Redirect("Login.aspx");
        }
        Object uid = Request["Id"];
        if (uid == null)
        {
            Response.Write("<script languge='javascript'>alert('wrong id')</script>");
            Response.Redirect("Photos.aspx");
        }
        int Id = int.Parse(Request["Id"]);
        String selectStr = "select Tittle,Text,PosterId from Comments where CommentsId = " + Id ;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(selectStr, conn);
        try
        {
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                title.Text = sdr.GetString(0);
                comments.Text = sdr.GetString(1);
                Literal1.Text = Convert.ToString(sdr.GetInt32(2));
            }
            sdr.Close();
            String sql = "select Response.Text,Response.WhenPosted from Response,Comments where Response.CommentsId = " + Id + " and Response.CommentsId = Comments.CommentsId";
            SqlCommand cmd1 = new SqlCommand(sql, conn);
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            int i = 0;
            while (sdr1.Read()) {
                Label lb = new Label();
                lb.ID = "res_" + i;
                DateTime t =  sdr1.GetDateTime(1);
                lb.Text = "<hr>" + sdr1.GetString(0) +"---" + t;
                Panel1.Controls.Add(lb);
                Panel1.Controls.Add(new LiteralControl(" </hr></br> "));
                i++;
            }
        }
        catch (SqlException exn)
        {
            Response.Write("wrong");
        }
        finally
        {
            conn.Close();
        }
    }
    protected void add_Click(object sender, EventArgs e)
    {
        int Id = int.Parse(Request["Id"]);
        String t = TextBox1.Text;
        int l = int.Parse(Literal1.Text);
        String sql = "insert into Response(WhenPosted,Text,CommentsId,PosterId) values(GetDate(),'" + t + "'," + Id + "," + l + ")";
        ExecuteSQl es = new ExecuteSQl();
        es.ExcuteSql(sql);
        Response.Redirect(Request.Url.ToString());
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