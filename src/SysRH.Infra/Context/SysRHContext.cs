using Microsoft.EntityFrameworkCore;
using SysRH.Domain.Entities;

namespace SysRH.Infra.Context;

public class SysRHContext : DbContext
{
    public SysRHContext()
    { }

    public SysRHContext(DbContextOptions<SysRHContext> options) : base(options)
    { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        var connection = "server=localhost; port=3306;database=SYSRH; uid=root;password=";
        options.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
    
    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new EmployeeMap());
    }
    
}