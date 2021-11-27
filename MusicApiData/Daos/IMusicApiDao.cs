using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApiData.DAL
{
    public interface IMusicApiDao<TModel> where TModel : class
    {
        public ICollection<TModel> GetAll();
        public TModel GetById(long id);
        public TModel Insert(TModel model);
        public TModel Update(TModel model);
        public bool Delete(long id);
    }
}
