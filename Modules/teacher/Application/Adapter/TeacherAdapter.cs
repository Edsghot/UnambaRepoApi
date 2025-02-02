using System.Net;
using System.Net.Mail;
using Mapster;
using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;
using MailKit.Net.Smtp;
using MimeKit;
using UnambaRepoApi.Model.Dtos.TeachingExperienceDto;
using UnambaRepoApi.Model.Dtos.ThesisAdvisingExperience;
using UnambaRepoApi.Model.Dtos.WorkExperience;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using TeachingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.TeachingExperienceDto;
using ThesisAdvisingExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.ThesisAdvisingExperienceDto;
using WorkExperienceDto = UnambaRepoApi.Model.Dtos.Teacher.WorkExperienceDto;

namespace UnambaRepoApi.Modules.Teacher.Application.Adapter;

public class TeacherAdapter : ITeacherInputPort
{
    private readonly ITeacherOutPort _teacherOutPort;
    private readonly ITeacherRepository _teacherRepository;
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 587;
    private readonly string _smtpUser = "edsghotSolutions@gmail.com";
    private readonly string _smtpPass = "lfqpacmpmnvuwhvb";


    public TeacherAdapter(ITeacherRepository repository, ITeacherOutPort teacherOutPort)
    {
        _teacherRepository = repository;
        _teacherOutPort = teacherOutPort;
    }

    public async Task GetById(int id)
    {
        var teachers = await _teacherRepository.GetAsync<TeacherEntity>(
            x => x.IdTeacher == id,
            query => query
                .Include(t => t.TeachingExperiences)
                .Include(t => t.WorkExperiences)
                .Include(t => t.ThesisAdvisingExperiences).AsNoTracking()
        );
        if (teachers == null)
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<TeacherDto>();
        _teacherOutPort.GetById(teacherDtos);
    }

    public async Task GetAllAsync()
    {
        var teachers = await _teacherRepository.GetAllAsync<TeacherEntity>(query => query
            .Include(t => t.TeachingExperiences)
            .Include(t => t.WorkExperiences)
            .Include(t => t.ThesisAdvisingExperiences).AsNoTracking()
        );

        var teacherEntities = teachers.ToList();
        if (!teacherEntities.Any())
        {
            _teacherOutPort.NotFound("No teacher found.");
            return;
        }

        var teacherDtos = teachers.Adapt<List<TeacherDto>>();

        _teacherOutPort.GetAllAsync(teacherDtos);
    }

    public async Task Login(LoginDto loginRequest)
    {
        var user = await _teacherRepository.GetAsync<TeacherEntity>(x =>
            x.Mail == loginRequest.Email && x.Password == loginRequest.Password);
        if (user == null)
        {
            _teacherOutPort.Error("Esta mal tus credenciales");
            return;
        }

        var teacher = user.Adapt<TeacherDto>();

        _teacherOutPort.Login(teacher);
    }


    private static string GenerateCode()
    {
        var random = new Random();
        return random.Next(1000, 9999).ToString();
    }

    public async Task SendVerificationEmailAsync(string toEmail)
    {
        var code = GenerateCode();

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("Jhedgost", _smtpUser));
        message.To.Add(new MailboxAddress("", toEmail));
        message.Subject = "Código de verificación";

