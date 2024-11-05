﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ReactApp2.Server.DateBase;

#nullable disable

namespace ReactApp2.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.1.24451.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ReactApp2.Server.Entity.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("LimitAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.Property<string>("repeater")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.CashExpenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ExpendDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ExpensesId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPriceDPH")
                        .HasColumnType("integer");

                    b.Property<int>("TotalPriceNotDPH")
                        .HasColumnType("integer");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpensesId");

                    b.ToTable("CashExpenses");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Investment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Duration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvestType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InvestmentAmount")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("InvestmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvestmentProfit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("InvestmentStock")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.Property<string>("investmentDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Investments");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("InterestRate")
                        .HasColumnType("double precision");

                    b.Property<string>("Lender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("LoanAmount")
                        .HasColumnType("double precision");

                    b.Property<string>("LoanName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeLoad")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("WalletId")
                        .HasColumnType("integer");

                    b.Property<double>("mounthlyPayment")
                        .HasColumnType("double precision");

                    b.Property<int>("term")
                        .HasColumnType("integer");

                    b.Property<double>("totalPayment")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("WalletId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CashExpensesId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExpendsId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PriceDPH")
                        .HasColumnType("integer");

                    b.Property<int>("PriceNotDPH")
                        .HasColumnType("integer");

                    b.Property<int>("PricePerUnit")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CashExpensesId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ExpensesId")
                        .HasColumnType("integer");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TransactionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Transactiontype")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExpensesId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Userid")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Userid");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Budget", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Wallet", null)
                        .WithMany("ListBudgets")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.CashExpenses", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Expenses", null)
                        .WithMany("CashExpenses")
                        .HasForeignKey("ExpensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Expenses", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Wallet", null)
                        .WithMany("Expenses")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Investment", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Wallet", null)
                        .WithMany("ListInvestments")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Loan", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Wallet", null)
                        .WithMany("ListLoan")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Product", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.CashExpenses", null)
                        .WithMany("Products")
                        .HasForeignKey("CashExpensesId");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Transaction", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.Expenses", null)
                        .WithMany("Transactions")
                        .HasForeignKey("ExpensesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Wallet", b =>
                {
                    b.HasOne("ReactApp2.Server.Entity.User", null)
                        .WithMany("Wallets")
                        .HasForeignKey("Userid");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.CashExpenses", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Expenses", b =>
                {
                    b.Navigation("CashExpenses");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.User", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("ReactApp2.Server.Entity.Wallet", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("ListBudgets");

                    b.Navigation("ListInvestments");

                    b.Navigation("ListLoan");
                });
#pragma warning restore 612, 618
        }
    }
}