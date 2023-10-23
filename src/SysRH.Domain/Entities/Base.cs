using System.Collections.Generic;

namespace SysRH.Domain.Entities;

public abstract class Base
{
    public long Id { get; set; }
    internal List<string> _erros;
    public IReadOnlyCollection<string> Erros => _erros;
    public abstract bool Validate();

}