using UnambaRepoApi.Configuration.DataBase;
using UnambaRepoApi.Modules.User.Application.Adapter;
using UnambaRepoApi.Modules.User.Application.Port;
using UnambaRepoApi.Modules.User.Domain.IRepository;
using UnambaRepoApi.Modules.User.Infraestructure.Presenter;
using UnambaRepoApi.Modules.User.Infraestructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySQLConnection"),
    new MySqlServerVersion(new Version(8, 0, 21))));
builder.Services.AddScoped<IUserInputPort, UserAdapter>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserOutPort, UserPresenter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();