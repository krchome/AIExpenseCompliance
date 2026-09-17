using ExpenseCompliance.Application.Claims;
using ExpenseCompliance.Domain.Claims;

namespace ExpenseCompliance.Infrastructure.Claims;

internal sealed class InMemoryExpenseClaimRepository : IExpenseClaimRepository
{
    private static readonly IReadOnlyList<ExpenseClaim> Claims =
    [
        new(
            Guid.Parse("b5cab2c8-3648-4eb2-9739-5eb8d5225b78"),
            "EXP-2026-0042", "Priya Sharma", "Harbour & Vine",
            new DateOnly(2026, 8, 5), 286.00m, "NZD", ExpenseCategory.ClientMeal,
            "Client dinner with two attendees after the Wellington strategy workshop.",
            ClaimStatus.FinanceReview),
        new(
            Guid.Parse("e69f14bf-e164-429a-b7d0-95b119032297"),
            "EXP-2026-0041", "Daniel Wong", "Auckland Airport Parking",
            new DateOnly(2026, 8, 3), 74.50m, "NZD", ExpenseCategory.Travel,
            "Airport parking for the Christchurch client visit.", ClaimStatus.UnderReview),
        new(
            Guid.Parse("9c746fc4-911f-4345-910d-7ee8424c60db"),
            "EXP-2026-0040", "Mia Thompson", "City Central Hotel",
            new DateOnly(2026, 8, 1), 412.00m, "NZD", ExpenseCategory.Accommodation,
            "Two-night accommodation for the quarterly planning meeting.", ClaimStatus.Approved)
    ];

    public Task<IReadOnlyList<ExpenseClaim>> ListAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult(Claims);

    public Task<ExpenseClaim?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        Task.FromResult(Claims.SingleOrDefault(x => x.Id == id));
}
