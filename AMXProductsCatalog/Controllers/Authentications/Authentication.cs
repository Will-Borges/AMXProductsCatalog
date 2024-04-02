using Microsoft.AspNetCore.Mvc;

namespace AMXProductsCatalog.Controllers.Authentications
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Authentication;
    using AMXProductsCatalog.Views.Users;

    [Route("v1/Authentication")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IUserPresenter _userPresenter;


        public Authentication(IUserPresenter userPresenter)
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
