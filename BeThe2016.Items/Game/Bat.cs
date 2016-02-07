﻿//
// 경기정보
//

using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace BeThe2016.Items
{
    [Table]
    public class Bat : DbItemBase
    {
        // PRIMARY KEY	IDENTITY
        [Column(AutoSync = AutoSync.OnInsert, IsDbGenerated = true, IsPrimaryKey = true, CanBeNull = false)]
        public override Int64 Id { get; set; }

        // Th Id
        [Column(CanBeNull = false)]
        public Int64 ThId { get; set; }

        [Column(CanBeNull = false)]
        public Int32 PitcherId { get; set; }

        [Column(CanBeNull = false)]
        public Int32 HitterId { get; set; }

        [Column(CanBeNull = false)]
        public String Result { get; set; }

        public List<Ball> Balls { get; set; }
    }
}

