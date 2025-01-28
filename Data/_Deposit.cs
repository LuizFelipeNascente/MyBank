using System;

namespace MyBank.Data;

public class _Deposit
{
    public decimal MakeDeposit(decimal newbalance, Guid id)
    {
        var context = new AppDbContext();

        context.Account.Find(id);
        var account = context.Account.Find(id);
        account.Balance = newbalance;
        context.SaveChanges();
        return account.Balance;
        
    }
}
