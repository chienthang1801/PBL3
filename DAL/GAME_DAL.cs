using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DTO;

namespace Net4.DAL
{
    public class GAME_DAL
    {
        private static GAME_DAL instance;
        public static GAME_DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GAME_DAL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns.Add("game_category_id", typeof(int));
            dataTable.Columns.Add("game_name", typeof(String));
            dataTable.Columns.Add("played_times", typeof(int));
            dataTable.Columns.Add("path", typeof(String));
            dataTable.Columns.Add("image_url", typeof(byte[]));
            return dataTable;
        }

        public DataTable getGame(int id)
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_category_id == id).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getGameByName(int id, string name)
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_category_id == id && p.game_name.Contains(name)).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getAllGame()
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }

        public DataTable getAllGameByName(string name)
        {
            using (VTH db = new VTH())
            {
                var queryResult = db.games.Select(p => new { p.id, p.game_category_id, p.game_name, p.played_times, p.path, p.image_url }).Where(p => p.game_name.Contains(name)).OrderBy(p => p.game_name);
                DataTable dataTable = getDataTable();

                foreach (var result in queryResult)
                {
                    dataTable.Rows.Add(result.id, result.game_category_id, result.game_name, result.played_times, result.path, result.image_url);
                }
                return dataTable;
            }
        }
    }
}
