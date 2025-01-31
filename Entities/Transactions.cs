using System;
using System.ComponentModel.DataAnnotations;
using MyBank.Enums;

namespace MyBank.Entities;

public class Transactions
{
    [Key]
    public Guid TransactionId { get; private set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public Guid SourceAccountId { get; set; }
    public Guid? DestinationAccountId { get; set; }
    public DateTime TransactionDate { get; private set; }

    // Construtor padrão definando a data da transação
    // com a atual da execução
    public Transactions()
    {
        TransactionDate = DateTime.Now;
    }

    // Recebendo o Id do usuário, valor da transação e tipo 
    // da transação como um texto. Por isso a conversão do tipo para o enum
    public Transactions(decimal value, TransactionType type, Guid id, Guid? destinationAccountId = null)
    {
        Amount = value;
        TransactionType = type;
        SourceAccountId = id;
        DestinationAccountId = destinationAccountId;
        TransactionDate = DateTime.Now;
    }
}
