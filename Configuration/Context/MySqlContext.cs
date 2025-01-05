using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Configuration.Context.EntityConfigurations;
using UnambaRepoApi.Configuration.DataBase.EntityConfigurations;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;
using UnambaRepoApi.Modules.User.Domain.Entity;
using UnambaRepoApi.Modules.Teacher;
using UnambaRepoApi.Modules.User;

namespace UnambaRepoApi.Configuration.Context;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=jhedgost.com;Database=dbjhfjuv_UnambaRepo;User=dbjhfjuv_edsghot;Password=Repro321.;";

        optionsBuilder.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 21))
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherEntityConfiguration());
        modelBuilder.ApplyConfiguration(new WorkExperienceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TeachingExperienceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ThesisAdvisingExperienceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ScientificArticleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ResearchProjectEntityConfiguration());
    }
}