using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class NhanVienController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachNhanVien()
        {
            var kq = dc.NhanViens.Select(x => new Models.CNhanVien
            {
                MaNV = x.MaNV,
                TenNV = x.TenNV,
                Tuoi = x.Tuoi,
                GioiTinh = x.GioiTinh,
                DiaChi = x.DiaChi,
                SoDT = x.SoDT,
                NgayVaoLam = x.NgayVaoLam,
                Luong = x.Luong,
                ChucVu = x.ChucVu,
                status = x.status
            });
            return Ok(kq.ToList());
        }

        public IHttpActionResult getNhanVien(string id)
        {
            Models.NhanVien kq = dc.NhanViens.Find(id);
            if (kq == null) return BadRequest();
            Models.CNhanVien nv = new Models.CNhanVien()
            {
                MaNV = kq.MaNV,
                TenNV = kq.TenNV,
                Tuoi = kq.Tuoi,
                GioiTinh = kq.GioiTinh,
                DiaChi = kq.DiaChi,
                SoDT = kq.SoDT,
                NgayVaoLam = kq.NgayVaoLam,
                Luong = kq.Luong,
                ChucVu = kq.ChucVu,
                status = kq.status
               
            };
            return Ok(nv);
        }

        public IHttpActionResult postNhanVien(Models.CNhanVien nv)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.NhanVien nv_1 = new Models.NhanVien()
            {
                MaNV =nv.MaNV,
                TenNV = nv.TenNV,
                Tuoi = nv.Tuoi,
                GioiTinh = nv.GioiTinh,
                DiaChi = nv.DiaChi,
                SoDT = nv.SoDT,
                NgayVaoLam = nv.NgayVaoLam,
                Luong = nv.Luong,
                ChucVu = nv.ChucVu,
                UserName = nv.UserName,
                Pass = nv.Pass,
                status = true
            };
            dc.NhanViens.Add(nv_1);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLuong(Models.CNhanVien nv)
        {
            Models.NhanVien nv_1 = dc.NhanViens.Find(nv.MaNV);
            if (nv_1 == null) return NotFound();
            nv_1.TenNV = nv.TenNV;
            nv_1.Tuoi = nv.Tuoi;
            nv_1.GioiTinh = nv.GioiTinh;
            nv_1.DiaChi = nv.DiaChi;
            nv_1.SoDT = nv.SoDT;
            nv_1.NgayVaoLam = nv.NgayVaoLam;
            nv_1.Luong = nv.Luong;
            nv_1.ChucVu = nv.ChucVu;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteLuong(string id)
        {
            Models.NhanVien nv = dc.NhanViens.Find(id);
            if (nv == null) return NotFound();
            nv.status = false;
            dc.SaveChanges();
            return Ok();
        }
    }
}
