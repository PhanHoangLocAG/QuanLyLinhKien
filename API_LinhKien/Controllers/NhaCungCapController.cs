using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class NhaCungCapController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachNhaCC()
        {
            var kq = dc.NhaCCs.Select(x => new Models.CNhaCC
            {
                TenNCC = x.TenNCC,
                MaNCC = x.MaNCC,
                status = x.status
            });

            return Ok(kq.ToList());
        }

        public IHttpActionResult getNhaCC(string id)
        {
            Models.NhaCC ncc = dc.NhaCCs.Find(id);
            if (ncc == null) return BadRequest();
            Models.CNhaCC n = new Models.CNhaCC()
            {
                MaNCC = ncc.MaNCC,
                TenNCC = ncc.TenNCC,
                status = ncc.status,
                LinhKiens = new List<Models.CLinhKien>() { }
            };
            foreach (Models.LinhKien item in ncc.LinhKiens)
            {
                Models.CLinhKien lk = new Models.CLinhKien()
                {
                    MaLK = item.MaLK,
                    TenLK = item.TenLK,
                    MaLoai = item.MaLoai,
                    MaNCC = item.MaNCC,
                    MoTa = item.MoTa,
                    Hinh = item.Hinh,
                    HangSX = item.HangSX,
                    GiaBan = item.GiaBan,
                    status = item.status,
                    ChiTietHDs = item.ChiTietHDs,
                    ChiTietPhieuXuats = item.ChiTietPhieuXuats
                };
                n.LinhKiens.Add(lk);
            }

            return Ok(n);
        }

        public IHttpActionResult putNhaCC(Models.CNhaCC ncc)
        {
            Models.NhaCC n = dc.NhaCCs.Find(ncc.MaNCC);
            if (n == null) return BadRequest();
            n.TenNCC = ncc.TenNCC;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult postNhaCC(Models.CNhaCC ncc)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.NhaCC n = new Models.NhaCC()
            {
                MaNCC = ncc.MaNCC,
                TenNCC = ncc.TenNCC,
                status = true
            };
            dc.NhaCCs.Add(n);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteNhaCC(string id)
        {
            Models.NhaCC ncc = dc.NhaCCs.Find(id);
            if (ncc == null) return BadRequest();
            ncc.status = false;
            dc.SaveChanges();
            return Ok();
        }
    }
}
