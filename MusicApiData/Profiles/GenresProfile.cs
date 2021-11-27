using AutoMapper;
using MusicApiData.Dtos;
using MusicApiData.Models;

namespace MusicApiData.Profiles
{
    public class GenresProfile : Profile
    {
        public GenresProfile()
        {
            CreateMap<Genre, GenreDto>();
        }
    }
}
