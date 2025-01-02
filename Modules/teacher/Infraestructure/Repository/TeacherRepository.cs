using UnambaRepoApi.Configuration.Context;
using UnambaRepoApi.Configuration.Context.Repository;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;

namespace UnambaRepoApi.Modules.Teacher.Infraestructure.Repository;

public class TeacherRepository : BaseRepository<MySqlContext>, ITeacherRepository
{
    public TeacherRepository(MySqlContext context) : base(context)
    {
    }
}