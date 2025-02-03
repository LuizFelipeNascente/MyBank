using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Entities;
using MyBank.Menus;

namespace MyBank.Data;

public class _Login
{
    // Novo metodo de verificação de email que recebe o email digitado
    // retornando apenas verdadeiro ou falso para a regra do login
    public bool CheckEmail(string email)
    {   
        // conexão com o banco
        var context = new AppDbContext();
        // Select no banco Account com a condição do do email digitado
        // no check name tem o msm conceito, porém com o FirstOrDefault tras apenas
        // o primeiro resultado (select top 1) e trás toda a linha do banco
        var checkEmail = context.Account.FirstOrDefault(e => e.Email == email);
        // Se o select não encontra dados, o metodo retorna falso
        if(checkEmail == null)
        {
            return false;
        } 
        // Caso ele encontre, retorna true 
        else
        {
            return true;
        }
    }

    //  METODO ATUALIZADO PARA TER 3 TIPOS DE RETORNO -> BOOL, STRING E GUID

    // Metodo para verificar o senha, caso o metodo CheckEmail
    // retorne verdadeito na regra de negocio, esse metodo de verificação de senha 
    // é chamado recebendo a senha e o email novamente
    public bool CheckPassword(string email, string password, out string userName, out Guid accountId)
    {
        // Inicializando as duas varias acrescentadas no retorno com o out
        userName = string.Empty; 
        accountId = Guid.Empty;
        // conexão com o banco
        var context = new AppDbContext();
        // DESAFASO *** busca no banco com where de email = email digitado
        var checkPassword = context.Account.FirstOrDefault(e => e.Email == email);
        // Não há verificação de null pois esse metodo só é chamado caso o email já existe
        // regra do primeiro passo da logica do login
        // Então quando localizado, ele verifica se a senha digitada bate com o banco em caso 
        // de bater retorna true
        if(checkPassword?.Password == password)
        {
            // Pega o nome do cliente
            userName = checkPassword.Name; 
            // Pega o ID  do cliente
            accountId = checkPassword.AccountId; 
            // Retorna verdadeiro
            return true;
        }
        // Caso a senha não bata, retorna false
        else
        {
            return false;
        }

    }

    // METODO DEFASADO APÓS O USO DO OUT NO METODO QUE VERIFICA A SENHA

    // Esse metodo foi impletado pois para ir para area logada 
    // é necessario enviar o nome do usuário e id.
    // Usado outro conceito de consulta sem usar linq e usando sql direto
    public AccountInfoDTO CheckNameIdForEmail(string email)
    {
        var context = new AppDbContext();
        var result = context.Account.FromSqlInterpolated($"SELECT AccountId, Name FROM Account WHERE Email = {email}")
                                     .Select(a => new {a.AccountId, a.Name})
                                     .FirstOrDefault();
                                     
        return new AccountInfoDTO { AccountId = result.AccountId, Name = result.Name };
    }
}
