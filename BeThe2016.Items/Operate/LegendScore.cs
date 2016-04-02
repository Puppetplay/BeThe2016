//
// 타자별 분석정보
//

using System;
using System.Data.Linq.Mapping;


namespace BeThe2016.Items
{
    [Table]
    public class LegendScore : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PlayerId { get; set; }

        [Column(CanBeNull = false)]
        public String PlayerName { get; set; }

        // 타수
        [Column(CanBeNull = false)]
        public Int32 BatCount { get; set; }

        // 교체확률
        [Column(CanBeNull = false)]
        public Double ChangeRatio { get; set; }

        // 상대전적
        [Column(CanBeNull = false)]
        public Int32 VsCount { get; set; }

        // 상대전적
        [Column(CanBeNull = false)]
        public Double VsRatio { get; set; }

        // 투수의 타자타입 안타율
        [Column(CanBeNull = false)]
        public Double PitcherOfBatterTypeRatio { get; set; }

        // 투수 타입 안타율
        [Column(CanBeNull = false)]
        public Double PitcherTypeRatio { get; set; }

        // 안타율
        [Column(CanBeNull = false)]
        public Double HitRatio { get; set; }

        // 기대 타석수
        [Column(CanBeNull = false)]
        public Int32 HopeBatCount { get; set; }
    }
}
