using LaboMovie.Models;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LaboMovie.Services
{
    public class MovieService : ApiRequester
    {
        public async Task<IEnumerable<Movie>> GetAll(string url)
        {
            return await Get<IEnumerable<Movie>>(url);
        }
    }
}
