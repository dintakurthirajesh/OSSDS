using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seed_DL;
using System.Data;

namespace Seed_BL
{
   public class LoginBAL
    {
        LoginDAL objLogin = new LoginDAL();
        public DataTable getLoginDetailsBAL(string username)
        {
            return objLogin.getLoginDetailsDAL(username);
        }
        public DataTable getUsers(string state, string dist, string mand,string role)
        {
            return objLogin.getUsers(state, dist, mand,role);
        }

        public DataTable ResetPwd(string UsrName)
        {
            return objLogin.ResetPwd(UsrName);
        }

        public DataTable CheckUser(string UsrName)
        {
            return objLogin.CheckUser(UsrName);
        }
        public DataTable updatePWDBAL(string UsrName, string password, string byuser)
        {
           return objLogin.updatePWDDAL(UsrName, password,byuser);
        }
        //public DataTable getInsertIndent()
        //{
        //}
    }
}
