using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

/// <summary>
/// Summary description for UserInfo
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class UserInfo : System.Web.Services.WebService {
    
    [WebMethod]
    public string GetImageUserid(int N)
    {
        String dirname = Server.MapPath("~/User_Images/");
        String[] filename = Directory.GetFiles(dirname);
        String imageFilename = filename[N % filename.Length];
        String nextFile = Path.GetFileNameWithoutExtension(imageFilename);
        return nextFile;
    }

    public UserInfo () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
}
