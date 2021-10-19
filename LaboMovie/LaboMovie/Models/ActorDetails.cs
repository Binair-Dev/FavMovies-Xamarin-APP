using System.Collections.Generic;

namespace LaboMovie.Models
{
    public class ActorDetails
    {
        public Person person { get; set; }
        public List<TitleMovie> playedMovies { get; set; }
        public List<TitleMovie> realisedMovies { get; set; }
        public List<TitleMovie> scenarisedMovies { get; set; }
    }
}
