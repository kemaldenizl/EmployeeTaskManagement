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

        public async Task<IDataResult<List<TaskItemDto>>> GetAll(CancellationToken cancellationToken){
            var taskItems = await _taskItemRepository.GetAll(cancellationToken);
            var dtos = _mapper.Map<List<TaskItemDto>>(taskItems);

            return new SuccessDataResult<List<TaskItemDto>>(dtos);
        }
        public async Task<IDataResult<TaskItemDto>> Get(int id, CancellationToken cancellationToken){
            var taskItem = await _taskItemRepository.Get(e => e.Id == id, cancellationToken);
            var dto = _mapper.Map<TaskItemDto>(taskItem);

            return new SuccessDataResult<TaskItemDto>(dto);
        }
        public async Task<IResult> Create(TaskItemCreateDto taskItemCreateDto, CancellationToken cancellationToken){
            var validationResult = await _createValidator.ValidateAsync(taskItemCreateDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var taskItem = _mapper.Map<TaskItem>(taskItemCreateDto);
            await _taskItemRepository.Add(taskItem, cancellationToken);

            return new SuccessResult();
        }
        public async Task<IResult> Update(TaskItemUpdateDto taskItemUpdateDto, CancellationToken cancellationToken){
            var validationResult = await _updateValidator.ValidateAsync(taskItemUpdateDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var taskItem = await _taskItemRepository.Get(taskItem => taskItem.Id == taskItemUpdateDto.Id, cancellationToken);
            if(taskItem is null){
                return new ErrorResult();
            }

            _mapper.Map(taskItemUpdateDto, taskItem);
            await _taskItemRepository.Update(taskItem, cancellationToken);

            return new SuccessResult();
        }
        public async Task<IResult> Delete(int id, CancellationToken cancellationToken){

            var taskItem = await _taskItemRepository.Get(taskItem => taskItem.Id == id, cancellationToken);
            if(taskItem is null){
                return new ErrorResult();
            }

            await _taskItemRepository.Delete(taskItem, cancellationToken);

            return new SuccessResult();
        }

    }
}