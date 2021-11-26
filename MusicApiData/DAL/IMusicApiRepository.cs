using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApiData.DAL
{
    interface IMusicApiRepository<TModel> where TModel : class
    {
        ICollection<TModel> GetAll();
        TModel GetById(long id);
        void Insert(TModel model);
        void Update(TModel model);
        void Delete(long id);
    }
}
