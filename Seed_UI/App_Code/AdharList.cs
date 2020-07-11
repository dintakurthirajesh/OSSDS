using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdharList
/// </summary>
public class AdharList
{
	public AdharList()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    public string KahatNo { get; set; }
    public string adharno { get; set; }

    public string GetAdharNo(string KahatNo)
    {
        return adharno;
    }
}