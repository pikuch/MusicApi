using Microsoft.EntityFrameworkCore;
using MusicApiData.Models;

namespace MusicApiData
{
    public class MusicApiDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlaylistSong>().HasKey(s => new { s.PlaylistId, s.SongId });

            var albums = new[]
            {
                new Album { Id = 1 }
            };

            var artists = new[]
{
                new Artist { Id = 1 }
            };

            var genres = new[]
{
                new Genre { Id = 1 }
            };

            var songs = new[]
{
                new Song { Id = 1 }
            };

            var playlists = new[]
{
                new Playlist { Id = 1 }
            };

            var playlistSongs = new[]
{
                new PlaylistSong { PlaylistId = 1, SongId = 1 }
            };

            modelBuilder.Entity<Album>().HasData(albums);
            modelBuilder.Entity<Artist>().HasData(artists);
            modelBuilder.Entity<Genre>().HasData(genres);
            modelBuilder.Entity<Song>().HasData(songs);
            modelBuilder.Entity<Playlist>().HasData(playlists);
            modelBuilder.Entity<PlaylistSong>().HasData(playlistSongs);
        }
    }
}
