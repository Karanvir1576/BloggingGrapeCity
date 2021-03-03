using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BloggingProject.Models
{
    public partial class Test20Context : DbContext
    {
        public Test20Context()
        {
        }

        public Test20Context(DbContextOptions<Test20Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserXBlog> UserXBlogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ABCD;Initial Catalog=Test20;Persist Security Info=True;User ID=ABCD;Password=ABCD");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("BLOGS");

                entity.Property(e => e.BlogId).HasColumnName("BLOG_ID");

                entity.Property(e => e.BlogHeader)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BLOG_HEADER");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("CONTENT");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__USER_DET__F3BEEBFF53E83036");

                entity.ToTable("USER_DETAILS");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<UserXBlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("USER_X_BLOGS");

                entity.Property(e => e.BlogId).HasColumnName("BLOG_ID");

                entity.Property(e => e.UserId).HasColumnName("USER_ID");

                entity.HasOne(d => d.Blog)
                    .WithMany()
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__USER_X_BL__BLOG___3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__USER_X_BL__USER___3A81B327");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
