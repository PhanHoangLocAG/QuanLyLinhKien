using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_LinhKien.Models
{
    public class CNhaCC
    {
       
        public string MaNCC { get; set; }

        public string TenNCC { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CLinhKien> LinhKiens { get; set; }
    }
}