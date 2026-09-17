using ExpenseCompliance.Domain.Claims;

namespace ExpenseCompliance.Application.Claims;

public interface IExpenseClaimRepository
{
    Task<IReadOnlyList<ExpenseClaim>> ListAsync(CancellationToken cancellationToken = default);
    Task<ExpenseClaim?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}
