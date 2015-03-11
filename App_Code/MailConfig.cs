using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// </summary>
public static class MailConfig
{
    /// <summary>
    /// </summary>
    public static string SMTPServer
    {
        get
        {
            string configSMTPServer=ConfigurationManager.AppSettings["SMTPServer"].ToString();
            if (configSMTPServer != null || configSMTPServer != "")
            {
                return configSMTPServer;
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// </summary>
    public static string SMTPUser
    {
        get
        {
            string configSMTPUser = ConfigurationManager.AppSettings["SMTPUser"].ToString();
            if (configSMTPUser != null || configSMTPUser != "")
            {
                return configSMTPUser;
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// </summary>
    public static string SMTPPwd
    {
        get
        {
            string configSMTPPwd = ConfigurationManager.AppSettings["SMTPPwd"].ToString();
            if (configSMTPPwd != null || configSMTPPwd != "")
            {
                return configSMTPPwd;
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// </summary>
    public static int SMTPPort
    {
        get
        {
            string configSMTPPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            if (configSMTPPort != null || configSMTPPort != "")
            {
                return int.Parse(configSMTPPort);
            }
            else
            {
                return 0;
            }
        }
    }
    /// <summary>
    /// </summary>
    public static string DisplayName
    {
        get
        {
            string configDisplay = ConfigurationManager.AppSettings["DisplayName"].ToString();
            if (configDisplay != null || configDisplay != "")
            {
                return configDisplay;
            }
            else
            {
                return null;
            }
        }
    }
}
