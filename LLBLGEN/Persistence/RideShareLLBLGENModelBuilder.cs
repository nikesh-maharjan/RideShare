﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.6.</auto-generated>
//------------------------------------------------------------------------------
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RideShare.LLBLGEN.EntityClasses;
using RideShare.LLBLGEN.TypedViewClasses;

namespace RideShare.LLBLGEN
{
	/// <summary>Model builder class for code first development.</summary>
	public partial class RideShareLLBLGENModelBuilder
	{
		/// <summary>Builds the model defined in this class with the modelbuilder specified. Called from the generated DbContext</summary>
		/// <param name="modelBuilder">The model builder to build the model with.</param>
		public virtual void BuildModel(ModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("dbo");
			MapTbladdress(modelBuilder.Entity<Tbladdress>());
			MapTblcontact(modelBuilder.Entity<Tblcontact>());
			MapTblContactType(modelBuilder.Entity<TblContactType>());
			MapTblRide(modelBuilder.Entity<TblRide>());
			MapTblRideRequest(modelBuilder.Entity<TblRideRequest>());
			MapTblUser(modelBuilder.Entity<TblUser>());
			MapTbladdress1(modelBuilder.Query<Tbladdress1TypedViewRow>());
			MapTblcontact1(modelBuilder.Query<Tblcontact1TypedViewRow>());
			MapTblContactType1(modelBuilder.Query<TblContactType1TypedViewRow>());
			MapTblRide1(modelBuilder.Query<TblRide1TypedViewRow>());
			MapTblRideRequest1(modelBuilder.Query<TblRideRequest1TypedViewRow>());
			MapTblUser1(modelBuilder.Query<TblUser1TypedViewRow>());
		}

		/// <summary>Defines the mapping information for the entity 'Tbladdress'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTbladdress(EntityTypeBuilder<Tbladdress> config)
		{
			config.ToTable("tbladdress");
			config.HasKey(t => t.AddressGuid);
			config.Property(t => t.AddressGuid).HasColumnName("address_Guid");
			config.Property(t => t.UserGuid).HasColumnName("user_Guid");
			config.Property(t => t.Street1).HasColumnName("street1").HasMaxLength(20).IsRequired();
			config.Property(t => t.Street2).HasColumnName("street2").HasMaxLength(20);
			config.Property(t => t.City).HasMaxLength(10);
			config.Property(t => t.State).HasColumnName("state").HasMaxLength(2).IsRequired();
			config.Property(t => t.PostalCode).HasColumnName("postal_code");
			config.Property(t => t.AddressCreateDate).HasColumnName("address_createDate");
			config.Property(t => t.AddressUpdateDate).HasColumnName("address_updateDate");
			config.HasOne(t => t.TblUser).WithMany(t => t.Tbladdresses).HasForeignKey(t => t.UserGuid);
		}

		/// <summary>Defines the mapping information for the entity 'Tblcontact'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblcontact(EntityTypeBuilder<Tblcontact> config)
		{
			config.ToTable("tblcontact");
			config.HasKey(t => t.ContactGuid);
			config.Property(t => t.ContactGuid).HasColumnName("contact_Guid");
			config.Property(t => t.UserGuid).HasColumnName("user_Guid");
			config.Property(t => t.ContactType).HasColumnName("contactType");
			config.Property(t => t.ContactValue).HasColumnName("contactValue").HasMaxLength(10).IsRequired();
			config.Property(t => t.IsActive).HasColumnName("isActive").HasMaxLength(1).IsRequired();
			config.Property(t => t.ContactCreateDate).HasColumnName("contact_createDate");
			config.Property(t => t.ContactUpdateDate).HasColumnName("contact_updateDate");
			config.HasOne(t => t.TblContactType).WithMany(t => t.Tblcontacts).HasForeignKey(t => t.ContactType);
			config.HasOne(t => t.TblUser).WithMany(t => t.Tblcontacts).HasForeignKey(t => t.UserGuid);
		}

		/// <summary>Defines the mapping information for the entity 'TblContactType'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblContactType(EntityTypeBuilder<TblContactType> config)
		{
			config.ToTable("tblContactType");
			config.HasKey(t => t.ContactTypeGuid);
			config.Property(t => t.ContactTypeGuid).HasColumnName("contactType_Guid");
			config.Property(t => t.ContactType).HasColumnName("contactType").HasMaxLength(6);
			config.Property(t => t.ContactTypeCreateDate).HasColumnName("contactType_CreateDate");
			config.Property(t => t.ContactTypeUpdateDate).HasColumnName("contactType_updateDate");
		}

