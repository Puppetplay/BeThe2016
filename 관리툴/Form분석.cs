using BeThe2016.Items;
using BeThe2016.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 관리툴
{
    public partial class Form분석 : Form
    {
        private DataBaseManager dbMgr = new DataBaseManager();

        public Form분석()
        {
            InitializeComponent();
        }

        private void bt분석_Click(object sender, EventArgs e)
        {
            GetPick();
        }

        // 픽을 선택한다.
        private void GetPick()
        {
            Int32 year = Convert.ToInt32(textBox1.Text.Substring(0, 4));
            Int32 mon = Convert.ToInt32(textBox1.Text.Substring(4, 2));
            Int32 day = Convert.ToInt32(textBox1.Text.Substring(6, 2));
            DateTime date = new DateTime(year, mon, day);
            var matches = dbMgr.SelectAll<Match>();

            var ps = GetBestBatters(date);
            ps = (from p in ps
                  where
                  p.BatCount > 300 &&
                  ////p.VsRatio > 0.25 &&
                  //p.PitcherOfBatterTypeRatio > 0.21 &&
                  //p.PitcherTypeRatio > 0.25 &&
                  p.HitRatio > 0.25
                  select p).ToList();
            dgResult.DataSource = ps;

        }

        private List<LegendScore> GetBestBatters(DateTime datetime)
        {
            List<LegendScore> legendScores = new List<LegendScore>();
            var lineUps = dbMgr.SelectAll<LineUp>();
            var entries = dbMgr.SelectAll<Entry>();

            // 엔트리 가지고오기
            var wEntries = from entry in entries
                           where entry.Year == datetime.Year &&
                                entry.Month == datetime.Month &&
                                entry.Day == datetime.Day
                           select entry;

            foreach(var entry in wEntries)
            {
                var legendScore = CalcRatio(entry.PlayerId, entry.PitcherId);
                legendScores.Add(legendScore);
            }
            return legendScores;
        }

        private LegendScore CalcRatio(Int32 batterId, Int32 pitcherId)
        {
            LegendScore legendScore = new LegendScore();
            
            try
            {
                var players = dbMgr.SelectAll<Player>();
                var matches = dbMgr.SelectAll<Match>();
                var ths = dbMgr.SelectAll<Th>();
                var bats = dbMgr.SelectAll<Bat>();

                // 투수를가져온다.
                var pitcher = (from p in players
                               where p.PlayerId == pitcherId
                               select p).First();

                // 타자를 가져온다.
                var batter = (from p in players
                              where p.PlayerId == batterId
                              select p).First();

                legendScore.PlayerId = batter.PlayerId;
                legendScore.PlayerName = batter.Name;

                Int32 startDate = 20150000;
                Int32 endDate = 20160000;

                // 제외조건 확인
                // 1. 300타수 이상인 타자인지 확인
                try
                {
                    var batCount = (from m in matches
                                    join t in ths
                                    on m.Id equals t.MatchId
                                    join b in bats
                                    on t.Id equals b.ThId
                                    where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                    b.HitterId == batter.PlayerId
                                    group b by b.HitterId into g
                                    select g.Count()).First();

                    legendScore.BatCount = batCount;
                }
                catch
                {

                }


                //// 2. 교체수가 50보다 작아야한다. 8프로 미만이어야한다.
                //var wLineUps = from l in lineUps
                //               where l.PlayerId == batter.PlayerId && l.EntryType == EntryType.Starting
                //               select l;

                //var wwLineUps = from l in wLineUps
                //                join m in matches
                //                on l.MatchId equals m.Id
                //                join wl in lineUps
                //                on new { l.MatchId, l.BatNumber, l.AttackType } equals new { wl.MatchId, wl.BatNumber, wl.AttackType }
                //                where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                //                   wl.EntryType == EntryType.Change
                //                select wl;

                //var changeCount = wwLineUps.Count();
                //var changeRate = changeCount * 1.0 / batCount;

                //legendScore.ChangeRatio = changeRate;

                // 3. 투수, 타자 상대전적이 0.25 이상이어야한다.
                try
                {
                    var vsCount = (from m in matches
                                 join t in ths
                                 on m.Id equals t.MatchId
                                 join b in bats
                                 on t.Id equals b.ThId
                                 join p in players
                                 on b.PitcherId equals p.PlayerId
                                 where m.GameId.StartsWith("2015") && b.HitterId == batter.PlayerId
                                  && b.PitcherId == pitcher.PlayerId
                                 group b by new { b.HitterId } into g
                                 select g.Count()).First();
                    legendScore.VsCount = vsCount;

                    var vsRatio = (from m in matches
                                   join t in ths
                                   on m.Id equals t.MatchId
                                   join b in bats
                                   on t.Id equals b.ThId
                                   join p in players
                                   on b.PitcherId equals p.PlayerId
                                   where m.GameId.StartsWith("2015") && b.HitterId == batter.PlayerId
                                    && b.PitcherId == pitcher.PlayerId
                                   group b by new { b.HitterId } into g
                                   select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();

                    legendScore.VsRatio = vsRatio;
                }
                catch(Exception e)
                {
                    //MessageBox.Show(e.ToString());
                }

                // 4. 투수의 타자타입 안타율이 0.21보다 높아야한다.
                try
                {
                    var tmpPitRatio = (from m in matches
                                       join t in ths
                                       on m.Id equals t.MatchId
                                       join b in bats
                                       on t.Id equals b.ThId
                                       join p in players
                                       on b.HitterId equals p.PlayerId
                                       where (m.GameId.StartsWith("2015")) && b.PitcherId == pitcher.PlayerId
                                        && p.Hand.Substring(2, 2) == batter.Hand.Substring(2, 2)
                                       select new
                                       {
                                           H = p.Hand.Substring(2, 2),
                                           b.PResult
                                       });

                    var pitRatio = (from r in tmpPitRatio
                                    group r by new { r.H } into g
                                    select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();

                    legendScore.PitcherOfBatterTypeRatio = pitRatio;
                }
                catch
                {

                }

                // 5. 타자의 투수타입 안타율이 0.25보다 높아야한다.
                try
                {
                    var hitRatio = (from m in matches
                                    join t in ths
                                    on m.Id equals t.MatchId
                                    join b in bats
                                    on t.Id equals b.ThId
                                    join p in players
                                    on b.PitcherId equals p.PlayerId
                                    where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                       b.HitterId == batter.PlayerId
                                        && p.Hand.Substring(0, 2) == pitcher.Hand.Substring(0, 2)
                                    group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                                    select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                    legendScore.PitcherTypeRatio = hitRatio;
                }
                catch
                {

                }

                // 5. 타자의  안타율이 0.20보다 높아야한다.
                try
                {
                    var hitRatioR = (from m in matches
                                     join t in ths
                                     on m.Id equals t.MatchId
                                     join b in bats
                                     on t.Id equals b.ThId
                                     join p in players
                                     on b.PitcherId equals p.PlayerId
                                     where (Convert.ToInt32(m.GameId.Substring(0, 8)) > startDate && Convert.ToInt32(m.GameId.Substring(0, 8)) < endDate) &&
                                       b.HitterId == batter.PlayerId
                                     group b by new { b.HitterId, Hand = p.Hand.Substring(0, 2) } into g
                                     select g.Count(x => x.PResult == PResultType.Hit) * 1.0 / g.Count()).First();
                    legendScore.HitRatio = hitRatioR;
                }
                catch
                {

                }


                return legendScore;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return legendScore;
        }
    }
}