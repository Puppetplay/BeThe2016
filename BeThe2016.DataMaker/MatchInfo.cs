using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeThe2016.DataMaker
{
    internal class MatchInfo
    {
        public List<PitcherInfo> HomeTeamPitcherInfos { get; set; }
        public List<PitcherInfo> AwayTeamPitcherInfos { get; set; }

        public List<HitterInfo> HomeTeamHitterInfos { get; set; }
        public List<HitterInfo> AwayTeamHitterInfos { get; set; }

        public Int32 HomeHitterCount { get; set; }
        public Int32 AwayHitterCount { get; set; }
    }
}
