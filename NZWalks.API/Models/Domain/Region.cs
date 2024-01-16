using NZWalks.API.Models.DTO;

namespace NZWalks.API.Models.Domain
{
    public class Region
    {
        #region Properties
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
        #endregion

        #region Constructors
        public Region()
        {
        }
        public Region(Guid id, string code, string name, string? regionImageUrl)
        {
            Id = id;
            Code = code;
            Name = name;
            RegionImageUrl = regionImageUrl;
        }
        public Region(string code, string name, string? regionImageUrl)
        {
            Code = code;
            Name = name;
            RegionImageUrl = regionImageUrl;
        }
        public Region(RegionDto regionDto)
        {
            Id = regionDto.Id;
            Code = regionDto.Code;
            Name = regionDto.Name;
            RegionImageUrl = regionDto.RegionImageUrl;
        }
        public Region(AddRegionRequestDto addRegionRequestDto)
        {
            Code = addRegionRequestDto.Code;
            Name = addRegionRequestDto.Name;
            RegionImageUrl = addRegionRequestDto.RegionImageUrl;
        }
        public Region(UpdateRegionRequestDto updateRegionRequestDto)
        {
            Code = updateRegionRequestDto.Code;
            Name = updateRegionRequestDto.Name;
            RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
        }
        #endregion
    }
}
