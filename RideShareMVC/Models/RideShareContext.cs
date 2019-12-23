using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RideShareMVC.Models
{
    public partial class RideShareContext : DbContext
    {
        public RideShareContext()
        {
        }

        public RideShareContext(DbContextOptions<RideShareContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblContactType> TblContactType { get; set; }
        public virtual DbSet<TblRide> TblRide { get; set; }
        public virtual DbSet<TblRideRequest> TblRideRequest { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<Tbladdress> Tbladdress { get; set; }
        public virtual DbSet<Tblcontact> Tblcontact { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=MYCOMPUTER1;Initial Catalog=RideShare;User ID=rideshareAdmin;Password=Password123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TblContactType>(entity =>
            {
                entity.HasKey(e => e.ContactTypeGuid);

                entity.ToTable("tblContactType");

                entity.Property(e => e.ContactTypeGuid)
                    .HasColumnName("contactType_Guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactType)
                    .HasColumnName("contactType")
                    .HasMaxLength(6);

                entity.Property(e => e.ContactTypeCreateDate)
                    .HasColumnName("contactType_CreateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactTypeUpdateDate)
                    .HasColumnName("contactType_updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblRide>(entity =>
            {
                entity.HasKey(e => e.RideGuid);

                entity.ToTable("tblRide");

                entity.Property(e => e.RideGuid)
                    .HasColumnName("ride_GUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RideCreateDate)
                    .HasColumnName("ride_createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RideEndAddressGuid).HasColumnName("rideEndAddress_Guid");

                entity.Property(e => e.RideEndDateTime)
                    .HasColumnName("rideEndDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RideFromGuid).HasColumnName("rideFrom_GUID");

                entity.Property(e => e.RideStartAddressGuid).HasColumnName("rideStartAddress_Guid");

                entity.Property(e => e.RideStartDateTime)
                    .HasColumnName("rideStartDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RideToGuid).HasColumnName("rideTo_GUID");

                entity.Property(e => e.RideUpdateDate)
                    .HasColumnName("ride_updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.RideEndAddressGu)
                    .WithMany(p => p.TblRideRideEndAddressGu)
                    .HasForeignKey(d => d.RideEndAddressGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRide_tbladdress1");

                entity.HasOne(d => d.RideFromGu)
                    .WithMany(p => p.TblRideRideFromGu)
                    .HasForeignKey(d => d.RideFromGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRide_tblUser");

                entity.HasOne(d => d.RideStartAddressGu)
                    .WithMany(p => p.TblRideRideStartAddressGu)
                    .HasForeignKey(d => d.RideStartAddressGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRide_tbladdress");

                entity.HasOne(d => d.RideToGu)
                    .WithMany(p => p.TblRideRideToGu)
                    .HasForeignKey(d => d.RideToGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRide_tblUser1");
            });

            modelBuilder.Entity<TblRideRequest>(entity =>
            {
                entity.HasKey(e => e.RideRequestGuid);

                entity.ToTable("tblRideRequest");

                entity.Property(e => e.RideRequestGuid)
                    .HasColumnName("rideRequest_GUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.RequestCreateDate)
                    .HasColumnName("request_createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestEndAddressGuid).HasColumnName("requestEndAddress_Guid");

                entity.Property(e => e.RequestEndDateTime)
                    .HasColumnName("requestEndDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestFromGuid).HasColumnName("requestFrom_GUID");

                entity.Property(e => e.RequestStartAddressGuid).HasColumnName("requestStartAddress_Guid");

                entity.Property(e => e.RequestStartDateTime)
                    .HasColumnName("requestStartDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.RequestToGuid).HasColumnName("requestTo_GUID");

                entity.Property(e => e.RequestUpdateDate)
                    .HasColumnName("request_updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.RequestEndAddressGu)
                    .WithMany(p => p.TblRideRequestRequestEndAddressGu)
                    .HasForeignKey(d => d.RequestEndAddressGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRideRequest_tbladdress1");

                entity.HasOne(d => d.RequestFromGu)
                    .WithMany(p => p.TblRideRequestRequestFromGu)
                    .HasForeignKey(d => d.RequestFromGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRideRequest_tblUser");

                entity.HasOne(d => d.RequestStartAddressGu)
                    .WithMany(p => p.TblRideRequestRequestStartAddressGu)
                    .HasForeignKey(d => d.RequestStartAddressGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRideRequest_tbladdress");

                entity.HasOne(d => d.RequestToGu)
                    .WithMany(p => p.TblRideRequestRequestToGu)
                    .HasForeignKey(d => d.RequestToGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblRideRequest_tblUser1");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserGuid);

                entity.ToTable("tblUser");

                entity.Property(e => e.UserGuid)
                    .HasColumnName("user_GUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("emailAddress")
                    .HasMaxLength(40);

                //entity.Property(e => e.Password)
                //    .IsRequired()
                //    .HasMaxLength(128);
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserCreateDate)
                    .HasColumnName("user_createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(30);

                entity.Property(e => e.UserUpdateDate)
                    .HasColumnName("user_updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Tbladdress>(entity =>
            {
                entity.HasKey(e => e.AddressGuid);

                entity.ToTable("tbladdress");

                entity.Property(e => e.AddressGuid)
                    .HasColumnName("address_Guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressCreateDate)
                    .HasColumnName("address_createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.AddressUpdateDate)
                    .HasColumnName("address_updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.City).HasMaxLength(10);

                entity.Property(e => e.PostalCode).HasColumnName("postal_code");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(2);

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .HasColumnName("street1")
                    .HasMaxLength(20);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(20);

                entity.Property(e => e.UserGuid).HasColumnName("user_Guid");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.Tbladdress)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbladdress_tblUser");
            });

            modelBuilder.Entity<Tblcontact>(entity =>
            {
                entity.HasKey(e => e.ContactGuid);

                entity.ToTable("tblcontact");

                entity.Property(e => e.ContactGuid)
                    .HasColumnName("contact_Guid")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactCreateDate)
                    .HasColumnName("contact_createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactType).HasColumnName("contactType");

                entity.Property(e => e.ContactUpdateDate)
                    .HasColumnName("contact_updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ContactValue)
                    .IsRequired()
                    .HasColumnName("contactValue")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("isActive")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserGuid).HasColumnName("user_Guid");

                entity.HasOne(d => d.ContactTypeNavigation)
                    .WithMany(p => p.Tblcontact)
                    .HasForeignKey(d => d.ContactType)
                    .HasConstraintName("FK_tblcontact_tblContactType");

                entity.HasOne(d => d.UserGu)
                    .WithMany(p => p.Tblcontact)
                    .HasForeignKey(d => d.UserGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblcontact_tblUser");
            });
        }
    }
}
