using System;
using MyBank.Entities;
using MyBank.Enums;
using Spectre.Console;

namespace MyBank.Menus;

public class LoggedInArea
{
    public LoggedInArea(Guid id, string? name)
    {
        {
        Console.Clear();

        var panel = new Panel($"Seja Bem Vindo {name}! Selecione a opção desejada");
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);
        
        var opt = AnsiConsole.Prompt(new SelectionPrompt<LoggedInMenuOption>().AddChoices(
            
            LoggedInMenuOption.Saldo,
            LoggedInMenuOption.Extrato,
            LoggedInMenuOption.Depósito,
            LoggedInMenuOption.Transferência,
            LoggedInMenuOption.Saque
            
            
            ));
            
            switch(opt)
            {
                case LoggedInMenuOption.Saldo : new AccountBank().CheckBalance(id);
                break;

                case LoggedInMenuOption.Extrato : Console.WriteLine("Seu saldo é");
                break;

                case LoggedInMenuOption.Depósito : Console.WriteLine("Seu saldo é");
                break;

                case LoggedInMenuOption.Transferência : Console.WriteLine("Seu saldo é");
                break;

                case LoggedInMenuOption.Saque :
                Console.Write("Digite quanto quer sacar: ");
                decimal value = decimal.Parse(Console.ReadLine());
                new AccountBank().Withdraw(value, id);
                break;
                
            }
    }
    }
}
