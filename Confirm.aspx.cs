using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {
            string guid = Request["user"].ToString();
            if (guid == "")
            {
                Response.Write("<script languge='javascript'>alert('wrong url, please check')</script>");
            }
            string sql = "update Posters set active=1,WhenConfirmed=GetDate() where active='" + guid + "'";
            ExecuteSQl es = new ExecuteSQl();
            if (es.ExcuteSql(sql) != 0)
            {
                Response.Write("<script languge='javascript'>alert('confirm sucessfully')</script>");
            }
            else
            {
                Response.Write("<script languge='javascript'>alert('confirm failed')</script>");
            }
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