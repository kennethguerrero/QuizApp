using QuizApp.ViewModels;
using Xamarin.Forms;

namespace QuizApp.Views
{
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is QuizPageViewModel viewModel)
            {
                await viewModel.GetQuiz();
            }
        }
    }
}