using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CLinhKien
    {
        public string MaLK { get; set; }

        public string MaLoai { get; set; }

        public string MaNCC { get; set; }

        public string TenLK { get; set; }

        public string MoTa { get; set; }

        public string Hinh { get; set; }

        public string HangSX { get; set; }

        public double? GiaBan { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }

        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

      
    }
}