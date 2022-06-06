using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppHumanResourcesDepartment.Model;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace AppHumanResourcesDepartment.Service
{
    public class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder();
            config.SetBasePath(Directory.GetCurrentDirectory());
            config.AddJsonFile("appsettings.json");
            string connectionString = config.Build().GetConnectionString("HumanResourcesContext");

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Security>()
                .Property("_password");

            modelBuilder.Entity<Person>()
                .HasOne(p => p.HumanSecurity)
                .WithOne(x=>x.Person)
                .HasForeignKey<Security>(b => b.PersonID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Department>()
                .HasMany(x => x.Works)
                .WithOne(x => x.Department)
                .HasForeignKey(b => b.DepartmentID)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Work>()
                .HasMany(x => x.RefineFields)
                .WithOne(x => x.Work)
                .HasForeignKey(x => x.WorkID)
                .OnDelete(DeleteBehavior.ClientCascade); ;

            modelBuilder.Entity<Work>()
                .HasOne(x => x.Perent)
                .WithOne(x => x.Next)
                .HasForeignKey<Work>(x => x.PerentID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Work>()
                .HasMany(x => x.People)
                .WithOne(x => x.Work)
                .HasForeignKey(x => x.WorkId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<RefineField>()
                .HasOne(x => x.Perent)
                .WithOne(x => x.Next)
                .HasForeignKey<RefineField>(x => x.PerentID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Security> Securitys { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<RefineField> RefineFields { get; set; }
    }
}
