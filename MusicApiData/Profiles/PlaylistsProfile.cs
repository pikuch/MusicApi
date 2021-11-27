using AutoMapper;
using MusicApiData.Dtos;
using MusicApiData.Models;

namespace MusicApiData.Profiles
{
    public class PlaylistsProfile : Profile
    {
        public PlaylistsProfile()
        {
            CreateMap<Playlist, PlaylistDto>();
        }
    }
}
