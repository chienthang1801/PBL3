using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DTO;

namespace Net4.DAL
{
    public class ACCOUNT_DAL
    {
        private static ACCOUNT_DAL instance;
        public static ACCOUNT_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ACCOUNT_DAL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable createAccountTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("role_name", typeof(String));
            dataTable.Columns.Add("remaining_time", typeof(String));
            return dataTable;
        }

        public DataTable createAccountTable2()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("user_name", typeof(String));
            dataTable.Columns.Add("remaining_time", typeof(String));
            return dataTable;
        }

        public DataTable getAccountInfo(string username, string password)
        {
            using (VTH db = new VTH())
            {
                var queryResult = from o in db.users
                                  join c in db.user_role on o.user_name equals c.user_name
                                  join i in db.customers on o.user_name equals i.user_name
                                  where (o.user_name == username && o.user_password == password)
                                  select new { user_name = o.user_name, role_name = c.role_name, remaining_time = i.remaining_time };


                DataTable dataTable = createAccountTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.user_name, result.role_name, result.remaining_time);
                }
                return dataTable;
            }
        }

        public int getAccountID(string username)
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.customers.Select(p => new { p.id, p.user_name, p.remaining_time }).Where(p => p.user_name == username).FirstOrDefault();
                return queryResult.id;
            }
        }

        public void updateRtime(int id,string newRemainingtime)
        {
            using (VTH db = new VTH())
            {
                customer c = db.customers.Find(id);
                c.remaining_time = newRemainingtime;
                db.SaveChanges();
            }
        }

        public string getPass(string username)
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.users.Find(username);
                return queryResult.user_password;
            }
        }

        public void resetPassword(string newPass,string username)
        {
            using (VTH db = new VTH())
            {
                user u = db.users.Find(username);
                u.user_password = newPass;
                db.SaveChanges();
            }
        }
    }
}
