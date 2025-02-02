using Microsoft.AspNetCore.Mvc;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Model.Dtos.TeachingExperienceDto;
using UnambaRepoApi.Model.Dtos.ThesisAdvisingExperience;
using UnambaRepoApi.Model.Dtos.WorkExperience;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using TeachingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.TeachingExperienceDto;
using ThesisAdvisingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.ThesisAdvisingExperienceDto;
using WorkExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.WorkExperienceDto;

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

    [HttpPost("AddTeacher")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherDto teacherDto)
    {
        await _teacherInputPort.CreateTeacherAsync(teacherDto);
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

    /// validar
    [HttpGet("GetAllTeachingExperiencesByTeacherId/{teacherId}")]
    public async Task<IActionResult> GetAllTeachingExperiencesByTeacherId(int teacherId)
    {
        await _teacherInputPort.GetAllTeachingExperiencesByTeacherIdAsync(teacherId);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetTeachingExperienceById/{id}")]
    public async Task<IActionResult> GetTeachingExperienceById(int id)
    {
        await _teacherInputPort.GetTeachingExperienceByIdAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPost("CreateTeachingExperience")]
    public async Task<IActionResult> CreateTeachingExperience([FromBody] CreateTeachingExperienceDto createDto)
    {
        await _teacherInputPort.CreateTeachingExperienceAsync(createDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPut("UpdateTeachingExperience")]
    public async Task<IActionResult> UpdateTeachingExperience([FromBody] TeachingExperienceDto updateDto)
    {
        await _teacherInputPort.UpdateTeachingExperienceAsync(updateDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpDelete("DeleteTeachingExperience/{id}")]
    public async Task<IActionResult> DeleteTeachingExperience(int id)
    {
        await _teacherInputPort.DeleteTeachingExperienceAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }


    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    [HttpGet("GetAllThesisAdvisingExperiencesByTeacherId/{teacherId}")]
    public async Task<IActionResult> GetAllThesisAdvisingExperiencesByTeacherId(int teacherId)
    {
        await _teacherInputPort.GetAllThesisAdvisingExperiencesByTeacherIdAsync(teacherId);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetThesisAdvisingExperienceById/{id}")]
    public async Task<IActionResult> GetThesisAdvisingExperienceById(int id)
    {
        await _teacherInputPort.GetThesisAdvisingExperienceByIdAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPost("CreateThesisAdvisingExperience")]
    public async Task<IActionResult> CreateThesisAdvisingExperience(
        [FromBody] CreateThesisAdvisingExperienceDto createDto)
    {
        await _teacherInputPort.CreateThesisAdvisingExperienceAsync(createDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPut("UpdateThesisAdvisingExperience")]
    public async Task<IActionResult> UpdateThesisAdvisingExperience([FromBody] ThesisAdvisingExperienceDto updateDto)
    {
        await _teacherInputPort.UpdateThesisAdvisingExperienceAsync(updateDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpDelete("DeleteThesisAdvisingExperience/{id}")]
    public async Task<IActionResult> DeleteThesisAdvisingExperience(int id)
    {
        await _teacherInputPort.DeleteThesisAdvisingExperienceAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    //=========================================================

    [HttpGet("GetAllWorkExperiencesByTeacherId/{teacherId}")]
    public async Task<IActionResult> GetAllWorkExperiencesByTeacherId(int teacherId)
    {
        await _teacherInputPort.GetAllWorkExperiencesByTeacherIdAsync(teacherId);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetWorkExperienceById/{id}")]
    public async Task<IActionResult> GetWorkExperienceById(int id)
    {
        await _teacherInputPort.GetWorkExperienceByIdAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPost("CreateWorkExperience")]
    public async Task<IActionResult> CreateWorkExperience([FromBody] CreateWorkExperienceDto createDto)
    {
        await _teacherInputPort.CreateWorkExperienceAsync(createDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPut("UpdateWorkExperience")]
    public async Task<IActionResult> UpdateWorkExperience([FromBody] WorkExperienceDto updateDto)
    {
        await _teacherInputPort.UpdateWorkExperienceAsync(updateDto);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }

    [HttpDelete("DeleteWorkExperience/{id}")]
    public async Task<IActionResult> DeleteWorkExperience(int id)
    {
        await _teacherInputPort.DeleteWorkExperienceAsync(id);
        var response = _teacherOutPort.GetResponse;

        return Ok(response);
    }
}