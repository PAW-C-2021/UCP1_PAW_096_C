using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_096_C.Models
{
    public partial class JajanOnlineContext : DbContext
    {
        public JajanOnlineContext()
        {
        }

        public JajanOnlineContext(DbContextOptions<JajanOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JenisKendaraan> JenisKendaraans { get; set; }
        public virtual DbSet<Ojek> Ojeks { get; set; }
        public virtual DbSet<Pemesan> Pemesans { get; set; }
        public virtual DbSet<PemilikToko> PemilikTokos { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<JenisKendaraan>(entity =>
            {
                entity.HasKey(e => e.IdJenisKendaraan);

                entity.ToTable("JenisKendaraan");

                entity.Property(e => e.IdJenisKendaraan)
                    .ValueGeneratedNever()
                    .HasColumnName("id_jenis_kendaraan");

                entity.Property(e => e.JenisKendaraan1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("jenis_kendaraan");
            });

            modelBuilder.Entity<Ojek>(entity =>
            {
                entity.HasKey(e => e.IdOjek);

                entity.ToTable("Ojek");

                entity.Property(e => e.IdOjek)
                    .ValueGeneratedNever()
                    .HasColumnName("id_ojek");

                entity.Property(e => e.IdJenisKendaraan).HasColumnName("id_jenis_kendaraan");

                entity.Property(e => e.NamaOjek)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_ojek");

                entity.Property(e => e.PlatNomor)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("plat_nomor");

                entity.HasOne(d => d.IdJenisKendaraanNavigation)
                    .WithMany(p => p.Ojeks)
                    .HasForeignKey(d => d.IdJenisKendaraan)
                    .HasConstraintName("FK_Ojek_JenisKendaraan");
            });

            modelBuilder.Entity<Pemesan>(entity =>
            {
                entity.HasKey(e => e.IdPemesan);

                entity.ToTable("Pemesan");

                entity.Property(e => e.IdPemesan)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pemesan");

                entity.Property(e => e.AlamatPemesan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("alamat_pemesan");

                entity.Property(e => e.NamaPemesan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama_pemesan");

                entity.Property(e => e.NoHpPemesan)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("no_hp_pemesan");

                entity.Property(e => e.TotalHarga)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("total_harga");
            });

            modelBuilder.Entity<PemilikToko>(entity =>
            {
                entity.HasKey(e => e.IdPemilikToko);

                entity.ToTable("PemilikToko");

                entity.Property(e => e.IdPemilikToko)
                    .ValueGeneratedNever()
                    .HasColumnName("id_pemilik_toko");

                entity.Property(e => e.NamaPemilikToko)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_pemilik_toko");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("id_barang");

                entity.Property(e => e.HargaBarang)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("harga_barang");

                entity.Property(e => e.IdOjek).HasColumnName("id_ojek");

                entity.Property(e => e.IdPemesan).HasColumnName("id_pemesan");

                entity.Property(e => e.IdPemilikToko).HasColumnName("id_pemilik_toko");

                entity.Property(e => e.JumlahBarang)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("jumlah_barang");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_barang");

                entity.Property(e => e.TotalHarga)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("total_harga");

                entity.HasOne(d => d.IdOjekNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdOjek)
                    .HasConstraintName("FK_Transaksi_Ojek");

                entity.HasOne(d => d.IdPemesanNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPemesan)
                    .HasConstraintName("FK_Transaksi_Pemesan");

                entity.HasOne(d => d.IdPemilikTokoNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdPemilikToko)
                    .HasConstraintName("FK_Transaksi_PemilikToko");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
