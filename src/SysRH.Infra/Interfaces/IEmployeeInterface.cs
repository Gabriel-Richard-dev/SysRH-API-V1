using SysRH.Domain.Entities;

namespace SysRH.Infra.Interfaces;

public interface IEmployeeInterface : IBaseInterface<Employee>
{
    
    Task<Employee> GetByCPF(int cpf);
    Task<Employee> DownloadHistory(long id);
    Task<Employee> DownloadTraining(long id);
    Task<List<Employee>> SearchByName(string parse_name);
    
}