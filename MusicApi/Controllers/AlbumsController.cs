using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using MusicApiData.Repositories;
using System;
using System.Collections.Generic;

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

        /// <summary>
        /// Initializes the controller
        /// </summary>
        /// <param name="logger">Logger to use</param>
        /// <param name="albumRepository">Album repository to use</param>
        public AlbumsController(ILogger<AlbumsController> logger, IAlbumRepository albumRepository)
        {
            _logger = logger;
            _albumRepository = albumRepository;
        }

        /// <summary>
        /// Returns the list of all albums
        /// </summary>
        /// <returns>List of albums</returns>
        [HttpGet]
        public ActionResult<ICollection<AlbumDto>> GetAllAlbums()
        {
            var allAlbums = _albumRepository.GetAll();
            _logger.LogInformation($"{DateTime.Now} All albums request returned {allAlbums.Count} objects.");
            return Ok(allAlbums);
        }

        /// <summary>
        /// Returns an album with given id
        /// </summary>
        /// <param name="id">Album id to search for</param>
        /// <returns>Requested album or 404 if it is not available</returns>
        [HttpGet("{id}")]
        public ActionResult<AlbumDto> GetAlbumById(long id)
        {
            var album = _albumRepository.GetById(id);

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
            var newAlbum = _albumRepository.Insert(album);
            if (newAlbum == null)
            {
                _logger.LogInformation($"{DateTime.Now} Create album with title={album.Title} returned an error.");
                return Conflict();
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} Create album with title={album.Title} succeeded.");
                return Created($"/albums/{newAlbum.Id}" ,newAlbum);
            }
        }
    }
}
