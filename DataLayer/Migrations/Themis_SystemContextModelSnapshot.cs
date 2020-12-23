﻿// <auto-generated />
using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(Themis_SystemContext))]
    partial class Themis_SystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.BlockChain", b =>
                {
                    b.Property<int>("BlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("BlockID")
                        .HasColumnType("int")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .HasColumnType("varchar(1)")
                        .HasMaxLength(1)
                        .IsUnicode(false);

                    b.Property<string>("Hash")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<string>("Idbd")
                        .HasColumnName("IDBD")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int>("PartyChoosed")
                        .HasColumnName("Party_Choosed")
                        .HasColumnType("int");

                    b.Property<string>("PreviouseHash")
                        .HasColumnType("varchar(2000)")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<int>("RegionChoosed")
                        .HasColumnName("Region_Choosed")
                        .HasColumnType("int");

                    b.Property<int>("YearToBirth")
                        .HasColumnName("Year_To_Birth")
                        .HasColumnType("int");

                    b.HasKey("BlockId")
                        .HasName("PK__BlockCha__1442151110DD289E");

                    b.ToTable("BlockChain");
                });

            modelBuilder.Entity("DataLayer.Models.ConsensusAccounts", b =>
                {
                    b.Property<string>("Idbd")
                        .HasColumnName("IDBD")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("RepByNodeR")
                        .HasColumnName("RepByNode_R")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<DateTime?>("RepDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Software")
                        .HasColumnType("varchar(5)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    b.HasKey("Idbd")
                        .HasName("PK__Consensu__B87DA8C3E8B93C43");

                    b.ToTable("Consensus_Accounts");
                });

            modelBuilder.Entity("DataLayer.Models.NprData", b =>
                {
                    b.Property<string>("Idvn")
                        .HasColumnName("IDVN")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("HashAds")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("IntroducedBy")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Repdate")
                        .HasColumnType("datetime");

                    b.HasKey("Idvn")
                        .HasName("PK__NPR___Da__B87C0A44F71D4561");

                    b.ToTable("NPR___Data");
                });

            modelBuilder.Entity("DataLayer.Models.NpvData", b =>
                {
                    b.Property<string>("Idbd")
                        .HasColumnName("IDBD")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("HashAds")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("IntroducedBy")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Repdate")
                        .HasColumnType("datetime");

                    b.HasKey("Idbd")
                        .HasName("PK__NPV___Da__B87DA8C3747E560B");

                    b.ToTable("NPV___Data");
                });
#pragma warning restore 612, 618
        }
    }
}