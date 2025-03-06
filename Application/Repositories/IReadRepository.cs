using System.Linq.Expressions;
using Domain.Common;

namespace Application.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    Task<T> GetByIdAsync(int id, bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
}

