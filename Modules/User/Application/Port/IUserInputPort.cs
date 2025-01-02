using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Modules.User.Domain.Entity;

namespace UnambaRepoApi.Modules.User.Application.Port;

public interface IUserInputPort
{
    Task GetAllUsersAsync();
}