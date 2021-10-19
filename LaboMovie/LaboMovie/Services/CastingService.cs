using LaboMovie.Models;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LaboMovie.Services
{
    public class CastingService : ApiRequester
    {
        public async Task<IEnumerable<Casting>> GetAll(string url)
        {
            return await Get<IEnumerable<Casting>>(url);
        }
        public async Task<IEnumerable<Casting>> GetById(string url)
        {
            return await Get<IEnumerable<Casting>>(url);
        }
    }
}
