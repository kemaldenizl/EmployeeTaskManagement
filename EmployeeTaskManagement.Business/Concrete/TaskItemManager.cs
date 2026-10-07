using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.DataResult;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.Result;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;
using EmployeeTaskManagement.Entities.Concrete;
using FluentValidation;
using AutoMapper;
using EmployeeTaskManagement.DataAccess.Abstract;

namespace EmployeeTaskManagement.Business.Concrete
{
    public class TaskItemManager : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<TaskItemCreateDto> _createValidator;
        private readonly IValidator<TaskItemUpdateDto> _updateValidator;
        public TaskItemManager
        (
            ITaskItemRepository taskItemRepository,
            IMapper mapper,
            IValidator<TaskItemCreateDto> createValidator,
            IValidator<TaskItemUpdateDto> updateValidator
        )
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IDataResult<List<TaskItemDto>> GetAll(){
            var taskItems = _taskItemRepository.GetAll();
            var dtos = _mapper.Map<List<TaskItemDto>>(taskItems);

            return new SuccessDataResult<List<TaskItemDto>>(dtos);
        }
        public IDataResult<List<TaskItemDto>> GetAllFromEmployee(int employeeId){
            var taskItems = _taskItemRepository.GetAll(e => e.EmployeeId == employeeId);
            var dtos = _mapper.Map<List<TaskItemDto>>(taskItems);

            return new SuccessDataResult<List<TaskItemDto>>(dtos);
        }
        public IDataResult<TaskItemDto> Get(int id){
            var taskItem = _taskItemRepository.Get(e => e.Id == id);
            var dto = _mapper.Map<TaskItemDto>(taskItem);

            return new SuccessDataResult<TaskItemDto>(dto);
        }
        public IResult Create(TaskItemCreateDto taskItemCreateDto){
            var validationResult = _createValidator.Validate(taskItemCreateDto);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var taskItem = _mapper.Map<TaskItem>(taskItemCreateDto);
            _taskItemRepository.Add(taskItem);

            return new SuccessResult();
        }
        public IResult Update(TaskItemUpdateDto taskItemUpdateDto){
            var validationResult = _updateValidator.Validate(taskItemUpdateDto);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var taskItem = _taskItemRepository.Get(taskItem => taskItem.Id == taskItemUpdateDto.Id);
            if(taskItem is null){
                return new ErrorResult();
            }

            _mapper.Map(taskItemUpdateDto, taskItem);
            _taskItemRepository.Update(taskItem);

            return new SuccessResult();
        }
        public IResult Delete(int id){

            var taskItem = _taskItemRepository.Get(taskItem => taskItem.Id == id);
            if(taskItem is null){
                return new ErrorResult();
            }

            _taskItemRepository.Delete(taskItem);

            return new SuccessResult();
        }

    }
}