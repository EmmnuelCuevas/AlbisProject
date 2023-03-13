﻿// <auto-generated />
using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221028160643_updte entity invoice")]
    partial class updteentityinvoice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Models.Client", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Address1")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsGob")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Rnc")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DataLayer.Models.Debt", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvoceID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Debts");
                });

            modelBuilder.Entity("DataLayer.Models.Invoice", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<string>("ClientID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCredit")
                        .HasColumnType("boolean");

                    b.Property<string>("NCF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.Property<float>("Taxes")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("DataLayer.Models.InvoiceDetail", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("InvoiceID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<float>("SubTotal")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ProductID");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("DataLayer.Models.NCF", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<int>("ActualGobNCF")
                        .HasColumnType("integer");

                    b.Property<int>("ActualNCF")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EndGobNCF")
                        .HasColumnType("integer");

                    b.Property<int>("EndNCF")
                        .HasColumnType("integer");

                    b.Property<string>("GobNCF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("NormalNCF")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StartGobNCF")
                        .HasColumnType("integer");

                    b.Property<int>("StartNCF")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("NCFs");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("GobPrice")
                        .HasColumnType("real");

                    b.Property<bool>("HasTaxes")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Debt", b =>
                {
                    b.HasOne("DataLayer.Models.Client", "Client")
                        .WithMany("Debts")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DataLayer.Models.Invoice", b =>
                {
                    b.HasOne("DataLayer.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("DataLayer.Models.InvoiceDetail", b =>
                {
                    b.HasOne("DataLayer.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Models.Client", b =>
                {
                    b.Navigation("Debts");
                });

            modelBuilder.Entity("DataLayer.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
