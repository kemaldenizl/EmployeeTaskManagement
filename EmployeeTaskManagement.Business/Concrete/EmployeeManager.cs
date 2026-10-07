using EmployeeTaskManagement.Business.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.DataResult;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.Result;
using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.Entities.Dtos.EmployeeDtos;
using FluentValidation;
using AutoMapper;
using EmployeeTaskManagement.Entities.Concrete;

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

        public IDataResult<List<EmployeeDto>> GetAll(){
            var employees = _employeeRepository.GetAll();
            var dtos = _mapper.Map<List<EmployeeDto>>(employees);

            return new SuccessDataResult<List<EmployeeDto>>(dtos);
        }
        public IDataResult<EmployeeDto> Get(int id){
            var employee = _employeeRepository.Get(e => e.Id == id);
            var dto = _mapper.Map<EmployeeDto>(employee);

            return new SuccessDataResult<EmployeeDto>(dto);
        }
        public IResult Create(EmployeeCreateDto employeeCreateDto){
            var validationResult = _createValidator.Validate(employeeCreateDto);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var employee = _mapper.Map<Employee>(employeeCreateDto);
            _employeeRepository.Add(employee);

            return new SuccessResult();
        }
        public IResult Update(EmployeeUpdateDto employeeUpdateDto){
            var validationResult = _updateValidator.Validate(employeeUpdateDto);
            if (!validationResult.IsValid){
                return new ErrorResult(string.Join(" | ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            var employee = _employeeRepository.Get(employee => employee.Id == employeeUpdateDto.Id);
            if(employee is null){
                return new ErrorResult();
            }

            _mapper.Map(employeeUpdateDto, employee);
            _employeeRepository.Update(employee);

            return new SuccessResult();
        }
        public IResult Delete(int id){
            var employee = _employeeRepository.Get(employee => employee.Id == id);
            if(employee is null){
                return new ErrorResult();
            }

            _employeeRepository.Delete(employee);

            return new SuccessResult();
        }
    }
}