using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Entities;
using Spectre.Console;

namespace MyBank.Menus;

public class AccountCreationMenu
{
    public void CreateAccount(AppDbContext context)
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
                System.Threading.Thread.Sleep(2000); 
                CreateAccount(context);
            }

            Console.Write("Informe seu Telefone: ");
            var phone = Console.ReadLine();
            if(string.IsNullOrEmpty(phone)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(2000); 
                CreateAccount(context);
            }

            Console.Write("Informe seu e-mail: ");
            var email = Console.ReadLine();
            if(string.IsNullOrEmpty(email)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(2000); 
                CreateAccount(context);
            }

            Console.Write("Informe sua Senha: ");
            var password = Console.ReadLine();
            if(string.IsNullOrEmpty(password)) 
            {
                Console.Write("Todos os dados são obrigatorios!");
                System.Threading.Thread.Sleep(2000); 
                CreateAccount(context);
            }

            AccountBank accountBank = new AccountBank();
            accountBank.SetName(name);
            accountBank.SetPhone(phone);
            accountBank.SetEmail(email);
            accountBank.SetPassword(password);

            context.Account.AddRange(accountBank);
            context.SaveChanges();
            Console.WriteLine("Conta criada com sucesso");
             

        }

   
}
