﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Photos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Object u = Session["userid"];
        if (u == null) {
            Response.Write("<script languge='javascript'>alert('please login')</script>");
            Response.Redirect("Login.aspx");
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
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
}