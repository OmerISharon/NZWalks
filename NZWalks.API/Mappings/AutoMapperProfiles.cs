using AutoMapper;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region Examples
            //Create map with members for cases when the fields name are not similar
            //CreateMap<Region, RegionDto>()
            //    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
            //    .ForMember(x => x.Code, opt => opt.MapFrom(x => x.Code))
            //    .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
            //    .ForMember(x => x.RegionImageUrl, opt => opt.MapFrom(x => x.RegionImageUrl))
            //    .ReverseMap();
            #endregion

            #region Regions
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();
            #endregion

            #region Walks
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();
            #endregion
        }
    }
}
