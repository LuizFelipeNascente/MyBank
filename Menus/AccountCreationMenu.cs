using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Entities;
using Spectre.Console;

namespace MyBank.Menus;

public class AccountCreationMenu
{
    //Existe um bug quando um dado não é preenchido 
    public void CreateAccount() 
        {
            Console.Clear();

            var panel = new Panel("Informe todos os dados para criação da sua conta");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            Console.Write("Informe seu nome: ");
            var name = Console.ReadLine();
            if(string.IsNullOrEmpty(name)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(1500); 
                CreateAccount();
            }

            Console.Write("Informe seu Telefone: ");
            var phone = Console.ReadLine();
            if(string.IsNullOrEmpty(phone)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(1500); 
                CreateAccount();
            }

            Console.Write("Informe seu e-mail: ");
            var email = Console.ReadLine();
            if(string.IsNullOrEmpty(email)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(1500); 
                CreateAccount();
            }

            Console.Write("Informe sua Senha: ");
            var password = Console.ReadLine();
            if(string.IsNullOrEmpty(password)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(1500); 
                CreateAccount();
            }

            AccountBank accountBank = new AccountBank();
            accountBank.SetName(name);
            accountBank.SetPhone(phone);
            accountBank.SetEmail(email);
            accountBank.SetPassword(password);

            Account account = new Account();
            account.Create(accountBank);
             

        }

   
}

//Validar conceito 
/*
public class AccountCreationMenu
{
    //Existe um bug quando um dado não é preenchido 
    public void CreateAccount() 
    {
        Console.Clear();

        var panel = new Panel("Informe todos os dados para criação da sua conta");
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);

        string name = GetInput("Informe seu nome");
        string phone = GetInput("Informe seu telefone (apenas números)", input => IsValidPhone(input));
        string email = GetInput("Informe seu e-mail", input => IsValidEmail(input));
        string password = GetPassword("Informe sua senha (mínimo 8 caracteres)");

        AccountBank accountBank = new AccountBank();
        accountBank.SetName(name);
        accountBank.SetPhone(phone);
        accountBank.SetEmail(email);
        accountBank.SetPassword(password);

        Account account = new Account();
        account.Create(accountBank);

    }

    private string GetInput(string message, Func<string, bool> validation = null)
    {
        while (true)
        {
            Console.Write($"{message}: ");
            string input = Console.ReadLine();

            // Valida se o dado não é nulo ou vazio
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Este campo é obrigatório. Preencha corretamente.");
                continue;
            }

            // Valida com base na função fornecida (se houver)
            if (validation != null && !validation(input))
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                continue;
            }

            return input;
        }
    }

    // Validação da quantidade de carecteres no telefone
    private bool IsValidPhone(string phone)
    {
        return phone.All(char.IsDigit) && phone.Length >= 8; // Mínimo 8 dígitos
    }

    // Validação de e-mail
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private string GetPassword(string message)
    {
        Console.Write($"{message}: ");
        string password = "";

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Enter) // Enter finaliza a senha
            {
                Console.WriteLine(); // Pula para a próxima linha
                if (password.Length >= 8) break; // Verifica o tamanho mínimo da senha
                Console.WriteLine("A senha deve ter no mínimo 6 caracteres. Tente novamente.");
                password = "";
                Console.Write($"{message}: ");
                continue;
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0) // Backspace remove caracteres
            {
                password = password[0..^1];
                Console.Write("\b \b"); // Remove o caractere da tela
            }
            else if (!char.IsControl(key.KeyChar)) // Adiciona caracteres visíveis
            {
                password += key.KeyChar;
                Console.Write("*"); // Mostra o asterisco
            }
        }

        return password;
    }
}

*/