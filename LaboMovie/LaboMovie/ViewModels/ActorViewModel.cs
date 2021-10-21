using LaboMovie.Models;
using LaboMovie.Services;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LaboMovie.ViewModels
{
    public class ActorViewModel : ViewModelBase
    {
        private int _playedHeight;
        public int playedHeight
        {
            get
            {
                return _playedHeight;
            }
            set
            {
                _playedHeight = value;
                OnPropertyChanged();
            }
        }

        private int _scenarisedHeight;
        public int scenarisedHeight
        {
            get
            {
                return _scenarisedHeight;
            }
            set
            {
                _scenarisedHeight = value;
                OnPropertyChanged();
            }
        }

        private int _realisedHeight;
        public int realisedHeight
        {
            get
            {
                return _realisedHeight;
            }
            set
            {
                _realisedHeight = value;
                OnPropertyChanged();
            }
        }

        private Actor _selectedActor;

        public Actor SelectedActor
        {
            get { return _selectedActor; }
            set { SetValue(ref _selectedActor, value); }
        }

        private ActorDetails _titleMovie;

        public ActorDetails ActorDetails
        {
            get { return _titleMovie; }
            set { 
                _titleMovie = value;
                if (_titleMovie.playedMovies.Count > 0) playedHeight = _titleMovie.playedMovies.Count * 19; else playedHeight = 20;
                if (_titleMovie.scenarisedMovies.Count > 0) scenarisedHeight = _titleMovie.scenarisedMovies.Count * 19; else scenarisedHeight = 20;
                if (_titleMovie.realisedMovies.Count > 0) realisedHeight = _titleMovie.realisedMovies.Count * 19; else realisedHeight = 20;
                OnPropertyChanged();
            }
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

        public ActorViewModel(ActorDetails movie)
        {
            ActorDetails = movie;
        }
    }
}
