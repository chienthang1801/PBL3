using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DTO;
using Net4.DAL;

namespace Net4.BLL
{
    public class NEWS_BLL
    {
        private static NEWS_BLL instance;
        public static NEWS_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NEWS_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable GetAllNEWS()
        {
            return NEWS_DAL.Instance.getAllNews();
        }
    }
}
