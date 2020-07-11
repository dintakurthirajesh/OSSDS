using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Seed_DL
{
   public class LoginDAL
    {
       public DataTable getLoginDetailsDAL(string username)
       {
           using (SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", con))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }
            

       public DataTable getUsers(string state, string dist, string mand,string role)
       {          
           using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", connection))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@action", SqlDbType.NVarChar).Value = "G";
                   da.SelectCommand.Parameters.Add("@state", SqlDbType.NVarChar).Value = state;
                   da.SelectCommand.Parameters.Add("@dist", SqlDbType.NVarChar).Value = dist;
                   da.SelectCommand.Parameters.Add("@mand", SqlDbType.NVarChar).Value = mand;
                   da.SelectCommand.Parameters.Add("@role", SqlDbType.Int).Value = role;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }

       public DataTable ResetPwd(string UsrName)
       {
           using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", connection))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@action", SqlDbType.NVarChar).Value = "S";
                   da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = UsrName;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }

       public DataTable updatePWDDAL(string UsrName, string password, string byuser)
       {
           using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", connection))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@action", SqlDbType.NVarChar).Value = "U";
                   da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = UsrName;
                   da.SelectCommand.Parameters.Add("@newpwd", SqlDbType.NVarChar).Value = password;
                   da.SelectCommand.Parameters.Add("@updatedUSer", SqlDbType.NVarChar).Value = byuser;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }


       public DataTable CheckUser(string UsrName)
       {
           using (SqlConnection connection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString()))
           {
               using (SqlDataAdapter da = new SqlDataAdapter("GetLoginDetails", connection))
               {
                   da.SelectCommand.CommandType = CommandType.StoredProcedure;
                   da.SelectCommand.Parameters.Add("@action", SqlDbType.NVarChar).Value = "C";
                   da.SelectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = UsrName;
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       }

    }
}
