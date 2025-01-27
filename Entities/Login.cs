using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Data;
using MyBank.Menus;

namespace MyBank.Entities;

public class Login
{
    public string Email { get; private set; }
    public string Password { get; private set; }


    public Login(string email, string password)
    {   
              
       this.Email = email;
       this.Password = password;
       new _Login().Check(Email, Password);
        
    }
}
