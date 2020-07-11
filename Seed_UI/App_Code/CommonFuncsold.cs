using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Common
/// </summary>
public class CommonFuncsold
{
    public void ShowAlertMessage(string error)
    {
        Page page = HttpContext.Current.Handler as Page;
        
        if (page != null)
        {
            error = error.Replace("'", "\'");
            ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + error + "');", true);
        }
    }
    public void BindDropDownLists(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {
        // if (ds.Tables.Count > 0)
        //{
        // if (ds.Tables[0].Rows.Count > 0)
        // {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem(strDefaultValue, ""));
        ////ddl.SelectedIndex = 0;
        // }
    }
    public void BindDropDownLists_WithAllOption(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("ALL", "ALL"));
    }

    public void BindDropDownLists_WithAnyOption(DropDownList ddl, DataTable ddt, string textfield, string valuefield, string strDefaultValue)
    {
        ddl.Items.Clear();
        ddl.DataSource = ddt;
        ddl.DataTextField = textfield;
        ddl.DataValueField = valuefield;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("Any", "Any"));
    }


    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    public DateTime Texttodateconverter(string textdate)
    {
        DateTime date = DateTime.Parse(textdate.ToString(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        return date;
    }


    public int GenerateRandomNo()
    {
        int _min = 1000;
        int _max = 9999;
        Random _rdm = new Random();
        return _rdm.Next(_min, _max);
    }


    public string GenerateUniqueText(int length)
    {
        string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; 
        string otp = string.Empty;
        for (int i = 0; i < length; i++)
        {
            string character = string.Empty;
            do
            {
                int index = new Random().Next(0, characters.Length);
                character = characters.ToCharArray()[index].ToString();
            } while (otp.IndexOf(character) != -1);
            otp += character;
        }
        return otp;
    }


    public string[] CalculateFinYearandMonth()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        string[] FinYear = new string[2];
        /*FINANCIAL YEAR - FROM APRIL TO MARCH   
         SO IF MONTH IS APRIL , THEN FINYEAR = CURRENT YEAR - CURRENT YEAR + 1
         ELSE CURRENT YEAR -1 - CURRENT YEAR*/

        if (Month >= 4)
        {
            FinYear[0] = (Year - 1).ToString() + "-" + (Year).ToString().Substring(2);
            FinYear[1] = (Year).ToString() + "-" + (Year + 1).ToString().Substring(2);
        }
        else
        {
            FinYear[0] = (Year).ToString() + "-" + (Year + 1).ToString().Substring(2);
            FinYear[1] = (Year - 1).ToString() + "-" + (Year).ToString().Substring(2);
        }
        return FinYear;

    }

    public void BindFinancialYears(DropDownList ddl)
    {
        string[] years = CalculateFinYearandMonth();
        ddl.Items.Clear();
        ddl.DataSource = years;
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("--Select--", ""));
    }

    public string getCurrentFinancialYear()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        if (Month >= 4)
            return Year.ToString() + "-" + (Year + 1).ToString().Substring(2);
        else
            return (Year - 1).ToString() + "-" + Year.ToString().Substring(2);
    }
    public string getPrviousFinancialYear()
    {
        int Year = DateTime.Now.Year;
        int Month = DateTime.Now.Month;
        if (Month >= 4)
            return (Year - 1).ToString() + "-" + Year.ToString().Substring(2);
        else
            return Year.ToString() + "-" + (Year + 1).ToString().Substring(2);
    }


    //IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    //public string Texttodateconverter(string textdate)
    //{
    //    string date = (DateTime.Parse(textdate.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date).ToString("yyyy-MM-dd"); //objCommon.Texttodateconverter
    //    return date;
    //}

    public decimal IsNumeric(string value)
    {
        decimal result;
        if (decimal.TryParse(value, out result))
            return result;
        else
            return 0;
    }

    public int IsInteger(string value)
    {
        int result;
        if (int.TryParse(value, out result))
            return result;
        else
            return 0;
    }



    public string ConvertNumbertoWords(int number)
    {
        if (number == 0)
            return "Zero";
        if (number < 0)
            return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000000000) + " Billion ";
            number %= 1000000000;
        }

        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " Crore ";
            number %= 10000000;
        }

        //if ((number / 1000000) > 0)
        //{
        //    words += ConvertNumbertoWords(number / 1000000) + " MILLION ";
        //    number %= 1000000;
        //}

        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " Lakhs ";
            number %= 100000;
        }


        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " Thousand ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " Hundred ";
            number %= 100;
        }
        if (number > 0)
        {
            if (words != "")
                words += "And ";
            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (number < 20)
                words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0)
                    words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }


}