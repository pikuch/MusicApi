using MusicApiData.Dtos;
using System.Collections.Generic;

namespace MusicApiData.Repositories
{
    public interface IAlbumRepository
    {
        public ICollection<AlbumDto> GetAll();
        public AlbumDto GetById(long id);
        public AlbumDto Insert(AlbumDto album);
        public AlbumDto Update(AlbumDto album);
        public bool Delete(long id);
    }
}
