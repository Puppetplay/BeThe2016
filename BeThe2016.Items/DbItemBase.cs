// 데이터 베이스에 저장되는 클래스의 최소단위

using System;

namespace BeThe2016.Items
{
    public abstract class DbItemBase
    {
        #region ♥ Property & Values

        // PRIMARY KEY	IDENTITY
        public abstract Int64 Id { get; set; }

        #endregion
    }
}
