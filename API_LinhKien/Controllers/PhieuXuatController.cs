using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class PhieuXuatController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachPX()
        {
            var kq = dc.PhieuXuats.Select(x => new Models.CPhieuXuat
            {
                MaPX = x.MaPX,
                MaKH = x.MaKH,
                MaNV = x.MaNV,
                NgayXuat = x.NgayXuat,
                TongTien = x.TongTien
            });

            return Ok(kq.ToList());
        }

        public IHttpActionResult getPhieuXuat(string id)
        {
            Models.PhieuXuat px = dc.PhieuXuats.Find(id);
            if (px == null) return BadRequest();
            Models.CPhieuXuat l = new Models.CPhieuXuat()
            {
                MaPX = px.MaPX,
                MaKH = px.MaKH,
                MaNV = px.MaNV,
                NgayXuat = px.NgayXuat,
                TongTien = px.TongTien
            };
            return Ok(l);
        }

        public IHttpActionResult postPhieuXuat(Models.CPhieuXuat px)
        {

            if (ModelState.IsValid == false) return BadRequest();
            Models.PhieuXuat l = new Models.PhieuXuat()
            {
                MaPX = px.MaPX,
                MaKH = px.MaKH,
                MaNV = px.MaNV,
                NgayXuat = px.NgayXuat,
                TongTien = px.TongTien
            };
            dc.PhieuXuats.Add(l);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deletePhieuXuat(string id)
        {
            Models.PhieuXuat ncc = dc.PhieuXuats.Find(id);
            if (ncc == null) return BadRequest();
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLinhKien(Models.PhieuXuat px)
        {
            Models.PhieuXuat l = dc.PhieuXuats.Find(px.MaPX);
            if (l == null) return BadRequest();
            l.MaPX = px.MaPX;
            l.MaKH = px.MaKH;
            l.MaNV = px.MaNV;
            l.NgayXuat = px.NgayXuat;
            l.TongTien = px.TongTien;
            dc.SaveChanges();
            return Ok();
        }
    }
}