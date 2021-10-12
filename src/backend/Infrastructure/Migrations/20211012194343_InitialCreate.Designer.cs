﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SqLiteContext))]
    [Migration("20211012194343_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Entities.Accommodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Accommodation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Number = 1,
                            State = 1
                        },
                        new
                        {
                            Id = 2,
                            Number = 2,
                            State = 1
                        },
                        new
                        {
                            Id = 3,
                            Number = 3,
                            State = 1
                        },
                        new
                        {
                            Id = 4,
                            Number = 4,
                            State = 1
                        },
                        new
                        {
                            Id = 5,
                            Number = 5,
                            State = 1
                        },
                        new
                        {
                            Id = 6,
                            Number = 6,
                            State = 1
                        },
                        new
                        {
                            Id = 8,
                            Number = 8,
                            State = 1
                        },
                        new
                        {
                            Id = 7,
                            Number = 7,
                            State = 1
                        },
                        new
                        {
                            Id = 9,
                            Number = 9,
                            State = 1
                        },
                        new
                        {
                            Id = 10,
                            Number = 10,
                            State = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccommodationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HeathState")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReasonForTreatment")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("Domain.Entities.Pet", b =>
                {
                    b.HasOne("Domain.Entities.Accommodation", "Accommodation")
                        .WithOne("Pet")
                        .HasForeignKey("Domain.Entities.Pet", "AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accommodation");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Domain.Entities.Accommodation", b =>
                {
                    b.Navigation("Pet");
                });

            modelBuilder.Entity("Domain.Entities.Owner", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
