namespace ExpenseCompliance.Application.Claims;

public sealed record ClaimListItem(
    Guid Id,
    string ReferenceNumber,
    string EmployeeName,
    string Merchant,
    DateOnly TransactionDate,
    decimal Amount,
    string Currency,
    string Category,
    string Status);
