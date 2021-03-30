using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CPhieuXuat
    {
        public int MaPX { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime? NgayXuat { get; set; }
        public double? TongTien { get; set; }
        public virtual ICollection<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
}