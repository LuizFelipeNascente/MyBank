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
}
