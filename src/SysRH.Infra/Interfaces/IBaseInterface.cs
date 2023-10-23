using SysRH.Domain.Entities;

namespace SysRH.Infra.Interfaces;

public interface IBaseInterface<T> where T : Base
{
    Task<T> Create(T obj);
    Task Remove(long id);
    Task<T> Get(long id);
    Task<List<T>> Get();
    
}