using System;
using MyBank.Data;
using MyBank.Menus;

namespace MyBank.Entities;

public class Account
{

    public decimal Balance { get; set; }
    public int AccountNumber { get; set; }
    public DateTime Addon { get; set; } 
    
 
    public void Create(AccountBank accountBank)
    {
        accountBank.AccountNumber = CheckAccountNumber();
        accountBank.Balance = 0;
        accountBank.Addon = DateTime.Now;

        var context = new AppDbContext();

        context.Account.Add(accountBank);
        context.SaveChanges();
        Console.WriteLine("Conta criada com sucesso");
        System.Threading.Thread.Sleep(1500);
        new HomeMenu();
       
    }
    
    public int CheckAccountNumber()
    {
        var context = new AppDbContext();
        int lastaccount = context.Account.Max(l => (int?)l.AccountNumber) ?? 0;

        return lastaccount + 1;

    }

}
