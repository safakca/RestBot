using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
   // public DbSet<T> Table { get; }
}