using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CHangSanXuat
    {
        public string MaHangSX { get; set; }

        public string TenHangSX { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CLinhKien> LinhKiens { get; set; }
    }
}