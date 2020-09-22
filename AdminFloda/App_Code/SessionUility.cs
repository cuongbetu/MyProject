using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeUtility;

/// <summary>
/// Summary description for SessionUility
/// </summary>
public class SessionUility
{
    public static string AdminUsername
    {
        get
        {
            return HttpContext.Current.Session["AdminUsername"].ToSafetyString();
        }
        set
        {
            HttpContext.Current.Session["AdminUsername"] = value;
        }
    }
    public static string AdminFullName
    {
        get
        {
            return HttpContext.Current.Session["AdminFullName"].ToSafetyString();
        }
        set
        {
            HttpContext.Current.Session["AdminFullName"] = value;
        }
    }
    public static string AdminAvatar
    {
        get
        {
            return HttpContext.Current.Session["AdminAvatar"].ToSafetyString();
        }
        set
        {
            HttpContext.Current.Session["AdminAvatar"] = value;
        }
    }
}