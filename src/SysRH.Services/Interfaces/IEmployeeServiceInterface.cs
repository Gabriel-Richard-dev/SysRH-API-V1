using SysRH.Services.DTO;

namespace SysRH.Services.Interfaces;

public interface IEmployeeServiceInterface
{
    Task<EmployeeDTO> Create(EmployeeDTO employeeDto);
    Task<EmployeeDTO> Update(EmployeeDTO employeeDto);
    Task Remove(long id);
    Task<EmployeeDTO?> Get(long id);
    Task<List<EmployeeDTO>> Get();
    Task<List<EmployeeDTO>> SearchByName(string name);
    Task<EmployeeDTO> GetByCpf(string cpf);
    Task<String> DownloadHistory(long id);
    Task<String> DownloadTrainings(long id);
}