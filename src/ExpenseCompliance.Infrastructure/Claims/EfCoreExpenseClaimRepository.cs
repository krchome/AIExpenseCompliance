using ExpenseCompliance.Application.Claims;
using ExpenseCompliance.Domain.Claims;
using ExpenseCompliance.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseCompliance.Infrastructure.Claims;

internal sealed class EfCoreExpenseClaimRepository(ExpenseComplianceDbContext dbContext)
    : IExpenseClaimRepository
{
    public async Task<IReadOnlyList<ExpenseClaim>> ListAsync(
        CancellationToken cancellationToken = default) =>
        await dbContext.ExpenseClaims
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<ExpenseClaim?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default) =>
        await dbContext.ExpenseClaims
            .AsNoTracking()
            .SingleOrDefaultAsync(claim => claim.Id == id, cancellationToken);
}
