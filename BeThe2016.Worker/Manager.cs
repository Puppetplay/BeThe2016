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
        #region Crawler

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

        // 플레이어 얻어오기
        public void SelectPlayer()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();
                dbMgr.DataContext.ExecuteCommand("TRUNCATE TABLE PLAYER", new Object[] { });

                var player_Ws = dbMgr.SelectAll<Player_W>();

                List<Player> players = new List<Player>();
                for(Int32 i = 0; i < player_Ws.Count(); )
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

        // 경기상황 불러오기
        public void SelectSituation_W()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();
                var schedules =  from schedule in dbMgr.SelectAll<Schedule>()
                                 join situation in dbMgr.SelectAll<Situation_W>()
                                 on schedule.GameId equals situation.GameId into t
                                 from subSituation in t.DefaultIfEmpty()
                                 where schedule.LeagueId == 1 && schedule.SeriesId == 0 
                                 && schedule.Href != null && subSituation.Content == null
                                 select schedule;

                schedules = from schedule in schedules
                            where schedule.Year >= 2013
                            select schedule;

                foreach (var schedule in schedules)
                {
                    List<Situation_W> situation_Ws = new List<Situation_W>();
                    var situation_W = GetSituation_W(mgr, schedule, 5);
                    situation_Ws.Add(situation_W);
                    dbMgr.Save<Situation_W>(situation_Ws);
                }
            }
            finally
            {
                mgr.Dispose();
            }
        }

        private Situation_W GetSituation_W(Crawler.Manager mgr, Schedule schedule, Int32 lastCount)
        {
            if(lastCount == 0)
            {
                throw new Exception(String.Format("경기상황 얻어오기 실패, 게임아이디 {0}", schedule.GameId));
            }
            try
            {
                var situation_W = mgr.GetSituation_W(schedule);
                return situation_W;
            }
            catch
            {
                return GetSituation_W(mgr, schedule, lastCount - 1);
            }
        }

        // BoxScore 불러오기
        public void SelectBoxScore_W()
        {
            Crawler.Manager mgr = new Crawler.Manager();
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();
                var schedules = from schedule in dbMgr.SelectAll<Schedule>()
                                join boxScore in dbMgr.SelectAll<BoxScore_W>()
                                on schedule.GameId equals boxScore.GameId into t
                                from subBoxScore in t.DefaultIfEmpty()
                                where schedule.LeagueId == 1 && schedule.SeriesId == 0
                                && schedule.Href != null && subBoxScore.AwayHitter == null
                                select schedule;

                schedules = from schedule in schedules
                            where schedule.Year >= 2013
                            select schedule;

                foreach (var schedule in schedules)
                {
                    List<BoxScore_W> boxScore_Ws = new List<BoxScore_W>();
                    var situation_W = GetBoxScore_W(mgr, schedule, 5);
                    boxScore_Ws.Add(situation_W);
                    dbMgr.Save<BoxScore_W>(boxScore_Ws);
                }
            }
            finally
            {
                mgr.Dispose();
            }
        }

        private BoxScore_W GetBoxScore_W(Crawler.Manager mgr, Schedule schedule, Int32 lastCount)
        {
            if (lastCount == 0)
            {
                throw new Exception(String.Format("경기상황 얻어오기 실패, 게임아이디 {0}", schedule.GameId));
            }
            try
            {
                var boxScore_W = mgr.GetBoxScore_W(schedule);
                return boxScore_W;
            }
            catch
            {
                return GetBoxScore_W(mgr, schedule, lastCount - 1);
            }
        }

        #endregion

        #region Maker

        // Match Data 만들기
        public void MakeMatch()
        {
            DataMaker.Manager mgr = new DataMaker.Manager();
            try
            {
                Util.DataBaseManager dbMgr = new Util.DataBaseManager();
                var schedules = from schedule in dbMgr.SelectAll<Schedule>()
                                join match in dbMgr.SelectAll<Match>()
                                on schedule.GameId equals match.GameId into t
                                from subMatch in t.DefaultIfEmpty()
                                where schedule.LeagueId == 1 && schedule.SeriesId == 0
                                && schedule.Href != null && subMatch.GameId == null
                                select schedule;

                schedules = from schedule in schedules
                            where schedule.Year >= 2013
                            select schedule;

                //schedules = from schedule in dbMgr.SelectAll<Schedule>()
                //            where schedule.GameId == "20150902LGWO0"
                //            select schedule;


                foreach (var schedule in schedules)
                {
                    dbMgr = new Util.DataBaseManager();
                    var situation = (from s in dbMgr.SelectAll<Situation_W>()
                                     where s.GameId == schedule.GameId
                                     select s).First();

                    var boxScore = (from b in dbMgr.SelectAll<BoxScore_W>()
                                    where b.GameId == schedule.GameId
                                    select b).First();

                    var match = mgr.MakeMatch(situation, boxScore);

                    // Match 저장
                    List<Match> matchs = new List<Match>();
                    matchs.Add(match);
                    dbMgr.Save<Match>(matchs);

                    // Th 저장
                    List<Th> ths = new List<Th>();
                    foreach (var th in match.Ths)
                    {
                        th.MatchId = match.Id;
                        ths.Add(th);
                    }
                    dbMgr.Save<Th>(ths);

                    // Bat 저장
                    List<Bat> bats = new List<Bat>();
                    foreach (var th in match.Ths)
                    {
                        if (th.AwayBats != null)
                        {
                            foreach (var bat in th.AwayBats)
                            {
                                bat.ThId = th.Id;
                                bats.Add(bat);
                            }
                        }

                        if (th.HomeBats != null)
                        {
                            foreach (var bat in th.HomeBats)
                            {
                                bat.ThId = th.Id;
                                bats.Add(bat);
                            }
                        }
                    }
                    dbMgr.Save<Bat>(bats);

                    // Ball 저장
                    List<Ball> balls = new List<Ball>();
                    foreach (var th in match.Ths)
                    {
                        if (th.AwayBats != null)
                        {
                            foreach (var bat in th.AwayBats)
                            {
                                foreach (var ball in bat.Balls)
                                {
                                    ball.BatId = bat.Id;
                                    balls.Add(ball);
                                }
                            }
                        }

                        if (th.HomeBats != null)
                        {
                            foreach (var bat in th.HomeBats)
                            {
                                foreach (var ball in bat.Balls)
                                {
                                    ball.BatId = bat.Id;
                                    balls.Add(ball);
                                }
                            }
                        }
                    }
                    dbMgr.Save<Ball>(balls);
                }
            }
            finally
            {
            }
        }
        #endregion
    }
}
