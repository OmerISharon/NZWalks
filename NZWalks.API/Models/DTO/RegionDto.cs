using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTO
{
    public class RegionDto
    {
        #region Properties
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
        #endregion

        #region Constructors
        public RegionDto()
        {
        }
        public RegionDto(Guid id, string code, string name, string? regionImageUrl)
        {
            Id = id;
            Code = code;
            Name = name;
            RegionImageUrl = regionImageUrl;
        }
        public RegionDto(Region region)
        {
            Id = region.Id;
            Code = region.Code;
            Name = region.Name;
            RegionImageUrl = region.RegionImageUrl;
        }
        #endregion

        #region Methods

        #endregion
    }
}
