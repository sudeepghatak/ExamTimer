using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Timer.Data
{
	public class ConfigDatabase
	{
		readonly SQLiteAsyncConnection database;

		public ConfigDatabase(string dbPath)
		{
			database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<Config>().Wait();
		}

		public Task<List<Config>> GetItemsAsync()
		{
			return database.Table<Config>().ToListAsync();
		}

		public Task<Config> GetKey(string key)
		{
			return database.Table<Config>().Where(i => i.Key == key).FirstOrDefaultAsync();
		}

    
        public Task<int> InsertItemAsync(Config item)
        {
            
                return database.InsertAsync(item);
            
        }

        public Task<int> SaveItemAsync(Config item)
		{
			if (item.ID != 0)
			{
				return database.UpdateAsync(item);
			}
			else {
				return database.InsertAsync(item);
			}
		}

		public Task<int> DeleteItemAsync(Config item)
		{
			return database.DeleteAsync(item);
		}
	}
}

