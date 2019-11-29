using Prism.Commands;
using Prism.Mvvm;
using QuizApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuizApp.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        private string passWord;
        public string PassWord
        {
            get => passWord;
            set => SetProperty(ref passWord, value);
        }

        public ICommand LoginGuestCommand => new Command(async () =>
        {
            await Prism.PrismApplicationBase.Current.MainPage.Navigation.PushAsync(new QuizPage());
        });

        public ICommand LoginAdminCommand => new Command(async () =>
        {
            if(userName == "admin" && passWord == "admin999")
            {
                await Prism.PrismApplicationBase.Current.MainPage.Navigation.PushAsync(new QuestionsPage());
                ClearFields();
            }
            else
            {
                await Prism.PrismApplicationBase.Current.MainPage.DisplayAlert("Error", "Wrong Username and/or Password", "OK");
                ClearFields();
            }
        });

        private void ClearFields()
        {
            UserName = string.Empty;
            PassWord = string.Empty;
        }

        public LoginPageViewModel()
        {

        }
	}
}
