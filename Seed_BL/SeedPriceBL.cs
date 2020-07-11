using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Seed_DL;
using Seed_BE;

namespace Seed_BL
{
    public class SeedPriceBL
    {
        SeedPriceDL obj = new SeedPriceDL();
        DataTable dt = new DataTable();
        public DataTable SeedPrice_IUDRBL(SeedPriceBE seedprice)
        {
               return obj.SeedPrice_IUDRDL(seedprice);
        }

    }
}
