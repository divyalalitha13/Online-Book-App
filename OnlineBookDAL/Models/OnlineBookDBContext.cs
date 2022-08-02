using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace OnlineBookDAL.Models
{
    public partial class OnlineBookDBContext : DbContext
    {
        public OnlineBookDBContext()
        {
        }

        public OnlineBookDBContext(DbContextOptions<OnlineBookDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<CardDetails> CardDetails { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }
        public virtual DbSet<BooksInCart> BooksInCart { get; set; }
        public virtual DbSet<BooksAndGenre> BooksAndGenre { get; set; }
        public virtual DbSet<BooksInOrders> BooksInOrders { get; set; }


        [DbFunction("ufn_ValidateUserCredentials", "dbo")]
        public static int ValidateUserCredentials(string emailId,string userPassword)
        {
            return 0;
        }

        [DbFunction("ufn_TotalAmountInCart", "dbo")]
        public static decimal TotalAmountInCart(string emailId)
        {
            return 0;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("OnlineBookDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.BookName)
                    .HasName("Book_uq_BookName")
                    .IsUnique();

                entity.Property(e => e.BookId)
                    .HasColumnName("BookID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cost).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GenreId).HasColumnName("GenreID");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Book_fk_GenreID");
            });

            modelBuilder.Entity<CardDetails>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("card_pk_cardnumber");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.Property(e => e.CartId).HasColumnName("CartID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_fk_BookID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_fk_EmailID");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.GenreName)
                    .HasName("Genre_uq_GenreName")
                    .IsUnique();

                entity.Property(e => e.GenreId)
                    .HasColumnName("GenreID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimatedDelivery).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk_BookID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_fk_EmailID");
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasKey(e => e.RatingId)
                    .HasName("Ratings_pk_RatingID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ratings_fk_BookID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ratings_fk_EmailID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ratings_fk_OrderID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("User_pk_EmailID");

                entity.HasIndex(e => e.ContactNo)
                    .HasName("User_uq_ContactNo")
                    .IsUnique();

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.WishlistId).HasColumnName("WishlistID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("EmailID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Wishlist_fk_BookID");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Wishlist_fk_EmailID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
