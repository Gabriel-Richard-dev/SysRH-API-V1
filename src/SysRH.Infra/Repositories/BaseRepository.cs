using SysRH.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();

        return obj;
    }
    public virtual async Task<T> Update(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj;
    }

    public virtual async Task Remove(long id)
    {
        var obj = await Get(id);
        
        if (obj is not null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
    }

    public virtual async Task<T> Get(long id)
    {
        var obj = await _context.Set<T>()
            .AsNoTrackingWithIdentityResolution()
            .Where<T>(x => (x.Id == id)).ToListAsync();
        
        return obj.FirstOrDefault();
    }

    public virtual async Task<List<T>> Get()
    {
        var list = await _context.Set<T>()
            .AsNoTrackingWithIdentityResolution()
            .ToListAsync();
        
        return list;
    }
}