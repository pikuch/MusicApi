using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApiData.DAL
{
    public class MusicApiRepository<TModel> : IMusicApiRepository<TModel> where TModel : class
    {
        private readonly MusicApiDbContext _context = null;
        private readonly DbSet<TModel> _table = null;

        public MusicApiRepository(MusicApiDbContext context)
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

        public void Insert(TModel model)
        {
            _table.Add(model);
            _context.SaveChanges();
        }

        public void Update(TModel model)
        {
            _table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            _table.Remove(_table.Find(id));
            _context.SaveChanges();
        }

    }
}
