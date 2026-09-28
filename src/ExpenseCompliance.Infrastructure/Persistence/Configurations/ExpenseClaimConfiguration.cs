using ExpenseCompliance.Domain.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseCompliance.Infrastructure.Persistence.Configurations;

internal sealed class ExpenseClaimConfiguration : IEntityTypeConfiguration<ExpenseClaim>
{
    public void Configure(EntityTypeBuilder<ExpenseClaim> builder)
    {
        builder.ToTable(
            "ExpenseClaims",
            table => table.HasCheckConstraint(
                "CK_ExpenseClaims_Amount_Positive",
                "[Amount] > 0"));

        builder.HasKey(claim => claim.Id);

        builder.Property(claim => claim.Id)
            .ValueGeneratedNever();

        builder.Property(claim => claim.ReferenceNumber)
            .HasMaxLength(30)
            .IsUnicode(false)
            .IsRequired();

        builder.HasIndex(claim => claim.ReferenceNumber)
            .IsUnique();

        builder.Property(claim => claim.EmployeeName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(claim => claim.Merchant)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(claim => claim.TransactionDate)
            .HasColumnType("date");

        builder.Property(claim => claim.Amount)
            .HasPrecision(18, 2);

        builder.Property(claim => claim.Currency)
            .HasMaxLength(3)
            .IsFixedLength()
            .IsUnicode(false)
            .IsRequired();

        builder.Property(claim => claim.Category)
            .HasConversion<string>()
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(claim => claim.BusinessPurpose)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(claim => claim.Status)
            .HasConversion<string>()
            .HasMaxLength(40)
            .IsRequired();
    }
}
