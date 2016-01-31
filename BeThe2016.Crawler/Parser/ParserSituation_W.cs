using BeThe2016.Items;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace BeThe2016.Crawler.Parser
{
    internal class ParserSituation_W : ParserBase
    {
        #region Singleton

        private ParserSituation_W()
        {

        }

        public static ParserSituation_W Instance
        {
            get { return Nested.instance; }

        }

        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly ParserSituation_W instance = new ParserSituation_W();
        }

        #endregion

        #region Public Functions

        public Situation_W Parse(Schedule schedule, String html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var element = doc.DocumentNode.SelectSingleNode("//*[@class=\"situation\"]");

            Situation_W situation_W = new Situation_W();
            situation_W.GameId = schedule.GameId;
            situation_W.Content = element.OuterHtml;
            return situation_W;
        }

        #endregion
    }
}
