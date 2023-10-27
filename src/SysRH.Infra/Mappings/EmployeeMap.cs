using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SysRH.Domain.Entities;

namespace SysRH.Infra.Mappings;

public class EmployeeMap : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");

        builder.HasKey(e => e.Id);
        
        builder.Property(x => x.Id)
            .UseMySqlIdentityColumn()
            .HasColumnType("BIGINT");
        
        builder.Property(e => e.CPF)
            .IsRequired()
            .HasColumnType("BIGINT");
        
        builder.Property(e => e.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(70)");
        
        builder.Property(e => e.Salary)
            .IsRequired()
            .HasColumnType("DECIMAL(12,2)");
        builder.Property(e => e.EmploymentHistory)
            .HasColumnType("VARCHAR(120)");
        builder.Property(e => e.Trainings)
            .HasColumnType("VARCHAR(120)");
    }
}