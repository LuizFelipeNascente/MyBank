using System;

namespace MyBank.Data;

public class _CheckBalance
{
    
    public decimal GetBalance(Guid id)
    {
        var context = new AppDbContext();
        var balance = context.Account.Find(id);
        return balance.Balance;
    }

    public string CheckName(Guid id)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        return account.Name;
    }
}
