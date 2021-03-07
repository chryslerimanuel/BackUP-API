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

        public DbSet<Person> Persons { set; get; }

        public DbSet<Education> Educations { set; get; }

        public DbSet<Account> Accounts { set; get; }

        public DbSet<University> Universities { set; get; }

        public DbSet<Profiling> Profilings { set; get; }

        public DbSet<Role> Roles { set; get; }

        public DbSet<AccountRole> AccountRoles { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOne(a => a.Account)
                .WithOne(b => b.Person)
                .HasForeignKey<Account>(b => b.NIK);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Profiling)
                .WithOne(b => b.Account)
                .HasForeignKey<Profiling>(b => b.NIK);

            modelBuilder.Entity<Profiling>()
                .HasOne(c => c.Education)
                .WithMany(e => e.Profilings);

            modelBuilder.Entity<University>()
                .HasMany(c => c.Educations)
                .WithOne(e => e.University);

            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.NIK, ar.RoleID });

            modelBuilder.Entity<AccountRole>()
                .HasOne(a => a.Account)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(a => a.NIK);
            
            modelBuilder.Entity<AccountRole>()
                .HasOne(r => r.Role)
                .WithMany(ar => ar.AccountRoles)
                .HasForeignKey(r => r.RoleID);
        }

    }
}
