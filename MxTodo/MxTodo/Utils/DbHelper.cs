using MxTodo.Config;
using MxTodo.MVVM.Model.Todo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MxTodo.Utils
{
    public class DbHelper
    {
        private readonly static object initLock = new object();
        private static string connstr = MxProperty.DbPath.Value;
        private static SQLiteConnection db;

        private DbHelper()
        {
        }

        private static void InitDb()
        {
            db = new SQLiteConnection(connstr);
            Debug.WriteLine(string.Format("[DB]: create connection => db path:{0}", connstr));
            CreateTableResult res = db.CreateTable<TodoItem>();
            Debug.Write(string.Format("[DB]: create table => res: {0}", res.ToString()));
        }

        public static SQLiteConnection Db
        {
            get
            {
                if (db == null)
                {
                    lock (initLock)
                    {
                        if (db == null)
                        {
                            InitDb();
                        }
                    }
                }
                return db;
            }
        }

        public static int Insert<T>(T model)
        {
            return Db.Insert(model);
        }

        public static int Update<T>(T model)
        {
            return Db.Update(model);
        }

        public static int Delete<T>(T model)
        {
            return Db.Delete(model);
        }

        public static List<T> Select<T>(string sql, params object[] args) where T : new()
        {
            return Db.Query<T>(sql, args);
        }

        public static int Execute(string sql)
        {
            return Db.Execute(sql);
        }
    }
}