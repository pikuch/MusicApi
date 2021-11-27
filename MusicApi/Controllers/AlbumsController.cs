using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApiData.DAL;
using MusicApiData.Dtos;
using MusicApiData.Models;
using MusicApiData.Repositories;
using System.Collections.Generic;

namespace MusicApi.Controllers
{
    [Route("albums")]
    public class AlbumsController : ControllerBase
    {
        
        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(ILogger<AlbumsController> logger, IAlbumRepository albumRepository)
        {
            _logger = logger;
            _albumRepository = albumRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<AlbumDto>> GetAllAlbums()
        {
            var allAlbums = _albumRepository.GetAll();
            return Ok(allAlbums);
        }

        [HttpGet("{id}")]
        public ActionResult<AlbumDto> GetAlbumById(long id)
        {
            var album = _albumRepository.GetById(id);

            if (album == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(album);
            }
        }
    }
}
