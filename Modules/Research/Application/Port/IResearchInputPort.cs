using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Modules.User.Domain.Entity;

namespace UnambaRepoApi.Modules.Research.Application.Port;

public interface IResearchInputPort
{
    Task GetAllResearchProject();
    Task GetAllScientificArticle();
}