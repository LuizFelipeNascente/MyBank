using System;

namespace MyBank.Services;

public interface IAccount
{
    void Deposit (double value);
    bool Withdraw (double value);
    double CheckBalance();
    string CheckAccountNumber(); 
}
