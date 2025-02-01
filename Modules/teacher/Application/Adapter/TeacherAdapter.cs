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
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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
            _teacherOutPort.NotFound("Esta mal tus credenciales");
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
}