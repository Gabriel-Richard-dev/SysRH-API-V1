using SysRH.Domain.Entities;

namespace SysRH.Infra.Interfaces;

public interface IEmployeeRepository : IBaseInterface<Employee>
{
    
    Task<Employee?> GetByCPF(long cpf);
    Task<String> DownloadHistory(long id);
    Task<String> DownloadTraining(long id);
    Task<List<Employee>> SearchByName(string parse_name);
    
}