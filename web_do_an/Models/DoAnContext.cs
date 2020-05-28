namespace web_do_an.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DoAnContext : DbContext
    {
        public DoAnContext()
            : base("name=DoAnContext")
        {
        }

        public virtual DbSet<CTDonHang> CTDonHangs { get; set; }
        public virtual DbSet<CTGioHang> CTGioHangs { get; set; }
        public virtual DbSet<DoAn> DoAns { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GioHang> GioHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguonGoc> NguonGocs { get; set; }
        public virtual DbSet<PhanLoai> PhanLoais { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoAn>()
                .HasMany(e => e.CTDonHangs)
                .WithRequired(e => e.DoAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DoAn>()
                .HasMany(e => e.CTGioHangs)
                .WithRequired(e => e.DoAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.CTDonHangs)
                .WithRequired(e => e.DonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GioHang>()
                .HasMany(e => e.CTGioHangs)
                .WithRequired(e => e.GioHang)
                .WillCascadeOnDelete(false);
        }
    }
}
