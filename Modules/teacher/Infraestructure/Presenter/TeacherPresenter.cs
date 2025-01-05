using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.Teacher;
using UnambaRepoApi.Modules.Teacher.Application.Port;

namespace UnambaRepoApi.Modules.Teacher.Infraestructure.Presenter;

public class TeacherPresenter : BasePresenter<object>, ITeacherOutPort
{
    public void GetAllAsync(IEnumerable<TeacherDto> data)
    {
        Success(data, "Teacher successfully retrieved.");
    }

    public void GetById(TeacherDto data)
    {
        Success(data, "Teacher data");
    }
}