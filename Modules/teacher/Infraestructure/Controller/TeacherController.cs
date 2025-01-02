using Microsoft.AspNetCore.Mvc;
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