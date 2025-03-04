using Application.Repositories;
using Domain.Common;

namespace Application.Abstractions;
public interface IUnitOfWork : IDisposable
{
    IReadRepository<T> ReadRepository<T>() where T : BaseEntity;
    IWriteRepository<T> WriteRepository<T>() where T : BaseEntity;
    Task<int> SaveChangesAsync();
}