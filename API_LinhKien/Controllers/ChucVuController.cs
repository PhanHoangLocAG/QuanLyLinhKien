using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class ChucVuController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachChucVu()
        {
            var kq = dc.ChucVus.Select(x => new Models.CChucVu
            {
               MaCV = x.MaCV,
               TenCV = x.TenCV,
               status = x.status
            });
            return Ok(kq.ToList());
        }

        public IHttpActionResult getChucVu(string id)
        {
            Models.ChucVu kq = dc.ChucVus.Find(id);
            if (kq == null) return BadRequest();
            Models.CChucVu cv = new Models.CChucVu()
            {
                MaCV = kq.MaCV,
                TenCV = kq.TenCV,
                status = kq.status,
                NhanViens = new List<Models.CNhanVien>() { }
            };
            foreach(Models.NhanVien item in kq.NhanViens)
            {
                Models.CNhanVien c = new Models.CNhanVien()
                {
                    MaNV = item.MaNV,
                    TenNV = item.TenNV,
                    Tuoi = item.Tuoi,
                    GioiTinh = item.GioiTinh,
                    DiaChi = item.DiaChi,
                    SoDT = item.SoDT,
                    NgayVaoLam = item.NgayVaoLam,
                    status = item.status
                };
                cv.NhanViens.Add(c);
            }
            return Ok(cv);
        }

        public IHttpActionResult postChucVu(Models.CChucVu cv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.ChucVu c = new Models.ChucVu()
            {
               MaCV = c.MaCV,
               TenCV = c.TenCV,
               status = true
            };
            dc.ChucVus.Add(c);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteChucVu(string id)
        {
            Models.ChucVu cv = dc.ChucVus.Find(id);
            if (cv == null) return NotFound();
            cv.status = false;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult put(Models.CChucVu cv)
        {
            Models.ChucVu c = dc.ChucVus.Find(cv.MaCV);
            if (c == null) return NotFound();
            c.TenCV = cv.TenCV;
            dc.SaveChanges();
            return Ok();
        }
    }
}
