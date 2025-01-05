using Mapster;
using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Model.Dtos.Research;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Research.Application.Port;
using UnambaRepoApi.Modules.Research.Domain.Entity;
using UnambaRepoApi.Modules.Research.Domain.IRepository;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;

namespace UnambaRepoApi.Modules.Research.Application.Adapter;

public class ResearchAdapter : IResearchInputPort
{
    private readonly IResearchOutPort _researchOutPort;
    private readonly IResearchRepository _researchRepository;

    public ResearchAdapter(IResearchRepository repository, IResearchOutPort outPort)
    {
        _researchRepository = repository;
        _researchOutPort = outPort;
    }

    public async Task GetAllResearchProject()
    {
        var research = await _researchRepository.GetAllAsync<ResearchProjectEntity>();

        var researchEntities = research.ToList();
        if (!researchEntities.Any())
        {
            _researchOutPort.NotFound("No se encontraron proyectos de investigacion");
            return;
        }

        var researchDtos = researchEntities.Adapt<List<ResearchProjectDto>>();

        _researchOutPort.GetAllResearchProject(researchDtos);
    }

    public async Task GetAllScientificArticle()
    {
        var research = await _researchRepository.GetAllAsync<ScientificArticleEntity>();

        var researchEntities = research.ToList();
        if (!researchEntities.Any())
        {
            _researchOutPort.NotFound("No se encontro articulos");
            return;
        }

        var researchDtos = researchEntities.Adapt<List<ScientificArticleDto>>();

        _researchOutPort.GetAllScientificArticle(researchDtos);
    }
}