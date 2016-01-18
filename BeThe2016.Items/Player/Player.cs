﻿//
// 선수정보
//

using System;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class Player : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        [Column(CanBeNull = false)]
        public String Team { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PlayerId { get; set; }

        [Column(CanBeNull = true)]
        public String SCR { get; set; }

        [Column(CanBeNull = true)]
        public Int32? BackNumber { get; set; }

        [Column(CanBeNull = false)]
        public String Name { get; set; }

        [Column(CanBeNull = false)]
        public String Position { get; set; }

        [Column(CanBeNull = false)]
        public String Hand { get; set; }

        [Column(CanBeNull = false)]
        public String BirthDate { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Height { get; set; }

        [Column(CanBeNull = false)]
        public Int32 Weight { get; set; }

        [Column(CanBeNull = true)]
        public String Career { get; set; }

        [Column(CanBeNull = true)]
        public String Deposit { get; set; }

        [Column(CanBeNull = true)]
        public String Salary { get; set; }

        [Column(CanBeNull = true)]
        public String Rank { get; set; }

        [Column(CanBeNull = true)]
        public String JoinYear { get; set; }
    }
}
