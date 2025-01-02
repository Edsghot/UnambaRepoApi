using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Configuration.Context;
using UnambaRepoApi.Configuration.Context.Repository;
using UnambaRepoApi.Configuration.DataBase;
using UnambaRepoApi.Modules.User.Domain.Entity;
using UnambaRepoApi.Modules.User.Domain.IRepository;

namespace UnambaRepoApi.Modules.User.Infraestructure.Repository;

public class UserRepository : BaseRepository<MySqlContext>, IUserRepository
{
    public UserRepository(MySqlContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }
}