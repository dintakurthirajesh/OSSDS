using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;


namespace Seed_DL
{
    public class SmsText_DL
    {
        public string BroadcastSMS(string mobileNo, string SMSMode, string txtMsg)
        {
            string userId = "comag-ts";
            string authCode = "7051494";
            string RevertText = "-- Invalid mobile number --";
            try
            {
                if (mobileNo.Length >= 10)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://mkisan.gov.in/ksewa/ksewa.aspx");
                    request.Timeout = 900000; request.ReadWriteTimeout = 900000;
                    request.ProtocolVersion = HttpVersion.Version10; request.UserAgent = ".NET Framework Example Client";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows98; DigExt)";
                    request.Method = "POST"; String query = "" + "txtMsg=" + System.Uri.EscapeDataString(txtMsg) + "&mobileNo=" +
                                    System.Uri.EscapeDataString(mobileNo) + "&SMSMode=" +
                                    System.Uri.EscapeDataString(SMSMode) + "&userId=" +
                                    System.Uri.EscapeDataString(userId) + "&authCode=" +
                                    System.Uri.EscapeDataString(authCode);
                    byte[] byteArray = Encoding.ASCII.GetBytes(query); request.ContentType = "application/x-www-form-urlencoded"; request.ContentLength = byteArray.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length); dataStream.Close();
                    WebResponse response = request.GetResponse();
                    String Status = ((HttpWebResponse)response).StatusDescription;
                    dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                    RevertText = responseFromServer;
                }
                else
                {
                    RevertText = "-- Invalid mobile number --";
                }
            }
            catch (Exception ex)
            {
                RevertText = ex.ToString();
            }
            return RevertText;
        }
    }
}
