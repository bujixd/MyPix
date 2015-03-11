using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpCookie cookie = Request.Cookies.Get("Login");
            if (cookie != null && cookie["Userid"] != null)
            {
                Userid.Text = cookie["Userid"];
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String userid = Userid.Text;
        String selectStr = "select user_name,password,visually_impaired,active,PosterId from Posters where user_name = '" + userid + "'";
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand(selectStr, conn);
        try
        {
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                if (sdr.GetString(3).Equals("1"))
                {
                    if (sdr.GetString(1) == password.Text)
                    {
                        Session["userid"] = userid;
                        Session["ada"] = sdr.GetBoolean(2);
                        Session["uid"] = sdr.GetInt32(4);
                        if (RememberMe.Checked)
                        {
                            HttpCookie cookie = new HttpCookie("Login");
                            cookie.Expires = DateTime.Now.AddDays(7);
                            cookie["Userid"] = userid;
                            Response.Cookies.Add(cookie);
                        }
                        else
                        {
                            Request.Cookies.Remove("Login");
                        }
                        Response.Redirect("Photos.aspx");
                    }
                    else
                    {
                        Warning.Text = "wrong password";
                    }
                }
                else
                {
                    Warning.Text = "please confirm the user though email";
                }
            }
            else
            {
                Warning.Text = "uesr did not exist";
            }
        }
        catch (IOException exn)
        {
            Warning.Text = "user not found (" + exn + ")";
        }
        finally {
            conn.Close();
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

        Object u = Session["userid"];
        if (u != null)
        {
            Session["userid"] = null;
            Session.Remove("userid");
            Session["uid"] = null;
            Session.Remove("uid");
        }
        /*HttpCookie cookie = Request.Cookies.Get("Registration");
        if (cookie != null && cookie["ADA"] == "true")
            Page.Theme = "ADA";*/
    }
}