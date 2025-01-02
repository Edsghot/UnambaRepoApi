using UnambaRepoApi.Model.Dtos.Response;
using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Modules.User.Application.Port;

namespace UnambaRepoApi.Modules.User.Infraestructure.Presenter;

public class UserPresenter : BasePresenter<object>, IUserOutPort
{
    public void GetAllUsersAsync(IEnumerable<UserDto> data)
    {
        Success(data, "Users successfully retrieved.");
    }

    public void NotFound(string message = "Data not found")
    {
        base.NotFound(message);
    }
}