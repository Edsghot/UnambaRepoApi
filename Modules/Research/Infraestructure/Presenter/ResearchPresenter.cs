using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.Research;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Research.Application.Port;
using UnambaRepoApi.Modules.Teacher.Application.Port;

namespace UnambaRepoApi.Modules.Research.Infraestructure.Presenter;

public class ResearchPresenter : BasePresenter<object>, IResearchOutPort
{
    public void GetAllResearchProject(IEnumerable<ResearchProjectDto> data)
    {
        Success(data, "Data encontrada");
    }

    public void GetAllScientificArticle(IEnumerable<ScientificArticleDto> data)
    {
        Success(data, "data encontrada");
    }
}