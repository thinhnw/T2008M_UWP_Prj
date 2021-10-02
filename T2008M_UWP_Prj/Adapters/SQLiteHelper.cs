using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Windows.Storage;
using System.IO;
namespace T2008M_UWP_Prj.Adapters
{
    class SQLiteHelper
    {
        private readonly string dbName = "t2008m.db";

        private static SQLiteHelper sQLiteHelper;// ô nhớ lưu trữ

        public SQLiteConnection _sQLiteConnection { get; set; }

        private SQLiteHelper()
        {
            // connect db
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            _sQLiteConnection = new SQLiteConnection(path);

            // tao table Cart
            var sql_txt = @"create table if not exists Cart(Id integer primary key, Name varchar(255), Image varchar(255), Price integer,Qty integer)";
            var statement = _sQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }


        public static SQLiteHelper GetInstance()
        {
            if (sQLiteHelper == null)
                sQLiteHelper = new SQLiteHelper();
            return sQLiteHelper;
        }
    }
}