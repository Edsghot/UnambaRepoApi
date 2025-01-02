namespace UnambaRepoApi.Model.Dtos.EmployeeT;

public record EmployeeTDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Message { get; set; }
    public string Occupation { get; set; }
}