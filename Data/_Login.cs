using System;
using MyBank.Menus;

namespace MyBank.Data;

public class _Login
{
    public void Check(string Email, string Password)
    {
        var context = new AppDbContext();
        try
        {
            var checkCredentials = context.Account.FirstOrDefault(c => c.Email == Email);
            if(checkCredentials.Email != null)
            {
                if(checkCredentials.Password == Password)
                {   
                    var id = checkCredentials.Id;
                    var name = checkCredentials.Name;
                    new LoggedInArea(id, name);
                }  
                else
                {
                    Console.WriteLine("Email ou senha incorretos!");
                    System.Threading.Thread.Sleep(1000); 
                    new LoginToMenu().Login();
                }
            } 
            else
            {
                Console.WriteLine("Dados invalidos! Tente novamente");
                System.Threading.Thread.Sleep(1000); 
                new LoginToMenu().Login();
            }
        } 
        catch (NullReferenceException)
        {
            Console.WriteLine("Conta não encontrada");
            System.Threading.Thread.Sleep(1000); 
            new LoginToMenu().Login();

        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("O email fornecido é nulo. Certifique-se de digitar um email válido.");
            System.Threading.Thread.Sleep(1000); 
            new LoginToMenu().Login();
        }
    }
}
