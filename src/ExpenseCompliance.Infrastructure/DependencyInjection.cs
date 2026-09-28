using ExpenseCompliance.Application.Claims;
using ExpenseCompliance.Infrastructure.Claims;
using ExpenseCompliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseCompliance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(connectionString);

        services.AddDbContext<ExpenseComplianceDbContext>(options =>
            options
                .UseSqlServer(connectionString)
                .UseSeeding((context, _) => ExpenseClaimSeedData.Seed(context))
                .UseAsyncSeeding((context, _, cancellationToken) =>
                    ExpenseClaimSeedData.SeedAsync(context, cancellationToken)));

        services.AddScoped<IExpenseClaimRepository, EfCoreExpenseClaimRepository>();

        return services;
    }
}
