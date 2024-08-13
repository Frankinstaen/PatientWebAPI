using Microsoft.EntityFrameworkCore;
using PatientWebAPI.Entity;
using System;

namespace PatientWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Name> Names { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Active> Actives { get; set; }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasOne(x => x.Active).WithMany(x => x.Patients)
                .HasForeignKey(x => x.ActiveId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Patient>().HasOne(x => x.Gender).WithMany(x => x.Patients)
                .HasForeignKey(x => x.GenderId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Patient>().HasOne(a => a.Name).WithOne(b => b.Patient)
                .HasForeignKey<Name>(b => b.PatientId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>().HasOne(a => a.Name).WithMany(x => x.Given).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Active>().HasData(
            new Active[]
            {
                new Active
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                },
                new Active {
                    Id = Guid.NewGuid(),
                    IsActive = false,
                }
            });
            modelBuilder.Entity<Gender>().HasData(
            new Gender[] {
                new Gender {
                    Id = Guid.NewGuid(),
                    GenderName = "male"
                },
                new Gender {
                    Id = Guid.NewGuid(),
                    GenderName = "female"
                },
                new Gender {
                    Id = Guid.NewGuid(),
                    GenderName = "other"
                },
                new Gender {
                    Id = Guid.NewGuid(),
                    GenderName = "unknow"
                }
            });
        }
    }
}
