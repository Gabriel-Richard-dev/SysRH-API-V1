using SysRH.Domain.Entities;
using System.Collections.Generic;
using SysRH.Infra.Context;
using SysRH.Infra.Interfaces;

namespace SysRH.Infra.Repositories;

public class BaseRepository<T> : IBaseInterface<T> where T : Base
{

    public readonly SysRHContext _context;
    
    public BaseRepository(SysRHContext context)
    {
        _context = context;
    }
    public Task<T> Create(T obj)
    {
        _context.Add
    }

    public Task Remove(long id)
    {
        throw new NotImplementedException();
    }

    public Task<T> Get(long id)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> Get()
    {
        throw new NotImplementedException();
    }
}