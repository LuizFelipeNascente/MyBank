using System;
using MyBank.Entities;

namespace MyBank.Services;

public interface IAccount
{
    void Deposit (double value);
    bool Withdraw (double value);
    double CheckBalance();
    string CheckAccountNumber(); 
    void Create(AccountBank data);
}
