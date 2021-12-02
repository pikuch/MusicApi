using MusicApiData.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApiData.Repositories
{
    public interface IAlbumRepository
    {
        public Task<ICollection<AlbumDto>> GetAllAsync();
        public Task<bool> Exists(long id);
        public Task<AlbumDto> GetByIdAsync(long id);
        public Task<AlbumDto> InsertAsync(AlbumDto album);
        public Task<bool> UpdateAsync(AlbumDto album);
        public Task<bool> DeleteAsync(long id);
    }
}
