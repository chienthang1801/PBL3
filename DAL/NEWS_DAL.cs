using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DTO;

namespace Net4.DAL
{
    public class NEWS_DAL
    {
        private static NEWS_DAL instance;
        public static NEWS_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NEWS_DAL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getNews()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("type", typeof(String));
            dataTable.Columns.Add("title", typeof(String));
            dataTable.Columns.Add("content", typeof(String));
            dataTable.Columns.Add("create_date", typeof(DateTime));
            dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }

        public DataTable getAllNews()
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.news.Select(p => new { p.id, p.type, p.title, p.content, p.create_date, p.image_url });
                DataTable dataTable = getNews();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.type, result.title, result.content, result.create_date, result.image_url);
                }
                return dataTable;
            }
        }
    }
}
