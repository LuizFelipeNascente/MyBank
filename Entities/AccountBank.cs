using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MyBank.Contracts;

namespace MyBank.Entities;

public class AccountBank : Account
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public DateTime Addon { get; set; } 
        
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

       
        public void Deposit(decimal value)
        {
                this.Balance = Balance + value;
        }

        public bool Withdraw(decimal value)
        {
                if(value > Balance)
                return false;

                Balance = Balance - value;
                return true;
        }

        public decimal CheckBalance()
        {
                return this.Balance;
        }

}
