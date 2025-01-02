using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Modules.User.Domain.Entity;

namespace UnambaRepoApi.Modules.Teacher.Application.Port;

public interface ITeacherInputPort
{
    Task GetAllAsync();
}