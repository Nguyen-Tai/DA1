﻿using QuanAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanAn
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base(@"Server=DESKTOP-GN3V8MM\SQLEXPRESS;Database=Cafeteria;Trusted_Connection=True")
        {

        }      
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
