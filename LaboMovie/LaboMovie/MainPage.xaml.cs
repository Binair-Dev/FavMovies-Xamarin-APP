using LaboMovie.ViewModels;
using Xamarin.Forms;

namespace LaboMovie
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new MovieViewModel();
            InitializeComponent();
        }
    }
}
