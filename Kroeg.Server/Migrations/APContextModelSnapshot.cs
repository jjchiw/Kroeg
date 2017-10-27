﻿// <auto-generated />
using Kroeg.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Kroeg.Server.Migrations
{
    [DbContext(typeof(APContext))]
    partial class APContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Kroeg.Server.Models.APDBEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsOwner");

                    b.Property<string>("SerializedData")
                        .HasColumnType("jsonb");

                    b.Property<string>("Type");

                    b.Property<DateTime>("Updated");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Kroeg.Server.Models.APTripleEntity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdId");

                    b.Property<bool>("IsOwner");

                    b.Property<string>("Type");

                    b.Property<DateTime>("Updated");

                    b.HasKey("EntityId");

                    b.HasIndex("IdId");

                    b.ToTable("TripleEntities");
                });

            modelBuilder.Entity("Kroeg.Server.Models.APUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kroeg.Server.Models.CollectionItem", b =>
                {
                    b.Property<int>("CollectionItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CollectionId");

                    b.Property<string>("ElementId");

                    b.Property<bool>("IsPublic");

                    b.HasKey("CollectionItemId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ElementId");

                    b.ToTable("CollectionItems");
                });

            modelBuilder.Entity("Kroeg.Server.Models.EventQueueItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<DateTime>("Added");

                    b.Property<int>("AttemptCount");

                    b.Property<string>("Data");

                    b.Property<DateTime>("NextAttempt");

                    b.HasKey("Id");

                    b.ToTable("EventQueue");
                });

            modelBuilder.Entity("Kroeg.Server.Models.JWKEntry", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("OwnerId");

                    b.Property<string>("SerializedData");

                    b.HasKey("Id", "OwnerId");

                    b.HasIndex("OwnerId");

                    b.ToTable("JsonWebKeys");
                });

            modelBuilder.Entity("Kroeg.Server.Models.SalmonKey", b =>
                {
                    b.Property<int>("SalmonKeyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EntityId");

                    b.Property<string>("PrivateKey");

                    b.HasKey("SalmonKeyId");

                    b.HasIndex("EntityId");

                    b.ToTable("SalmonKeys");
                });

            modelBuilder.Entity("Kroeg.Server.Models.Triple", b =>
                {
                    b.Property<int>("TripleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AttributeId");

                    b.Property<string>("Object");

                    b.Property<int>("PredicateId");

                    b.Property<int>("SubjectEntityId");

                    b.Property<int>("SubjectId");

                    b.Property<int?>("TypeId");

                    b.HasKey("TripleId");

                    b.HasIndex("AttributeId");

                    b.HasIndex("PredicateId");

                    b.HasIndex("SubjectEntityId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TypeId");

                    b.ToTable("Triples");
                });

            modelBuilder.Entity("Kroeg.Server.Models.TripleAttribute", b =>
                {
                    b.Property<int>("AttributeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Uri");

                    b.HasKey("AttributeId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Kroeg.Server.Models.UserActorPermission", b =>
                {
                    b.Property<int>("UserActorPermissionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActorId");

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("UserId");

                    b.HasKey("UserActorPermissionId");

                    b.HasIndex("ActorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserActorPermissions");
                });

            modelBuilder.Entity("Kroeg.Server.Models.WebSubClient", b =>
                {
                    b.Property<int>("WebSubClientId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Expiry");

                    b.Property<string>("ForUserId");

                    b.Property<string>("Secret");

                    b.Property<string>("TargetUserId");

                    b.Property<string>("Topic");

                    b.HasKey("WebSubClientId");

                    b.HasIndex("ForUserId");

                    b.HasIndex("TargetUserId");

                    b.ToTable("WebSubClients");
                });

            modelBuilder.Entity("Kroeg.Server.Models.WebsubSubscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Callback");

                    b.Property<DateTime>("Expiry");

                    b.Property<string>("Secret");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("WebsubSubscriptions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kroeg.Server.Models.APTripleEntity", b =>
                {
                    b.HasOne("Kroeg.Server.Models.TripleAttribute", "Id")
                        .WithMany("Entities")
                        .HasForeignKey("IdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kroeg.Server.Models.CollectionItem", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "Collection")
                        .WithMany()
                        .HasForeignKey("CollectionId");

                    b.HasOne("Kroeg.Server.Models.APDBEntity", "Element")
                        .WithMany()
                        .HasForeignKey("ElementId");
                });

            modelBuilder.Entity("Kroeg.Server.Models.JWKEntry", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kroeg.Server.Models.SalmonKey", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");
                });

            modelBuilder.Entity("Kroeg.Server.Models.Triple", b =>
                {
                    b.HasOne("Kroeg.Server.Models.TripleAttribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("Kroeg.Server.Models.TripleAttribute", "Predicate")
                        .WithMany()
                        .HasForeignKey("PredicateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kroeg.Server.Models.APTripleEntity", "SubjectEntity")
                        .WithMany("Triples")
                        .HasForeignKey("SubjectEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kroeg.Server.Models.TripleAttribute", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kroeg.Server.Models.TripleAttribute", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Kroeg.Server.Models.UserActorPermission", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "Actor")
                        .WithMany()
                        .HasForeignKey("ActorId");

                    b.HasOne("Kroeg.Server.Models.APUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Kroeg.Server.Models.WebSubClient", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "ForUser")
                        .WithMany()
                        .HasForeignKey("ForUserId");

                    b.HasOne("Kroeg.Server.Models.APDBEntity", "TargetUser")
                        .WithMany()
                        .HasForeignKey("TargetUserId");
                });

            modelBuilder.Entity("Kroeg.Server.Models.WebsubSubscription", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APDBEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kroeg.Server.Models.APUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Kroeg.Server.Models.APUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
