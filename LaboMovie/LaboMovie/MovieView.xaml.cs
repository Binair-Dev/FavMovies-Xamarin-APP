using LaboMovie.Models;
using LaboMovie.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboMovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieView : ContentPage
    {
        public MovieView(Movie movie, Person real, Person scenarist, Category cat, ObservableCollection<Actor> actors)
        {
            BindingContext = new MovieDetailsViewModel(movie, real, scenarist, cat, actors);
            InitializeComponent();
        }
    }
}