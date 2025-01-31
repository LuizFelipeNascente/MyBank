using System;

namespace MyBank.Data;

public class _Transfer
{
    public void MakeTransfer(Guid idOrigin, decimal newbalanceOrigin, Guid idDestination, decimal newbalanceDestination)
    {
        var context = new AppDbContext();

        var accountOrigin = context.Account.Find(idOrigin);
        // Atribuindo ao saldo o novo valor após o transferencia - 
        accountOrigin.Balance = newbalanceOrigin;
        // Savlando as alterações
        context.SaveChanges();

         var accountDestination = context.Account.Find(idOrigin);
        // Atribuindo ao saldo o novo valor após a transferencia +
        accountDestination.Balance = newbalanceDestination;
        // Savlando as alterações
        context.SaveChanges();

    }

    public Guid GetGuidForAccountId(int CodeAccountDestination)
    {
        var context = new AppDbContext();
        var guidAccountId = context.Account.FirstOrDefault(a => a.AccountNumber == CodeAccountDestination);
        return guidAccountId.AccountId;
        
    }
}
