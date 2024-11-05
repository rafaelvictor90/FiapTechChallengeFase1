using FIAP.Grupo75.Contacts.Application.DTOs;
using FIAP.Grupo75.Contacts.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FIAP.Grupo75.Contacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(IContactService contactService,
                                         ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        // -- Query methods
        #region GetMethods

        /// <summary>
        ///     Returns the complete list of contacts (Descending order by creation date)
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <returns>Returns list of contacts</returns>
        /// <response code="200">List of contacts retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactGetDTO>>> Get()
        {
            try
            {
                _logger.LogInformation("ContactsController, Method Get, Fetching all contacts.");

                var contacts = await _contactService.GetAllContacts();

                if (contacts == null || !contacts.Any())
                    return NotFound("Contacts not found");

                return Ok(contacts);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "ContactsController, Method Get, Database timeout while fetching contacts.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method Get, An error occurred while fetching contacts.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Returns contact by id
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="id">Contact ID registered in the database</param>
        /// <returns>Returns a contact</returns>
        /// <response code="200">Contact retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("{id:int}", Name = "GetContact")]
        public async Task<ActionResult<ContactGetDTO>> Get(int id)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method GetContact, Fetching a contact.");

                var contact = await _contactService.GetById(id);
                if (contact == null)
                    return NotFound("Contact not found");

                return Ok(contact);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetContact, Database timeout while fetching contact.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetContact, An error occurred while fetching contact.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Return contact by area code (DDD), (Descending order by creation date)
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="ddd">Contact DDD registered in the database</param>
        /// <returns>Returns list of contacts</returns>
        /// <response code="200">List of contacts retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("DDD/{ddd:int}", Name = "GetContactsByDdd")]
        public async Task<ActionResult<ContactGetDTO>> GetByDdd(int ddd)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method GetByDdd, Fetching contacts.");

                var contacts = await _contactService.GetByDdd(ddd.ToString());
                if (contacts == null || !contacts.Any())
                    return NotFound("Contacts not found");

                return Ok(contacts);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetByDdd, Database timeout while fetching contacts.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetByDdd, An error occurred while fetching contacts.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Find contacts by passing part of the text into name, email, telephone and region name
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="search">Text to search the database</param>
        /// <returns>Returns list of contacts</returns>
        /// <response code="200">List of contacts retrieved successfully.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        /// <response code="503">Service is currently unavailable. Please try again later.</response>
        [HttpGet("Search/{search:alpha}", Name = "GetBySearch")]
        public async Task<ActionResult<ContactGetDTO>> GetBySearch(string search)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method GetBySearch, Fetching contacts.");

                var contacts = await _contactService.GetBySearch(search);
                if (contacts == null || !contacts.Any())
                    return NotFound("Contacts not found");

                return Ok(contacts);
            }
            catch (TimeoutException ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetBySearch, Database timeout while fetching contacts.");
                return StatusCode(503, "Service is currently unavailable. Please try again later.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method GetBySearch, An error occurred while fetching contacts.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        #endregion

        /// <summary>
        ///     Register a new contact
        /// </summary>
        /// <remarks> 
        /// Requires authentication via token independent of Role
        /// Request example:
        /// Obs.: It is not necessary to send the ID in this request
        ///       {
        ///         "name": "Contact name",
        ///         "phoneNumber": "12345-6789",
        ///         "email": "test@test.com",
        ///         "ddd": "11"
        ///       }
        /// </remarks>
        /// <param name="contactDTO">Object ContactDTO</param>
        /// <returns>Returns the registered contact</returns>
        /// <response code="201">Contact registered in the database.</response>
        /// <response code="400">Failed to process the request.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactDTO contactDTO)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method Post, Register a new contact.");

                if (contactDTO == null)
                    return BadRequest("Invalid Data");

                var contactGetDTO = await _contactService.Add(contactDTO);

                if (contactGetDTO == null || contactGetDTO.Id == 0)
                    return NotFound("DDD not found");

                return Created("", contactGetDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method Post, An error occurred while fetching contacts.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Update the contact
        /// </summary>
        /// <remarks> 
        /// Requires authentication via token independent of Role
        /// Request example:
        /// Obs.: The ID is required to verify the contact to be recorded
        ///       {
        ///         "id": 1,
        ///         "name": "Contact name",
        ///         "phoneNumber": "12345-6789",
        ///         "email": "test@test.com",
        ///         "ddd": "11"
        ///       }
        /// </remarks>
        /// <param name="id">Contact ID registered in the database</param>
        /// <param name="contactDTO">Object ContactDTO</param>
        /// <returns>Returns updated contact</returns>
        /// <response code="200">The update was successful and data is returned.</response>
        /// <response code="400">Failed to process the request.</response>
        /// <response code="404">The contact to be updated does not exist.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ContactDTO contactDTO)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method Put, Update the contact.");

                if (id != contactDTO.Id)
                    return BadRequest();

                if (contactDTO == null)
                    return BadRequest("Invalid Data");

                var contactGetDTO = await _contactService.Update(contactDTO);

                return Ok(contactDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method Put, An error occurred while fetching contacts.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        /// <summary>
        ///     Delete a contact by ID
        /// </summary>
        /// <remarks> 
        ///     Requires authentication via token independent of Role
        /// </remarks>
        /// <param name="id">Contact ID registered in the database</param>
        /// <returns>Returns the deleted contact</returns>
        /// <response code="200">The contact was successfully deleted and data is returned</response>
        /// <response code="404">The contact to be updated does not exist.</response>
        /// <response code="500">An error occurred while retrieving the items. Please try again later.</response>
        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation("ContactsController, Method Delete, Delete a contact by ID.");

                var contact = await _contactService.GetById(id);
                if (contact == null)
                    return NotFound("Contact not found");

                await _contactService.Remove(id);

                return Ok(contact);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ContactsController, Method Delete, An error occurred while fetching contact.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

    }
}