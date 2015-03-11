using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Net;
using System.Net.Mail;
using System.Text;

/// <summary>
/// </summary>
public class SendMail
{
	public SendMail()
	{
	}
    public MailMessage MakeMail(string to,string title,string content)
    {
        MailMessage msg = new MailMessage();
        msg.To.Add(to);
        msg.From=new MailAddress (MailConfig.SMTPUser, MailConfig.DisplayName);
        msg.Subject = title;
        msg.Body = content;
        msg.IsBodyHtml = true;
        msg.SubjectEncoding = Encoding.GetEncoding("utf-8");
        msg.BodyEncoding = Encoding.GetEncoding("utf-8");

        return msg;
    }

    public SmtpClient SMTP
    {
        get
        {
            SmtpClient smtp = new SmtpClient(MailConfig.SMTPServer, MailConfig.SMTPPort);
            smtp.Credentials = new NetworkCredential(MailConfig.SMTPUser, MailConfig.SMTPPwd);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            return smtp;
        }
    }

    public bool Send(MailMessage msg)
    {
        try
        {
            SmtpClient smtp = SMTP;
            smtp.Send(msg);
            return true;
        }
        catch (Exception error)
        {
            return false;
        }
    }
}
