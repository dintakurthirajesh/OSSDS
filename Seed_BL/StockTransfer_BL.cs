using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;

namespace Seed_BL
{
    public class StockTransfer_BL
    {
        StockTransfer stk = new StockTransfer();

        public DataTable GetStockPosition(string year, string season, string dist, string mand, string crop,string cv)
        {
            return stk.GetStockPosition(year, season, dist, mand, crop,cv);
        }


        public DataTable GetSps(string spcode, string dist, string mand)
        {
            return stk.GetSps(spcode, dist, mand);
        }


        public DataTable SptoSpTransfer(string fromsp, string crop, string cv, string year, string season, string nobtotr, string weight, string tosp, string user, string ip)
        {
            return stk.SptoSpTransfer(fromsp, crop,cv, year, season, nobtotr,weight,tosp,user,ip);
        }

        public DataTable SptoMandTransfer(string year, string season, string crop, string cv, string spcode, string nobtotr, string weight, string user, string ip)
        {
            return stk.SptoMandTransfer(year, season, crop, cv, spcode, nobtotr,weight, user,ip);
        }

        /// ***Stock Transfer By DAO

        public DataTable GetStockPositionMandWise(string year, string season, string dist, string crop, string cv)
        {
            return stk.GetStockPositionMandWise(year, season, dist, crop, cv);
        }


        public DataTable GetMandals(string dist, string mand)
        {
            return stk.GetMandals(dist, mand);
        }

        public DataTable MandalToMandalTrnsfer(string year, string season, string dist, string from, string to, string crop)
        {
            return stk.MandalToMandalTrnsfer(year, season, dist, from, to, crop);
        }

        public DataTable MandalToDistTrnsfer(string year, string season, string dist, string from, string crop)
        {
            return stk.MandalToDistTrnsfer(year, season, dist, from, crop);
        }
    }
}
