using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;

namespace EmployeeTaskManagement.Business.Abstract
{
    public interface IEmployeeService
    {
        IDataResult<List<EmployeeDto>> GetAll();
        IDataResult<EmployeeDto> Get(int id);
        IResult Create(EmployeeCreateDto employeeCreateDto);
        IResult Update(EmployeeUpdateDto employeeUpdateDto);
        IResult Delete(int id);
    }
}