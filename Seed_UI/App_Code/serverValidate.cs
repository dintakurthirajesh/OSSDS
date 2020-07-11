using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for serverValidate
/// </summary>
public class serverValidate
{
    public serverValidate()
    {

    }
  
    public bool IsCenterId(string centerId)
    {
        if ((centerId.ToString().Trim() != "") && (centerId != null))
        {
            Regex objCenterId = new Regex("");
            return objCenterId.IsMatch(centerId);
        }
        else
        {
            return true;
        }
    }
    //For Email Address
    public bool IsValidEmail(string strIn)
    {
        // Return true if strIn is in valid e-mail format.
        if (strIn != null)
        {
            return Regex.IsMatch(strIn,
               @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" +
               @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }
        else
        {
            return false;
        }
    }
    //For Mobile No
    public bool ISMobileNo(string strphoneNo)
    {
        //Return true if mobile No starts with 9 8 7 and 10 digits
        if ((strphoneNo.ToString().Trim() != "") && (strphoneNo != null))
        {
            Regex objMobilePattern = new Regex("^([7-9]{1})([0-9]{9})$");
            return objMobilePattern.IsMatch(strphoneNo);
        }
        else
        {
            return false;
        }
    }
    //For Password
    public bool ISValidPassword(string password)
    {
        if ((password.ToString().Trim() != "") && (password != null))
        {
            //Regex objMobilePattern = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
            //return objMobilePattern.IsMatch(password);
            return true;
        }
        else
        {
            return false;
        }
    }
    //IsValidAddress   Min-1, Max-100, -/.,A-Za-z0-9 space is validated string ---------------------------------------- 
    public bool IsValidAddress(string address, int minval, int maxval)
    {
        if ((address.ToString().Trim() != "") && (address != null))
        {
            Regex objMobilePattern = new Regex("^[-/.,A-Za-z0-9\\s]{" + minval + "," + maxval + "}$");
            return objMobilePattern.IsMatch(address);
        }
        else
        {
            return true;
        }
    }
    //for string
    public bool IsUnicodeString(string name,int minval,int maxval)
    {
        if (name.ToString() == "")
        {
            return false;
        }
        if ((name.ToString().Trim() != "") && (name != null))
        {
            Regex objMobilePattern = new Regex("^[.,A-Za-z\\s]{" + minval + "," + maxval + "}$");
            return objMobilePattern.IsMatch(name);
        }
        else
        {
            return true;
        }
    }
    //For Numbers
    public bool IsNumber(string strMobNo, int minval, int maxval)
    {
        if (strMobNo.ToString() == "")
        {
            return false;
        }
        if ((strMobNo.ToString().Trim() != "") && (strMobNo != null))
        {
            Regex objMobilePattern = new Regex("^[0-9]{" + minval + "," + maxval + "}$");
            return objMobilePattern.IsMatch(strMobNo);
        }
        else
        {
            return true;
        }       
    }
}
