using LaboMovie.Models;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LaboMovie.Services
{
    public class ScenarisedmovieService : ApiRequester
    {
        public async Task<IEnumerable<TitleMovie>> GetAll(string url)
        {
            return await Get<IEnumerable<TitleMovie>>(url);
        }
        public async Task<IEnumerable<TitleMovie>> GetById(string url)
        {
            return await Get<IEnumerable<TitleMovie>>(url);
        }
    }
}
