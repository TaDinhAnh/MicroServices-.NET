using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Profiles
{
    public class PlatFormProfile : Profile
    {

        public PlatFormProfile()
        {
            //Source -> target

            CreateMap<Platform, PlatFormReadDto>();
            CreateMap<PlatFormCreateDto, Platform>();
        }
    }
}