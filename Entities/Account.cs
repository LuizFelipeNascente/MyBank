using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Services;
using MyBank.Data;

namespace MyBank.Entities;

public class Account : IAccount
{

    public Account()
    {
        this.AccountNumber = "000001";
        Account.OtherAccounts ++;
    }

    public double Balance { get; set; }
    public string AccountNumber { get; set; }
    public static int OtherAccounts { get; set; }
    
    public void Create(AccountBank data)
    {
        var context = new AppDbContext();
        context.Account.AddRange(data);
        context.SaveChanges();
        Console.WriteLine("Conta criada com sucesso");
    }
    public void Deposit(double value)
    {
        this.Balance = Balance + value;
    }

    public bool Withdraw(double value)
    {
        if(value > Balance)
        return false;

        Balance = Balance - value;
        return true;
    }

    public double CheckBalance()
    {
        return this.Balance;
    }

    public string CheckAccountNumber()
    {
        return this.AccountNumber;
    }

}
