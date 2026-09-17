namespace ExpenseCompliance.Application.Claims;

public sealed record ClaimDetails(
    Guid Id,
    string ReferenceNumber,
    string EmployeeName,
    string Merchant,
    DateOnly TransactionDate,
    decimal Amount,
    string Currency,
    string Category,
    string BusinessPurpose,
    string Status,
    string Recommendation,
    IReadOnlyList<string> PolicyFindings);
