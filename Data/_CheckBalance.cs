using System;

namespace MyBank.Data;

public class _CheckBalance
{
    //Metodo para pegar o saldo atual da id passado
    public decimal GetBalance(Guid id)
    {
        //Instanciando a conexão com o banco de dados pelo dbset 
        var context = new AppDbContext();
        //Usando o contexto para localizar uma linha no banco de dados e armazendo na variavel balance
        // o Find busca apenas por chaves primarias e trás todo o conteudo.
        var balance = context.Account.Find(id);
        // Retorno para quem chamou o metodo o objeto.Propiedade. 
        return balance.Balance;
    }
    //Metodo para buscar nome do id modificado para voltar o menu com o nome no cabeçalho
    public string CheckName(Guid id)
    {
        var context = new AppDbContext();
        var account = context.Account.Find(id);
        return account.Name;
    }
}
