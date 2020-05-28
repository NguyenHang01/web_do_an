namespace web_do_an.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoAn")]
    public partial class DoAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoAn()
        {
            CTDonHangs = new HashSet<CTDonHang>();
            CTGioHangs = new HashSet<CTGioHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaDA { get; set; }

        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string MaNG { get; set; }

        [StringLength(50)]
        public string TenDA { get; set; }

        public double GiaNhap { get; set; }

        public double GiaXuat { get; set; }

        public DateTime? HSD { get; set; }

        public string MoTa { get; set; }

        public string Anh { get; set; }

        public double chiet_khau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGioHang> CTGioHangs { get; set; }

        public virtual NguonGoc NguonGoc { get; set; }

        public virtual PhanLoai PhanLoai { get; set; }
    }
}
