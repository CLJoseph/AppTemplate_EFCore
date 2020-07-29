using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {

        private readonly string connectionString; 
       
        public DbSet<Address> Addresses { get; set; }
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public ApplicationDbContext(string connection): base()
        {
            this.connectionString = connection;
        }
        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
            else {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Dev"); // 
            // configure Tables
           
            builder.Entity<Address>(ConfigureAddress);
            builder.Entity<ApplicationRole>(ConfigureApplicationRole);
            builder.Entity<ApplicationUser>(ConfigureApplicationUser);
        }
        private void ConfigureApplicationUser(EntityTypeBuilder<ApplicationUser> obj)
        {
            obj.ToTable("AspNetUsers");
            obj.Property(p => p.PersonName).HasMaxLength(255);
        }
        private void ConfigureApplicationRole(EntityTypeBuilder<ApplicationRole> obj)
        {
            obj.ToTable("AspNetRoles");
            obj.Property(p => p.Name).HasMaxLength(255);
            
        }
      
        private void ConfigureAddress(EntityTypeBuilder<Address> obj)
        {
            obj.ToTable("Addresses");
            obj.Property(p => p.Line1).HasMaxLength(50);
            obj.Property(p => p.Line2).HasMaxLength(50);
            obj.Property(p => p.Line3).HasMaxLength(50);
            obj.Property(p => p.Line4).HasMaxLength(50);
            obj.Property(p => p.Line5).HasMaxLength(50);
            obj.Property(p => p.Code).HasMaxLength(12);
        }
       
       
    }
}
