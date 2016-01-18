using System;
using OpenQA.Selenium.Chrome;

namespace BeThe2016.Crawler
{
    internal class CrawlerPlayer_W : CrawlerBase
    {
        #region Property & Values

        private readonly String URL = "http://www.koreabaseball.com/Player/Search.aspx";

        private String teamInitial;
        private Int32 page;

        #endregion

        #region Constructor

        public CrawlerPlayer_W(ChromeDriver chromeDriver)
            : base(chromeDriver)
        {

        }

        public override String GetHTML()
        {
            driver.Navigate().GoToUrl(URL);
            SetComboBox("cphContainer_cphContents_ddlTeam", teamInitial);
            Sleep(2000);
            if (page > 5)
            {
                if (IsExistElement("cphContainer_cphContents_ucPager_btnNext"))
                {
                    ClickButton("cphContainer_cphContents_ucPager_btnLast");
                }
                else
                {
                    return null;
                }
            }

            Int32 index = (page - 1 % 5) + 1;
            String id = "cphContainer_cphContents_ucPager_btnNo" + index.ToString();
            if (IsExistElement(id))
            {
                ClickButton(id);
                Sleep(2000);
                return driver.FindElementByXPath("//tbody").GetAttribute("outerHTML");
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region public Functions

        public void Init(String teamInitial, Int32 page)
        {
            this.teamInitial = teamInitial;
            this.page = page;
        }

        #endregion
    }
}
