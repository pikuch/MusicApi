using System.Collections.Generic;

namespace MusicApiData.Models
{
    public class Song
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int LengthInSeconds { get; set; }
        public long AlbumId { get; set; }
        public Album Album { get; set; }
        public long ArtistId { get; set; }
        public Artist Artist { get; set; }
        public long GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
