using AutoMapper;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApiData.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly IMusicApiDao<Song> _songDao;
        private readonly IMapper _mapper;
        public SongRepository(IMusicApiDao<Song> songDao, IMapper mapper)
        {
            _songDao = songDao;
            _mapper = mapper;
        }

        public async Task<ICollection<SongDto>> GetAllAsync()
        {
            var result = await _songDao.GetAllAsync();
            return _mapper.Map<ICollection<SongDto>>(result);
        }

        public async Task<ICollection<SongDto>> GetAllByAlbumIdAsync(long id)
        {
            var result = await _songDao.GetAllAsync();
            var filtered = result.Where(s => s.AlbumId == id);
            return _mapper.Map<ICollection<SongDto>>(filtered);
        }

        public async Task<SongDto> GetSongByIdAndAlbumIdAsync(long id, long songId)
        {
            var result = await _songDao.GetAllAsync();
            var filtered = result.Where(s => s.AlbumId == id && s.Id == songId).SingleOrDefault();
            return _mapper.Map<SongDto>(filtered);
        }

        public async Task<SongDto> GetByIdAsync(long id)
        {
            var result = await _songDao.GetByIdAsync(id);
            return _mapper.Map<SongDto>(result);
        }

        public async Task<SongDto> InsertAsync(SongDto song)
        {
            var result = await _songDao.InsertAsync(_mapper.Map<Song>(song));
            return _mapper.Map<SongDto>(result);
        }

        public async Task<bool> UpdateAsync(SongDto song)
        {
            var result = await _songDao.UpdateAsync(_mapper.Map<Song>(song));
            return result;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _songDao.DeleteAsync(id);
            return result;
        }

        
    }
}
