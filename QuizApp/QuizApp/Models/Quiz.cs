using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Models
{
    public class Quiz
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
