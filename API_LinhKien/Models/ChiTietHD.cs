namespace API_LinhKien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHD")]
    public partial class ChiTietHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string MaLK { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHD { get; set; }

        public int SoLuong { get; set; }

        public double? DonGia { get; set; }

        public bool? status { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual LinhKien LinhKien { get; set; }
    }
}
