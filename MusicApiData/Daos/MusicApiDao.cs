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
        public async Task<ICollection<TModel>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(long id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<TModel> InsertAsync(TModel model)
        {
            await _table.AddAsync(model);
            if (_context.SaveChanges() == 1)
            {
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(TModel model)
        {
            //_context.Entry(model).State = EntityState.Modified;
            _table.Update(model);
            var result = await _context.SaveChangesAsync();
            return (result == 1);
        }
        public async Task<bool> DeleteAsync(long id)
        {
            _table.Remove(_table.Find(id));
            var result = await _context.SaveChangesAsync();
            return (result == 1);
        }

    }
}
