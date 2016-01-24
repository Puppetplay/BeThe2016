using BeThe2016.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeThe2016.Worker
{
    public class Manager
    {
        // 플레이어 리스트 얻어오기
        public void SelectPlayer_W()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            Util.DataBaseManager dbMgr = new Util.DataBaseManager();

            dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PLAYER_W", new Object[] { });
         
            foreach (String team in Util.Util.Teams)
            {
                var players = mgr.GetPlayer_W(team);
                dbMgr.Save<Player_W>(players);
            }
        }

        // 플레이어 얻어오기
        public void SelectPlayer()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            Util.DataBaseManager dbMgr = new Util.DataBaseManager();
            dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PLAYER", new Object[] { });

            var player_Ws = dbMgr.SelectAll<Player_W>();

            List<Player> players = new List<Player>();
            foreach(var player_W in player_Ws)
            {
                var player = mgr.GetPlayer(player_W);
                players.Add(player);
            }
            dbMgr.Save<Player>(players);
        }

    }
}
