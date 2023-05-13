using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Net4.DAL;
using Net4.DTO;

namespace Net4.BLL
{
    public class GAME_BLL
    {
        private static GAME_BLL instance;
        public static GAME_BLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GAME_BLL();
                }
                return instance;
            }
            private set { }
        }

        public DataTable getGameByID(int id)
        {
            return GAME_DAL.Instance.getGame(id);
        }

        public DataTable getAllGAME()
        {
            return GAME_DAL.Instance.getAllGame();
        }

        public DataTable getGameByNAME(int id,string name)
        {
            return GAME_DAL.Instance.getGameByName(id,name);
        }
        public DataTable getAllGameByNAME(string name)
        {
            return GAME_DAL.Instance.getAllGameByName(name);
        }
    }
}