		/// <summary>Defines the mapping information for the entity 'TblRide'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblRide(EntityTypeBuilder<TblRide> config)
		{
			config.ToTable("tblRide");
			config.HasKey(t => t.RideGuid);
			config.Property(t => t.RideGuid).HasColumnName("ride_GUID");
			config.Property(t => t.RideFromGuid).HasColumnName("rideFrom_GUID");
			config.Property(t => t.RideToGuid).HasColumnName("rideTo_GUID");
			config.Property(t => t.RideStartDateTime).HasColumnName("rideStartDateTime");
			config.Property(t => t.RideEndDateTime).HasColumnName("rideEndDateTime");
			config.Property(t => t.RideStartAddressGuid).HasColumnName("rideStartAddress_Guid");
			config.Property(t => t.RideEndAddressGuid).HasColumnName("rideEndAddress_Guid");
			config.Property(t => t.RideCreateDate).HasColumnName("ride_createDate");
			config.Property(t => t.RideUpdateDate).HasColumnName("ride_updateDate");
			config.HasOne(t => t.Tbladdress).WithMany(t => t.TblRides).HasForeignKey(t => t.RideStartAddressGuid);
			config.HasOne(t => t.Tbladdress1).WithMany(t => t.TblRides1).HasForeignKey(t => t.RideEndAddressGuid);
			config.HasOne(t => t.TblUser).WithMany(t => t.TblRides).HasForeignKey(t => t.RideFromGuid);
			config.HasOne(t => t.TblUser1).WithMany(t => t.TblRides1).HasForeignKey(t => t.RideToGuid);
		}

		/// <summary>Defines the mapping information for the entity 'TblRideRequest'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblRideRequest(EntityTypeBuilder<TblRideRequest> config)
		{
			config.ToTable("tblRideRequest");
			config.HasKey(t => t.RideRequestGuid);
			config.Property(t => t.RideRequestGuid).HasColumnName("rideRequest_GUID");
			config.Property(t => t.RequestFromGuid).HasColumnName("requestFrom_GUID");
			config.Property(t => t.RequestToGuid).HasColumnName("requestTo_GUID");
			config.Property(t => t.RequestStartDateTime).HasColumnName("requestStartDateTime");
			config.Property(t => t.RequestEndDateTime).HasColumnName("requestEndDateTime");
			config.Property(t => t.RequestStartAddressGuid).HasColumnName("requestStartAddress_Guid");
			config.Property(t => t.RequestEndAddressGuid).HasColumnName("requestEndAddress_Guid");
			config.Property(t => t.RequestCreateDate).HasColumnName("request_createDate");
			config.Property(t => t.RequestUpdateDate).HasColumnName("request_updateDate");
			config.HasOne(t => t.Tbladdress).WithMany(t => t.TblRideRequests).HasForeignKey(t => t.RequestStartAddressGuid);
			config.HasOne(t => t.Tbladdress1).WithMany(t => t.TblRideRequests1).HasForeignKey(t => t.RequestEndAddressGuid);
			config.HasOne(t => t.TblUser).WithMany(t => t.TblRideRequests).HasForeignKey(t => t.RequestFromGuid);
			config.HasOne(t => t.TblUser1).WithMany(t => t.TblRideRequests1).HasForeignKey(t => t.RequestToGuid);
		}

