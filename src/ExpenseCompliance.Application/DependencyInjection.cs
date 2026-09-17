using ExpenseCompliance.Application.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseCompliance.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IClaimQueries, ClaimQueries>();
        return services;
    }
}
