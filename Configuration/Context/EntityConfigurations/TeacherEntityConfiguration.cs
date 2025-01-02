using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;

namespace UnambaRepoApi.Configuration.Context.EntityConfigurations;

public class TeacherEntityConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.ToTable("Teacher");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(t => t.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.PhoneNumber)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Gender)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.BirthDate)
            .IsRequired();

        builder.Property(t => t.RegistrationCode)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(t => t.Description)
            .HasMaxLength(900);
        builder.Property(t => t.ProfileImage)
            .HasMaxLength(500); // Opcional, no es requerido

        builder.Property(t => t.Facebook)
            .HasMaxLength(200); // Opcional, no es requerido

        builder.Property(t => t.Instagram)
            .HasMaxLength(200); // Opcional, no es requerido

        builder.Property(t => t.LinkedIn)
            .HasMaxLength(200); // Opcional, no es requerido
    }
}