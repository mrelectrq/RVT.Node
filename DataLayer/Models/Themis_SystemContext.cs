using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLayer.Models
{
    public partial class Themis_SystemContext : DbContext
    {
        public Themis_SystemContext()
        {
        }

        public Themis_SystemContext(DbContextOptions<Themis_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlockChain> BlockChain { get; set; }
        public virtual DbSet<ConsensusAccounts> ConsensusAccounts { get; set; }
        public virtual DbSet<NprData> NprData { get; set; }
        public virtual DbSet<NpvData> NpvData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GDI15RS\\SQLEXPRESS; Database=Themis_System;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlockChain>(entity =>
            {
                entity.HasKey(e => e.BlockId)
                    .HasName("PK__BlockCha__1442151127B9A35E");

                entity.Property(e => e.BlockId)
                    .HasColumnName("BlockID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Hash)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Idbd)
                    .HasColumnName("IDBD")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PartyChoosed).HasColumnName("Party_Choosed");

                entity.Property(e => e.PreviouseHash)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RegionChoosed).HasColumnName("Region_Choosed");

                entity.Property(e => e.YearToBirth).HasColumnName("Year_To_Birth");
            });

            modelBuilder.Entity<ConsensusAccounts>(entity =>
            {
                entity.HasKey(e => e.Idbd)
                    .HasName("PK__Consensu__B87DA8C388F0C736");

                entity.Property(e => e.Idbd)
                    .HasColumnName("IDBD")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RepByNodeR)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RepDateTime).HasColumnType("datetime");

                entity.Property(e => e.Software)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NprData>(entity =>
            {
                entity.HasKey(e => e.Idvn)
                    .HasName("PK__NPR___Da__B87C0A44B26AA198");

                entity.ToTable("NPR___Data");

                entity.Property(e => e.Idvn)
                    .HasColumnName("IDVN")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HashAds)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IntroducedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Repdate).HasColumnType("datetime");
            });

            modelBuilder.Entity<NpvData>(entity =>
            {
                entity.HasKey(e => e.Idbd)
                    .HasName("PK__NPV___Da__B87DA8C37B72DFF9");

                entity.ToTable("NPV___Data");

                entity.Property(e => e.Idbd)
                    .HasColumnName("IDBD")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.HashAds)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IntroducedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Repdate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
