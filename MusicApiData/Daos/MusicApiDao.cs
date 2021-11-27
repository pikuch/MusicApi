using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApiData.DAL
{
    public class MusicApiDao<TModel> : IMusicApiDao<TModel> where TModel : class
    {
        private readonly MusicApiDbContext _context = null;
        private readonly DbSet<TModel> _table = null;

        public MusicApiDao(MusicApiDbContext context)
        {
            _context = context;
            _table = _context.Set<TModel>();
        }
        public ICollection<TModel> GetAll()
        {
            return _table.ToList();
        }

        public TModel GetById(long id)
        {
            return _table.Find(id);
        }

        public TModel Insert(TModel model)
        {
            _table.Add(model);
            if (_context.SaveChanges() == 1)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public TModel Update(TModel model)
        {
            _table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            if (_context.SaveChanges() == 1)
            {
                return model;
            }
            else
            {
                return null;
            }
        }
        public bool Delete(long id)
        {
            _table.Remove(_table.Find(id));
            return _context.SaveChanges() == 1;
        }

    }
}
