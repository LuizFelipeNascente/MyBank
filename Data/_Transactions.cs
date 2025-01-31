using System;
using System.Transactions;
using MyBank.Entities;
using MyBank.Menus;

namespace MyBank.Data;

public class _Transactions
{
    public void TransactionWithdraw(Transactions saveTransaction)
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
        Console.WriteLine($"\nSaque de R$ {saveTransaction.Amount * -1} realizado com sucesso \n=================================== \n \nSeu Saldo atual é de R$ {currentBalance}");
        //Espera 2 segundos
        System.Threading.Thread.Sleep(5000);
        // Faz uma verificação do nome do usuário origem ou destino da transação
        var name = CheckName(saveTransaction.SourceAccountId);
        //Leva de volta para area logada passando o id do usuário.
        new LoggedInArea(saveTransaction.SourceAccountId, name);

    }

    public void TransactionDeposit(Transactions saveTransaction)
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
        Console.WriteLine($"\nDeposito de R$ {saveTransaction.Amount} realizado com sucesso \n=================================== \n \nSeu Saldo atual é de R$ {currentBalance}");
        //Espera 2 segundos
        System.Threading.Thread.Sleep(5000);
        // Faz uma verificação do nome do usuário origem ou destino da transação
        var name = CheckName(saveTransaction.SourceAccountId);
        //Leva de volta para area logada passando o id do usuário.
        new LoggedInArea(saveTransaction.SourceAccountId, name);

    }

    public void TransactionTransfer(Transactions saveTransaction)
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
        Console.WriteLine($"\nDeposito de R$ {saveTransaction.Amount} realizado com sucesso \n=================================== \n \nSeu Saldo atual é de R$ {currentBalance}");
        //Espera 2 segundos
        System.Threading.Thread.Sleep(5000);
        // Faz uma verificação do nome do usuário origem ou destino da transação
        var name = CheckName(saveTransaction.SourceAccountId);
        //Leva de volta para area logada passando o id do usuário.
        new LoggedInArea(saveTransaction.SourceAccountId, name);

    }

    public string CheckName(Guid id)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        return account.Name;
    }
}
