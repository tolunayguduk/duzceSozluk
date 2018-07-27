namespace duzceSozluk.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class sozlukVeritabani : DbContext
    {
        public sozlukVeritabani()
            : base("name=sozlukVeritabani")
        {
        }

        public virtual DbSet<Baslik> Baslik { get; set; }
        public virtual DbSet<BaslikTur> BaslikTur { get; set; }
        public virtual DbSet<Begeni> Begeni { get; set; }
        public virtual DbSet<Entry> Entry { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Sikayet> Sikayet { get; set; }
        public virtual DbSet<SikayetTur> SikayetTur { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Baslik>()
                .Property(e => e.baslik)
                .IsFixedLength();

            modelBuilder.Entity<Baslik>()
                .Property(e => e.resim)
                .IsFixedLength();

            modelBuilder.Entity<BaslikTur>()
                .Property(e => e.ad)
                .IsFixedLength();

            modelBuilder.Entity<Entry>()
                .Property(e => e.icerik)
                .IsUnicode(false);

            modelBuilder.Entity<Entry>()
                .Property(e => e.resim)
                .IsFixedLength();

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Begeni)
                .WithOptional(e => e.Entry)
                .HasForeignKey(e => e.entryID);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Begeni1)
                .WithOptional(e => e.Entry1)
                .HasForeignKey(e => e.entryID);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Begeni2)
                .WithOptional(e => e.Entry2)
                .HasForeignKey(e => e.entryID);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.ad)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.soyad)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.email)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.nick)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.sifre)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.fotograf)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Baslik)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.olusturanID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Begeni)
                .WithOptional(e => e.Kullanici)
                .HasForeignKey(e => e.kullaniciID);

            modelBuilder.Entity<Kullanici>()
                .HasMany(e => e.Begeni1)
                .WithOptional(e => e.Kullanici1)
                .HasForeignKey(e => e.kullaniciID);

            modelBuilder.Entity<Sikayet>()
                .Property(e => e.aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<SikayetTur>()
                .Property(e => e.tur)
                .IsFixedLength();

            modelBuilder.Entity<Yetki>()
                .Property(e => e.yetki1)
                .IsFixedLength();
        }
    }
}
