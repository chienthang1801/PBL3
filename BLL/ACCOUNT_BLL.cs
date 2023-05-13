using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DTO;
using Net4.DAL;
using System.Data;

namespace Net4.BLL
{
    public class ACCOUNT_BLL
    {
        private static ACCOUNT_BLL instance;
        public static ACCOUNT_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ACCOUNT_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getAccountINFO(string username, string password)
        {
            return ACCOUNT_DAL.Instance.getAccountInfo(username, password);
        }

        public int getAccountID(string username)
        {
            return ACCOUNT_DAL.Instance.getAccountID(username);
        }

        public void updateReminingtime(int ID,string newRemainingtime)
        {
            ACCOUNT_DAL.Instance.updateRtime(ID, newRemainingtime);
        }

        public Boolean checkPassword(string s, string user_name)
        {
            if (s != ACCOUNT_DAL.Instance.getPass(user_name))
                return false;
            else return true;
        }

        public void resetPASS(string newPass,string user_name) 
        {
            ACCOUNT_DAL.Instance.resetPassword(newPass,user_name);
        }
    }
}
