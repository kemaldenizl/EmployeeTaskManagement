using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Business.Abstract
{
    public interface IEmployeeService
    {
        Task<IDataResult<List<EmployeeDto>>> GetAll(CancellationToken cancellationToken);
        Task<IDataResult<EmployeeDto>> Get(int id, CancellationToken cancellationToken);
        Task<IDataResult<List<TaskItemDto>>> GetTasks(int id, CancellationToken cancellationToken);
        Task<IResult> Create(EmployeeCreateDto employeeCreateDto, CancellationToken cancellationToken);
        Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto, CancellationToken cancellationToken);
        Task<IResult> Delete(int id, CancellationToken cancellationToken);
    }
}