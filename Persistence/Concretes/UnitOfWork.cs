using Application.Abstractions;
using Application.Repositories;
using Domain.Common;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence.Concretes;
public class UnitOfWork : IUnitOfWork
{        
    private readonly Context _context;
    private readonly Dictionary<Type, object> _readRepositories = new();
    private readonly Dictionary<Type, object> _writeRepositories = new();

    public UnitOfWork(Context context)
    {
        _context = context;
    }
    public IReadRepository<T> ReadRepository<T>() where T : BaseEntity
    {
        if (!_readRepositories.ContainsKey(typeof(T)))
        { 
            _readRepositories[typeof(T)] = new ReadRepository<T>(_context);
        }

        return (IReadRepository<T>)_readRepositories[typeof(T)];
    }

    public IWriteRepository<T> WriteRepository<T>() where T : BaseEntity
    {
        if (!_writeRepositories.ContainsKey(typeof(T)))
        {
            _writeRepositories[typeof(T)] = new WriteRepository<T>(_context);
        }
        return (IWriteRepository<T>)_writeRepositories[typeof(T)];    
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}