using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Business.Abstract
{
    public interface ITaskItemService
    {
        Task<IDataResult<List<TaskItemDto>>> GetAll(CancellationToken cancellationToken);
        Task<IDataResult<TaskItemDto>> Get(int id, CancellationToken cancellationToken);
        Task<IResult> Create(TaskItemCreateDto taskItemCreateDto, CancellationToken cancellationToken);
        Task<IResult> Update(TaskItemUpdateDto taskItemUpdateDto, CancellationToken cancellationToken);
        Task<IResult> Delete(int id, CancellationToken cancellationToken);
    }
}