using System;

namespace MyBank.Data;

public class _Deposit
{
    //Metodo para realizar um deposito, enviado o novo valor do saldo e id da conta
    
    // Subistitui o return
    // public _Deposit(decimal newbalance, Guid id, out decimal balance) {
    //    balance = MakeDeposit(newbalance, id);
    //}
    public decimal MakeDeposit(decimal newbalance, Guid id)
    {
        // Conecetando ao contexto do banco
        var context = new AppDbContext();

        // Localizando a conta com o id passado no paremetro do metodo
        context.Account.Find(id);
        var account = context.Account.Find(id);
        // Atribuindo ao saldo o novo valor após o deposito
        account.Balance = newbalance;
        // Savlando as alterações
        context.SaveChanges();
        // Retorno o saldo atual após o deposito realizado
        return account.Balance;
        
    }
}
