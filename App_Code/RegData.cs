using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// </summary>
public class RegData
{

    public String name;
    public String userName;
    public String password;
    public String userProfile;
    public String state;
    public String politic;
    public ArrayList interests = new ArrayList();
    public Boolean ada;

    public RegData(String n, String u, String p, String up, String s,
        String po, ArrayList i, Boolean a) {

            name = n;
            userName = u;
            password = p;
            userProfile = up;
            state = s;
            politic = po;
            for (int j = 0; j < i.Count; j++) {
                interests.Add(i[j]);
            }
            ada = a;
    }

	public RegData()
	{
	
	}
}