using Microsoft.AspNetCore.Mvc;

namespace YellowPage.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly YellowPageDb _context;

        public AuthController(YellowPageDb context)
        {
            _context = context;
        }


        [HttpPost("/signin")]
        public ActionResult SignInUser()
        {
            return Problem("Endpoint not implemented!");
        }

        [HttpPost("/signup")]
        public ActionResult SignUpUser()
        {
            return Problem("Endpoint not implemented!");
        }
    }
}
