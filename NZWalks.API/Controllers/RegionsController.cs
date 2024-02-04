using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        #region Constructor
        private readonly IRepository<Region> regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRepository<Region> regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        #endregion

        #region CRUD

        #region Get All
        // GET ALL REGIONS
        // GET: https://localhost:portnumber/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            // Get data from database
            var regionsDomain = await regionRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            // Map Domain Model to DTO (Data Transfer Object)
            var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

            // Return a list of DTO
            return Ok(regionsDto);
        }
        #endregion

        #region Get By Id
        // GET SIGNLE REGION BY ID
        // GET: https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            // Get data from database - Domain Models
            var regionDomain = await regionRepository.GetAsync(id);

            // If didn't find region by id - return a NotFound message
            if (regionDomain == null) return NotFound();

            // Map Domain Model to DTO (Data Transfer Object)
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            // Return a DTO
            return Ok(regionDto);
        }
        #endregion

        #region Create
        // CREATE NEW REGION
        // POST: https://localhost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Convert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domain Model to create Region
            await regionRepository.CreateAsync(regionDomainModel);

            // Map Domain Model back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(Get), new { id = regionDto.Id }, regionDto);
        }
        #endregion

        #region Update
        // UPDATE EXISTING REGION
        // PUT: http://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Get data from database - Domain Models
            // id is primary key - can use find() method without specifing the searched property
            var regionDomainModel = await regionRepository.GetAsync(id);

            // If didn't find region by id - return a NotFound message
            if (regionDomainModel == null) return NotFound();

            // Update the existing object with the new data
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await regionRepository.UpdateAsync(regionDomainModel);

            // Convert Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
        #endregion

        #region Delete
        // DELETE EXISTING REGION
        // DELETE: http://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Get data from database - Domain Models
            // id is primary key - can use find() method without specifing the searched property
            var regionDomainModel = await regionRepository.GetAsync(id);

            // If didn't find region by id - return a NotFound message
            if (regionDomainModel == null) return NotFound();

            // Delete region from dbContext and Save.
            await regionRepository.DeleteAsync(regionDomainModel);

            // Return deleted Region back
            // Convert Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return Ok(regionDto);
        }
        #endregion

        #endregion
    }
}
