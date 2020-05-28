namespace web_do_an.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguonGoc")]
    public partial class NguonGoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguonGoc()
        {
            DoAns = new HashSet<DoAn>();
        }

        [Key]
        [StringLength(50)]
        public string MaNG { get; set; }

        [StringLength(50)]
        public string TenNuoc { get; set; }

        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoAn> DoAns { get; set; }
    }
}
