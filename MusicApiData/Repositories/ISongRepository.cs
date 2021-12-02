using MusicApiData.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApiData.Repositories
{
    public interface ISongRepository
    {
        public Task<ICollection<SongDto>> GetAllAsync();
        public Task<ICollection<SongDto>> GetAllByAlbumIdAsync(long id);
        public Task<SongDto> GetSongByIdAndAlbumIdAsync(long id, long songId);
        public Task<SongDto> GetByIdAsync(long id);
        public Task<SongDto> InsertAsync(SongDto song);
        public Task<bool> UpdateAsync(SongDto song);
        public Task<bool> DeleteAsync(long id);
    }
}
