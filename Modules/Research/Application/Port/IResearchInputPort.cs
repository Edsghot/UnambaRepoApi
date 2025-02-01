using UnambaRepoApi.Model.Dtos.Article;
using UnambaRepoApi.Model.Dtos.project;
using UnambaRepoApi.Model.Dtos.User;
using UnambaRepoApi.Modules.User.Domain.Entity;

namespace UnambaRepoApi.Modules.Research.Application.Port;

public interface IResearchInputPort
{
    Task GetAllResearchProject();
    Task GetAllScientificArticle();
    Task CreateResearchProjectAsync(CreateResearchProjectDto createDto);
    Task UpdateResearchProjectAsync(int id, CreateResearchProjectDto updateDto);
    Task DeleteResearchProjectAsync(int id);
    Task GetResearchProjectByIdAsync(int id);
    ///article
    Task GetScientificArticleByIdAsync(int id);
    Task CreateScientificArticleAsync(CreateScientificArticleDto createDto);
    Task UpdateScientificArticleAsync(int id, CreateScientificArticleDto updateDto);
    Task DeleteScientificArticleAsync(int id);
}