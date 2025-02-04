﻿using Microsoft.EntityFrameworkCore;

namespace Tizza
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Pizza> Pizza { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Pizzaria>().HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
