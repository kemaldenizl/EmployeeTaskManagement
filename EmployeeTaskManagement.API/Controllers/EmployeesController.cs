using System.Threading.Tasks;
using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService){
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetAll(cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.Get(id, cancellationToken);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpGet("{id:int}/tasks")]
        public async Task<IActionResult> GetTasks(int id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.GetTasks(id, cancellationToken);
            return result.Success ? Ok(result) : NotFound(result);
        }
 
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _employeeService.Create(dto, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeUpdateDto dto, CancellationToken cancellationToken)
        {
            var result = await _employeeService.Update(dto, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _employeeService.Delete(id, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
