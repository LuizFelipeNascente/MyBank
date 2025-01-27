using System;
using System.Transactions;
using MyBank.Entities;
using MyBank.Menus;

namespace MyBank.Data;

public class _Transactions
{
    public void Transaction(Transactions saveTransaction)
    {   
        //Instancia contexto com banco
        var context = new AppDbContext();

        //Adiciona ao banco a transação
        context.Transactions.Add(saveTransaction);
        // Salva as alterações feitoas 
        context.SaveChanges();

        //Instancia uma verificação de saldo após o saque
        var currentBalance = new _CheckBalance().GetBalance(saveTransaction.SourceAccountId);
        //Mostra em tela o valor sacado, vindo da transação e usa o instancia do salva para mostrar o valor restante na conta.
        Console.WriteLine($"Saque de R$ {saveTransaction.Amount} realizado com sucesso \nSeu Saldo atual é de: {currentBalance}");
        //Espera 2 segundos
        System.Threading.Thread.Sleep(5000);
        //Leva de volta para area logada passando o id do usuário.
        new LoggedInArea(saveTransaction.SourceAccountId, null);

    }
}
