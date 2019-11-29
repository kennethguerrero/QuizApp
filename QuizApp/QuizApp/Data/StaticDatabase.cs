using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Data
{
    public class StaticDatabase
    {
        public List<Quiz> GetQuiz()
        {
            var quizList = new List<Quiz>
            {
                new Quiz
                {
                    Question = "Who sang \"My Way\"?",
                    Answer1 = "Frank Sinatra",
                    Answer2 = "Nat King Cole",
                    Answer3 = "Michael Buble",
                    CorrectAnswer = "Frank Sinatra"
                },
                new Quiz
                {
                    Question = "Ringo, John, Paul and?",
                    Answer1 = "Eric",
                    Answer2 = "Stuart",
                    Answer3 = "George",
                    CorrectAnswer = "George"
                },
                new Quiz
                {
                    Question = "Lead singer of the Band Led Zeppelin",
                    Answer1 = "Jimmy Page",
                    Answer2 = "Robert Plant",
                    Answer3 = "John Bonham",
                    CorrectAnswer = "Robert Plant"
                }
            };
            return quizList;
        }
    }
}