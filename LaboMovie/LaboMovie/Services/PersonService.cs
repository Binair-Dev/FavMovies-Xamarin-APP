using LaboMovie.Models;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LaboMovie.Services
{
    public class PersonService : ApiRequester
    {
        public async Task<IEnumerable<Person>> GetAll(string url)
        {
            return await Get<IEnumerable<Person>>(url);
        }
        public async Task<Person> GetById(string url)
        {
            return await Get<Person>(url);
        }
    }
}
