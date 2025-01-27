using System;
using MyBank.Entities;

namespace MyBank.Contracts;

public interface IAccount
{
    void _Deposit (double value);
    bool _Withdraw (double value);
    decimal _CheckBalance();
    string CheckAccountNumber(); 
    void Create(AccountBank data);
}
