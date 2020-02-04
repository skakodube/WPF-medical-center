namespace MedicalCentre.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<DOCTOR> DOCTORs { get; set; }
        public virtual DbSet<MEDICATION> MEDICATIONs { get; set; }
        public virtual DbSet<PATIENT> PATIENTs { get; set; }
        public virtual DbSet<PROCEDUR> PROCEDURs { get; set; }
        public virtual DbSet<REQMEDICATION> REQMEDICATIONs { get; set; }
        public virtual DbSet<REQPROCEDURE> REQPROCEDUREs { get; set; }
        public virtual DbSet<SPEC> SPECs { get; set; }
        public virtual DbSet<VISIT> VISITs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.IDD)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.SURNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.SAL)
                .HasPrecision(5, 0);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.ADDRESS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.PHONENUM)
                .HasPrecision(9, 0);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.SPECIALIZATION)
                .HasPrecision(18, 0);

            modelBuilder.Entity<DOCTOR>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DOCTOR>()
                .HasMany(e => e.VISITs)
                .WithRequired(e => e.DOCTOR1)
                .HasForeignKey(e => e.DOCTOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.IDM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MEDICATION>()
                .Property(e => e.COST)
                .HasPrecision(4, 0);

            modelBuilder.Entity<MEDICATION>()
                .HasMany(e => e.REQMEDICATIONs)
                .WithRequired(e => e.MEDICATION1)
                .HasForeignKey(e => e.MEDICATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.IDP)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.SURNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.ADDRESS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .Property(e => e.GENDER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PATIENT>()
                .HasMany(e => e.VISITs)
                .WithRequired(e => e.PATIENT1)
                .HasForeignKey(e => e.PATIENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PROCEDUR>()
                .Property(e => e.IDPR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PROCEDUR>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PROCEDUR>()
                .Property(e => e.COST)
                .HasPrecision(4, 0);

            modelBuilder.Entity<PROCEDUR>()
                .HasMany(e => e.REQPROCEDUREs)
                .WithRequired(e => e.PROCEDUR1)
                .HasForeignKey(e => e.PROCEDUR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<REQMEDICATION>()
                .Property(e => e.IDRM)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQMEDICATION>()
                .Property(e => e.VISIT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQMEDICATION>()
                .Property(e => e.MEDICATION)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQMEDICATION>()
                .Property(e => e.QUANTITY)
                .HasPrecision(2, 0);

            modelBuilder.Entity<REQPROCEDURE>()
                .Property(e => e.IDRPR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQPROCEDURE>()
                .Property(e => e.VISIT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQPROCEDURE>()
                .Property(e => e.PROCEDUR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<REQPROCEDURE>()
                .Property(e => e.QUANTITY)
                .HasPrecision(2, 0);

            modelBuilder.Entity<SPEC>()
                .Property(e => e.IDS)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SPEC>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SPEC>()
                .HasMany(e => e.DOCTORs)
                .WithRequired(e => e.SPEC)
                .HasForeignKey(e => e.SPECIALIZATION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.IDV)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.DOCTOR)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VISIT>()
                .Property(e => e.PATIENT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.REQMEDICATIONs)
                .WithRequired(e => e.VISIT1)
                .HasForeignKey(e => e.VISIT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VISIT>()
                .HasMany(e => e.REQPROCEDUREs)
                .WithRequired(e => e.VISIT1)
                .HasForeignKey(e => e.VISIT)
                .WillCascadeOnDelete(false);
        }
    }
}
