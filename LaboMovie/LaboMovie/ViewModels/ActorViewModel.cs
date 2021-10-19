using LaboMovie.Models;
using LaboMovie.Services;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace LaboMovie.ViewModels
{
    public class ActorViewModel : ViewModelBase
    {
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
            set { _titleMovie = value; }
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
