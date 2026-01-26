using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PetSavingBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace PetSavingBackend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Admission> Admissions{set; get;} 
        public DbSet<Appointmet> Appointmets{set; get;} 
        public DbSet<Inventory> Inventories{set; get;} 
        public DbSet<Patient> Patients{set; get;} 
        public DbSet<Status> Statuses{set; get;} 
        public DbSet<Client> Clients{set;get;}
        public DbSet<Vet> Vets{set;get;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Llama al método base para asegurar que la configuración predeterminada se aplique.
            base.OnModelCreating(builder);

            // Seed initial roles into the database.
            List<Inventory> products = new List<Inventory>
            {
                // Role for Administrator
                new Inventory
                {
                    Id = 1,
                    Name = "Waiter",
                    Description = "WAITER",
                    UnitValue = 1.75m,
                    Stock = 5,
                    SupplerName = "LMAO"
                },
            };
            // Agrega los roles al modelo.
            builder.Entity<Inventory>().HasData(products);
        }
    
    }
}