using UnambaRepoApi.Configuration.Shared;
using UnambaRepoApi.Model.Dtos.Teacher;

namespace UnambaRepoApi.Modules.Teacher.Application.Port;

public interface ITeacherOutPort : IBasePresenter<object>
{
    void GetAllAsync(IEnumerable<TeacherDto> data);
    void GetById(TeacherDto teacher);
    void Login(TeacherDto data);
}