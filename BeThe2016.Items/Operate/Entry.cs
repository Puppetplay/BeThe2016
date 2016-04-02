//
// 출전정보
//

using System;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class Entry : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Year { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Month { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Day { get; set; }

        [Column(CanBeNull = true)]
        public String HomeTeam { get; set; }

        [Column(CanBeNull = true)]
        public String AwayTeam { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PlayerId { get; set; }

        [Column(CanBeNull = false)]
        public String PlayerName { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PitcherId { get; set; }

        [Column(CanBeNull = false)]
        public String PitcherName { get; set; }

        [Column(CanBeNull = false)]
        public Int32 BatNumber { get; set; }
    }
}
