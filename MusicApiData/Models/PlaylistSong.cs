namespace MusicApiData.Models
{
    public class PlaylistSong
    {
        public long PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public long SongId { get; set; }
        public Song Song { get; set; }
    }
}
