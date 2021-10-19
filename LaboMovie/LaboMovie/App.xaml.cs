using LaboMovie.Services;
using Xamarin.Forms;

namespace LaboMovie
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<MovieService>(new MovieService());
            DependencyService.RegisterSingleton<PersonService>(new PersonService());
            DependencyService.RegisterSingleton<CategoryService>(new CategoryService());
            DependencyService.RegisterSingleton<CastingService>(new CastingService());
            DependencyService.RegisterSingleton<PlayedmovieService>(new PlayedmovieService());
            DependencyService.RegisterSingleton<ScenarisedmovieService>(new ScenarisedmovieService());
            DependencyService.RegisterSingleton<RealisedmovieService>(new RealisedmovieService());

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
