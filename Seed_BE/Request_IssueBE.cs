using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Request_IssueBE
/// </summary>
/// 
namespace Seed_BE
{
    public class Request_IssueBE
    {
        public string DistCode { get; set; }
        public string MandCode { get; set; }
        public string VillCode { get; set; }
        public string KhataNo { get; set; }
        public string FinYear { get; set; }
        public string SeasonName { get; set; }        
        public string Farmer_Name { get; set; }
        public string Father_Name { get; set; }
        public string Gender { get; set; }
        public string Caste { get; set; }
        public string Farmer_Type { get; set; }
        public string AadharNo { get; set; }
        public string surveynos { get; set; }
        public string extent { get; set; }
        public string bank { get; set; }
        public string branch { get; set; }
        public string acno { get; set; }
        public string ifsc { get; set; }
        public string mobile { get; set; }

        public string personName { get; set; }
        public string relation { get; set; }
        public string personAdhar { get; set; }
        public string personMobile { get; set; }


        public DataTable CropDetails_KhataWs { get; set; }

    }
}