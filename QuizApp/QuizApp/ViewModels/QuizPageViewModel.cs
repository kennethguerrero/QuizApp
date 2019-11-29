using Prism.Commands;
using Prism.Mvvm;
using QuizApp.Data;
using QuizApp.Models;
using QuizApp.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
	public class QuizPageViewModel : BindableBase
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

        private string answer1;
        public string Answer1
        {
            get => answer1;
            set => SetProperty(ref answer1, value);
        }

        private string answer2;
        public string Answer2
        {
            get => answer2;
            set => SetProperty(ref answer2, value);
        }

        private string answer3;
        public string Answer3
        {
            get => answer3;
            set => SetProperty(ref answer3, value);
        }

        private string answer;
        public string Answer
        {
            get => answer;
            set => SetProperty(ref answer, value);
        }

        private string correctAnswer;
        public string CorrectAnswer
        {
            get => correctAnswer;
            set => SetProperty(ref correctAnswer, value);
        }

        public QuizPageViewModel()
        {
            GetQuiz();
            //GetStaticDatabase();
        }

        public async Task GetQuiz()
        {
            QuizList = await App.Database.GetQuizAsync();
            RandomQuestion();
        }

        private void GetStaticDatabase()
        {
            var staticDatabase = new StaticDatabase();
            QuizList = staticDatabase.GetQuiz();
        }

        public void RandomQuestion()
        {
            int length = QuizList.Count();
            var random = new Random();
            int randomNumber = random.Next(length);
            Quiz selectedItem = QuizList[randomNumber];

            Question = selectedItem.Question;
            Answer1 = selectedItem.Answer1;
            Answer2 = selectedItem.Answer2;
            Answer3 = selectedItem.Answer3;
            CorrectAnswer = selectedItem.CorrectAnswer;
        }

        public ICommand NavigateAddQuestionPageCommand => new Command(async () =>
        {
            await Prism.PrismApplicationBase.Current.MainPage.Navigation.PushAsync(new AddQuestionPage());
        });

        string SSID = "Network not found";
        string Password = "bb1willwashthedishestonight";

        public ICommand SubmitAnswerCommand => new Command(async () =>
        {
            if (Answer == CorrectAnswer)
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Congrats!",
                    Answer + " " + "is correct. Here's the internet details:" + "\n" + "\n" +
                    "Wifi Name: " + SSID + "\n" + "Password: " + Password, 
                    "OK");
            }
            else
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Try again", Answer + " is not correct.", "OK");

                Answer = string.Empty;
                RandomQuestion();
            }
        });

        public ICommand SubmitAnswer1Command => new Command(async () =>
        {
            if(Answer1 == CorrectAnswer)
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Congrats!",
                    answer1 + " " + "is correct. Here's the internet details:" + "\n" + "\n" +
                    "Wifi Name: " + SSID + "\n" + "Password: " + Password,
                    "OK");
            }
            else
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Try again", Answer + " is not correct.", "OK");
                RandomQuestion();
            }
        });

        public ICommand SubmitAnswer2Command => new Command(async () =>
        {
            if (Answer2 == CorrectAnswer)
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Congrats!",
                    answer2 + " " + "is correct. Here's the internet details:" + "\n" + "\n" +
                    "Wifi Name: " + SSID + "\n" + "Password: " + Password,
                    "OK");
            }
            else
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Try again", Answer + " is not correct.", "OK");
                RandomQuestion();
            }
        });

        public ICommand SubmitAnswer3Command => new Command(async () =>
        {
            if (Answer3 == CorrectAnswer)
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Congrats!",
                    answer3 + " " + "is correct. Here's the internet details:" + "\n" + "\n" +
                    "Wifi Name: " + SSID + "\n" + "Password: " + Password,
                    "OK");
            }
            else
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Try again", Answer + " is not correct.", "OK");
                RandomQuestion();
            }
        });
    }
}