		/// <summary>Defines the mapping information for the entity 'TblUser'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblUser(EntityTypeBuilder<TblUser> config)
		{
			config.ToTable("tblUser");
			config.HasKey(t => t.UserGuid);
			config.Property(t => t.UserGuid).HasColumnName("user_GUID");
			config.Property(t => t.UserName).HasColumnName("userName").HasMaxLength(30).IsRequired();
			config.Property(t => t.EmailAddress).HasColumnName("emailAddress").HasMaxLength(40).IsRequired();
			config.Property(t => t.Password).HasMaxLength(100);
			config.Property(t => t.UserCreateDate).HasColumnName("user_createDate");
			config.Property(t => t.UserUpdateDate).HasColumnName("user_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'Tbladdress1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTbladdress1(QueryTypeBuilder<Tbladdress1TypedViewRow> config)
		{
			config.ToView("tbladdress");
			config.Property(t => t.AddressGuid).HasColumnName("address_Guid");
			config.Property(t => t.UserGuid).HasColumnName("user_Guid");
			config.Property(t => t.Street1).HasColumnName("street1").HasMaxLength(20).IsRequired();
			config.Property(t => t.Street2).HasColumnName("street2").HasMaxLength(20);
			config.Property(t => t.City).HasMaxLength(10);
			config.Property(t => t.State).HasColumnName("state").HasMaxLength(2).IsRequired();
			config.Property(t => t.PostalCode).HasColumnName("postal_code");
			config.Property(t => t.AddressCreateDate).HasColumnName("address_createDate");
			config.Property(t => t.AddressUpdateDate).HasColumnName("address_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'Tblcontact1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblcontact1(QueryTypeBuilder<Tblcontact1TypedViewRow> config)
		{
			config.ToView("tblcontact");
			config.Property(t => t.ContactGuid).HasColumnName("contact_Guid");
			config.Property(t => t.UserGuid).HasColumnName("user_Guid");
			config.Property(t => t.ContactType).HasColumnName("contactType");
			config.Property(t => t.ContactValue).HasColumnName("contactValue").HasMaxLength(10).IsRequired();
			config.Property(t => t.IsActive).HasColumnName("isActive").HasMaxLength(1).IsRequired();
			config.Property(t => t.ContactCreateDate).HasColumnName("contact_createDate");
			config.Property(t => t.ContactUpdateDate).HasColumnName("contact_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'TblContactType1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblContactType1(QueryTypeBuilder<TblContactType1TypedViewRow> config)
		{
			config.ToView("tblContactType");
			config.Property(t => t.ContactTypeGuid).HasColumnName("contactType_Guid");
			config.Property(t => t.ContactType).HasColumnName("contactType").HasMaxLength(6);
			config.Property(t => t.ContactTypeCreateDate).HasColumnName("contactType_CreateDate");
			config.Property(t => t.ContactTypeUpdateDate).HasColumnName("contactType_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'TblRide1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblRide1(QueryTypeBuilder<TblRide1TypedViewRow> config)
		{
			config.ToView("tblRide");
			config.Property(t => t.RideGuid).HasColumnName("ride_GUID");
			config.Property(t => t.RideFromGuid).HasColumnName("rideFrom_GUID");
			config.Property(t => t.RideToGuid).HasColumnName("rideTo_GUID");
			config.Property(t => t.RideStartDateTime).HasColumnName("rideStartDateTime");
			config.Property(t => t.RideEndDateTime).HasColumnName("rideEndDateTime");
			config.Property(t => t.RideStartAddressGuid).HasColumnName("rideStartAddress_Guid");
			config.Property(t => t.RideEndAddressGuid).HasColumnName("rideEndAddress_Guid");
			config.Property(t => t.RideCreateDate).HasColumnName("ride_createDate");
			config.Property(t => t.RideUpdateDate).HasColumnName("ride_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'TblRideRequest1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblRideRequest1(QueryTypeBuilder<TblRideRequest1TypedViewRow> config)
		{
			config.ToView("tblRideRequest");
			config.Property(t => t.RideRequestGuid).HasColumnName("rideRequest_GUID");
			config.Property(t => t.RequestFromGuid).HasColumnName("requestFrom_GUID");
			config.Property(t => t.RequestToGuid).HasColumnName("requestTo_GUID");
			config.Property(t => t.RequestStartDateTime).HasColumnName("requestStartDateTime");
			config.Property(t => t.RequestEndDateTime).HasColumnName("requestEndDateTime");
			config.Property(t => t.RequestStartAddressGuid).HasColumnName("requestStartAddress_Guid");
			config.Property(t => t.RequestEndAddressGuid).HasColumnName("requestEndAddress_Guid");
			config.Property(t => t.RequestCreateDate).HasColumnName("request_createDate");
			config.Property(t => t.RequestUpdateDate).HasColumnName("request_updateDate");
		}

		/// <summary>Defines the mapping information for the typed view 'TblUser1'</summary>
		/// <param name="config">The configuration to modify.</param>
		protected virtual void MapTblUser1(QueryTypeBuilder<TblUser1TypedViewRow> config)
		{
			config.ToView("tblUser");
			config.Property(t => t.UserGuid).HasColumnName("user_GUID");
			config.Property(t => t.UserName).HasColumnName("userName").HasMaxLength(30).IsRequired();
			config.Property(t => t.EmailAddress).HasColumnName("emailAddress").HasMaxLength(40).IsRequired();
			config.Property(t => t.Password).HasMaxLength(100);
			config.Property(t => t.UserCreateDate).HasColumnName("user_createDate");
			config.Property(t => t.UserUpdateDate).HasColumnName("user_updateDate");
		}
	}


	/// <summary>Extensions class for extension methods used in the model builder code</summary>
	internal static partial class RideShareLLBLGENModelBuilderExtensions
	{
        private static readonly string READONLY_ANNOTATION = "custom:readonly";

		/// <summary>Extension method which is used by the context class to determine whether an entity is readonly</summary>
		/// <typeparam name="TEntity">The type of the entity.</typeparam>
		/// <param name="builder">The entity type builder object to augment.</param>
		/// <returns>the passed in entity type builder</returns>
		internal static EntityTypeBuilder<TEntity> IsReadOnly<TEntity>(this EntityTypeBuilder<TEntity> builder)
			where TEntity : class
		{
			builder.HasAnnotation(READONLY_ANNOTATION, true);
			return builder;
		}
		
		/// <summary>Determines whether the passed in entity type has the readonly annotation set.
		/// </summary>
		/// <param name="entity">The entity type to check.</param>
		/// <returns>true if the entity type is marked as read-only, false otherwise</returns>
		public static bool IsReadOnly(this IEntityType entity)
		{
			var annotation = entity.FindAnnotation(READONLY_ANNOTATION);
			return annotation != null && (bool)annotation.Value;
		}
	}
}

