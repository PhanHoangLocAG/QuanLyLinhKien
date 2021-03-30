namespace API_LinhKien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LuongNV")]
    public partial class LuongNV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LuongNV()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        public int MaLuong { get; set; }

        public double HeSo { get; set; }

        public DateTime NgayThang { get; set; }

        public int SoNgayLam { get; set; }

        public double LuongCoBan { get; set; }

        public double? ThucLanh { get; set; }

        public bool? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
