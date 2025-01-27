using System;
using Microsoft.EntityFrameworkCore;
using MyBank.Entities;

namespace MyBank.Data;

public class AppDbContext : DbContext
        {
            public string DbPath { get; }

            public DbSet<AccountBank> Account { get; set; }

            public DbSet<Transactions> Transactions { get; set; }

            public AppDbContext()
            {
                DbPath = "Mybank.db";
            }

            protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
        }
