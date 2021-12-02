using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApiData.DAL
{
    public interface IMusicApiDao<TModel> where TModel : class
    {
        public Task<ICollection<TModel>> GetAllAsync();
        public Task<TModel> GetByIdAsync(long id);
        public Task<TModel> InsertAsync(TModel model);
        public Task<bool> UpdateAsync(TModel model);
        public Task<bool> DeleteAsync(long id);
    }
}
