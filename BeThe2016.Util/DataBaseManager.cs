// 데이터베이스 연결 매니저

using BeThe2016.Items;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;

namespace BeThe2016.Util
{
    public class DataBaseManager
    {
        #region ♥ Property & Values

        //private readonly static String DATA_SOURCE = "61.73.185.162,3915";
        private readonly static String DATA_SOURCE = "MIN-PC";

        private readonly static String USER_ID = "sa";

        //private readonly static String PASSWORD = "@1014vkfl";
        private readonly static String PASSWORD = "1";
        private readonly static String CATALOG = "BETHE2016";

        public DataContext DataContext { get; set; }

        #endregion

        #region ♥ Constructor

        public DataBaseManager()
        {
            var connection = new SqlConnection(GetConnString());
            DataContext = new DataContext(connection);
        }

        #endregion

        #region ♥ Public Functions

        // 조회하기
        public IQueryable<T> SelectAll<T>() where T : DbItemBase
        {
            var table = DataContext.GetTable<T>();
            var query = from item in table
                        select item;
            return query;
        }

        // 데이터 저장
        public void Save<T>(IEnumerable<T> items) where T : DbItemBase
        {
            var table = DataContext.GetTable(typeof(T));
            Int32 count = 0;
            foreach (DbItemBase item in items)
            {
                count++;
                table.InsertOnSubmit(item);
                if (count > 200)
                {
                    count = 0;
                    DataContext.SubmitChanges();
                }
            }
            DataContext.SubmitChanges();
        }

        public void Submit()
        {
            DataContext.SubmitChanges();
        }


        // 데이터 베이스 연결 테스트
        public Boolean TryConnect()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region ♥ Private Functions

        private String GetConnString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DATA_SOURCE;
            builder.InitialCatalog = CATALOG;
            builder.UserID = USER_ID;
            builder.Password = PASSWORD;
            return builder.ConnectionString;
        }

        #endregion
    }
}
