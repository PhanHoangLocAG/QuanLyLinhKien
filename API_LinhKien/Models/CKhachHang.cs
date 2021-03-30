using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CKhachHang
    {
        public string MaKh { get; set; }

        public string TenKH { get; set; }
        public bool GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual ICollection<PhieuXuat> PhieuXuats { get; set; }
    }
}