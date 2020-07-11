using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for docCheck
/// </summary>
public class docCheck : IHttpHandler
{
    public bool IsReusable
    {
        get { return false; }
    }

    public void ProcessRequest(HttpContext context)
    {
       string MyReferrer = context.Request.Path;
        if ((context.Request.ServerVariables["HTTP_REFERER"] == null) || (context.Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            context.Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = context.Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = context.Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                context.Response.Redirect("~/Error.aspx");
            }
        }
        string path = MyReferrer.ToLower();
        if (path.Contains("Seed_UI") || path.Contains("SalesPoint"))
        {
            var Role = context.Session["Role"];
            if (Role != null)
            {
            }
            else { context.Response.Redirect("~/Error.aspx"); }
        }
        context.Response.Buffer = true;
        context.Response.Clear();
        context.Response.AddHeader("content-disposition", context.Request.Url.AbsolutePath);
        context.Response.ContentType = "application/pdf";
        context.Response.WriteFile(context.Server.MapPath(context.Request.Url.AbsolutePath)); 
    }  
}