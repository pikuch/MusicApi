using AutoMapper;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using System;
using System.Collections.Generic;

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

        public ICollection<AlbumDto> GetAll()
        {
            return _mapper.Map<ICollection<AlbumDto>>(_albumDao.GetAll());
        }

        public AlbumDto GetById(long id)
        {
            return _mapper.Map<AlbumDto>(_albumDao.GetById(id));
        }

        public AlbumDto Insert(AlbumDto album)
        {
            var newAlbum = album;
            newAlbum.Id = 0;
            return _mapper.Map<AlbumDto>(_albumDao.Insert(_mapper.Map<Album>(newAlbum)));
        }

        public AlbumDto Update(AlbumDto album)
        {
            return _mapper.Map<AlbumDto>(_albumDao.Update(_mapper.Map<Album>(album)));
        }
        public bool Delete(long id)
        {
            return _albumDao.Delete(id);
        }

    }
}
