using LaboMovie;
using LaboMovie.Models;
using LaboMovie.Services;
using LaboMovie.Tools;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LaboMovie.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        public ObservableCollection<Movie> MovieList { get; set; }

        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                SetValue(ref _selectedMovie, value);
                if (!(_selectedMovie is null))
                    LoadMovie();
            }
        }

        public MovieViewModel()
        {

            MovieList = new ObservableCollection<Movie>();
            LoadItems("http://localhost:41798/api/Movie");
        }

        private async void LoadItems(string url)
        {
            MovieList.Clear();

            IEnumerable<Movie> req = await DependencyService.Get<MovieService>().GetAll(url);

            foreach (Movie item in req)
            {
                MovieList.Add(item);
            }
        }

        private async void LoadMovie()
        {
            Person real = await DependencyService.Get<PersonService>().GetById("http://localhost:41798/api/Person/" + _selectedMovie.RealisatorId);
            Person scenarist = await DependencyService.Get<PersonService>().GetById("http://localhost:41798/api/Person/" + _selectedMovie.ScenaristId);
            Category cat = await DependencyService.Get<CategoryService>().GetById("http://localhost:41798/api/Category/" + _selectedMovie.CategoryId);
            IEnumerable<Casting> castings = await DependencyService.Get<CastingService>().GetById("http://localhost:41798/api/Casting/" + _selectedMovie.Id);

            ObservableCollection<Actor> actors = new ObservableCollection<Actor>();
            IEnumerable<Person> persons = await DependencyService.Get<PersonService>().GetAll("http://localhost:41798/api/Person/");

            actors.Add(new Actor()
            {
                Id = real.Id,
                LastName = real.LastName,
                FirstName = real.FirstName,
                Role = "Réalisateur"
            });
            actors.Add(new Actor()
            {
                Id = scenarist.Id,
                LastName = scenarist.LastName,
                FirstName = scenarist.FirstName,
                Role = "Scénariste"
            });

            foreach (Person p in persons)
            {
                foreach (Casting casting in castings)
                {
                    if(p.Id == casting.PersonId)
                    {
                        actors.Add(new Actor()
                        {
                            Id = p.Id,
                            LastName = p.LastName,
                            FirstName = p.FirstName,
                            Role = casting.Role
                        });
                    }
                }
            }
            await App.Current.MainPage.Navigation.PushModalAsync(new MovieView(_selectedMovie, real, scenarist, cat, actors));
        }
    }
}