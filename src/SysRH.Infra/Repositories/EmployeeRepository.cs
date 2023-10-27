using Microsoft.EntityFrameworkCore;
using SysRH.Domain.Entities;
using SysRH.Infra.Context;
using SysRH.Infra.Interfaces;

namespace SysRH.Infra.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    private readonly SysRHContext _context;
    public EmployeeRepository(SysRHContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<Employee?> GetByCPF(long cpf)
    {
        var employee = await _context.Set<Employee>()
            .Where(e => e.CPF == cpf)
            .ToListAsync();

        return employee.FirstOrDefault();
    }

    public virtual async Task<String> DownloadHistory(long id)
    {
        var employ = await Get(id);
        var filestring = employ.EmploymentHistory;

        return filestring;
    }

    public virtual async Task<String> DownloadTraining(long id)
    {
        var employ = await Get(id);
        var filestring = employ.Trainings;

        return filestring;
    }

    public virtual async Task<List<Employee>> SearchByName(string parse_name)
    {
        var listemployee = new List<Employee>();
        await foreach (var emp in _context.Employees)
        {
            if (emp.Name.ToLower().Contains(parse_name.ToLower()))
            {
                listemployee.Add(emp);
            }
        }

        return listemployee;
    }
}