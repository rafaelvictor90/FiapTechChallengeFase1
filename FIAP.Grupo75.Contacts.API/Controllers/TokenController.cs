using FIAP.Grupo75.Contacts.API.Models;
using FIAP.Grupo75.Contacts.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FIAP.Grupo75.Contacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ContactsController> _logger;

        public TokenController(IAuthenticate authentication, IConfiguration configuration,
                                         ILogger<ContactsController> logger)
        {
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        ///     Create user
        /// </summary>
        /// <remarks> 
        /// Request example:
        /// Obs.: Will create a new user
        ///       {
        ///         "email": "user@example.com",
        ///         "password": "stringstri"
        ///       }
        /// </remarks>
        /// <param name="userInfo">Object LoginModel</param>
        /// <response code="201">Registration completed successfully.</response>
        /// <response code="400">Failed to process the request.</response>
        /// <response code="500">An error occurred while creating the user. Please try again later.</response>
        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            try
            {
                _logger.LogInformation("TokenController, Method CreateUser, Register a new user.");

                var result = await _authentication.RegisterUser(userInfo.Email, userInfo.Password);

                if (result)
                {
                    return Ok($"User {userInfo.Email} was created successfully");
                }
                else
                {
                    _logger.LogInformation("TokenController, Method CreateUser, Failed to process the request.");
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TokenController, Method CreateUser, An error occurred while fetching user.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }


        /// <summary>
        ///     Log in
        /// </summary>
        /// <remarks> 
        /// Request example:
        /// Obs.: The token will be valid for 10 minutes
        ///       {
        ///         "email": "user@example.com",
        ///         "password": "stringstri"
        ///       }
        /// </remarks>
        /// <param name="userInfo">Object LoginModel</param>
        /// <returns>Returns an authentication token</returns>
        /// <response code="201">Login successfully.</response>
        /// <response code="400">Failed to process the request.</response>
        /// <response code="500">An error occurred while retrieving the token. Please try again later.</response>
        [HttpPost("LoginUser")]
        [AllowAnonymous]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            try
            {
                _logger.LogInformation("TokenController, Method Login, log in.");

                var resul = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

                if (resul)
                {
                    return GenerateToken(userInfo);
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid Login attempt.");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TokenController, Method Login, An error occurred while fetching user.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            try
            {
                _logger.LogInformation("TokenController, Method GenerateToken, Generating token.");

                var claims = new[]
                {
                    new Claim("email", userInfo.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var privateKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

                var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

                var expiration = DateTime.UtcNow.AddMinutes(10);

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: credentials
                    );

                return new UserToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TokenController, Method GenerateToken, An error occurred while generating the token.");
                throw new Exception();
            }
        }
    }
}
