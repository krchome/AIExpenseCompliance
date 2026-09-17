using Microsoft.Extensions.DependencyInjection;

namespace ExpenseCompliance.AI;

public static class DependencyInjection
{
    public static IServiceCollection AddAIServices(this IServiceCollection services)
    {
        // Model clients arrive in Video 4; this project boundary is established now.
        return services;
    }
}
