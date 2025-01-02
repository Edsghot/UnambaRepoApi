using UnambaRepoApi.Configuration.Context.Repository;
using UnambaRepoApi.Modules.User.Domain.Entity;

namespace UnambaRepoApi.Modules.User.Domain.IRepository;

public interface IUserRepository : IBaseRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
}