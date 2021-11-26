using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicApiData.DAL;
using MusicApiData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApi.Controllers
{
    [ApiController]
    [Route("playlists")]
    public class PlaylistsController : ControllerBase
    {
        
        private readonly ILogger<PlaylistsController> _logger;
        private readonly IMusicApiRepository<Playlist> _repository;

        public PlaylistsController(ILogger<PlaylistsController> logger, IMusicApiRepository<Playlist> repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<ICollection<Playlist>> GetAllPlaylists()
        {
            var allPlaylists = _repository.GetAll();
            return Ok(allPlaylists);
        }

        [HttpGet("{id}")]
        public ActionResult<Playlist> GetPlaylistById(long id)
        {
            var playlist = _repository.GetById(id);
            return Ok(playlist);
        }
    }
}