        message.Body = new TextPart("html")
        {
            Text = $"<h2>Tu código de verificación es: <b>{code}</b></h2><p>Este código expira en unos minutos.</p>"
        };

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpUser, _smtpPass);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            var validatioon = await _teacherRepository.GetAsync<ValidateEntity>(x => x.Email == toEmail);
            if (validatioon != null)
            {
                validatioon.Code = code;
                await _teacherRepository.UpdateAsync(validatioon);
            }
            else
            {
                var verification = new ValidateEntity
                {
                    Email = toEmail,
                    Code = code
                };
                await _teacherRepository.AddAsync(verification);
            }

            _teacherOutPort.Ok("Código de verificación enviado");
        }
        catch (Exception ex)
        {
            _teacherOutPort.Error("Error: " + ex.Message);
        }
    }

    public async Task ValidateCode(string email, string inputCode)
    {
        var data = await _teacherRepository.GetAsync<ValidateEntity>(x => x.Email == email && x.Code == inputCode);

        if (data == null)
        {
            _teacherOutPort.Error("El codigo es incorrecto intente de nuevo!");
            return;
        }

        _teacherOutPort.Ok("El codigo es correcto");
    }

    public async Task CreateTeacherAsync(CreateTeacherDto teacherDto)
    {
        var teacher = new TeacherEntity
        {
            FirstName = teacherDto.FirstName,
            LastName = teacherDto.LastName,
            Dni = teacherDto.Dni, // ✅ Agregado
            School = teacherDto.School, // ✅ Agregado
            Mail = teacherDto.Mail,
            Password = teacherDto.Password,
            RegistrationCode = teacherDto.RegistrationCode ?? string.Empty,
            Image = teacherDto.Image,
            Facebook = teacherDto.Facebook,
            Description = teacherDto.Description ?? string.Empty,
            LinkedIn = teacherDto.LinkedIn,
            Orcid = teacherDto.Orcid, // ✅ Agregado
            Scopus = teacherDto.Scopus, // ✅ Agregado
            Concytec = teacherDto.Concytec, // ✅ Agregado

            // Campos adicionales en el Entity que no vienen del DTO
            Phone = string.Empty, // No viene del DTO, se deja vacío
            Gender = false, // No viene del DTO, valor por defecto
            BirthDate = DateTime.MinValue, // No viene del DTO, valor por defecto
            Instagram = null, // No viene del DTO, se deja como null
            Position = string.Empty, // No viene del DTO, se deja vacío
            WorkExperiences = new List<WorkExperienceEntity>(), // Se inicializa vacío
            TeachingExperiences = new List<TeachingExperienceEntity>(), // Se inicializa vacío
            ThesisAdvisingExperiences = new List<ThesisAdvisingExperienceEntity>() // Se inicializa vacío
        };

        await _teacherRepository.AddAsync(teacher);

        _teacherOutPort.Ok("Se creó correctamente el docente.");
    }

    /// <summary>
    /// //////////////////
    /// </summary>
    /// <param name="teacherId"></param>

    #region Teaching Data

    public async Task GetAllTeachingExperiencesByTeacherIdAsync(int teacherId)
    {
        var experiences =
            await _teacherRepository.GetAllAsync<TeachingExperienceEntity>(x => x.Where(x => x.TeacherId == teacherId));
        var experienceEntities = experiences.ToList();
        if (!experienceEntities.Any())
        {
            _teacherOutPort.NotFound("No se encontraron experiencias de enseñanza para el docente.");
            return;
        }

        var experienceDtos = experienceEntities.Adapt<List<TeachingExperienceDto>>();
        _teacherOutPort.Success(experienceDtos, "data");
    }

    public async Task GetTeachingExperienceByIdAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<TeachingExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de enseñanza no encontrada.");
            return;
        }

        var experienceDto = experience.Adapt<TeachingExperienceDto>();
        _teacherOutPort.Success(experienceDto, "data");
    }

    public async Task CreateTeachingExperienceAsync(CreateTeachingExperienceDto createDto)
    {
        var experience = createDto.Adapt<TeachingExperienceEntity>();
        await _teacherRepository.AddAsync(experience);
        _teacherOutPort.Ok("Experiencia de enseñanza creada exitosamente.");
    }

    public async Task UpdateTeachingExperienceAsync(TeachingExperienceDto updateDto)
    {
        var experience = await _teacherRepository.GetAsync<TeachingExperienceEntity>(x => x.Id == updateDto.Id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de enseñanza no encontrada.");
            return;
        }

        experience = updateDto.Adapt(experience);
        await _teacherRepository.UpdateAsync(experience);
        _teacherOutPort.Ok("Experiencia de enseñanza actualizada exitosamente.");
    }

    public async Task DeleteTeachingExperienceAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<TeachingExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de enseñanza no encontrada.");
            return;
        }

        await _teacherRepository.DeleteAsync(experience);
        _teacherOutPort.Ok("Experiencia de enseñanza eliminada exitosamente.");
    }

    #endregion

    #region Teaching Advising data

    public async Task GetAllThesisAdvisingExperiencesByTeacherIdAsync(int teacherId)
    {
        var experiences =
            await _teacherRepository.GetAllAsync<ThesisAdvisingExperienceEntity>(x =>
                x.Where(x => x.TeacherId == teacherId));
        var experienceEntities = experiences.ToList();
        if (!experienceEntities.Any())
        {
            _teacherOutPort.NotFound("No se encontraron experiencias de asesoría de tesis para el docente.");
            return;
        }

        var experienceDtos = experienceEntities.Adapt<List<ThesisAdvisingExperienceDto>>();
        _teacherOutPort.Success(experienceDtos, "data");
    }

    public async Task GetThesisAdvisingExperienceByIdAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<ThesisAdvisingExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de asesoría de tesis no encontrada.");
            return;
        }

        var experienceDto = experience.Adapt<ThesisAdvisingExperienceDto>();
        _teacherOutPort.Success(experienceDto, "data");
    }

    public async Task CreateThesisAdvisingExperienceAsync(CreateThesisAdvisingExperienceDto createDto)
    {
        var experience = createDto.Adapt<ThesisAdvisingExperienceEntity>();
        await _teacherRepository.AddAsync(experience);
        _teacherOutPort.Ok("Experiencia de asesoría de tesis creada exitosamente.");
    }

    public async Task UpdateThesisAdvisingExperienceAsync(ThesisAdvisingExperienceDto updateDto)
    {
        var experience = await _teacherRepository.GetAsync<ThesisAdvisingExperienceEntity>(x => x.Id == updateDto.Id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de asesoría de tesis no encontrada.");
            return;
        }

        experience = updateDto.Adapt(experience);
        await _teacherRepository.UpdateAsync(experience);
        _teacherOutPort.Ok("Experiencia de asesoría de tesis actualizada exitosamente.");
    }

    public async Task DeleteThesisAdvisingExperienceAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<ThesisAdvisingExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia de asesoría de tesis no encontrada.");
            return;
        }

        await _teacherRepository.DeleteAsync(experience);
        _teacherOutPort.Ok("Experiencia de asesoría de tesis eliminada exitosamente.");
    }

    #endregion

    #region Work expericie

    public async Task GetAllWorkExperiencesByTeacherIdAsync(int teacherId)
    {
        var experiences =
            await _teacherRepository.GetAllAsync<WorkExperienceEntity>(x => x.Where(x => x.TeacherId == teacherId));
        var experienceEntities = experiences.ToList();
        if (!experienceEntities.Any())
        {
            _teacherOutPort.NotFound("No se encontraron experiencias laborales para el docente.");
            return;
        }

        var experienceDtos = experienceEntities.Adapt<List<WorkExperienceDto>>();
        _teacherOutPort.Success(experienceDtos, "data");
    }

    public async Task GetWorkExperienceByIdAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<WorkExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia laboral no encontrada.");
            return;
        }

        var experienceDto = experience.Adapt<WorkExperienceDto>();
        _teacherOutPort.Success(experienceDto, "data");
    }

    public async Task CreateWorkExperienceAsync(CreateWorkExperienceDto createDto)
    {
        var experience = createDto.Adapt<WorkExperienceEntity>();
        await _teacherRepository.AddAsync(experience);
        _teacherOutPort.Ok("Experiencia laboral creada exitosamente.");
    }

    public async Task UpdateWorkExperienceAsync(WorkExperienceDto updateDto)
    {
        var experience = await _teacherRepository.GetAsync<WorkExperienceEntity>(x => x.Id == updateDto.Id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia laboral no encontrada.");
            return;
        }

        experience = updateDto.Adapt(experience);
        await _teacherRepository.UpdateAsync(experience);
        _teacherOutPort.Ok("Experiencia laboral actualizada exitosamente.");
    }

    public async Task DeleteWorkExperienceAsync(int id)
    {
        var experience = await _teacherRepository.GetAsync<WorkExperienceEntity>(x => x.Id == id);
        if (experience == null)
        {
            _teacherOutPort.NotFound("Experiencia laboral no encontrada.");
            return;
        }

        await _teacherRepository.DeleteAsync(experience);
        _teacherOutPort.Ok("Experiencia laboral eliminada exitosamente.");
    }

    #endregion
}