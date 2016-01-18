//
// 선수List
//

using System;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class Player_W : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        [Column(CanBeNull = false)]
        public String Team { get; set; }

        [Column(CanBeNull = false)]
        public String Href { get; set; }
    }
}
