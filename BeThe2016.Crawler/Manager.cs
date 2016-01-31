using System;
using System.Linq;
using System.Drawing;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using BeThe2016.Items;
using BeThe2016.Crawler.Crawler;

namespace BeThe2016.Crawler
{
    public class Manager : IDisposable
    {
        #region Property & Values

        private ChromeDriver chromeDriver;

        #endregion

        #region Public Functions

        #region Player

        // Player_W 정보 얻기
        public List<Player_W> GetPlayer_W(String teamName)
        {
            try
            {
                InitCromeDriver();
                String teamInitial = Util.Util.GetTeamInitialFromName(teamName);
                
                if(teamName.ToUpper() == "KT")
                {
                    teamName = "kt";
                }
                List<Player_W> players = new List<Player_W>();
                for (Int32 i = 1; i < 7; ++i)
                {
                    try
                    {
                        CrawlerPlayer_W crawler = new CrawlerPlayer_W(chromeDriver);
                        crawler.Init(teamName, i);
                        String html = crawler.GetHTML();
                        if (html != null)
                        {
                            List<Player_W> ps = Parser.ParserPlayer_W.Instance.Parse(html, teamInitial);
                            players = players.Concat(ps).ToList();
                        }
                    }
                    catch
                    {
                        i--;
                        continue;
                    }
                }
                return players;
            }
            finally
            {
                DisposeDriver();
            }
        }

        // Player 정보 얻기
        public Player GetPlayer(Player_W player_W)
        {
            InitCromeDriver();
            CrawlerPlayer crawler = new CrawlerPlayer(chromeDriver);
            crawler.Init(player_W.Href);

            String html = crawler.GetHTML();

            String[] items = player_W.Href.Split(new String[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
            Int32 playerId = Convert.ToInt32(items[items.Length - 1]);
            var player = Parser.ParserPlayer.Instance.Parse(html, player_W.Team, playerId);
            return player;
        }

        #endregion

        #region Schedule

        // 스케줄 정보 얻기
        public List<Schedule> GetSchedule(Int32 year, Int32 month)
        {
            InitCromeDriver();
            CrawlerSchedule crawler = new CrawlerSchedule(chromeDriver);
            crawler.Init(year, month);
            String html = crawler.GetHTML();
            return Parser.ParserShedule.Instance.Parse(html, year, month);
        }

        #endregion

        #region Situation

        // 경기상황 정보 얻기
        public Situation_W GetSituation_W(Schedule schedule)
        {
            InitCromeDriver();
            CrawlerSituation crawler = new CrawlerSituation(chromeDriver);
            crawler.Init(schedule);
            String html = crawler.GetHTML();
            return Parser.ParserSituation_W.Instance.Parse(schedule, html);

        }

        #endregion

        public void Dispose()
        {
            DisposeDriver();
        }

        private void DisposeDriver()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }

        #endregion

        #region Private Functions

        private void InitCromeDriver()
        {
            if (chromeDriver == null)
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                var chromeOptions = new ChromeOptions();
                chromeDriverService.HideCommandPromptWindow = true;
                chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                chromeDriver.Manage().Window.Size = new Size(500, 800);
            }
        }

        #endregion

    }
}
