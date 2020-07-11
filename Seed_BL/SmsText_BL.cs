using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;

namespace Seed_BL
{
    public class SmsText
    {
        SmsText_DL obj = new SmsText_DL();
        public string BroadcastSMS(string mobileNo, string SMSMode, string txtMsg)
        {
            return obj.BroadcastSMS(mobileNo, SMSMode, txtMsg);
        }

    }
}
