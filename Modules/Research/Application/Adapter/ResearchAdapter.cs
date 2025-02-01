﻿using Mapster;
using Microsoft.EntityFrameworkCore;
using UnambaRepoApi.Model.Dtos.Article;
using UnambaRepoApi.Model.Dtos.project;
using UnambaRepoApi.Model.Dtos.Research;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Research.Application.Port;
using UnambaRepoApi.Modules.Research.Domain.Entity;
using UnambaRepoApi.Modules.Research.Domain.IRepository;
using UnambaRepoApi.Modules.Teacher.Application.Port;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;
using UnambaRepoApi.Modules.Teacher.Domain.IRepository;
using ScientificArticleDto = UnambaRepoApi.Model.Dtos.Research.ScientificArticleDto;

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

    public async Task CreateResearchProjectAsync(CreateResearchProjectDto createDto)
    {
        var researchProject = createDto.Adapt<ResearchProjectEntity>();
        await _researchRepository.AddAsync(researchProject);
        _researchOutPort.Ok("Proyecto de investigación creado exitosamente.");
    }

    public async Task UpdateResearchProjectAsync(int id, CreateResearchProjectDto updateDto)
    {
        var researchProject = await _researchRepository.GetAsync<ResearchProjectEntity>(x => x.Id == id);
        if (researchProject == null)
        {
            _researchOutPort.NotFound("Proyecto de investigación no encontrado.");
            return;
        }

        researchProject = updateDto.Adapt(researchProject);
        await _researchRepository.UpdateAsync(researchProject);
        _researchOutPort.Ok("Proyecto de investigación actualizado exitosamente.");
    }

    public async Task DeleteResearchProjectAsync(int id)
    {
        var researchProject = await _researchRepository.GetAsync<ResearchProjectEntity>(x => x.Id == id);
        if (researchProject == null)
        {
            _researchOutPort.NotFound("Proyecto de investigación no encontrado.");
            return;
        }

        await _researchRepository.DeleteAsync(researchProject);
        _researchOutPort.Ok("Proyecto de investigación eliminado exitosamente.");
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

    public async Task GetResearchProjectByIdAsync(int id)
    {
        var researchProject = await _researchRepository.GetAsync<ResearchProjectEntity>(x => x.Id == id);
        if (researchProject == null)
        {
            _researchOutPort.NotFound("Proyecto de investigación no encontrado.");
            return;
        }

        var researchDto = researchProject.Adapt<ResearchProjectDto>();
        _researchOutPort.Success(researchDto, "data encontrada");
    }


    //++++++++++++++++++++++++++++++++++++++++++ARTICLE

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
    
    public async Task GetScientificArticleByIdAsync(int id)
    {
        var article = await _researchRepository.GetAsync<ScientificArticleEntity>(x => x.Id == id);
        if (article == null)
        {
            _researchOutPort.NotFound("Artículo científico no encontrado.");
            return;
        }

        var articleDto = article.Adapt<ScientificArticleDto>();
        _researchOutPort.Success(articleDto, "Artículo encontrado.");
    }

    public async Task CreateScientificArticleAsync(CreateScientificArticleDto createDto)
    {
        var article = createDto.Adapt<ScientificArticleEntity>();
        await _researchRepository.AddAsync(article);
        _researchOutPort.Ok("Artículo científico creado exitosamente.");
    }

    public async Task UpdateScientificArticleAsync(int id, CreateScientificArticleDto updateDto)
    {
        var article = await _researchRepository.GetAsync<ScientificArticleEntity>(x => x.Id == id);
        if (article == null)
        {
            _researchOutPort.NotFound("Artículo científico no encontrado.");
            return;
        }

        article = updateDto.Adapt(article);
        await _researchRepository.UpdateAsync(article);
        _researchOutPort.Ok("Artículo científico actualizado exitosamente.");
    }

    public async Task DeleteScientificArticleAsync(int id)
    {
        var article = await _researchRepository.GetAsync<ScientificArticleEntity>(x => x.Id == id);
        if (article == null)
        {
            _researchOutPort.NotFound("Artículo científico no encontrado.");
            return;
        }

        await _researchRepository.DeleteAsync(article);
        _researchOutPort.Ok("Artículo científico eliminado exitosamente.");
    }
    
}