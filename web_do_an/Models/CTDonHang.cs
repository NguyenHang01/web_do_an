namespace web_do_an.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MaDA { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        public virtual DoAn DoAn { get; set; }

        public virtual DonHang DonHang { get; set; }
    }
}
