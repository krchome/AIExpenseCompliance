using ExpenseCompliance.Application.Claims;
using ExpenseCompliance.Infrastructure.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseCompliance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IExpenseClaimRepository, InMemoryExpenseClaimRepository>();
        return services;
    }
}
