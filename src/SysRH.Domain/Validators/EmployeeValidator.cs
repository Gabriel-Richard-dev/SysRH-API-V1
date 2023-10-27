using FluentValidation;
using SysRH.Domain.Entities;

namespace SysRH.Domain.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("O funcionario tem que ter um nome")
            .NotNull()
            .WithMessage("O nome nao pode ser nulo")
            .MinimumLength(3)
            .WithMessage("O nome deve ter no minimo 3 caracteres")
            .MaximumLength(70)
            .WithMessage("O nome deve ter no maximo 70 caracteres");

        RuleFor(x => x.CPF)
            .NotEmpty()
            .WithMessage("O funcionario tem que ter um CPF")
            .NotNull()
            .WithMessage("O CPF NAO PODE SER NULO");
            
            
        RuleFor(x => x.Salary)
            .NotEmpty()
            .WithMessage("O salario nao pode estar vazio")
            .NotNull()
            .WithMessage("O salario nao pode ser nulo");
        
        
    }
}