using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CLuong
    {
        public int MaLuong { get; set; }

        public double HeSo { get; set; }

        public DateTime NgayThang { get; set; }

        public int SoNgayLam { get; set; }

        public double LuongCoBan { get; set; }

        public double? ThucLanh { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CNhanVien> NhanViens { get; set; }
    }
}