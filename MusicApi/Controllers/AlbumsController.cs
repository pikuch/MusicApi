using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using MusicApiData.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    /// <summary>
    /// Albums controller responsible for CRUD operations on albums
    /// </summary>
    [ApiController]
    [Route("albums")]
    public class AlbumsController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumRepository _albumRepository;
        private readonly ISongRepository _songRepository;

        /// <summary>
        /// Initializes the controller
        /// </summary>
        /// <param name="logger">Logger to use</param>
        /// <param name="albumRepository">Album repository to use</param>
        /// <param name="songRepository">Song repository to use</param>
        public AlbumsController(
            ILogger<AlbumsController> logger,
            IAlbumRepository albumRepository,
            ISongRepository songRepository)
        {
            _logger = logger;
            _albumRepository = albumRepository;
            _songRepository = songRepository;
        }

        /// <summary>
        /// Returns the list of all albums
        /// </summary>
        /// <returns>List of albums</returns>
        [HttpGet]
        public async Task<ActionResult<ICollection<AlbumDto>>> GetAllAlbums()
        {
            var allAlbums = await _albumRepository.GetAllAsync();
            _logger.LogInformation($"{DateTime.Now} All albums request returned {allAlbums.Count} objects.");
            return Ok(allAlbums);
        }

        /// <summary>
        /// Returns an album with given id
        /// </summary>
        /// <param name="id">Album id to search for</param>
        /// <returns>Requested album or 404 if it is not available</returns>
        [HttpGet("{id}", Name = "GetAlbumById")]
        public async Task<ActionResult<AlbumDto>> GetAlbumById(long id)
        {
            var album = await _albumRepository.GetByIdAsync(id);

            if (album == null)
            {
                _logger.LogInformation($"{DateTime.Now} Get album by id={id} returned 404.");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Get album by id={id} returned the requested album.");
                return Ok(album);
            }
        }

        /// <summary>
        /// Adds a new album
        /// </summary>
        /// <param name="album">Album to add</param>
        /// <returns>Added album if operation successfull</returns>
        [HttpPost]
        public ActionResult<AlbumDto> CreateAlbum(AlbumDto album)
        {
            album.Id = 0;
            var newAlbum = _albumRepository.InsertAsync(album);
            if (newAlbum == null)
            {
                _logger.LogInformation($"{DateTime.Now} Create album with title={album.Title} returned an error.");
                return Conflict();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Create album with title={album.Title} succeeded.");
                return CreatedAtRoute(nameof(GetAlbumById), new { id = newAlbum.Id }, newAlbum);
            }
        }

        /// <summary>
        /// Updates an existing album
        /// </summary>
        /// <param name="id">Id of album to update</param>
        /// <param name="album">New album data</param>
        /// <returns>Action result</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlbum(long id, AlbumDto album)
        {
            album.Id = id;
            AlbumDto existing = await _albumRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            existing.Title = album.Title;
            existing.Year = album.Year;
            await _albumRepository.UpdateAsync(existing);
            return NoContent();
        }

        /// <summary>
        /// Deletes an album
        /// </summary>
        /// <param name="id">Id of album to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlbum(long id)
        {
            AlbumDto existing = await _albumRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            await _albumRepository.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Returns songs from an album with given id
        /// </summary>
        /// <param name="id">Album id to search for</param>
        /// <returns>Requested songs or 404 if they are not available</returns>
        [HttpGet("{id}/songs")]
        public async Task<ActionResult<ICollection<SongDto>>> GetSongsFromAlbum(long id)
        {
            var songs = await _songRepository.GetAllByAlbumIdAsync(id);

            if (songs == null || songs.Count == 0)
            {
                _logger.LogInformation($"{DateTime.Now} Get songs from album with id={id} returned 404.");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Get songs from album with id={id} returned the requested album.");
                return Ok(songs);
            }
        }

        /// <summary>
        /// Returns song with given id from an album with given id
        /// </summary>
        /// <param name="id">Album id to search for</param>
        /// <param name="songId">Song id to search for</param>
        /// <returns>Requested song or 404 if it is not available</returns>
        [HttpGet("{id}/songs/{songId}")]
        public async Task<ActionResult<SongDto>> GetSongFromAlbum(long id, long songId)
        {
            var song = await _songRepository.GetSongByIdAndAlbumIdAsync(id, songId);

            if (song == null)
            {
                _logger.LogInformation($"{DateTime.Now} Get song with id={songId} from album with id={id} returned 404.");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Get song with id={songId} from album with id={id} returned the requested song.");
                return Ok(song);
            }
        }

        /// <summary>
        /// Adds a new song to the given album
        /// </summary>
        /// <param name="id">Album to add the song to</param>
        /// <param name="song">Song to add</param>
        /// <returns>Added song if operation successfull</returns>
        [HttpPost("{id}/songs")]
        public async Task<ActionResult<SongDto>> CreateSong(long id, SongDto song)
        {
            if (song.AlbumId != id)
            {
                _logger.LogInformation($"{DateTime.Now} Create song with title={song.Title} run on the wrong album id.");
                return Conflict();
            }

            var albumExists = await _albumRepository.Exists(song.AlbumId);
            if (!albumExists)
            {
                _logger.LogInformation($"{DateTime.Now} Attempted to create a song in an album that doesn't exist.");
                return Conflict();
            }

            song.Id = 0;
            var newSong = _songRepository.InsertAsync(song);
            
            if (newSong == null)
            {
                _logger.LogInformation($"{DateTime.Now} Create song with title={song.Title} returned an error.");
                return Conflict();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Create song with title={song.Title} succeeded.");
                return Ok(newSong);
            }
        }

        /// <summary>
        /// Deletes song from the given album
        /// </summary>
        /// <param name="id">Album to delete the song from</param>
        /// <param name="songId">Song id to delete</param>
        /// <returns></returns>
        [HttpDelete("{id}/songs/{songId}", Name = "CreateSong")]
        public async Task<ActionResult> DeleteSong(long id, long songId)
        {
            SongDto existing = await _songRepository.GetByIdAsync(songId);
            if (existing == null)
            {
                _logger.LogInformation($"{DateTime.Now} Attempted to delete a song that didn't exist.");
                return NotFound();
            }
            await _songRepository.DeleteAsync(songId);
            _logger.LogInformation($"{DateTime.Now} Deleted a song with id={songId}.");
            return NoContent();
        }

    }
}
