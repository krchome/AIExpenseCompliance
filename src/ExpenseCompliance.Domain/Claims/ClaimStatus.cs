namespace ExpenseCompliance.Domain.Claims;

public enum ClaimStatus
{
    Draft,
    Processing,
    NeedsVerification,
    Submitted,
    UnderReview,
    ClarificationRequested,
    FinanceReview,
    Approved,
    Rejected,
    Closed
}
