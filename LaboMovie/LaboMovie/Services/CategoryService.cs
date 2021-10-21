using LaboMovie.Models;
using LaboMovie.Tools;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace LaboMovie.Services
{
    public class CategoryService : ApiRequester
    {
        public async Task<IEnumerable<Category>> GetAll(string url)
        {
            return await Get<IEnumerable<Category>>(url);
        }
        public async Task<Category> GetById(string url)
        {
            return await Get<Category>(url);
        }
    }
}
