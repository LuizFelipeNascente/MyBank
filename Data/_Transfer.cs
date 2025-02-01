using System;

namespace MyBank.Data;

public class _Transfer
{
    public void MakeTransfer(Guid idOrigin, decimal newbalanceOrigin, Guid idDestination, decimal newbalanceDestination)
    {
        // conexão com o banco de dados
        var context = new AppDbContext();
        //Buscando a conta origem atrás do id passado 
        var accountOrigin = context.Account.Find(idOrigin);
        // Atribuindo o novo saldo após o transferencia negativa
        accountOrigin.Balance = newbalanceOrigin;
        // Savlando as alterações
        context.SaveChanges();

         //Buscando a conta destino atrás do id passado 
        var accountDestination = context.Account.Find(idDestination);
        // Atribuindo ao saldo o novo valor após a transferencia positiva
        accountDestination.Balance = newbalanceDestination;
        // Savlando as alterações
        context.SaveChanges();

    }

    // Metodo que busca e retorna o Guid de uma conta bancaria
    // atraves do codigo da conta
    public Guid GetGuidForAccountId(int CodeAccountDestination)
    {
        var context = new AppDbContext();
        var guidAccountId = context.Account.FirstOrDefault(a => a.AccountNumber == CodeAccountDestination);
        return guidAccountId.AccountId;
        
    }
}
