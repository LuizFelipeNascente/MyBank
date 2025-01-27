using System;
using MyBank.Enums;

namespace MyBank.Entities;

public class Transactions
{
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public Guid SourceAccountId { get; set; }
    public string? DestinationAccountId { get; set; }
    public DateTime TransactionDate { get; set; }
    
    public Transactions(decimal value, string type, Guid id)
    {
        this.Amount = value;
        if (Enum.TryParse<TransactionType>(type, true, out var parsedType))
        {
            TransactionType = parsedType;
        }
        else
        {
            throw new ArgumentException($"O tipo de transação '{type}' é inválido.", nameof(type));
        }
        this.SourceAccountId = id;
        this.DestinationAccountId = null;
        this.TransactionDate = DateTime.Now;

    }
}
