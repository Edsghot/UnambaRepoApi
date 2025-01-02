using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;

namespace UnambaRepoApi.Modules.Teacher.Application.Adapter;

public class TeacherAdapter : ITeacherInputPort
{
    private readonly ITeacherOutPort _teacherOutPort;
    private readonly ITeacherRepository _teacherRepository;

    public TeacherAdapter(ITeacherRepository repository, ITeacherOutPort teacherOutPort)
    {
        _teacherRepository = repository;
        _teacherOutPort = teacherOutPort;
    }

    public async Task GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync<TeacherEntity>();

        if (!teachers.Any())
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Select(teacher => new TeacherDto
        {
            Id = teacher.Id,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Email = teacher.Email,
            PhoneNumber = teacher.PhoneNumber,
            Gender = teacher.Gender,
            BirthDate = teacher.BirthDate,
            RegistrationCode = teacher.RegistrationCode,
            ProfileImage = teacher.ProfileImage,
            Facebook = teacher.Facebook,
            Instagram = teacher.Instagram,
            LinkedIn = teacher.LinkedIn
        });

        _teacherOutPort.GetAllAsync(teacherDtos);
    }
}