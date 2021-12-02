using AutoMapper;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApiData.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IMusicApiDao<Album> _albumDao;
        private readonly IMapper _mapper;
        public AlbumRepository(IMusicApiDao<Album> albumDao, IMapper mapper)
        {
            _albumDao = albumDao;
            _mapper = mapper;
        }

        public async Task<bool> Exists(long id)
        {
            var result = await _albumDao.GetByIdAsync(id);
            return result != null;
        }

        public async Task<ICollection<AlbumDto>> GetAllAsync()
        {
            var result = await _albumDao.GetAllAsync();
            return _mapper.Map<ICollection<AlbumDto>>(result);
        }

        public async Task<AlbumDto> GetByIdAsync(long id)
        {
            var result = await _albumDao.GetByIdAsync(id);
            return _mapper.Map<AlbumDto>(result);
        }

        public async Task<AlbumDto> InsertAsync(AlbumDto album)
        {
            var result = await _albumDao.InsertAsync(_mapper.Map<Album>(album));
            return _mapper.Map<AlbumDto>(result);
        }

        public async Task<bool> UpdateAsync(AlbumDto album)
        {
            var result = await _albumDao.UpdateAsync(_mapper.Map<Album>(album));
            return result;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var result = await _albumDao.DeleteAsync(id);
            return result;
        }

    }
}
