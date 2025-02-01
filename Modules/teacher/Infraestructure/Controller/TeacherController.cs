using Microsoft.AspNetCore.Mvc;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Teacher.Application.Port;

namespace UnambaRepoApi.Modules.Teacher.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherInputPort _teacherInputPort;
    private readonly ITeacherOutPort _teacherOutPort;

    public TeacherController(ITeacherInputPort teacherInputPort, ITeacherOutPort teacherOutPort)
    {
        _teacherInputPort = teacherInputPort;
        _teacherOutPort = teacherOutPort;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        await _teacherInputPort.GetAllAsync();
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _teacherInputPort.GetById(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
    {
        await _teacherInputPort.Login(loginRequest);
        var response = _teacherOutPort.GetResponse;


        return Ok(response);
    }

    [HttpPost("SendCodeValidation/{email}")]
    public async Task<IActionResult> SendCodeValidation([FromRoute] string email)
    {
        await _teacherInputPort.SendVerificationEmailAsync(email);
        var response = _teacherOutPort.GetResponse;
        return Ok(response);
    }

    [HttpGet("ValidateMail")]
    public async Task<IActionResult> ValidateEmail([FromQuery] ValidateDto data)
    {
        await _teacherInputPort.ValidateCode(data.Email, data.Code);
        var response = _teacherOutPort.GetResponse;
        return Ok(response);
    }


    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ResearchController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ResearchController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}