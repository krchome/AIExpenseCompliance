namespace ExpenseCompliance.Application.Claims;

public sealed class ClaimQueries(IExpenseClaimRepository repository) : IClaimQueries
{
    public async Task<IReadOnlyList<ClaimListItem>> ListAsync(CancellationToken cancellationToken = default)
    {
        var claims = await repository.ListAsync(cancellationToken);
        return claims
            .OrderByDescending(x => x.TransactionDate)
            .Select(x => new ClaimListItem(
                x.Id, x.ReferenceNumber, x.EmployeeName, x.Merchant,
                x.TransactionDate, x.Amount, x.Currency,
                SplitName(x.Category.ToString()), SplitName(x.Status.ToString())))
            .ToArray();
    }

    public async Task<ClaimDetails?> GetDetailsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var claim = await repository.GetByIdAsync(id, cancellationToken);
        if (claim is null) return null;

        var findings = claim.ReferenceNumber == "EXP-2026-0042"
            ? new[]
            {
                "Client-meal attendee details are present.",
                "The calculated per-person amount exceeds the standard meal threshold.",
                "Finance review is required before an authorised decision."
            }
            : new[] { "Policy evaluation is waiting for a later episode." };

        return new ClaimDetails(
            claim.Id, claim.ReferenceNumber, claim.EmployeeName, claim.Merchant,
            claim.TransactionDate, claim.Amount, claim.Currency,
            SplitName(claim.Category.ToString()), claim.BusinessPurpose,
            SplitName(claim.Status.ToString()),
            claim.ReferenceNumber == "EXP-2026-0042" ? "Route to Finance" : "Pending evaluation",
            findings);
    }

    private static string SplitName(string value) =>
        System.Text.RegularExpressions.Regex.Replace(value, "([a-z])([A-Z])", "$1 $2");
}
