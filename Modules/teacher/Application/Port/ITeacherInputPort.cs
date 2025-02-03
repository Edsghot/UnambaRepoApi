using UnambaRepoApi.Model.Dtos.AcademicFormation;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Model.Dtos.TeachingExperienceDto;
using UnambaRepoApi.Model.Dtos.ThesisAdvisingExperience;
using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Model.Dtos.WorkExperience;
using UnambaRepoApi.Modules.User.Domain.Entity;
using TeachingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.TeachingExperienceDto;
using ThesisAdvisingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.ThesisAdvisingExperienceDto;
using WorkExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.WorkExperienceDto;

namespace UnambaRepoApi.Modules.Teacher.Application.Port;

public interface ITeacherInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task Login(LoginDto loginRequest);
    Task SendVerificationEmailAsync(string toEmail);
    Task ValidateCode(string email, string inputCode);

    Task CreateTeacherAsync(CreateTeacherDto teacherDto);

    //teaching experiencia
    Task GetAllTeachingExperiencesByTeacherIdAsync(int teacherId);
    Task GetTeachingExperienceByIdAsync(int id);
    Task CreateTeachingExperienceAsync(CreateTeachingExperienceDto createDto);
    Task UpdateTeachingExperienceAsync(TeachingExperienceDto updateDto);
    Task DeleteTeachingExperienceAsync(int id);

    //teaching advising thesis experiencia
    Task GetAllThesisAdvisingExperiencesByTeacherIdAsync(int teacherId);
    Task GetThesisAdvisingExperienceByIdAsync(int id);
    Task CreateThesisAdvisingExperienceAsync(CreateThesisAdvisingExperienceDto createDto);
    Task UpdateThesisAdvisingExperienceAsync(ThesisAdvisingExperienceDto updateDto);
    Task DeleteThesisAdvisingExperienceAsync(int id);

    //Teaching advising ...........

    Task GetAllWorkExperiencesByTeacherIdAsync(int teacherId);
    Task GetWorkExperienceByIdAsync(int id);
    Task CreateWorkExperienceAsync(CreateWorkExperienceDto createDto);
    Task UpdateWorkExperienceAsync(WorkExperienceDto updateDto);
    Task DeleteWorkExperienceAsync(int id);
    Task GetTeacherStatsAsync(int teacherId);
    Task UpdateTeacherAsync(UpdateTeacherDto updateDto);
    Task GetAllEducationFormationsByTeacherIdAsync(int teacherId);
    Task GetEducationFormationByIdAsync(int id);
    Task CreateEducationFormationAsync(CreateAcademicFormationDto createDto);
    Task UpdateEducationFormationAsync(UpdateAcademicFormationDto updateDto);
    Task DeleteEducationFormationAsync(int id);
}