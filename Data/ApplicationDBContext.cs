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

            // Admission <-> Patient
            builder.Entity<Admission>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Admissions)
                .HasForeignKey(a => a.PatientId);

            // Admission <-> Vet
            builder.Entity<Admission>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Admissions)
                .HasForeignKey(a => a.VetId);

            // Admission <-> Status
            builder.Entity<Admission>()
                .HasMany(a => a.Statuses)
                .WithOne(s => s.Admission)
                .HasForeignKey(s => s.AdmissionId);

            // Appointment <-> Patient
            builder.Entity<Appointmet>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointmets)
                .HasForeignKey(a => a.PatientId);

            // Appointment <-> Client
            builder.Entity<Appointmet>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Appointmets)
                .HasForeignKey(a => a.ClientId);

            // Appointment <-> Vet
            builder.Entity<Appointmet>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointmets)
                .HasForeignKey(a => a.VetId);

            // Patient <-> Client
            builder.Entity<Patient>()
                .HasOne(p => p.Client)
                .WithMany(c => c.Patients)
                .HasForeignKey(p => p.ClientId);
        }
    }
}