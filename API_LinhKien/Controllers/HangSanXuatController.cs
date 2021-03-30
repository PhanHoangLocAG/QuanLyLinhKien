using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class HangSanXuatController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachHangSanXuat()
        {
            var kq = dc.HangSXes.Select(x => new Models.CHangSanXuat
            {
                MaHangSX = x.MaHangSX,
                TenHangSX = x.TenHangSX,
                status = x.status
            });
            return Ok(kq.ToList());
        }

        public IHttpActionResult getHangSanXuat(string id)
        {
            Models.HangSX kq = dc.HangSXes.Find(id);
            if (kq == null) return BadRequest();
            Models.CHangSanXuat hsx = new Models.CHangSanXuat()
            {
                MaHangSX = kq.MaHangSX,
                TenHangSX = kq.TenHangSX,
                status = kq.status,
                LinhKiens = new List<Models.CLinhKien>() { }
            };
            foreach(Models.LinhKien item in kq.LinhKiens)
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
                hsx.LinhKiens.Add(lk);
            }
            return Ok(hsx);
        }

        public IHttpActionResult postHangSanXuat(Models.CHangSanXuat hsx)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.HangSX h = new Models.HangSX()
            {
                MaHangSX = hsx.MaHangSX,
                TenHangSX = hsx.TenHangSX,
                status = true
            };
            dc.HangSXes.Add(h);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteHangSanXuat(string id)
        {
            Models.HangSX h = dc.HangSXes.Find(id);
            if (h == null) return NotFound();
            h.status = false;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putHangSanXuat(Models.CHangSanXuat hsx)
        {
            Models.HangSX h = dc.HangSXes.Find(hsx.MaHangSX);
            if (h == null) return NotFound();
            h.TenHangSX = hsx.TenHangSX;
            dc.SaveChanges();
            return Ok();
        }
    }
}
