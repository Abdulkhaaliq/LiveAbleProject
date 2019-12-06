using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.IO;
using LiveAble.Model;
using LiveAble.Services.Interfaces;

namespace PlyOn.Services
{
    public class LiveableDatabase : IDatabase
    {

        static SQLiteConnection sqliteconnection;


        public LiveableDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Information.db");

            sqliteconnection = new SQLiteConnection(dbPath);
            sqliteconnection.CreateTable<People>();
        }

        public List<People> GetAllInformationData()
        {
            return (from data in sqliteconnection.Table<People>()
                    select data).ToList();
        }

        public People GetInformationData(int id)
        {
            return sqliteconnection.Table<People>().FirstOrDefault(t => t.ID == id);
        }

        public void DeleteAllInformation()
        {
            sqliteconnection.DeleteAll<People>();
        }

        public void SaveItemAsync(People info)
        {
            if (info.ID != 0)
            {
                sqliteconnection.Update(info);
            }
            else
            {
                sqliteconnection.Insert(info);
            }
        }

        public void DeleteInfo(int id)
        {
            sqliteconnection.Delete<People>(id);
        }

    }
}