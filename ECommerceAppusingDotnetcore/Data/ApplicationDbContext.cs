﻿using ECommerceAppusingDotnetcore.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAppusingDotnetcore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<User> user { get; set; }
        public DbSet<Product> myproducts { get; set; }
        public DbSet<Cart> Mycart { get; set; }

    }
}
