using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AR_JC_ProyectoP2.Models;

namespace AR_JC_ProyectoP2
{
    public class LogRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        private SQLiteAsyncConnection conn;
        private async Task Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Log>();
        }

        public LogRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async Task AddNewLog(int nuevaResenaId)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                await Init();
                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(nuevaResenaId.ToString()))
                    throw new Exception("Valid name required");

                // TODO: Insert the new person into the database
                DateTime fecha = DateTime.Now;
                result = await conn.InsertAsync(new Log { IdResenaL = nuevaResenaId, DateTime= fecha});

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", nuevaResenaId, ex.Message);
            }

        }

        public async Task<List<Log>> GetAllLogs()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                await Init();
                return await conn.Table<Log>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Log>();
        }
    }
}
