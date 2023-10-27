using System;
using FluentValidation;
using SysRH.Domain.Validators;

namespace SysRH.Domain.Entities;

public class Employee : Base
{
    protected Employee() {}

    public Employee(long cpf, string name, decimal salary, string employmentHistory, string trainings)
    {
        CPF = cpf;
        Name = name;
        Salary = salary;
        EmploymentHistory = employmentHistory;
        Trainings = trainings;

    }

    public long CPF { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string EmploymentHistory{ get; set; }
    public string Trainings { get; set; }

    #region setters
    public void SwitchCPF(int cpf)
    {
        CPF = cpf;
        Validate();
    }

    public void SwitchName(string name)
    {
        Name = name;
        Validate();
    }
    
    public void SwitchSalary(decimal salary)
    {
        Salary = salary;
        Validate();
    }
    
    public void SwitchEmployeeHistory(string history)
    {
        EmploymentHistory = history;
        Validate();
    }
    
    public void SwitchTrainings(string trainings)
    {
        Trainings = trainings;
        Validate();
    }
    #endregion
    public override bool Validate()
    {
        var validate = new EmployeeValidator();
        var validation = validate.Validate(this);
        if (!validation.IsValid)
        {
            foreach (var erros in validation.Errors)
            {
                _erros.Add(erros.ErrorMessage);
            }

            throw new Exception();

        }

        return true;
    }
}