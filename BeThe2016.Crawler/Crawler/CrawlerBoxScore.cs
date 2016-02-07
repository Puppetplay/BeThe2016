using System;
using BeThe2016.Items;
using OpenQA.Selenium.Chrome;

namespace BeThe2016.Crawler.Crawler
{
    internal class CrawlerBoxScore : CrawlerBase
    {
        #region Property & Values

        private Schedule itemSchedule;

        private readonly String URL = "http://sports.news.naver.com/gameCenter/gameRecord.nhn?gameId={0}&category=kbo";

        #endregion

        #region Constructor

        public CrawlerBoxScore(ChromeDriver chromeDriver)
            : base(chromeDriver)
        {

        }

        #endregion

        #region public Functions

        public void Init(Schedule schedule)
        {
            itemSchedule = schedule;
        }

        public override String GetHTML()
        {
            driver.Navigate().GoToUrl(String.Format(URL, itemSchedule.GameId));
            Sleep(1000);
            try
            {
                return driver.FindElementByXPath("//HTML").GetAttribute("outerHTML");
            }
            catch
            {
                throw new OpenQA.Selenium.StaleElementReferenceException("페이지 로드오류");
            }
        }

        #endregion
    }
}
