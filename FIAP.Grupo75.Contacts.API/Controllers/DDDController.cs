using FIAP.Grupo75.Contacts.Application.DTOs;
using FIAP.Grupo75.Contacts.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Grupo75.Contacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DDDController : ControllerBase
    {
        private readonly IDddService _dddService;
        private readonly ILogger<DDDController> _logger;

        public DDDController(IDddService dddService,
                            ILogger<DDDController> logger)
        {
            _dddService = dddService;
            _logger = logger;
        }

        /// <summary>
        ///     Returns the complete list of regions (Sorted by region name)
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <returns>Returns list of area codes and regions</returns>
        /// <response code="200">List of regions retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DddDTO>>> Get()
        {
            try
            {
                _logger.LogInformation("DDDController, Method Get, Fetching all regions.");

                var ddds = await _dddService.GetAllDdd();

                if (ddds == null || !ddds.Any())
                    return NotFound("DDDs not found");

                return Ok(ddds);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "DDDController, Method Get, Database timeout while fetching regions.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DDDController, Method Get, An error occurred while fetching regions.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Returns region by id
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="id">Regions ID registered in the database</param>
        /// <returns>Returns a region</returns>
        /// <response code="200">List of regions retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("{id:int}", Name = "GetDDD")]
        public async Task<ActionResult<DddDTO>> Get(int id)
        {
            try
            {
                _logger.LogInformation("DDDController, Method GetDDD, Fetching all regions.");

                var ddd = await _dddService.GetById(id);

                if (ddd == null)
                    return NotFound("DDD not found");

                return Ok(ddd);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "DDDController, Method GetDDD, Database timeout while fetching regions.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DDDController, Method GetDDD, An error occurred while fetching regions.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Returns region by area code (DDD)
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="ddd">Region DDD registered in the database</param>
        /// <returns>Returns list of area codes and regions</returns>
        /// <response code="200">List of regions retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("Code/{ddd:int}", Name = "GetByDdd")]
        public async Task<ActionResult<DddDTO>> GetByDdd(int ddd)
        {
            try
            {
                _logger.LogInformation("DDDController, Method GetByDdd, Fetching all regions.");

                var entityDdd = await _dddService.GetByDdd(ddd.ToString());

                if (entityDdd == null)
                    return NotFound("DDD not found");

                return Ok(entityDdd);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "DDDController, Method GetByDdd, Database timeout while fetching regions.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DDDController, Method GetByDdd, An error occurred while fetching regions.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Finds regions by passing part of the text in code and name of the region (Sorted by region name)
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="search">Text to search the database</param>
        /// <returns>Returns list of area codes and regions</returns>
        /// <response code="200">List of regions retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("{search:alpha}/Search", Name = "GetDDDBySearch")]
        public async Task<ActionResult<DddDTO>> GetBySearch(string search)
        {
            try
            {
                _logger.LogInformation("DDDController, Method GetBySearch, Fetching all regions.");

                var ddds = await _dddService.GetBySearch(search);
                if (ddds == null)
                    return NotFound("DDDs not found");

                return Ok(ddds);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "DDDController, Method GetBySearch, Database timeout while fetching regions.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DDDController, Method GetBySearch, An error occurred while fetching regions.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
