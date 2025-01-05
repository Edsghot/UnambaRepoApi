using UnambaRepoApi.Configuration.Context;
using UnambaRepoApi.Modules.Teacher.Application.Adapter;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;
using UnambaRepoApi.Modules.Teacher.Infraestructure.Presenter;
using UnambaRepoApi.Modules.Teacher.Infraestructure.Repository;
using UnambaRepoApi.Modules.User.Application.Adapter;
using UnambaRepoApi.Modules.User.Application.Port;
using UnambaRepoApi.Modules.User.Domain.IRepository;
using UnambaRepoApi.Modules.User.Infraestructure.Presenter;
using UnambaRepoApi.Modules.User.Infraestructure.Repository;
using AutoMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Mapping;
using UnambaRepoApi.Modules.Research.Application.Adapter;
using UnambaRepoApi.Modules.Research.Application.Port;
using UnambaRepoApi.Modules.Research.Domain.IRepository;
using UnambaRepoApi.Modules.Research.Infraestructure.Presenter;
using
    UnambaRepoApi.Modules.Research.Infraestructure.Repository; // Asegúrate de incluir el espacio de nombres de AutoMapper

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlContext>();
builder.Services.AddMapster();
MappingConfig.RegisterMappings();

builder.Services.AddScoped<IUserInputPort, UserAdapter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserOutPort, UserPresenter>();

builder.Services.AddScoped<ITeacherInputPort, TeacherAdapter>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherOutPort, TeacherPresenter>();

builder.Services.AddScoped<IResearchInputPort, ResearchAdapter>();
builder.Services.AddScoped<IResearchRepository, ResearchRepository>();
builder.Services.AddScoped<IResearchOutPort, ResearchPresenter>();


// Configuración de CORS para permitir cualquier origen
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Apply migrations and update database automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MySqlContext>();
    if (dbContext.Database.GetPendingMigrations().Any())
    {
        dbContext.Database.Migrate();
        Console.WriteLine("Migraciones aplicadas correctamente.");
    }
    else
    {
        dbContext.Database.EnsureCreated();
        Console.WriteLine("Base de datos ya estaba actualizada.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilitar CORS para todos los orígenes
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();