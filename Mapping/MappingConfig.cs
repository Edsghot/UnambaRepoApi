using Mapster;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Teacher.Domain.Entity;

namespace UnambaRepoApi.Mapping;

public class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<TeacherEntity, TeacherDto>.NewConfig();
        TypeAdapterConfig<WorkExperienceEntity, WorkExperienceDto>.NewConfig();
        TypeAdapterConfig<TeachingExperienceEntity, TeachingExperienceDto>.NewConfig();
        TypeAdapterConfig<ThesisAdvisingExperienceEntity, ThesisAdvisingExperienceDto>.NewConfig();
    }
}