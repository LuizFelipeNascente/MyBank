using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using MyBank.Services;

namespace MyBank.Entities;

public class AccountBank
{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        [NotMapped]
        public IAccount Account {get; set; }

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

}
