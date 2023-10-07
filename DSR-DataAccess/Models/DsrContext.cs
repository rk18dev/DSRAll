using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DSR_DataAccess.Models;

public partial class DsrContext : DbContext
{
    public DsrContext()
    {
    }

    public DsrContext(DbContextOptions<DsrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalGuestCost> AdditionalGuestCosts { get; set; }

    public virtual DbSet<Amendment> Amendments { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<ContactDetail> ContactDetails { get; set; }

    public virtual DbSet<Dsradmin> Dsradmins { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<StoreImage> StoreImages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=DSR;Trusted_Connection=True;encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalGuestCost>(entity =>
        {
            entity.HasKey(e => e.AdditionGuestId);

            entity.ToTable("AdditionalGuestCost");

            entity.Property(e => e.AdditionGuestCost).HasColumnType("money");
            entity.Property(e => e.AdditionGuestType)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Amendment>(entity =>
        {
            entity.ToTable("Amendment");

            entity.Property(e => e.Features)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC0710534E99");

            entity.Property(e => e.BookFromDate).HasColumnType("datetime");
            entity.Property(e => e.BookToDate).HasColumnType("datetime");
            entity.Property(e => e.BookingDate).HasColumnType("date");
            entity.Property(e => e.BookingDateTime).HasColumnType("datetime");
            entity.Property(e => e.BookingId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BookingStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BookingUser)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsPayment)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsProofSubmitted)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PaymentAmount).HasColumnType("money");
        });

        modelBuilder.Entity<ContactDetail>(entity =>
        {
            entity.HasKey(e => e.ContactId);

            entity.Property(e => e.ContactName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dsradmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__DSRAdmin__719FE4E878FAEA0D");

            entity.ToTable("DSRAdmin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Fullname)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");

            entity.Property(e => e.HotelLocation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.HotelName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ImageList)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Latitude)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Longitude)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.Property(e => e.Comments)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rating1).HasColumnName("Rating");
            entity.Property(e => e.ReviewModifiedDate).HasColumnType("date");
            entity.Property(e => e.ReviewedBy)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.AmendmentList)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StoreImage>(entity =>
        {
            entity.Property(e => e.ImagePath)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FullName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
