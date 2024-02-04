using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        #region Constructor
        private readonly IRepository<Walk> walkRepository;
        private readonly IMapper mapper;

        public WalksController(IRepository<Walk> walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        #endregion

        #region CRUD

        #region Get All
        // GET ALL WALKS
        // GET: /api/walks
        // With Full Query: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            // Get data from database
            var walksDomain = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            // Map Domain Model to DTO (Data Transfer Object)
            var walksDto = mapper.Map<List<WalkDto>>(walksDomain);

            // Return a list of DTO
            return Ok(walksDto);
        }
        #endregion

        #region Get By Id
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            // Get data from database - Domain Models
            var walkDomain = await walkRepository.GetAsync(id);

            // If didn't find walk by id - return a NotFound message
            if (walkDomain == null) return NotFound();

            // Map Domain Model to DTO (Data Transfer Object)
            var walkDto = mapper.Map<WalkDto>(walkDomain);

            // Return a DTO
            return Ok(walkDto);
        }
        #endregion

        #region Create
        // CREATE Walks
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            // Map AddWalkRequestDto DTO to Walk Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            // Map Walk Domain Model back to WalkDto
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }
        #endregion

        #region Update
        // UPDATE EXISTING WALK
        // PUT: http://localhost:portnumber/api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Get data from database - Domain Models
            // id is primary key - can use find() method without specifing the searched property
            var walkDomainModel = await walkRepository.GetAsync(id);

            // If didn't find walk by id - return a NotFound message
            if (walkDomainModel == null) return NotFound();

            // Update the existing object with the new data
            walkDomainModel.Name = updateWalkRequestDto.Name;
            walkDomainModel.Description = updateWalkRequestDto.Description;
            walkDomainModel.LengthInKm = updateWalkRequestDto.LengthInKm;
            walkDomainModel.WalkImageUrl = updateWalkRequestDto.WalkImageUrl;
            walkDomainModel.DifficultyId = updateWalkRequestDto.DifficultyId;
            walkDomainModel.RegionId = updateWalkRequestDto.RegionId;

            await walkRepository.UpdateAsync(walkDomainModel);

            // Convert Domain Model to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Get data from database - Domain Models
            // id is primary key - can use find() method without specifing the searched property
            var walkDomainModel = await walkRepository.GetAsync(id);

            // If didn't find walk by id - return a NotFound message
            if (walkDomainModel == null) return NotFound();

            // Delete walk from dbContext and Save.
            await walkRepository.DeleteAsync(walkDomainModel);

            // Return deleted Walk back
            // Convert Domain Model to DTO
            var walkDto = mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }
        #endregion

        #endregion
    }
}
