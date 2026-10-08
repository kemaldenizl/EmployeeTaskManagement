using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.DataResult;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.Result;
using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using FluentValidation;
using AutoMapper;
using EmployeeTaskManagement.Entities.Concrete;
using EmployeeTaskManagement.Entities.Dtos.TaskItemDtos;

namespace EmployeeTaskManagement.Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EmployeeCreateDto> _createValidator;
        private readonly IValidator<EmployeeUpdateDto> _updateValidator;
        public EmployeeManager
        (
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            IValidator<EmployeeCreateDto> createValidator,
            IValidator<EmployeeUpdateDto> updateValidator
        )
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IDataResult<List<EmployeeDto>>> GetAll(CancellationToken cancellationToken){
            var employees = await _employeeRepository.GetAll(cancellationToken, null, e => e.Tasks);
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);

            return new SuccessDataResult<List<EmployeeDto>>(dtos);
        }
        public async Task<IDataResult<EmployeeDto>> Get(int id, CancellationToken cancellationToken){
            var employee = await _employeeRepository.Get(e => e.Id == id, cancellationToken, e => e.Tasks);
            var dto = _mapper.Map<EmployeeDto>(employee);

            return new SuccessDataResult<EmployeeDto>(dto);
        }
        public async Task<IDataResult<List<TaskItemDto>>> GetTasks(int id, CancellationToken cancellationToken){
            var employee = await _employeeRepository.Get(e => e.Id == id, cancellationToken, e => e.Tasks);
            var dto = _mapper.Map<List<TaskItemDto>>(employee.Tasks);

            return new SuccessDataResult<List<TaskItemDto>>(dto);
        }
        public async Task<IResult> Create(EmployeeCreateDto employeeCreateDto, CancellationToken cancellationToken){
            var validationResult = await _createValidator.ValidateAsync(employeeCreateDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var employee = _mapper.Map<Employee>(employeeCreateDto);
            await _employeeRepository.Add(employee, cancellationToken);

            return new SuccessResult();
        }
        public async Task<IResult> Update(EmployeeUpdateDto employeeUpdateDto, CancellationToken cancellationToken){
            var validationResult = await _updateValidator.ValidateAsync(employeeUpdateDto, cancellationToken);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var employee = await _employeeRepository.Get(employee => employee.Id == employeeUpdateDto.Id, cancellationToken);
            if(employee is null){
                return new ErrorResult();
            }

            _mapper.Map(employeeUpdateDto, employee);
            await _employeeRepository.Update(employee, cancellationToken);

            return new SuccessResult();
        }
        public async Task<IResult> Delete(int id, CancellationToken cancellationToken){
            var employee = await _employeeRepository.Get(employee => employee.Id == id, cancellationToken);
            if(employee is null){
                return new ErrorResult();
            }

            await _employeeRepository.Delete(employee, cancellationToken);

            return new SuccessResult();
        }
    }
}