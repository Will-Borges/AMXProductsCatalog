using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AMXProductsCatalog.Controllers.Users
{
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Users;

    [Route("v1/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserPresenter _userPresenter;


        public UserController(IUserPresenter userPresenter)
        {
            _userPresenter = userPresenter;
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            try
            {
                var createWithSucess = await _userPresenter.CreateUser(user);
                return Ok(createWithSucess);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
