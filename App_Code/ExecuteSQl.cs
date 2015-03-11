using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

/// <summary>
/// </summary>
public class ExecuteSQl
{
    public ExecuteSQl()
    {
       
    }
    /// <summary>
    /// </summary>
    public string conString
    {
        get
        {
            string con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            if (con != null || con != "")
            {
                return con;
            }
            else
            {
                return null;
            }
        }
    }
    /// <summary>
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public int ExcuteSql(string sql)
    {
        string conStr = conString;
        SqlConnection con = new SqlConnection(conStr);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteNonQuery();
        }
        catch
        {
            return 0;
        }
        finally
        {
            con.Close();
        }
    }

    public Boolean ExcuteRead(string sql)
    {
        string conStr = conString;
        SqlConnection con = new SqlConnection(conStr);
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
                return true;
            else
                return false;

        }
        catch
        {
            return false;
        }
        finally
        {
            con.Close();
        }
    }
}
