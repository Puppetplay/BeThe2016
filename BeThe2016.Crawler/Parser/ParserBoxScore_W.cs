using BeThe2016.Items;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace BeThe2016.Crawler.Parser
{
    internal class ParserBoxScore_W : ParserBase
    {
        #region Singleton

        private ParserBoxScore_W()
        {

        }

        public static ParserBoxScore_W Instance
        {
            get { return Nested.instance; }

        }

        private class Nested
        {
            static Nested()
            {
            }
            internal static readonly ParserBoxScore_W instance = new ParserBoxScore_W();
        }

        #endregion

        #region Public Functions

        public BoxScore_W Parse(Schedule schedule, String html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            var elements = doc.DocumentNode.SelectNodes("//table[@id='xtable1']");

            BoxScore_W boxScore_W = new BoxScore_W();
            boxScore_W.GameId = schedule.GameId;
            boxScore_W.AwayHitter = elements[0].OuterHtml;
            boxScore_W.HomeHitter = elements[1].OuterHtml;

            elements = doc.DocumentNode.SelectNodes("//table[@id='xtable3']");
            boxScore_W.AwayPitcher = elements[0].OuterHtml;
            boxScore_W.HomePitcher = elements[1].OuterHtml;

            return boxScore_W;
        }

        #endregion
    }
}
