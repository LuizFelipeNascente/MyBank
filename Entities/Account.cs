using System;
using MyBank.Data;
using MyBank.Menus;

namespace MyBank.Entities;

public class Account
{

    // Seta o saldo inicial como 0
    public decimal Balance { get; set; } = 0;
    public int AccountNumber { get; private set; }
    // Seta a data de criação com a data atual da execução
    public DateTime Addon { get; private set; } = DateTime.Now;
    
    // Metodo que cria a conta, recebendo os dados do menu
    // e os demais dados já inicializado na classe
    public void Create(AccountBank accountBank)
    {
        // Chama a checagem do ultimo numero e atricbui a a conta atual 
        // que está sendo criada
        accountBank.AccountNumber = CheckAccountNumber();
        
        // Instacia a conexão com o banco de dados
        var context = new AppDbContext();

        // Adiciona a nova conta ao banco
        context.Account.Add(accountBank);
        // Salva as alterações feitas
        context.SaveChanges();
        // Informa que a conta foi criada
        Console.WriteLine("Conta criada com sucesso");
        // Agfuarda 1,5 segundos
        System.Threading.Thread.Sleep(1500);
        // Redireciona para o menu inicial
        new HomeMenu();
       
    }
    
    // Metodo que verifica o ultimo numero de conta criado e retorna ele + 1
    // gerando assim o proximo numero a ser criado
    public int CheckAccountNumber()
    {
        var context = new AppDbContext();
        int lastaccount = context.Account.Max(l => (int?)l.AccountNumber) ?? 0;

        return lastaccount + 1;

    }

    public string ReadPassword()
        {
            string password = string.Empty;
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
            } while (true);

            Console.WriteLine();
            return password;
        }

}
