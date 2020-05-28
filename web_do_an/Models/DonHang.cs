namespace web_do_an.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CTDonHangs = new HashSet<CTDonHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaDH { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? NgayDat { get; set; }

        public double? SDT { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
