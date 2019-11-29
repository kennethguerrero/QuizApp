using Prism.Commands;
using Prism.Mvvm;
using QuizApp.Models;
using QuizApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
	public class AddQuestionPageViewModel : BindableBase
	{
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

        private string correctAnswer;
        public string CorrectAnswer
        {
            get => correctAnswer;
            set => SetProperty(ref correctAnswer, value);
        }

        public ICommand SaveQuestionCommand => new Command(async () =>
        {
            var quiz = new Quiz
            {
                Question = question,
                Answer1 = answer1,
                Answer2 = answer2,
                Answer3 = answer3,
                CorrectAnswer = correctAnswer
            };

            await App.Database.SaveQuizAsync(quiz);
            await Prism.PrismApplicationBase.Current.MainPage.Navigation.PopAsync();
        });

        public AddQuestionPageViewModel()
        {

        }
	}
}
