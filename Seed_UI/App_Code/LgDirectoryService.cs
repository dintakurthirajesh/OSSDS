using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Seed_BE;
using Seed_DL;
using System.Data;
/// <summary>
/// Summary description for LgDirectoryService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class LgDirectoryService : System.Web.Services.WebService {
    MasterDAL OBJ = new MasterDAL();
    public LgDirectoryService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public List<LocationBE> GetDistrictMaster()
    {
        List<LocationBE> listdistrict =new  List<LocationBE>();
        DataTable dt = new DataTable();
        dt = OBJ.viewdataDALlg("36");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                LocationBE distlist = new LocationBE();
                distlist.distlgcd = dr["Distcode"].ToString();
                distlist.distlgcd = dr["Distcode_lg"].ToString();
                distlist.distname = dr["DistName"].ToString();
                listdistrict.Add(distlist);
            }
           
            
        }
        

        return listdistrict;
    }
    [WebMethod]
    public List<LocationBE> GetMandalMaster(String Districtcd)
    {
        List<LocationBE> listmandal = new List<LocationBE>();
        DataTable dt = new DataTable();
        dt = OBJ.viewDistdataDAL(Districtcd.ToString(), "R");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                LocationBE mandallist = new LocationBE();
                mandallist.mandalcd = dr["Mandcode"].ToString();
                mandallist.mandallgcd = dr["MandCode_LG"].ToString();
                mandallist.mandalname = dr["MandName"].ToString();
                listmandal.Add(mandallist);
            }


        }


        return listmandal;
    }
    [WebMethod]
    public List<LocationBE> GetVillageMaster(string Districtcd, string mandalcd)
    {
        List<LocationBE> listvillage = new List<LocationBE>();
        DataTable dt = new DataTable();
        dt = OBJ.GetVillages(Districtcd.ToString(), mandalcd, "R");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                LocationBE villagelist = new LocationBE();
                villagelist.villagecd = dr["Villcode"].ToString();
                villagelist.villagelgcd = dr["VillCode_LG"].ToString();
                villagelist.villagename = dr["VillName"].ToString();
                listvillage.Add(villagelist);
            }


        }


        return listvillage;
    }
    [WebMethod]
    public string District_IU(string Distcd, string Distcd_LG, string Distname, string flag)
    {

        LocationBE distlist = new LocationBE();
        if (flag == "I")
        {
            distlist.Flage = "I";
        }
        else if (flag == "U")
        {
            distlist.Flage = "U";
        }
        else
        {            
           distlist.Flage = "R";            
        }
        distlist.distname = Distname;
        distlist.distcd = Distcd;
        distlist.distlgcd = Distcd_LG;
        distlist.userid = "";
        DataTable dt = new DataTable();
        dt = OBJ.insertDistDAL(distlist);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return "Data Not Updated";
        }
      


        return "1";
    }

    [WebMethod]
    public string Mandal_IU(string Distcdcd, string mandalcd, string mandalcd_lg, string Mandalname, string estradistrict, string flag)
    {

        LocationBE mandallist = new LocationBE();
        if (flag == "I")
        {
            mandallist.Flage = "I";
        }
        else if (flag == "U")
        {
            mandallist.Flage = "U";
        }
        else
        {
            mandallist.Flage = "R";
        }
        
        mandallist.distcd = Distcdcd;
        mandallist.mandallgcd = mandalcd_lg;
        mandallist.mandalcd = mandalcd;
        mandallist.mandalname = Mandalname;
        mandallist.userid = "";
        if (estradistrict != "")
        {
            mandallist.distname = estradistrict;
        }
        else
        {
            mandallist.distname = "";
        }
        mandallist.distlgcd = "";
        mandallist.MandalType = "";
        DataTable dt = new DataTable();
        dt = OBJ.insertMandaltDAL(mandallist);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return "Data Not Updated";
        }



        return "1";
    }

    [WebMethod]
    public string Village_IU(string Distcdcd, string mandalcd, string villagecd, string villagecd_lg, string villagename, string flag)
    {

        LocationBE mandallist = new LocationBE();
        if (flag == "I")
        {
            mandallist.Flage = "I";
        }
        else if (flag == "U")
        {
            mandallist.Flage = "U";
        }
        else
        {
            mandallist.Flage = "R";
        }

        mandallist.distcd = Distcdcd;
        mandallist.villagelgcd = villagecd_lg;
        mandallist.mandalcd = mandalcd;
        mandallist.villagecd = villagecd;
        mandallist.villagename = villagename;
        mandallist.userid = "";
        
        DataTable dt = new DataTable();
        dt = OBJ.InsertVillage(mandallist);
        if (dt.Rows.Count > 0)
        {
            return dt.Rows[0][0].ToString();
        }
        else
        {
            return "Data Not Updated";
        }



        return "1";
    }
}
