using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService){
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.Get(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
 
        [HttpPost]
        public IActionResult Add(EmployeeCreateDto dto)
        {
            var result = _employeeService.Create(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpPut]
        public IActionResult Update(EmployeeUpdateDto dto)
        {
            var result = _employeeService.Update(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
