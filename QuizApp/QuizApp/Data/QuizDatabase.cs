using QuizApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Data
{
    public class QuizDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public QuizDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Quiz>().Wait();
        }

        public Task<List<Quiz>> GetQuizAsync()
        {
            return _database.Table<Quiz>().ToListAsync();
        }

        public Task<Quiz> GetQuizAsync(int id)
        {
            return _database.Table<Quiz>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveQuizAsync(Quiz quiz)
        {
            if (quiz.ID != 0)
            {
                return _database.UpdateAsync(quiz);
            }
            else
            {
                return _database.InsertAsync(quiz);
            }
        }
    }
}
