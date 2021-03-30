using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class KhachHangController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachKH()
        {
            var kq = dc.KhachHangs.Select(x => new Models.CKhachHang
            {
                MaKh = x.MaKH,
                TenKH = x.TenKh,
                GioiTinh = x.GioiTinh,
                Tuoi = x.Tuoi,
                DiaChi = x.DiaChi,
                SoDT = x.SoDT,
                status = x.status
            });

            return Ok(kq.ToList());
        }

        public IHttpActionResult getKhachHang(string id)
        {
            Models.KhachHang kh = dc.KhachHangs.Find(id);
            if (kh == null) return BadRequest();
            Models.CKhachHang l = new Models.CKhachHang()
            {
                MaKh = kh.MaKH,
                TenKH = kh.TenKh,
                GioiTinh = kh.GioiTinh,
                Tuoi = kh.Tuoi,
                DiaChi = kh.DiaChi,
                SoDT = kh.SoDT,
                status = kh.status
            };
            return Ok(l);
        }

        public IHttpActionResult postKhachHang(Models.CKhachHang kh)
        {

            if (ModelState.IsValid == false) return BadRequest();
            Models.KhachHang k = new Models.KhachHang()
            {
                MaKH = kh.MaKh,
                TenKh = kh.TenKH,
                GioiTinh = kh.GioiTinh,
                Tuoi = kh.Tuoi,
                DiaChi = kh.DiaChi,
                SoDT = kh.SoDT,
                status = true
            };
            dc.KhachHangs.Add(k);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteKhachHang(string id)
        {
            Models.KhachHang ncc = dc.KhachHangs.Find(id);
            if (ncc == null) return BadRequest();
            ncc.status = false;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putKhachHang(Models.CKhachHang kh)
        {
            Models.KhachHang k = dc.KhachHangs.Find(kh.MaKh);
            if (k == null) return BadRequest();
            k.MaKH = kh.MaKh;
            k.TenKh = kh.TenKH;
            k.GioiTinh = kh.GioiTinh;
            k.Tuoi = kh.Tuoi;
            k.DiaChi = kh.DiaChi;
            k.SoDT = kh.SoDT;
            k.status = kh.status;
            dc.SaveChanges();
            return Ok();
        }
    }
}
