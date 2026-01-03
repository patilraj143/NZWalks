using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.data;
using NZWalks.API.Models.domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class regionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbcontext;
        public regionsController(NZWalksDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var regions =await dbcontext.regions.ToListAsync();

                var regionDtos = new List<regionDto>();
                regionDtos = regions.Select(r => new regionDto
                {
                    id = r.id,
                    name = r.name,
                    code = r.code,
                    regionImageURL = r.regionImageURL
                }).ToList();

                return Ok(regionDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getById([FromRoute] Guid id)
        {
            try
            {
                var regions =await dbcontext.regions.FindAsync(id);
                if(regions==null)
                    return NotFound();

                var regionDtos = new regionDto()
                {
                    id = regions.id,
                    name = regions.name,
                    code = regions.code,
                    regionImageURL = regions.regionImageURL,
                };
                return Ok(regionDtos);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> addRegion([FromBody] addRegionModel addRegionModel)
        {
            try
            {
                var regionModel = new region()
                {
                    code = addRegionModel.code,
                    name = addRegionModel.name,
                    regionImageURL = addRegionModel.regionImageURL
                };
                await dbcontext.regions.AddAsync(regionModel);
                await dbcontext.SaveChangesAsync();

                var regionDto = new regionDto()
                {
                    id = regionModel.id,
                    code = regionModel.code,
                    name = regionModel.name,
                    regionImageURL = regionModel.regionImageURL
                };
                return CreatedAtAction(nameof(getById), new { id = regionDto.id }, regionDto);
                
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> updateRegion([FromRoute] Guid id, [FromBody] addRegionModel addRegionModel)
        {
            try
            {
                var regionModel =await dbcontext.regions.FindAsync(id);
                if (regionModel == null)
                    return NotFound();

                regionModel.code = addRegionModel.code;
                regionModel.name = addRegionModel.name;
                regionModel.regionImageURL = addRegionModel.regionImageURL;
                await dbcontext.SaveChangesAsync();

                var regionDto = new regionDto()
                {
                    id = regionModel.id,
                    code = regionModel.code,
                    name = regionModel.name,
                    regionImageURL = regionModel.regionImageURL
                };
                return Ok(regionDto);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> deleteRegion([FromRoute] Guid id)
        {
            try
            {
                var regionModel =await dbcontext.regions.FindAsync(id);
                if(regionModel==null)
                    return NotFound();
                dbcontext.regions.Remove(regionModel);
                await dbcontext.SaveChangesAsync();

                return Ok("Delete successfully" + id);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
