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
        public Int64 MathId { get; set; }

        [Column(CanBeNull = false)]
        public ThType Type { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Number { get; set; }

        public List<Bat> Bats { get; set; }
    }

    public enum ThType
    {
        Notdefine,
        초,
        말
    }
}

