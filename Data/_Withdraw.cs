using System;
using System.Diagnostics;
using MyBank.Entities;

namespace MyBank.Data;

public class _Withdraw
{
    public decimal MakeWithdrawal(Guid id, decimal newbalance)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        account.Balance = newbalance;
        context.SaveChanges();
        return account.Balance;
    }

    public string CheckName(Guid id)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        return account.Name;
    }
}
