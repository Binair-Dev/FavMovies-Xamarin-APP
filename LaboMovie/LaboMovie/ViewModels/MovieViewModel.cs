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
        public ObservableCollection<Category> CategoryList { get; set; }

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

        private Category _selectedCategory;

        public Category CategoryMovie
        {
            get { return _selectedCategory; }
            set
            {
                SetValue(ref _selectedCategory, value);
                if (!(_selectedCategory is null))
                {
                    if(_selectedCategory.Id != 0)
                        App.Current.MainPage.Navigation.PushModalAsync(new MainPage(_selectedCategory));
                    else
                        App.Current.MainPage.Navigation.PushModalAsync(new MainPage(null));
                }
            }
        }

        public MovieViewModel(Category cat = null)
        {
            if(cat == null)
            {
                MovieList = new ObservableCollection<Movie>();
                CategoryList = new ObservableCollection<Category>();
                LoadItems();
            }
            else
            {
                MovieList = new ObservableCollection<Movie>();
                CategoryList = new ObservableCollection<Category>();
                LoadItems(cat);
            }
        }

        private async void LoadItems()
        {
            MovieList.Clear();

            IEnumerable<Movie> req = await DependencyService.Get<MovieService>().GetAll("http://localhost:41798/api/Movie");
            IEnumerable<Category> cats = await DependencyService.Get<CategoryService>().GetAll("http://localhost:41798/api/Category");

            foreach (Movie item in req)
            {
                MovieList.Add(item);
            }
            CategoryList.Add(new Category() 
            {
                Id = 0, Nom = "Tout"
            });
            foreach (Category item in cats)
            {
                CategoryList.Add(item);
            }
        }

        private async void LoadItems(Category cat)
        {
            MovieList.Clear();

            IEnumerable<Movie> req = await DependencyService.Get<MovieService>().GetAll("http://localhost:41798/api/Movie");
            IEnumerable<Category> cats = await DependencyService.Get<CategoryService>().GetAll("http://localhost:41798/api/Category");

            foreach (Movie item in req)
            {
                if(cat.Id == item.Id)
                    MovieList.Add(item);
            }
            CategoryList.Add(new Category()
            {
                Id = 0,
                Nom = "Tout"
            });
            foreach (Category item in cats)
            {
                CategoryList.Add(item);
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