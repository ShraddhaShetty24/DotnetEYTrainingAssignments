using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryTestMVC.Models
{
    public partial class LibrarytestContext : DbContext
    {
        public LibrarytestContext()
        {
        }

        public LibrarytestContext(DbContextOptions<LibrarytestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuthorT> AuthorTs { get; set; } = null!;
        public virtual DbSet<BookT> BookTs { get; set; } = null!;
        public virtual DbSet<BorrowT> BorrowTs { get; set; } = null!;
        public virtual DbSet<StudentT> StudentTs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost;trusted_connection=true;database=Librarytest");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorT>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.ToTable("AuthorT");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookT>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("BookT");

                entity.Property(e => e.BookName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookTs)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__BookT__AuthorId__3D5E1FD2");
            });

            modelBuilder.Entity<BorrowT>(entity =>
            {
                entity.HasKey(e => e.BorrowId);

                entity.ToTable("BorrowT");

                entity.Property(e => e.TakenDate).HasColumnType("date");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BorrowTs)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__BorrowT__AuthorI__440B1D61");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowTs)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__BorrowT__BookId__412EB0B6");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BorrowTs)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__BorrowT__Student__403A8C7D");
            });

            modelBuilder.Entity<StudentT>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("StudentT");

                entity.Property(e => e.StudentFirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentLastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
