using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YellowPage.Api.Dtos;
using YellowPage.Api.Models;
using YellowPage.Api.Services;

namespace YellowPage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private IMapper _mapper;
        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }


        [HttpPost("/signin")]
        public ActionResult SignInUser()
        {
            return Problem("Endpoint not implemented!");
        }

        [AllowAnonymous]
        [HttpPost("/register")]
        public ActionResult SignUpUser(RegisterUserDto request)
        {
            // map model to entity
            var user = _mapper.Map<User>(request);

            try
            {
                // create user
                _service.Register(user, request.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
