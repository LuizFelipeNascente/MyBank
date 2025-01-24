using System;
using MyBank.Enums;
using Spectre.Console;
using MyBank.Data;
using MyBank.Entities;


namespace MyBank.Menus;

public class HomeMenu
{

    static HomeMenu()
    {
        Console.Clear();

        var panel = new Panel("Selecione a opção desejada");
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);
        
        var opt = AnsiConsole.Prompt(new SelectionPrompt<HomeMenuOptions>().AddChoices(
            
            HomeMenuOptions.CriarConta,
            HomeMenuOptions.Entrar,
            HomeMenuOptions.Sair));
            using (var context = new AppDbContext())

            switch(opt)
            {
                case HomeMenuOptions.CriarConta: new AccountCreationMenu().CreateAccount(context);
                break;

                case HomeMenuOptions.Entrar: new LoginToMenu().Login();
                break;

                case HomeMenuOptions.Sair: Console.Clear(); Console.WriteLine("Saindo conta ...."); 
                break;
            }
    }
}
