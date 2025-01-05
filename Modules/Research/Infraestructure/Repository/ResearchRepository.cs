using UnambaRepoApi.Configuration.Context;
using UnambaRepoApi.Configuration.Context.Repository;
using UnambaRepoApi.Modules.Research.Domain.IRepository;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;

namespace UnambaRepoApi.Modules.Research.Infraestructure.Repository;

public class ResearchRepository : BaseRepository<MySqlContext>, IResearchRepository
{
    public ResearchRepository(MySqlContext context) : base(context)
    {
    }
}