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

        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrgBranch> OrganisationBranches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<InstructionItem> InstructionItems { get; set; }
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
            builder.HasDefaultSchema("Ins");
            // configure Tables
            builder.Entity<Organisation>(ConfigureOrganisation);
            builder.Entity<Instruction>(ConfigureInstruction);
            builder.Entity<InstructionItem>(ConfigureInstructionItems);
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
            // using migrations to seed the application roles into the database
            //obj.HasData(new ApplicationRole() { Name = AppRole.Administrator.ToString(), Id=Guid.NewGuid(),  NormalizedName= AppRole.Administrator.ToString().ToUpperInvariant() });
            //obj.HasData(new ApplicationRole() { Name = AppRole.Manager.ToString(), Id = Guid.NewGuid(), NormalizedName = AppRole.Manager.ToString().ToUpperInvariant() });
            //obj.HasData(new ApplicationRole() { Name = AppRole.User.ToString(), Id = Guid.NewGuid(), NormalizedName = AppRole.User.ToString().ToUpperInvariant() });

        }
        private void ConfigureInstructionItems(EntityTypeBuilder<InstructionItem> obj)
        {
            obj.ToTable("InstructionItems");
            obj.Property(p => p.Id).IsRequired();
            obj.Property(p => p.Item).HasMaxLength(250);
            obj.Property(p => p.Quantity).HasMaxLength(12);
            obj.Property(p => p.UnitPrice).HasMaxLength(12);
            obj.Property(p => p.Price).HasMaxLength(12);
            obj.Property(p => p.Tax).HasMaxLength(12);
            obj.Property(p => p.Total).HasMaxLength(12);
            obj.Property(p => p.Image).HasMaxLength(250);
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
        private void ConfigureInstruction(EntityTypeBuilder<Instruction> obj)
        {
            obj.ToTable("Instructions");
            obj.Property(p => p.Id).IsRequired();
            obj.Property(p => p.RowVersionNo).IsRowVersion();
            obj.Property(p => p.Code).HasMaxLength(50);
            obj.Property(p => p.ReferenceCode).HasMaxLength(50);
            obj.Property(p => p.Status).HasMaxLength(50);
            obj.Property(p => p.Date).HasMaxLength(50);
            obj.Property(p => p.Note).HasMaxLength(250);
            obj.Property(p => p.From).HasMaxLength(250);
            obj.Property(p => p.AttentionOf).HasMaxLength(150);
            obj.Property(p => p.To).HasMaxLength(150);
            obj.Property(p => p.ToEmail).HasMaxLength(250);
            obj.Property(p => p.Price).HasMaxLength(50);
            obj.Property(p => p.Tax).HasMaxLength(50);
            obj.Property(p => p.Total).HasMaxLength(50);

        }
        private void ConfigureOrganisation(EntityTypeBuilder<Organisation> obj)
        {
            obj.ToTable("Organisations");
            obj.Property(p => p.Id).IsRequired();
            obj.Property(p => p.RowVersionNo).IsRowVersion();
            obj.Property(p => p.Name).HasMaxLength(250);
        }
    }
}
