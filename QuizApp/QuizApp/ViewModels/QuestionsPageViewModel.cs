using Prism.Commands;
using Prism.Mvvm;
using QuizApp.Models;
using QuizApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
	public class QuestionsPageViewModel : BindableBase
	{
        private List<Quiz> quizList;
        public List<Quiz> QuizList
        {
            get => quizList;
            set => SetProperty(ref quizList, value);
        }

        private string question;
        public string Question
        {
            get => question;
            set => SetProperty(ref question, value);
        }

        private string correctAnswer;
        public string CorrectAnswer
        {
            get => correctAnswer;
            set => SetProperty(ref correctAnswer, value);
        }

        public async Task GetQuiz()
        {
            QuizList = await App.Database.GetQuizAsync();
        }

        public QuestionsPageViewModel()
        {
            //GetQuiz();
        }

        public ICommand NavigateAddQuestionPageCommand => new Command(async () =>
        {
            await Prism.PrismApplicationBase.Current.MainPage.Navigation.PushAsync(new AddQuestionPage());
        });

    }
}