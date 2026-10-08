using System.Threading.Tasks;
using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;

        public TaskItemsController(ITaskItemService taskItemService){
            _taskItemService = taskItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _taskItemService.GetAll(cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _taskItemService.Get(id, cancellationToken);
            return result.Success ? Ok(result) : NotFound(result);
        }
 
        [HttpPost]
        public async Task<IActionResult> Add(TaskItemCreateDto dto, CancellationToken cancellationToken)
        {
            var result = await _taskItemService.Create(dto, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpPut]
        public async Task<IActionResult> Update(TaskItemUpdateDto dto, CancellationToken cancellationToken)
        {
            var result = await _taskItemService.Update(dto, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _taskItemService.Delete(id, cancellationToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
