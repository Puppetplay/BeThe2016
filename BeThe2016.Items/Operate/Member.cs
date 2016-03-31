//
// 회원정보
//

using System;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    public enum  Enable
    {
        Enable,
        Unenable
    }

    [Table]
    public class Member : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        [Column(CanBeNull = false)]
        public String Name { get; set; }

        [Column(CanBeNull = false)]
        public String KakaoName { get; set; }

        [Column(CanBeNull = false)]
        public Enable Enable { get; set; }
    }
}
