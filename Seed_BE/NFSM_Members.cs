using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seed_BE
{
   public  class NFSM_Members
    {
        public string statecd { get; set; }
        public string statelgcd { get; set; }
        public string statename { get; set; }
        public string statename_tel { get; set; }
        public string distcd { get; set; }
        public string distlgcd { get; set; }
        public string distname { get; set; }
        public string DistName_Tel { get; set; }
        public string mandalcd { get; set; }
        public string mandallgcd { get; set; }
        public string MandalType { get; set; }
        public string mandalname { get; set; }
        public string mandalname_tel { get; set; }
        public string panchayatcd { get; set; }
        public string panchayatlgcd { get; set; }
        public string panchayatname { get; set; }
        public string panchayatname_tel { get; set; }
        public string villagecd { get; set; }
        public string villagelgcd { get; set; }
        public string villagename { get; set; }
        public string villagename_tel { get; set; }
        public string ipaddress { get; set; }
        public string userid { get; set; }
        public string Flag { get; set; }
        public string yearcd { get; set; }
        public string yeardesc { get; set; }
        public string schemecode { get; set; }
        public string subschemecode { get; set; }
        public string subschemename { get; set; }
        public string Componentcode { get; set; }
        public string Componentname { get; set; }
        public string schemename { get; set; }
        public int active { get; set; }
        public DateTime efct_dt { get; set; }
        public string farmername { get; set; }
        public string fatherorhusname { get; set; }
        public string gendercd { get; set; }
        public string categorycd { get; set; }
        public string catstecd { get; set; }
        public string address{ get; set; }
        public string mobileno { get; set; }
        public string aadharno { get; set; }
        public string emailid { get; set; }
        public string bankcd { get; set; }
        public string ifsccode { get; set; }
        public string accountno { get; set; }
        public string schemetype { get; set; }
        public string pattadharno { get; set; }
        public string landextent { get; set; }
        public decimal fullcost { get; set; }
        public decimal subsidyamt { get; set; }
        public decimal nonsubsidyamt { get; set; }
        public string challanno { get; set; }
        public string challanamount { get; set; }
        public string challandate { get; set; }
        public string farmerid { get; set; }
        public string cropcd { get; set; }
        public string cropname { get; set; }
        public string intervensioncd { get; set; }
        public string intervensionname { get; set; }
        public string subintervensioncd { get; set; }
        public string subintervensionname { get; set; }
        public string itemcd { get; set; }
        public string itemname { get; set; }
        public string agencycd { get; set; }
        public string agencyname { get; set; }
        public string LandType { get; set; }
        public string DifferentlyAbled { get; set; }
        public string percentDisability { get; set; }
        public byte[] upImage { get; set; }
        public string doc_code { get; set; }
        public string doc_type { get; set; }
        public string invoice_other { get; set; }
        public string item_nos { get; set; }
        public string uid { get; set; }
        public string subitemcode { get; set; }
        public string FirmName { get; set; }
        public string Firm_code { get; set; }
        public string phoneNo { get; set; }
        public string Percentage { get; set; }
        //Rajesh
        public string MaxLength { get; set; }
    }
   public class FarmerDetails
   {
       public string FarmerName { get; set; }
       public string AadharNo { get; set; }
       public string GenderId { get; set; }
       public string GenderDesc { get; set; }
       public string CasteId { get; set; }
       public string CasteName { get; set; }
       public string VillageId { get; set; }
       public string VillageName { get; set; }
       public string MandalId { get; set; }
       public string Mandalname { get; set; }
       public string DistrictId { get; set; }
       public string DistrictName { get; set; }
       public string MobileNo { get; set; }
       public string BankId { get; set; }
       public string BankName { get; set; }
       public string IFSCCode { get; set; }
       public string AccountNo { get; set; }
       public string Form1BNo { get; set; }
       public string Form1BLandId { get; set; }
       public string FormBLandDesc { get; set; }
       public string FormBLandRemarks { get; set; }
       public string SurveyNo { get; set; }
       public string TotalExtent { get; set; }
        //Rajesh
        public string MaxLength { get; set; }

    }
}
