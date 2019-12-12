using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.IO;
using LiveAble.Model;
using LiveAble.Services.Interfaces;
using System.Threading.Tasks;

namespace PlyOn.Services
{
    public class LiveableDatabase : IDatabase
    {

        private SQLiteAsyncConnection userDatabase;


        public LiveableDatabase()
        {
            var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Information.db3");

            userDatabase = new SQLiteAsyncConnection(dbPath);
            userDatabase.CreateTableAsync<People>().Wait();
        }

        public Task<List<People>> GetAllInformationData()
        {
            return userDatabase.Table<People>().ToListAsync();
             
        }

        public Task<People> GetPeopleByEmail(string Email)
        {
            return userDatabase.Table<People>().Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public Task<int> DeleteAllInformation()
        {
            return userDatabase.DeleteAllAsync<People>();
        }

        public Task<int> SaveItemAsync(People info)
        {
               return userDatabase.InsertAsync(info);
        }

 
    }
}