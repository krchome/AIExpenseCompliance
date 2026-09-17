using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseCompliance.Domain.Claims
{
    public sealed class ExpenseClaim
    {
        private ExpenseClaim() { }

        public ExpenseClaim(
            Guid id,
            string referenceNumber,
            string employeeName,
            string merchant,
            DateOnly transactionDate,
            decimal amount,
            string currency,
            ExpenseCategory category,
            string businessPurpose,
            ClaimStatus status)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            if (string.IsNullOrWhiteSpace(referenceNumber)) throw new ArgumentException("A reference number is required.", nameof(referenceNumber));

            Id = id;
            ReferenceNumber = referenceNumber;
            EmployeeName = employeeName;
            Merchant = merchant;
            TransactionDate = transactionDate;
            Amount = amount;
            Currency = currency;
            Category = category;
            BusinessPurpose = businessPurpose;
            Status = status;
        }

        public Guid Id { get; private set; }
        public string ReferenceNumber { get; private set; } = string.Empty;
        public string EmployeeName { get; private set; } = string.Empty;
        public string Merchant { get; private set; } = string.Empty;
        public DateOnly TransactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public string Currency { get; private set; } = "NZD";
        public ExpenseCategory Category { get; private set; }
        public string BusinessPurpose { get; private set; } = string.Empty;
        public ClaimStatus Status { get; private set; }
    }
}

