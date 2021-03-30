using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CNhanVien
    {
        public string MaNV { get; set; }

        public string TenNV { get; set; }

        public int Tuoi { get; set; }

        public bool? GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public string SoDT { get; set; }

        public DateTime? NgayVaoLam { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public string ChucVu { get; set; }

        public int Luong { get; set; }

        public bool? status { get; set; }


        
    }
}