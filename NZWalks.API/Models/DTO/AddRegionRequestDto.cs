using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        #region Properties
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
        #endregion

        #region Constructors
        public AddRegionRequestDto()
        {
        }
        public AddRegionRequestDto(string code, string name, string? regionImageUrl)
        {
            Code = code;
            Name = name;
            RegionImageUrl = regionImageUrl;
        }
        public AddRegionRequestDto(Region region)
        {
            Code = region.Code;
            Name = region.Name;
            RegionImageUrl = region.RegionImageUrl;
        }
        #endregion
    }
}
