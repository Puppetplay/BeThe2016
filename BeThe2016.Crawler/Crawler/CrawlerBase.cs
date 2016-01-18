using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BeThe2016.Crawler
{
    abstract class CrawlerBase
    {
        #region Property & Values

        protected ChromeDriver driver;

        #endregion

        #region Constructor

        public CrawlerBase(ChromeDriver chromeDriver)
        {
            driver = chromeDriver;
        }

        #endregion

        #region Abstract Functions

        public abstract String GetHTML();
        

        #endregion

        #region Protected Functions

        // 콤보박스선택
        protected void SetComboBox(String id, String value)
        {
            var combo = driver.FindElementById(id);
            var options = combo.FindElements(By.TagName("option"));
            var option = (from o in options
                          where o.Text == value
                          select o).First();
            if (option == null)
            {
                throw new Exception();
            }
            else
            {
                option.Click();
            }
        }

        protected void Sleep(Int32 tick)
        {
            System.Threading.Thread.Sleep(tick);
        }

        // 버튼클릭
        protected void ClickButton(String id)
        {
            var button = driver.FindElementById(id);
            button.Click();
        }

        // 엘레멘트 정의 확인
        protected Boolean IsExistElement(String id)
        {
            try
            {
                driver.FindElementById(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
