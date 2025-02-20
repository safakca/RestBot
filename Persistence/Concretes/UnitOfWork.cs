using Application.Abstractions;
using Persistence.Contexts;

namespace Persistence.Concretes;
public class UnitOfWork : IUnitOfWork
{        
    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}