using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tshirt.Models;
using Tshirt.Service.Interfaces;

namespace Tshirt.Service
{
    public class TeesDatabase : IData
    {
        private SQLiteAsyncConnection database;

        public TeesDatabase()
        {
            string dbPath = GetDbPath();

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Tees>().Wait();
        }

        private string GetDbPath()
        { 
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tees.Db3");
        }

        public Task<List<Tees>> GetItemsAsync()
        {
            return database.Table<Tees>().ToListAsync();
        }

        public Task<List<Tees>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Tees>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<Tees> GetItemAsync(int id)
        {
            return database.Table<Tees>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Tees item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Tees item)
        {
            return database.DeleteAsync(item);
        }
    }
}