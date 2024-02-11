using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SkolDB_labb4.Models
{
    public partial class Labb2DbContext : DbContext
    {
        public Labb2DbContext()
        {
        }

        public Labb2DbContext(DbContextOptions<Labb2DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBefattning> TblBefattnings { get; set; } = null!;
        public virtual DbSet<TblBetyg> TblBetygs { get; set; } = null!;
        public virtual DbSet<TblKlass> TblKlasses { get; set; } = null!;
        public virtual DbSet<TblKur> TblKurs { get; set; } = null!;
        public virtual DbSet<TblPersonal> TblPersonals { get; set; } = null!;
        public virtual DbSet<TblStudent> TblStudents { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-GIGGNJEG;Initial Catalog=Labb2Db;Integrated security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBefattning>(entity =>
            {
                entity.HasKey(e => e.BefattningsId);

                entity.ToTable("tblBefattning");

                entity.Property(e => e.BefattningsId).HasColumnName("BefattningsID");

                entity.Property(e => e.BefattningsNamn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblBetyg>(entity =>
            {
                entity.HasKey(e => e.BetygId);

                entity.ToTable("tblBetyg");

                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.BetygDatum).HasColumnType("date");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_tblBetyg_tblKurs");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_tblBetyg_tblPersonal");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_tblBetyg_tblStudent");
            });

            modelBuilder.Entity<TblKlass>(entity =>
            {
                entity.HasKey(e => e.KlassId);

                entity.ToTable("tblKlass");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.KlassNamn)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblKur>(entity =>
            {
                entity.HasKey(e => e.KursId);

                entity.ToTable("tblKurs");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.KursNamn)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId);

                entity.ToTable("tblPersonal");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.BefattningsId).HasColumnName("BefattningsID");

                entity.Property(e => e.PersonalEnamn)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PersonalENamn");

                entity.Property(e => e.PersonalFnamn)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PersonalFNamn");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<TblStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("tblStudent");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudentEnamn)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("StudentENamn");

                entity.Property(e => e.StudentFnamn)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("StudentFNamn");

                entity.HasOne(d => d.Klass)
                    .WithMany(p => p.TblStudents)
                    .HasForeignKey(d => d.KlassId)
                    .HasConstraintName("FK_tblStudent_tblKlass");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
