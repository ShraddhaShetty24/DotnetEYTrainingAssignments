using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudTwoTablesWebApi_Feb13.Models
{
    public partial class StudentCourse2Context : DbContext
    {
        public StudentCourse2Context()
        {
        }

        public StudentCourse2Context(DbContextOptions<StudentCourse2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Tcourse1> Tcourse1s { get; set; } = null!;
        public virtual DbSet<Tstudent1> Tstudent1s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost;trusted_connection=true;database=StudentCourse2");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tcourse1>(entity =>
            {
                entity.HasKey(e => e.CourseId);

                entity.ToTable("TCourse1");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tstudent1>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("TStudent1");

                entity.Property(e => e.StudentAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Tstudent1s)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TStudent1__Cours__3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
