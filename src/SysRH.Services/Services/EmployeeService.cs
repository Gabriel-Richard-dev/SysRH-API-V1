using AutoMapper;
using SysRH.Domain.Entities;
using SysRH.Infra.Interfaces;
using SysRH.Services.DTO;
using SysRH.Services.Interfaces;

namespace SysRH.Services.Services;

public class EmployeeService : IEmployeeServiceInterface
{
    public EmployeeService(IMapper mapper, IEmployeeRepository employeeRepository)
    {
        _mapper = mapper;
        _employeeRepository = employeeRepository;
    }

    private readonly IMapper _mapper;
    private readonly IEmployeeRepository _employeeRepository;
    
    public async Task<EmployeeDTO> Create(EmployeeDTO employeeDto)
    {
        Employee? employeeExists = await _employeeRepository.Get(employeeDto.Id);
        
        if (employeeExists is null)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var employeeCreated = await _employeeRepository.Create(employee);
        
            return _mapper.Map<EmployeeDTO>(employeeCreated);
        }

        throw new Exception();
    }

    public async Task<EmployeeDTO> Update(EmployeeDTO employeeDto)
    {
        Employee? employeeExists = await _employeeRepository.Get(employeeDto.Id);
        if (employeeExists != null)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.Update(employee);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        throw new Exception();

    }

    public async Task Remove(long id)
    {
        await _employeeRepository.Remove(id);
    }

    public async Task<EmployeeDTO?> Get(long id)
    {
        var employee = await _employeeRepository.Get(id);
        
        return _mapper.Map<EmployeeDTO>(employee);
        
    }

    public async Task<List<EmployeeDTO>> Get()
    {
        return _mapper.Map<List<EmployeeDTO>>(await _employeeRepository.Get());
    }

    public async Task<List<EmployeeDTO>> SearchByName(string name)
    {
        var employeeList = await _employeeRepository.SearchByName(name);
        return _mapper.Map<List<EmployeeDTO>>(employeeList);
    }

    public async Task<EmployeeDTO> GetByCpf(string cpf)
    {
        var employeeExists = await _employeeRepository.GetByCPF(cpf);
        
        return _mapper.Map<EmployeeDTO>(employeeExists);
        

        
    }

    public async Task<String> DownloadHistory(long id)
    {
        var path = await _employeeRepository.DownloadHistory(id);
        return path;

    }

    public async Task<String> DownloadTrainings(long id)
    {
        var path = await _employeeRepository.DownloadTraining(id);
        return path;
    }
}