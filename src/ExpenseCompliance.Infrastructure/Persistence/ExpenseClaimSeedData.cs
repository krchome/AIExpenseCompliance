using ExpenseCompliance.Domain.Claims;
using Microsoft.EntityFrameworkCore;

namespace ExpenseCompliance.Infrastructure.Persistence;

internal static class ExpenseClaimSeedData
{
    public static void Seed(DbContext context)
    {
        var claims = CreateClaims();
        var claimIds = claims.Select(claim => claim.Id).ToArray();
        var referenceNumbers = claims.Select(claim => claim.ReferenceNumber).ToArray();

        var existingClaims = context.Set<ExpenseClaim>()
            .AsNoTracking()
            .Where(claim =>
                claimIds.Contains(claim.Id) ||
                referenceNumbers.Contains(claim.ReferenceNumber))
            .Select(claim => new { claim.Id, claim.ReferenceNumber })
            .ToArray();

        var existingIds = existingClaims.Select(claim => claim.Id).ToHashSet();
        var existingReferenceNumbers = existingClaims
            .Select(claim => claim.ReferenceNumber)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var missingClaims = claims
            .Where(claim =>
                !existingIds.Contains(claim.Id) &&
                !existingReferenceNumbers.Contains(claim.ReferenceNumber))
            .ToArray();

        if (missingClaims.Length == 0)
        {
            return;
        }

        context.Set<ExpenseClaim>().AddRange(missingClaims);
        context.SaveChanges();
    }

    public static async Task SeedAsync(
        DbContext context,
        CancellationToken cancellationToken)
    {
        var claims = CreateClaims();
        var claimIds = claims.Select(claim => claim.Id).ToArray();
        var referenceNumbers = claims.Select(claim => claim.ReferenceNumber).ToArray();

        var existingClaims = await context.Set<ExpenseClaim>()
            .AsNoTracking()
            .Where(claim =>
                claimIds.Contains(claim.Id) ||
                referenceNumbers.Contains(claim.ReferenceNumber))
            .Select(claim => new { claim.Id, claim.ReferenceNumber })
            .ToArrayAsync(cancellationToken);

        var existingIds = existingClaims.Select(claim => claim.Id).ToHashSet();
        var existingReferenceNumbers = existingClaims
            .Select(claim => claim.ReferenceNumber)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var missingClaims = claims
            .Where(claim =>
                !existingIds.Contains(claim.Id) &&
                !existingReferenceNumbers.Contains(claim.ReferenceNumber))
            .ToArray();

        if (missingClaims.Length == 0)
        {
            return;
        }

        context.Set<ExpenseClaim>().AddRange(missingClaims);
        await context.SaveChangesAsync(cancellationToken);
    }

    private static ExpenseClaim[] CreateClaims() =>
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
            "Airport parking for the Christchurch client visit.",
            ClaimStatus.UnderReview),
        new(
            Guid.Parse("9c746fc4-911f-4345-910d-7ee8424c60db"),
            "EXP-2026-0040", "Mia Thompson", "City Central Hotel",
            new DateOnly(2026, 8, 1), 412.00m, "NZD", ExpenseCategory.Accommodation,
            "Two-night accommodation for the quarterly planning meeting.",
            ClaimStatus.Approved)
    ];
}
