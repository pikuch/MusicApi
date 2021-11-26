using Microsoft.EntityFrameworkCore;
using MusicApiData.Models;
using System;

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
                new Album { Id = 1, Title = "The Eminem Show", Year = 2002 },
                new Album { Id = 2, Title = "Feels So Good", Year = 2002 },
                new Album { Id = 3, Title = "Smash", Year = 1994 },
                new Album { Id = 4, Title = "The House", Year = 2010 }
            };

            var artists = new[]
            {
                new Artist { Id = 1, Name = "Eminem" },
                new Artist { Id = 2, Name = "Atomic Kitten" },
                new Artist { Id = 3, Name = "The Offspring" },
                new Artist { Id = 4, Name = "Katie Melua" }
            };

            var genres = new[]
            {
                new Genre { Id = 1, Name = "Rap rock" },
                new Genre { Id = 2, Name = "Pop" },
                new Genre { Id = 3, Name = "Punk rock" },
                new Genre { Id = 4, Name = "Progressive rock" }
            };

            var songs = new[]
            {
                new Song { Id = 1, Title = "Business", AlbumId = 1, ArtistId = 1, GenreId = 1, LengthInSeconds = 251 },
                new Song { Id = 2, Title = "Square Dance", AlbumId = 1, ArtistId = 1, GenreId = 1, LengthInSeconds = 323 },
                new Song { Id = 3, Title = "Soldier", AlbumId = 1, ArtistId = 1, GenreId = 1, LengthInSeconds = 226 },
                new Song { Id = 4, Title = "Say What You Say", AlbumId = 1, ArtistId = 1, GenreId = 1, LengthInSeconds = 309 },
                new Song { Id = 5, Title = "It's OK!", AlbumId = 2, ArtistId = 2, GenreId = 2, LengthInSeconds = 196 },
                new Song { Id = 6, Title = "Feels So Good", AlbumId = 2, ArtistId = 2, GenreId = 2, LengthInSeconds = 210 },
                new Song { Id = 7, Title = "Walking on the Water", AlbumId = 2, ArtistId = 2, GenreId = 2, LengthInSeconds = 240 },
                new Song { Id = 8, Title = "Bad Habit", AlbumId = 3, ArtistId = 3, GenreId = 3, LengthInSeconds = 223 },
                new Song { Id = 9, Title = "Come Out and Play", AlbumId = 3, ArtistId = 3, GenreId = 3, LengthInSeconds = 197 },
                new Song { Id = 10, Title = "Smash", AlbumId = 3, ArtistId = 3, GenreId = 3, LengthInSeconds = 642 },
                new Song { Id = 11, Title = "The Flood", AlbumId = 4, ArtistId = 4, GenreId = 4, LengthInSeconds = 243 },
                new Song { Id = 12, Title = "A Happy Place", AlbumId = 4, ArtistId = 4, GenreId = 4, LengthInSeconds = 207 },
                new Song { Id = 13, Title = "A Moment of Madness", AlbumId = 4, ArtistId = 4, GenreId = 4, LengthInSeconds = 227 },
                new Song { Id = 14, Title = "Twisted", AlbumId = 4, ArtistId = 4, GenreId = 4, LengthInSeconds = 224 }
            };

            var playlists = new[]
            {
                new Playlist { Id = 1, Name = "Cool playlist", Created = DateTime.Now.AddDays(-200) },
                new Playlist { Id = 2, Name = "Songs to listen to", Created = DateTime.Now.AddDays(-100) },
                new Playlist { Id = 3, Name = "Music", Created = DateTime.Now.AddDays(-50) }
            };

            var playlistSongs = new[]
            {
                new PlaylistSong { PlaylistId = 1, SongId = 5 },
                new PlaylistSong { PlaylistId = 1, SongId = 6 },
                new PlaylistSong { PlaylistId = 1, SongId = 12 },
                new PlaylistSong { PlaylistId = 2, SongId = 1 },
                new PlaylistSong { PlaylistId = 2, SongId = 4 },
                new PlaylistSong { PlaylistId = 2, SongId = 7 },
                new PlaylistSong { PlaylistId = 2, SongId = 9 },
                new PlaylistSong { PlaylistId = 2, SongId = 10 },
                new PlaylistSong { PlaylistId = 2, SongId = 14 },
                new PlaylistSong { PlaylistId = 3, SongId = 2 },
                new PlaylistSong { PlaylistId = 3, SongId = 3 },
                new PlaylistSong { PlaylistId = 3, SongId = 8 },
                new PlaylistSong { PlaylistId = 3, SongId = 11 },
                new PlaylistSong { PlaylistId = 3, SongId = 1 },
                new PlaylistSong { PlaylistId = 3, SongId = 12 },
                new PlaylistSong { PlaylistId = 3, SongId = 13 }
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
