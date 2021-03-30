using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class LuongController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachLuong()
        {
            var kq = dc.LuongNVs.Select(x => new Models.CLuong
            {
                MaLuong = x.MaLuong,
                HeSo = x.HeSo,
                NgayThang = x.NgayThang,
                SoNgayLam = x.SoNgayLam,
                LuongCoBan = x.LuongCoBan,
                ThucLanh = x.ThucLanh,
                status = x.status
            });
            return Ok(kq.ToList());
        }

        public IHttpActionResult getLuong(string id)
        {
            Models.LuongNV kq = dc.LuongNVs.Find(id);
            if (kq == null) return BadRequest();
            Models.CLuong luong = new Models.CLuong()
            {
                MaLuong = kq.MaLuong,
                HeSo = kq.HeSo,
                NgayThang = kq.NgayThang,
                SoNgayLam = kq.SoNgayLam,
                LuongCoBan = kq.LuongCoBan,
                ThucLanh = kq.ThucLanh,
                status = kq.status,
                NhanViens = new List<Models.CNhanVien>() { }
            };
            foreach (Models.NhanVien item in kq.NhanViens)
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
                luong.NhanViens.Add(c);
            }
            return Ok(luong);
        }

        public IHttpActionResult postLuong(Models.CLuong luong)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.LuongNV l = new Models.LuongNV()
            {
                MaLuong = luong.MaLuong,
                HeSo = luong.HeSo,
                NgayThang = luong.NgayThang,
                SoNgayLam = luong.SoNgayLam,
                LuongCoBan = luong.LuongCoBan,
                ThucLanh = luong.ThucLanh,
                status = true
            };
            dc.LuongNVs.Add(l);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLuong(Models.CLuong luong)
        {
            Models.LuongNV l = dc.LuongNVs.Find(luong.MaLuong);
            if (l == null) return NotFound();
            l.HeSo = luong.HeSo;
            l.NgayThang = luong.NgayThang;
            l.SoNgayLam = luong.SoNgayLam;
            l.LuongCoBan = luong.LuongCoBan;
            l.ThucLanh = luong.ThucLanh;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteLuong(string id)
        {
            Models.LuongNV luong = dc.LuongNVs.Find(id);
            if (luong == null) return NotFound();
            luong.status = false;
            dc.SaveChanges();
            return Ok();
        }
    }
}
