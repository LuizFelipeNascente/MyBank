using System;
using System.Diagnostics;
using MyBank.Entities;

namespace MyBank.Data;

public class _Withdraw
{
    // Metodo para realizar um saque.
    public decimal MakeWithdrawal(Guid id, decimal newbalance)
    {
        // Instanciando o contexto de conexão com o banco de dados
        var context = new AppDbContext();
        // Buscando a conta atraves do Find
        var account = context.Account.Find(id);
        // Atribuindo ao saldo o novo valor após o saque feito
        account.Balance = newbalance;
        // Salvado as modificações feitas
        context.SaveChanges();
        // Retornando o saldo atual após o saque
        return account.Balance;
    }
    // Metodo para buscar o nome da conta e voltar para o menu com o nome no cabeçalho
    public string CheckName(Guid id)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        return account.Name;
    }
}
