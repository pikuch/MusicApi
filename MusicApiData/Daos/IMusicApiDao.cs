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
        public void Insert(TModel model);
        public void Update(TModel model);
        public void Delete(long id);
    }
}
