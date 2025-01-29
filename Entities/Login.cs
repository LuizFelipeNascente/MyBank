using System;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Menus;

namespace MyBank.Entities;

// teste de dto na alteração da logica de login para a entidade
// Usando AccountInfoDTO para resgatar nome e id da conta a partir de
// uma consulta sql feita com where de email difita
// consulta necessária para ir para area logada enviando o nome para o cabeçalho
// e enviando id para as transações
public class AccountInfoDTO
{
    public Guid AccountId { get; set; }
    public string Name { get; set; }
}

public class Login
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    // Recebendo email e senha e setando nos atributos
    public Login(string email, string password)
    {   
              
       Email = email;
       Password = password;
       GetEmailPassword(email, password);
        
    }

    // Metodo que pega no banco as informações do email e senha digitados
    public void GetEmailPassword(string email, string password)
    {
        // Instanciando o metodo que verifica se o email existe no banco de dados true/false
        var checkEmail = new _Login().CheckEmail(email);
        // Se existir, realiza a logica de verifica a senha, se não existir volta para o input
        if(checkEmail == true)
        {
            // Instanciando o metodo que verifica se a senha digitada bate com a senha do banco
            // envia o email novamente para um novo select
            var checkPassword = new _Login().CheckPassword(email, password);
            // Se a senha bater, instancia um outro metodo e depois manda para area logada
            if(checkPassword == true)
            {
                // Senha bate então o metodo para verificar o nome e id da conta é instanciado
                var name = new _Login().CheckNameIdForEmail(email);
                // Encaminha para area logada manda nome e id da conta que logou
                new LoggedInArea(name.AccountId, name.Name);
                
            }
            else
            {
                // Caso a senha esteja incorreta, retorna msg para o usuário e volta ppara a tela de login
                Console.WriteLine("=====================");
                Console.WriteLine("\nSenha incorreta");
                System.Threading.Thread.Sleep(1500); 
                new LoginToMenu().Login();
            }
        }
        else
        {
            // Caso o email não exista, informa msg na tela volta para a tela de login
            Console.WriteLine("=====================");
            Console.WriteLine("\nEmail não encontrado");
            System.Threading.Thread.Sleep(1500); 
            new LoginToMenu().Login();
        }
    }
}
