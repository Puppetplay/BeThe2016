//
// 경기정보
//

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class Th : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        // MathId
        [Column(CanBeNull = false)]
        public Int64 MatchId { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Number { get; set; }

        public List<Bat> AwayBats { get; set; }

        public List<Bat> HomeBats { get; set; }
    }
}

