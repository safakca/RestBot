using System.Linq.Expressions;
using Application.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Domain.Entities;
 
public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly Context _context;
    private DbSet<T> Table => _context.Set<T>();
 
    public ReadRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
 
        if (!tracking)
            query = query.AsNoTracking();
 
        return query;
    }
 
    public async Task<T> GetByIdAsync(int id, bool tracking = true)
    {
        var query = Table.AsQueryable();
 
        if (!tracking)
            query = query.AsNoTracking();
 
        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }
 
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        if (method == null)
            throw new ArgumentNullException(nameof(method));
 
        var query = Table.Where(method);
 
        if (!tracking)
            query = query.AsNoTracking();
 
        return query;
    }
}