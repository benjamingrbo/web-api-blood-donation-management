using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RWAAPI.Models
{
    public partial class bazaContext : DbContext
    {
        public bazaContext()
        {
        }

        public bazaContext(DbContextOptions<bazaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donacija> Donacijas { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<HistorijaBolesti> HistorijaBolestis { get; set; }
        public virtual DbSet<KrvnaGrupa> KrvnaGrupas { get; set; }
        public virtual DbSet<Opcina> Opcinas { get; set; }
        public virtual DbSet<Osoba> Osobas { get; set; }
        public virtual DbSet<RhFaktor> RhFaktors { get; set; }
        public virtual DbSet<Ustanova> Ustanovas { get; set; }
        public virtual DbSet<VwDonacije> VwDonacijes { get; set; }
        public virtual DbSet<VwHistorija> VwHistorijas { get; set; }
        public virtual DbSet<VwSveOsobe> VwSveOsobes { get; set; }
        public virtual DbSet<VwUstanova> VwUstanovas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=baza;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Donacija>(entity =>
            {
                entity.ToTable("Donacija");

                entity.Property(e => e.DonacijaId).HasColumnName("donacijaId");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanovaId");

                entity.HasOne(d => d.JmbgNavigation)
                    .WithMany(p => p.Donacijas)
                    .HasForeignKey(d => d.Jmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donacija__jmbg__46E78A0C");

                entity.HasOne(d => d.Ustanova)
                    .WithMany(p => p.Donacijas)
                    .HasForeignKey(d => d.UstanovaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Donacija__ustano__47DBAE45");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.ToTable("Grad");

                entity.Property(e => e.GradId).HasColumnName("gradId");

                entity.Property(e => e.NazivGrada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivGrada");
            });

            modelBuilder.Entity<HistorijaBolesti>(entity =>
            {
                entity.HasKey(e => e.DijagnozaId)
                    .HasName("PK__historij__AF716635EA68108A");

                entity.ToTable("historijaBolesti");

                entity.Property(e => e.DijagnozaId).HasColumnName("dijagnozaId");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Dijagnoza)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dijagnoza");

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.HasOne(d => d.JmbgNavigation)
                    .WithMany(p => p.HistorijaBolestis)
                    .HasForeignKey(d => d.Jmbg)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__historijaB__jmbg__4BAC3F29");
            });

            modelBuilder.Entity<KrvnaGrupa>(entity =>
            {
                entity.ToTable("krvnaGrupa");

                entity.Property(e => e.KrvnaGrupaId).HasColumnName("krvnaGrupaId");

                entity.Property(e => e.KrvnaGrupa1)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("krvnaGrupa");
            });

            modelBuilder.Entity<Opcina>(entity =>
            {
                entity.ToTable("Opcina");

                entity.Property(e => e.OpcinaId).HasColumnName("opcinaId");

                entity.Property(e => e.GradId).HasColumnName("gradId");

                entity.Property(e => e.NazivOpcine)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivOpcine");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Opcinas)
                    .HasForeignKey(d => d.GradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Opcina__gradId__38996AB5");
            });

            modelBuilder.Entity<Osoba>(entity =>
            {
                entity.HasKey(e => e.Jmbg)
                    .HasName("PK__Osoba__8C39FC662D0600D2");

                entity.ToTable("Osoba");

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojKnjizice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brojKnjizice");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FaktorId).HasColumnName("faktorId");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.KrvnaGrupaId).HasColumnName("krvnaGrupaId");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(255)
                    .HasColumnName("napomena");

                entity.Property(e => e.OpcinaId).HasColumnName("opcinaId");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prezime");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telefon");

                entity.HasOne(d => d.Faktor)
                    .WithMany(p => p.Osobas)
                    .HasForeignKey(d => d.FaktorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Osoba__faktorId__412EB0B6");

                entity.HasOne(d => d.KrvnaGrupa)
                    .WithMany(p => p.Osobas)
                    .HasForeignKey(d => d.KrvnaGrupaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Osoba__krvnaGrup__403A8C7D");

                entity.HasOne(d => d.Opcina)
                    .WithMany(p => p.Osobas)
                    .HasForeignKey(d => d.OpcinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Osoba__opcinaId__3F466844");
            });

            modelBuilder.Entity<RhFaktor>(entity =>
            {
                entity.HasKey(e => e.FaktorId)
                    .HasName("PK__rhFaktor__A75A4E06CE428E91");

                entity.ToTable("rhFaktor");

                entity.Property(e => e.FaktorId).HasColumnName("faktorId");

                entity.Property(e => e.Faktor)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("faktor");
            });

            modelBuilder.Entity<Ustanova>(entity =>
            {
                entity.ToTable("Ustanova");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanovaId");

                entity.Property(e => e.NazivUstanove)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nazivUstanove");

                entity.Property(e => e.OpcinaId).HasColumnName("opcinaId");

                entity.HasOne(d => d.Opcina)
                    .WithMany(p => p.Ustanovas)
                    .HasForeignKey(d => d.OpcinaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ustanova__opcina__440B1D61");
            });

            modelBuilder.Entity<VwDonacije>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwDonacije");

                entity.Property(e => e.BrojKnjizice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brojKnjizice");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.DonacijaId).HasColumnName("donacijaId");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Faktor)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("faktor");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.Property(e => e.KrvnaGrupa)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("krvnaGrupa");

                entity.Property(e => e.NazivOpcine)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivOpcine");

                entity.Property(e => e.NazivUstanove)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nazivUstanove");

                entity.Property(e => e.Opis)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prezime");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telefon");
            });

            modelBuilder.Entity<VwHistorija>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwHistorija");

                entity.Property(e => e.BrojKnjizice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brojKnjizice");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.Dijagnoza)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("dijagnoza");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prezime");
            });

            modelBuilder.Entity<VwSveOsobe>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSveOsobe");

                entity.Property(e => e.Adresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("adresa");

                entity.Property(e => e.BrojKnjizice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("brojKnjizice");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Faktor)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("faktor");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("ime");

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("jmbg");

                entity.Property(e => e.KrvnaGrupa)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("krvnaGrupa");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(255)
                    .HasColumnName("napomena");

                entity.Property(e => e.NazivOpcine)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivOpcine");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("prezime");

                entity.Property(e => e.Telefon)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("telefon");
            });

            modelBuilder.Entity<VwUstanova>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUstanova");

                entity.Property(e => e.NazivGrada)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivGrada");

                entity.Property(e => e.NazivOpcine)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("nazivOpcine");

                entity.Property(e => e.NazivUstanove)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("nazivUstanove");

                entity.Property(e => e.UstanovaId).HasColumnName("ustanovaId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
