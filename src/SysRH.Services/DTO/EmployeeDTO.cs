namespace SysRH.Services.DTO;

public class EmployeeDTO
{
    public long Id { get; set; }

    public long CPF { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }

    public string EmploymentHistory { get; set; }
    public string Trainings { get; set; }

    public EmployeeDTO()
    { }

    public EmployeeDTO(long id, long cpf, string name, decimal salary, string history, string trainings)
    {
        Id = id;
        CPF = cpf;
        Name = name;
        Salary = salary;
        EmploymentHistory = history;
        Trainings = trainings;
    }

}
