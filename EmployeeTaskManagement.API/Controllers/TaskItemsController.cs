using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemsController(ITaskItemService taskItemService){
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _taskItemService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("employee/{employeeId:int}")]
        public IActionResult GetAllFromEmployee(int employeeId)
        {
            var result = _taskItemService.GetAllFromEmployee(employeeId);
            return result.Success ? Ok(result) : NotFound(result);
        }
 
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _taskItemService.Get(id);
            return result.Success ? Ok(result) : NotFound(result);
        }
 
        [HttpPost]
        public IActionResult Add(TaskItemCreateDto dto)
        {
            var result = _taskItemService.Create(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpPut]
        public IActionResult Update(TaskItemUpdateDto dto)
        {
            var result = _taskItemService.Update(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var result = _taskItemService.Delete(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
