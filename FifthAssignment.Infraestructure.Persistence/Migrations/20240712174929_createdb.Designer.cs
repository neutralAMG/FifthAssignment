﻿// <auto-generated />
using System;
using FifthAssignment.Infraestructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FifthAssignment.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(fifthAssignmentContext))]
    [Migration("20240712174929_createdb")]
    partial class createdb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Transaction")
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.BeneficiaryPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("BeneficiaryBankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserBankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BeneficiaryBankAccountId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("BeneficiaryBankAccountId"), false);

                    b.HasIndex("UserBankAccountId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserBankAccountId"), false);

                    b.ToTable("BeneficiaryPayments", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.CreditcardPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserBankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserCreditCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserBankAccountId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserBankAccountId"), false);

                    b.HasIndex("UserCreditCardId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserCreditCardId"), false);

                    b.ToTable("CreditcardPayments", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.ExpressPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<Guid>("BankAccountFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BankAccountToId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountFromId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("BankAccountFromId"), false);

                    b.HasIndex("BankAccountToId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("BankAccountToId"), false);

                    b.ToTable("ExpressPayments", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.LoanPayment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserBankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserLoanId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserBankAccountId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserBankAccountId"), false);

                    b.HasIndex("UserLoanId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserLoanId"), false);

                    b.ToTable("LoanPayments", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.MoneyAdvance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserBankAccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserCreditCardId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserBankAccountId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserBankAccountId"), false);

                    b.HasIndex("UserCreditCardId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserCreditCardId"), false);

                    b.ToTable("MoneyAdvances", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TransactionDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionDetailId")
                        .IsUnique()
                        .HasFilter("[TransactionDetailId] IS NOT NULL");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("TransactionDetailId"), false);

                    b.HasIndex("TransactionTypeId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("TransactionTypeId"), false);

                    b.ToTable("Transactions", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SpecificTransactionDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TransactionIdId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpecificTransactionDetailId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("SpecificTransactionDetailId"), false);

                    b.HasIndex("TransactionTypeId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("TransactionTypeId"), false);

                    b.ToTable("TransactionDetails", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes", "Transaction");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Express Payment"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beneficiary Payment"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CreditCard Payment"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Loan Payment"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Transfer"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Money Advance"
                        });
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserAccountFromId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserAccountToId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserAccountFromId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserAccountFromId"), false);

                    b.HasIndex("UserAccountToId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserAccountToId"), false);

                    b.ToTable("Transfers", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentifierNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserId"), false);

                    b.ToTable("BankAccounts", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.Beneficiary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserBeneficiaryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserBeneficiaryId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserBeneficiaryId"), false);

                    b.HasIndex("UserId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserId"), false);

                    b.ToTable("Beneficiaries", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditLimit")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentifierNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserId"), false);

                    b.ToTable("CreditCards", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("IdentifierNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    SqlServerIndexBuilderExtensions.IsClustered(b.HasIndex("UserId"), false);

                    b.ToTable("Loans", "Transaction");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.BeneficiaryPayment", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "BeneficiaryAccount")
                        .WithMany("BeneficiaryPayments")
                        .HasForeignKey("BeneficiaryBankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserBankAccount")
                        .WithMany("UserPayments")
                        .HasForeignKey("UserBankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BeneficiaryAccount");

                    b.Navigation("UserBankAccount");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.CreditcardPayment", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserBankAccount")
                        .WithMany("CreditCardPayments")
                        .HasForeignKey("UserBankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.CreditCard", "UserCreditCard")
                        .WithMany("CreditCardPayments")
                        .HasForeignKey("UserCreditCardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserBankAccount");

                    b.Navigation("UserCreditCard");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.ExpressPayment", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "BankAccountFrom")
                        .WithMany("ExpressPaymentsFrom")
                        .HasForeignKey("BankAccountFromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "BankAccountTo")
                        .WithMany("ExpressPaymentsTo")
                        .HasForeignKey("BankAccountToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BankAccountFrom");

                    b.Navigation("BankAccountTo");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.LoanPayment", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserBankAccount")
                        .WithMany("LoansPayments")
                        .HasForeignKey("UserBankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.Loan", "UserLoan")
                        .WithMany("LoansPayments")
                        .HasForeignKey("UserLoanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserBankAccount");

                    b.Navigation("UserLoan");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.MoneyAdvance", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserBankAccount")
                        .WithMany("MoneyAdvances")
                        .HasForeignKey("UserBankAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.CreditCard", "UserCreditCard")
                        .WithMany("MoneyAdvances")
                        .HasForeignKey("UserCreditCardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserBankAccount");

                    b.Navigation("UserCreditCard");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionDetail", "TransactionDetail")
                        .WithOne("Transaction")
                        .HasForeignKey("FifthAssignment.Core.Domain.Entities.PaymentContext.Transaction", "TransactionDetailId");

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionDetail");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionDetail", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionType", "TransactionType")
                        .WithMany("TransactionDetails")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.Transfer", b =>
                {
                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserAccountFrom")
                        .WithMany("TransfersFrom")
                        .HasForeignKey("UserAccountFromId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", "UserAccountTo")
                        .WithMany("TransfersTo")
                        .HasForeignKey("UserAccountToId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("UserAccountFrom");

                    b.Navigation("UserAccountTo");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionDetail", b =>
                {
                    b.Navigation("Transaction")
                        .IsRequired();
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PaymentContext.TransactionType", b =>
                {
                    b.Navigation("TransactionDetails");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.BankAccount", b =>
                {
                    b.Navigation("BeneficiaryPayments");

                    b.Navigation("CreditCardPayments");

                    b.Navigation("ExpressPaymentsFrom");

                    b.Navigation("ExpressPaymentsTo");

                    b.Navigation("LoansPayments");

                    b.Navigation("MoneyAdvances");

                    b.Navigation("TransfersFrom");

                    b.Navigation("TransfersTo");

                    b.Navigation("UserPayments");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.CreditCard", b =>
                {
                    b.Navigation("CreditCardPayments");

                    b.Navigation("MoneyAdvances");
                });

            modelBuilder.Entity("FifthAssignment.Core.Domain.Entities.PersistanceContext.Loan", b =>
                {
                    b.Navigation("LoansPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
