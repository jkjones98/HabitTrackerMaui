using HabitTrackerMaui.Models;
using SQLite;
using Microsoft.Data.Sqlite;
using HabitTrackerMaui;

namespace HabitTrackerMaui.Data
{
    public class HabitTrackRepository
    {
        string _dbPath;
        private SQLiteConnection connection;

        public HabitTrackRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void Init()
        {
            connection = new SQLiteConnection(_dbPath);

            connection.CreateTable<RunTracker>();
        }

        public List<RunTracker> ShowAllRuns()
        {
            Init();
            connection = new SQLiteConnection(_dbPath);

            return connection.Table<RunTracker>().ToList();
        }

        public void Insert(RunTracker run)
        {   
            connection = new SQLiteConnection(_dbPath);
            connection.Insert(run);
        }

        public void Update(RunTracker update)
        {
            connection = new SQLiteConnection(_dbPath);
            connection.Update(update);

        }

        public void Delete(int id)
        {   
            connection = new SQLiteConnection(_dbPath);
            connection.Delete(new RunTracker{Id = id});

        }
    }
}
