using LaboMovie.Models;
using LaboMovie.ViewModels;
using Xamarin.Forms;

namespace LaboMovie
{
    public partial class MainPage : ContentPage
    {
        public MainPage(Category cat = null)
        {
            BindingContext = new MovieViewModel(cat);
            InitializeComponent();
        }
    }
}
