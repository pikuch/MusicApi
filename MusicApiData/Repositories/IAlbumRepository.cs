using MusicApiData.Dtos;
using System.Collections.Generic;

namespace MusicApiData.Repositories
{
    public interface IAlbumRepository
    {
        public ICollection<AlbumDto> GetAll();
        public AlbumDto GetById(long id);
        public void Insert(AlbumDto album);
        public void Update(AlbumDto album);
        public void Delete(long id);
    }
}
