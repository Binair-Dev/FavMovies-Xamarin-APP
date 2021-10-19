using LaboMovie.Models;
using LaboMovie.Services;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LaboMovie.ViewModels
{
    public class MovieDetailsViewModel : ViewModelBase
    {
        private ObservableCollection<Actor> _actors;

        public ObservableCollection<Actor> Actors
        {
            get { return _actors; }
            set { _actors = value; }
        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _releaseYear;

        public int ReleaseYear
        {
            get { return _releaseYear; }
            set { _releaseYear = value; }
        }

        private string _synopsis;

        public string Synopsis
        {
            get { return _synopsis; }
            set { _synopsis = value; }
        }

        private string _posterUrl;

        public string PosterUrl
        {
            get { return _posterUrl; }
            set { _posterUrl = value; }
        }

        private string _realisator;

        public string Realisator
        {
            get { return _realisator; }
            set { _realisator = value; }
        }

        private string _scenarist;

        public string Scenarist
        {
            get { return _scenarist; }
            set { _scenarist = value; }
        }

        private string _category;

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        private string _personalComment;

        public string PersonalComment
        {
            get { return _personalComment; }
            set { _personalComment = value; }
        }

        private Actor _selectedActor;

        public Actor SelectedActor
        {
            get { return _selectedActor; }
            set
            {
                SetValue(ref _selectedActor, value);
                if (!(_selectedActor is null))
                    LoadActor();
            }
        }

        private ObservableCollection<Person> _actorList;

        public ObservableCollection<Person> ActorList
        {
            get { return _actorList; }
            set { _actorList = value; }
        }


        private Command _closeCommand;
        public Command CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new Command(CloseMethod)); }
        }

        private void CloseMethod()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }

        public MovieDetailsViewModel(Movie movie, Person real, Person scenarist, Category cat, ObservableCollection<Actor> actors)
        {
            Actors = actors;
            LoadItems(movie, real, scenarist, cat);
        }

        private void LoadItems(Movie movie, Person real, Person scenarist, Category cat)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseYear = movie.ReleaseYear;
            Synopsis = movie.Synopsis;
            PosterUrl = movie.PosterUrl;
            Realisator = real.FirstName + " " + real.LastName;
            Scenarist = scenarist.FirstName + " " + scenarist.LastName;
            Category = cat.Nom;
            PersonalComment = movie.PersonalComment;
        }

        private async void LoadActor()
        {
            ActorDetails details = new ActorDetails();
            details.playedMovies = new List<TitleMovie>();
            details.scenarisedMovies = new List<TitleMovie>();
            details.realisedMovies = new List<TitleMovie>();
            Person p = await DependencyService.Get<PersonService>().GetById("http://localhost:41798/api/Person/" + _selectedActor.Id);

            IEnumerable<TitleMovie> played = await DependencyService.Get<PlayedmovieService>().GetById("http://localhost:41798/api/PlayedMovie/" + _selectedActor.Id);
            IEnumerable<TitleMovie> scenarised = await DependencyService.Get<ScenarisedmovieService>().GetById("http://localhost:41798/api/ScenarisedMovie/" + _selectedActor.Id);
            IEnumerable<TitleMovie> realised = await DependencyService.Get<RealisedmovieService>().GetById("http://localhost:41798/api/RealisedMovie/" + _selectedActor.Id);

            foreach (TitleMovie title in played)
            {
                details.playedMovies.Add(title);
            }
            foreach (TitleMovie title in scenarised)
            {
                details.scenarisedMovies.Add(title);
            }
            foreach (TitleMovie title in realised)
            {
                details.realisedMovies.Add(title);
            }

            if (details.playedMovies.Count <= 0) details.playedMovies.Add(new TitleMovie() { Title = "Aucun" });
            if (details.scenarisedMovies.Count <= 0) details.scenarisedMovies.Add(new TitleMovie() { Title = "Aucun" });
            if (details.realisedMovies.Count <= 0) details.realisedMovies.Add(new TitleMovie() { Title = "Aucun" });
            details.person = p;

            await App.Current.MainPage.Navigation.PushModalAsync(new ActorView(details));
        }
    }
}
