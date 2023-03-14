﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WestSouth.IDP.DbContexts;

#nullable disable

namespace WestSouth.IDP.Migrations
{
    [DbContext(typeof(IdentityDbContext))]
    [Migration("20230314031612_InitialWestSouthIdentityMigration")]
    partial class InitialWestSouthIdentityMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("WestSouth.IDP.Entities.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8f757b9d-5d36-4eb7-b34b-b0dac758b825"),
                            ConcurrencyStamp = "6119b49d-df55-4fc1-bb80-5db347b89b6a",
                            Type = "given_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "David"
                        },
                        new
                        {
                            Id = new Guid("7a46836e-aacd-4551-b8d8-ee5bd95c70fa"),
                            ConcurrencyStamp = "343c535f-e11a-4962-8b20-2cde3b94c181",
                            Type = "family_name",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "Flagg"
                        },
                        new
                        {
                            Id = new Guid("0bb2bca5-39c5-42d5-bdd6-008086ea6881"),
                            ConcurrencyStamp = "9c496942-97cb-44e2-897f-5f085308c375",
                            Type = "country",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "nl"
                        },
                        new
                        {
                            Id = new Guid("67d4d0a5-fe5a-48a0-9791-1e42eff05044"),
                            ConcurrencyStamp = "8ae7d0b8-e00f-42cb-aec5-e075b444ff2d",
                            Type = "role",
                            UserId = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Value = "FreeUser"
                        },
                        new
                        {
                            Id = new Guid("57c92a47-8730-423e-8e48-9f9c255a2ec2"),
                            ConcurrencyStamp = "d1f01603-fc1c-4695-91f6-6cb3ea7ff343",
                            Type = "given_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Emma"
                        },
                        new
                        {
                            Id = new Guid("ac520452-0c89-4643-8c1a-ee590589c6d0"),
                            ConcurrencyStamp = "30d5630a-3cdb-42c5-8d84-e29da0863ffb",
                            Type = "family_name",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "Flagg"
                        },
                        new
                        {
                            Id = new Guid("af9cffc7-f921-443d-bd2c-499be59fed3e"),
                            ConcurrencyStamp = "1aba9816-251b-4dbe-bca6-833304c6dac3",
                            Type = "country",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "be"
                        },
                        new
                        {
                            Id = new Guid("4e6ea32e-f6a4-48e4-85a7-b09ea4f0d3cb"),
                            ConcurrencyStamp = "77893bae-be67-4aad-b395-3c0729296e65",
                            Type = "role",
                            UserId = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Value = "PayingUser"
                        });
                });

            modelBuilder.Entity("WestSouth.IDP.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Subject")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                            Active = true,
                            ConcurrencyStamp = "ebc692a9-67b8-4b42-81c9-d09465c96efb",
                            Password = "password",
                            Subject = "d860efca-22d9-47fd-8249-791ba61b07c7",
                            UserName = "David"
                        },
                        new
                        {
                            Id = new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                            Active = true,
                            ConcurrencyStamp = "7939d0e9-8326-4e3e-b849-514108b58bd4",
                            Password = "password",
                            Subject = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                            UserName = "Emma"
                        });
                });

            modelBuilder.Entity("WestSouth.IDP.Entities.UserClaim", b =>
                {
                    b.HasOne("WestSouth.IDP.Entities.User", "User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WestSouth.IDP.Entities.User", b =>
                {
                    b.Navigation("Claims");
                });
#pragma warning restore 612, 618
        }
    }
}