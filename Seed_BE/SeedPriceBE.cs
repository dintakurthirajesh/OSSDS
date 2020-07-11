using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Seed_BE
{
    public class SeedPriceBE
    {
        public string Year { get; set; }
        public string Season { get; set; }
        public string CropCode { get; set; }
        public string CropVCode { get; set; }
        public string CropName { get; set; }
        public string SeedVarietyName { get; set; }
        public double Actual_Price { get; set; }
        public double Subsidized_Price { get; set; }
        public string Subsidy_Amount { get; set; }
        public string UserName { get; set; }
        public string Action { get; set; }
        public string Company { get; set; }
        public DateTime date { get; set; }
    }
}
