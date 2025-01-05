using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.Research;
using UnambaRepoApi.Model.Dtos.Teacher;

namespace UnambaRepoApi.Modules.Research.Application.Port;

public interface IResearchOutPort : IBasePresenter<object>
{
    void GetAllResearchProject(IEnumerable<ResearchProjectDto> data);
    void GetAllScientificArticle(IEnumerable<ScientificArticleDto> data);
}