using System;
using System.ComponentModel;
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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; } 
        public string Password { get; private set; }
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

       
        public void _Deposit(decimal value)
        {
                this.Balance = Balance + value;
        }

        
        public void Withdraw(decimal value, Guid id)
        {
               var balance = new _CheckBalance().GetBalance(id);
               if(value > balance){
               Console.WriteLine($"Saldo insulficiente! Seu saldo é: {balance}");
               System.Threading.Thread.Sleep(1500); 
               new LoggedInArea(id);}
               else{ 
               var withdraw = new _Withdraw();
               var newbalance = balance - value;
               withdraw.MakeWithdrawal(id, newbalance);
               //new Transactions(value, id, "Saque");
               }
        }
       
        public void CheckBalance(Guid id)
        {       
                var balance = new _CheckBalance().GetBalance(id);
                Console.WriteLine($"Seu saldo é: R$ {balance}");
        }
        

}
