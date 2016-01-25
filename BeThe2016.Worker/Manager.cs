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
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();

                dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PLAYER_W", new Object[] { });

                foreach (String team in Util.Util.Teams)
                {
                    var players = mgr.GetPlayer_W(team);
                    dbMgr.Save<Player_W>(players);
                }
            }
            finally
            {
                mgr.Dispose();
            }
        }

        // 플레이어 얻어오기1
        public void SelectPlayer()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();
                dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PLAYER", new Object[] { });

                var player_Ws = dbMgr.SelectAll<Player_W>();

                List<Player> players = new List<Player>();
                foreach (var player_W in player_Ws)
                {
                    var player = mgr.GetPlayer(player_W);
                    players.Add(player);
                }
                dbMgr.Save<Player>(players);
            }
            finally
            {
                mgr.Dispose();
            }
        }

        // 일정불러오기 
        public void SelectSchedule()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            Util.DataBaseManager dbMgr = new Util.DataBaseManager();

            // 일정불러오기 
            var allSchedule = dbMgr.SelectAll<Schedule>();
            Int32 year = 2010;
            Int32 month = 3;

            if(allSchedule.Count() > 0)
            { 
                 year = (from schedule in allSchedule select schedule.Year).Max();
                 month = (from schedule in allSchedule where schedule.Year == year select schedule.Month).Max();
            }
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = DateTime.Now;

            try
            {
                Int32 errorCount = 0;
                while (startDate <= endDate)
                {
                    try
                    {
                        var data = mgr.GetSchedule(startDate.Year, startDate.Month);

                        var scheduleTable = dbMgr.DataContext.GetTable<Schedule>();
                        var delSchedule = from schedule in allSchedule
                                          where schedule.Year == startDate.Year && schedule.Month == startDate.Month
                                          select schedule;

                        foreach (var schedule in delSchedule)
                        {
                            scheduleTable.DeleteOnSubmit(schedule);
                        }
                        dbMgr.DataContext.SubmitChanges();

                        dbMgr.Save(data);
                        startDate = startDate.AddMonths(1);
                        errorCount = 0;
                    }
                    catch (OpenQA.Selenium.StaleElementReferenceException exception)
                    {
                        if (errorCount < 10)
                        {
                            errorCount++;
                            continue;
                        }
                        else
                        {
                            throw exception;
                        }
                    }
                }
            }
            finally
            {
                mgr.Dispose();
            }
        }

    }
}
