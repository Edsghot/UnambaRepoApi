namespace UnambaRepoApi.Modules.Teacher.Domain.Entity;

public record TeacherEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string RegistrationCode { get; set; } = string.Empty;
    public string ProfileImage { get; set; } = string.Empty;
    public string? Facebook { get; set; }
    public string? Description { get; set; } = string.Empty;
    public string? Instagram { get; set; }
    public string? LinkedIn { get; set; }
}