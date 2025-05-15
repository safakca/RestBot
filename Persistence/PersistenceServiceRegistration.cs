using Application.Abstractions;
using Application.Repositories;
using Application.Repositories.Reservations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concretes;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Repositories.Reservations;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Database
        var connectionString = configuration.GetConnectionString("PostgreSQL");
        services.AddDbContext<Context>(options =>
            options.UseNpgsql(connectionString));
       
        // Repositories
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        
        // Reservation
        services.AddScoped(typeof(IReservationReadRepository), typeof(ReservationReadRepository));
        services.AddScoped(typeof(IReservationWriteRepository), typeof(ReservationWriteRepository));
        
        // UnitOfWork 
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
    }
}

