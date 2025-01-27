using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MyBank.Contracts;
using MyBank.Data;
using MyBank.Enums;

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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public AccountStatus Status {get; set; } = AccountStatus.Active;
        
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

        
        public bool _Withdraw(decimal value)
        {
                if(value > Balance)
                return false;

                Balance = Balance - value;
                return true;
        }
       
        public void CheckBalance(Guid id)
        {       
                var balance = new _CheckBalance().GetBalance(id);
                Console.WriteLine($"Seu saldo é: R$ {balance}");
        }
        

}
