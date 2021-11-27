using AutoMapper;
using MusicApiData.Dtos;
using MusicApiData.Models;

namespace MusicApiData.Profiles
{
    public class ArtistsProfile : Profile
    {
        public ArtistsProfile()
        {
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();
        }
    }
}
