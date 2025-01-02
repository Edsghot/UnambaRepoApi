using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.User;

namespace UnambaRepoApi.Modules.User.Application.Port;

public interface IUserOutPort : IBasePresenter<object>
{
    void GetAllUsersAsync(IEnumerable<UserDto> data);
}