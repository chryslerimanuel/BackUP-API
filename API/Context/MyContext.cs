using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
               .HasOne(person => person.Account)
               .WithOne(account => account.Person)
               .HasForeignKey<Account>(account => account.NIK);

            modelBuilder.Entity<Account>()
               .HasOne(account => account.Profiling)
               .WithOne(profiling => profiling.Account)
               .HasForeignKey<Profiling>(profiling => profiling.NIK);

            modelBuilder.Entity<Profiling>()
               .HasOne(profiling => profiling.Education)
               .WithMany(education => education.Profiling)
               .HasForeignKey(profiling => profiling.Education_Id);

            modelBuilder.Entity<Education>()
               .HasOne(education => education.University)
               .WithMany(university => university.Education)
               .HasForeignKey(education => education.University_Id);

            modelBuilder.Entity<AccountRole>()
               .HasKey(ra => new { ra.Role_Id, ra.Account_NIK });

            modelBuilder.Entity<AccountRole>()
               .HasOne(ra => ra.Role)
               .WithMany(role => role.AccountRoles)
               .HasForeignKey(ra => ra.Role_Id);

            modelBuilder.Entity<AccountRole>()
               .HasOne(ra => ra.Account)
               .WithMany(account => account.AccountRoles)
               .HasForeignKey(ra => ra.Account_NIK);
        }
    }
}
