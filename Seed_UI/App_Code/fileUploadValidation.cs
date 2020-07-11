using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Summary description for fileUploadValidation
/// </summary>
public static  class fileUploadValidation
{
	public static Boolean fluValidation(FileUpload fluDoc)
	{       
            if (fluDoc.PostedFile.ContentLength < 4000000)
            {
                int filLength = fluDoc.PostedFile.ContentLength;
                byte[] objFile = new byte[filLength - 1];
                objFile = fluDoc.FileBytes;
                string mime = MimeType.GetMimeType(objFile, fluDoc.FileName);
                if (mime == "application/pdf")
                {
                    return true;
                }
                else
                {
                    
                    return false;

                }
            }
            else
            {
                
                return false;
            }
       
	}
    public static Boolean fluValidationimage(FileUpload fluDoc)
    {
        if (fluDoc.PostedFile.ContentLength < 4000000)
        {
            int filLength = fluDoc.PostedFile.ContentLength;
            byte[] objFile = new byte[filLength - 1];
            objFile = fluDoc.FileBytes;
            string mime = MimeType.GetMimeType(objFile, fluDoc.FileName);
            if (mime == "image/jpeg")
            {
                return true;
            }
            else
            {

                return false;

            }
        }
        else
        {

            return false;
        }

    }
}