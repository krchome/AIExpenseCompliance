using ExpenseCompliance.Domain.Claims;
using Microsoft.EntityFrameworkCore;

namespace ExpenseCompliance.Infrastructure.Persistence;

public sealed class ExpenseComplianceDbContext(
    DbContextOptions<ExpenseComplianceDbContext> options) : DbContext(options)
{
    public DbSet<ExpenseClaim> ExpenseClaims => Set<ExpenseClaim>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseComplianceDbContext).Assembly);
    }
}
