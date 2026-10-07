using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Business.Abstract
{
    public interface ITaskItemService
    {
        IDataResult<List<TaskItemDto>> GetAll();
        IDataResult<List<TaskItemDto>> GetAllFromEmployee(int employeeId);
        IDataResult<TaskItemDto> Get(int id);
        IResult Create(TaskItemCreateDto taskItemCreateDto);
        IResult Update(TaskItemUpdateDto taskItemUpdateDto);
        IResult Delete(int id);
    }
}