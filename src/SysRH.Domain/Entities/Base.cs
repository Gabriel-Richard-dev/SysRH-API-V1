using System.Collections.Generic;

namespace SysRH.Domain.Entities;

public abstract class Base
{
    internal List<string> _erros;
    public long Id { get; set; }
    internal IReadOnlyCollection<string> Erros => _erros;
    public abstract bool Validate();

}