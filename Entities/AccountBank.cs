using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyBank.Contracts;
using MyBank.Data;
using MyBank.Enums;
using MyBank.Menus;

namespace MyBank.Entities;

// Review - Criação de Conta
// validar a unicidade do e-mail ou número de telefone 
// A senha deve ter pelo menos 8 caracteres, incluindo letras, números e caracteres especiais. 


// Review - Depósitos
//
// Um recibo de depósito deve ser gerado e enviado ao usuário. 

// Implementar Extrato bancario.

public class AccountBank : Account
{
        [Key]   
        public Guid AccountId { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; } 
        public string Password { get; private set; }
        // Setando o status inicial da conta como Ativa
        public AccountStatus Status {get; private set; } = AccountStatus.Active;
        
        public void SetName(string name)
        {
                this.Name = name;
        }

        public void SetPhone(string phone)
        {
                this.Phone = phone;
        }

        public void SetEmail(string email)
        {
                this.Email = email;
        }

        public void SetPassword(string password)
        {
                this.Password = password;
        }


       // Metodo para realizar um deposito
        public void Deposit(decimal value, Guid id)
        {
            //Checagem do saldo atual em conta
            var balance = new _CheckBalance().GetBalance(id);
            // Instanciando a classe de deposito
            var deposit = new _Deposit();
            // Adicionado o valor input do cliente ao valor atual do saldo
            // valor depositado + valor atual em conta 
            var newbalance = balance + value;
            //enviando o deposito para a classe instanciada
            deposit.MakeDeposit(newbalance, id);

            // Instanciando a classe de transação, com valores do construtor da classe
            // junto com o valores do deposito atual, passados pelo usuário
            // e passando o tipo da transação em texto que será convertido em enum
            var currentDeposit = new Transactions(value, TransactionType.Deposito, id);
            // Instanciando a classe de conexão com o banco de dados
            // e passa a tranção atual como paramentro
            var saveTransaction = new _Transactions();
            saveTransaction.TransactionDeposit(currentDeposit);
               
        }

        // Metodo para realizar um saque
        public void Withdraw(decimal value, Guid id)
        {
            // chevagem se o valor sacado e menor que o valor disponivel na conta
            var balance = new _CheckBalance().GetBalance(id);
            if(value > balance)
            {
                Console.WriteLine($"Saldo insulficiente! Seu saldo é: {balance}");
                System.Threading.Thread.Sleep(2000); 
                // instanciando um novo metodo para checar o nome do usuario
                // para voltar com nome no titulo na area logada
                var name = new _Withdraw().CheckName(id);
                new LoggedInArea(id, name);
            }
            else
            { 
                //Realiza o saque diminuindo o saldo atual do valor sacado
                var withdraw = new _Withdraw();
                var newbalance = balance - value;
                withdraw.MakeWithdrawal(id, newbalance);

                // Salva a transação no banco de dados, chamando o construtor da classe
                // passando as informações do saque atual
                // Instancia a classse passand os parametros e o restante das informações
                // são implementados no prprio construtor.
                var currentWithdrawal = new Transactions(value * -1, TransactionType.Saque, id);

                // Isntancia a classe de conexão com o banco de dados
                // e passa a tranção atual como paramentro
                var saveTransaction = new _Transactions();
                saveTransaction.TransactionWithdraw(currentWithdrawal);
            }
        }
       
        public void CheckBalance(Guid id)
        {
            //Isntancvia a classe que vcerifica o saldo e o retorna   
            var balance = new _CheckBalance().GetBalance(id);
            // Instancia a classe que verifica o nome e o retorno
            var name = new _CheckBalance().CheckName(id);
            // Mostro em tela o nome e saldo do cliente
            Console.WriteLine("=====================================");
            Console.WriteLine($"{name} Seu saldo é: R$ {balance}    ");
            Console.WriteLine("=====================================");
            //Aguardo 3,5 segundos
            System.Threading.Thread.Sleep(3000); 
            //Volto para a area logada com o nome do cliente
            new LoggedInArea(id, name);
        }
        

}
