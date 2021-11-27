using AutoMapper;
using MusicApiData.Dtos;
using MusicApiData.Models;

namespace MusicApiData.Profiles
{
    public class AlbumsProfile : Profile
    {
        public AlbumsProfile()
        {
            CreateMap<Album, AlbumDto>();
        }
    }
}
