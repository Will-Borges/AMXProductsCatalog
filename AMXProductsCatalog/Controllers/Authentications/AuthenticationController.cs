using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Authentications
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Authentication;

    [Route("v1/AuthenticationController")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserPresenter _userPresenter;


        public AuthenticationController(IUserPresenter userPresenter)
        {
            _userPresenter = userPresenter; 
        }


        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDTO userDto)
        {
            try
            {
                var token = await _userPresenter.AuthenticateUser(userDto);
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
