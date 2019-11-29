using QuizApp.ViewModels;
using Xamarin.Forms;

namespace QuizApp.Views
{
    public partial class QuestionsPage : ContentPage
    {
        public QuestionsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is QuestionsPageViewModel viewModel)
            {
                await viewModel.GetQuiz();
            }
        }
    }
}
