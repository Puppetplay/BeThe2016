using System;
using OpenQA.Selenium.Chrome;

namespace BeThe2016.Crawler.Crawler
{
    internal class CrawlerSituation: CrawlerBase
    {
        #region Property & Values

        private String itemGameId;
        private Int32 itemYear;
        private readonly String URL = "http://www.koreabaseball.com/Schedule/Game/Situation.aspx?leagueId=1&seriesId=0&gameId={0}&gyear={1}";

        #endregion

        #region Constructor

        public CrawlerSituation(ChromeDriver chromeDriver)
            : base(chromeDriver)
        {

        }

        #endregion

        #region public Functions

        public void Init(String gameId, Int32 year)
        {
            itemGameId = gameId;
            itemYear = year;
        }

        public override String GetHTML()
        {
            driver.Navigate().GoToUrl(String.Format(URL, itemGameId, itemYear));
            Sleep(1000);
            try
            {
                //SetComboBox("cphContainer_cphContents_ddlYear", itemYear);
                //Sleep(1000);
                //SetComboBox("cphContainer_cphContents_ddlMonth", itemMonth);
                //Sleep(2000);
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
