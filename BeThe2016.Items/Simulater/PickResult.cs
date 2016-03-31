using BeThe2016.Items;
using System;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class PickResult : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        // MathId
        [Column(CanBeNull = false)]
        public String GameDate { get; set; }

        // MathId
        [Column(CanBeNull = false)]
        public Int64 MatchId { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PlayerId { get; set; }
 
    }
}
