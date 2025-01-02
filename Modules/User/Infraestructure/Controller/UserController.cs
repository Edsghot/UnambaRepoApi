using UnambaRepoApi.Model.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using UnambaRepoApi.Modules.User.Application.Port;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UnambaRepoApi.Modules.User.Infraestructure.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInputPort _userInputPort;
        private readonly IUserOutPort _userOutPort;

        public UserController(IUserInputPort userInputPort, IUserOutPort userOutPort)
        {
            _userInputPort = userInputPort;
            _userOutPort = userOutPort;            
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _userInputPort.GetAllUsersAsync();
            var response = _userOutPort.GetResponse;

            return Ok(response);
        }

        // GET api/<TeacherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TeacherController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TeacherController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TeacherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
