using System;
using Spectre.Console;

namespace MyBank.Menus;

public class LoginToMenu
{
     public void Login()
        {
            Console.Clear();

            var panel = new Panel("Faça Login usando seu número de telefone e senha");
            panel.Border = BoxBorder.Double;
            AnsiConsole.Write(panel);

            Console.Write("Digite seu E-mail: ");

            var email = Console.ReadLine();
            if(string.IsNullOrEmpty(email)) 
            {
                Console.Write("E-mail inválido");
                System.Threading.Thread.Sleep(1500); 
                Login();
                
            }

            Console.Write("Digite sua Senha: ");
            var password = Console.ReadLine();
            
            Console.WriteLine(email + " " + password);
        }
}
