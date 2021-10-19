using LaboMovie.Models;
using LaboMovie.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboMovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActorView : ContentPage
    {
        public ActorView(ActorDetails movie)
        {
            BindingContext = new ActorViewModel(movie);
            InitializeComponent();
        }
    }
}