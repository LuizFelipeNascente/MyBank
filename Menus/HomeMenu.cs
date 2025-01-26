using System;
using MyBank.Enums;
using Spectre.Console;


namespace MyBank.Menus;

public class HomeMenu
{

    public HomeMenu()
    {
        Console.Clear();

        var panel = new Panel("Selecione a opção desejada");
        panel.Border = BoxBorder.Double;
        AnsiConsole.Write(panel);
        
        var opt = AnsiConsole.Prompt(new SelectionPrompt<HomeMenuOptions>().AddChoices(
            
            HomeMenuOptions.CriarConta,
            HomeMenuOptions.Entrar,
            HomeMenuOptions.Sair));
            
            switch(opt)
            {
                case HomeMenuOptions.CriarConta: new AccountCreationMenu().CreateAccount();
                break;

                case HomeMenuOptions.Entrar: new LoginToMenu().Login();
                break;

                case HomeMenuOptions.Sair: Console.Clear(); 
                Console.WriteLine("Saindo do sistema ...."); 
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                return; 
                
            }
    }
}
