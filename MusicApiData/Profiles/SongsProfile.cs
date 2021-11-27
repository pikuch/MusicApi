using AutoMapper;
using MusicApiData.Dtos;
using MusicApiData.Models;

namespace MusicApiData.Profiles
{
    public class SongsProfile : Profile
    {
        public SongsProfile()
        {
            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();
        }
    }
}
