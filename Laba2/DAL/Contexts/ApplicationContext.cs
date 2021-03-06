using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using DAL.Entities;

namespace DAL.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<MedicalBills> MedicalBills { get; set; }
        public DbSet<MedicalBillsType> MedicalBillsType { get; set; }
        public DbSet<Form> Form{ get; set; }
        public DbSet<StoreHouse> StoreHouse { get; set; }
        public DbSet<WriteOfList> WriteOfList { get; set; }
        public DbSet<WaitableList> WaitableList { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalBills>()
                .HasOne<MedicalBillsType>(s => s.MedicalBillsType)
                .WithMany(g => g.MedicalBills)
                .HasForeignKey(s => s.MedicalBillsTypeId);

            modelBuilder.Entity<MedicalBills>()
                .HasOne<Form>(s => s.Form)
                .WithMany(g => g.MedicalBills)
                .HasForeignKey(s => s.FormId);

            modelBuilder.Entity<StoreHouse>()
                .HasOne<MedicalBills>(s => s.MedicalBills)
                .WithMany(s => s.StoreHouses)
                .HasForeignKey(s => s.MedicalBillId);

            modelBuilder.Entity<WriteOfList>()
               .HasOne<MedicalBills>(s => s.MedicalBills)
               .WithMany(s => s.WriteOfLists)
               .HasForeignKey(s => s.MedicalBillId);

            modelBuilder.Entity<WaitableList>()
              .HasOne<MedicalBills>(s => s.MedicalBills)
              .WithMany(s => s.WaitableLists)
              .HasForeignKey(s => s.MedicalBillId);

            modelBuilder.Entity<WriteOfList>().HasKey(c => new { c.MedicalBillId, c.Id });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = StoreHouse; Trusted_Connection=True;");
        }
    }
}
