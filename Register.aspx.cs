using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
        if (!IsValid)
            return;
        String fn = name.Text.Trim();
        String un = UserName.Text.Trim();
        String pwd = password.Text.Trim();
        String em = email.Text.Trim();
        String up = userProfile.Text.Trim();
        Boolean vi = ChooseADA.Checked;
        int vic = 0;
        if (vi)
        {
            vic = 1;
        }
        ExecuteSQl es = new ExecuteSQl();
        String check = "select user_name from Posters where user_name = '" + un + "'";
        Boolean a = es.ExcuteRead(check);
        if (a == true)
        {
            Response.Write("<script languge='javascript'>alert('user already exist')</script>");
        }
        else
        {
            String sql = "insert into Posters(full_name,user_name,password,email,user_profile,visually_impaired,WhenRegistered) values ('" + fn + "','" + un + "','" + pwd + "','" + em + "','" + up + "'," + vic + ",GetDate());";
            if (es.ExcuteSql(sql) != 0)
            {


                SendMail sm = new SendMail();
                string to = em;
                string title = "TestEmail";
                string guid = Guid.NewGuid().ToString();
                string content = @"<a href='http://localhost:53206/Confirm.aspx?user=" + guid
                    + "'>http://localhost:53206/Confirm.aspx?user=" + guid + "</a>";
                if (sm.Send(sm.MakeMail(to, title, content)))
                {
                    string strSql = "update Posters set active='" + guid + "' where user_name='" + un + "'";
                    es.ExcuteSql(strSql);
                    Response.Write("<script languge='javascript'>alert('your registeration already done, please check your email')</script>");
                }
                else
                {
                    Response.Write("<script languge='javascript'>alert('something wrong with your registeration')</script>");
                }
            }
            else
            {
                Response.Write("<script languge='javascript'>alert('something wrong with your registeration')</script>");
            }


            /*HttpCookie cookie = new HttpCookie("Registration");
            cookie["name"] = name.Text;
            cookie["userName"] = UserName.Text;
            cookie["password"] = password.Text;
            cookie["userProfile"] = userProfile.Text;
            cookie["state"] = state.SelectedValue;
            cookie["politic"] = politic.SelectedValue;
            foreach (ListItem item in interests.Items)
            {
                if (item.Selected)
                {
                    cookie.Values.Add("interests", item.Text);
                }
            }
            if (ChooseADA.Checked)
                cookie["ADA"] = "true";
            else
                cookie["ADA"] = "false";
            cookie.Expires = DateTime.Now.AddMonths(3);
            Response.Cookies.Add(cookie);*/
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