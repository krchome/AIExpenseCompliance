namespace ExpenseCompliance.Application.Claims;

public interface IClaimQueries
{
    Task<IReadOnlyList<ClaimListItem>> ListAsync(CancellationToken cancellationToken = default);
    Task<ClaimDetails?> GetDetailsAsync(Guid id, CancellationToken cancellationToken = default);
}
