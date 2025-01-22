using System;
using Spectre.Console;


namespace MyBank.Menus;

public enum HomeMenuOptions
{
    Entrar,
    CriarConta,
    Sair,
}

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

            switch(opt)
            {
                case HomeMenuOptions.CriarConta: Console.Clear(); Console.WriteLine("Criando conta ...."); 
                break;

                case HomeMenuOptions.Entrar: Console.WriteLine("Entrando na conta ...."); 
                break;

                case HomeMenuOptions.Sair: Console.Clear(); Console.WriteLine("Saindo conta ...."); 
                break;
            }
            
    }

}
