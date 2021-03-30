using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class LoaiLinhKienController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachLoaiLinhKien()
        {
            var kq = dc.LoaiLKs.Select(x => new Models.CLoaiLinhKien{ 
                MaLoai = x.MaLoai,
                TenLoai = x.TenLoai,
                status = x.status
            });

            return Ok(kq.ToList());
        }

        public IHttpActionResult getLoaiLinhKien(string id)
        {
            Models.LoaiLK l = dc.LoaiLKs.Find(id);
            Models.CLoaiLinhKien LoaiLinhKien = new Models.CLoaiLinhKien()
            {
                MaLoai = l.MaLoai,
                TenLoai = l.TenLoai,
                LinhKiens = new List<Models.CLinhKien>() { }
            };
            foreach(Models.LinhKien item in l.LinhKiens)
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
                LoaiLinhKien.LinhKiens.Add(lk);
            }

            return Ok(LoaiLinhKien);
        }

        public IHttpActionResult postLoaiLinhKien(Models.CLoaiLinhKien LoaiLinhKien)
        {
            if (ModelState.IsValid == false) return BadRequest();
            Models.LoaiLK l = new Models.LoaiLK()
            {
                MaLoai = LoaiLinhKien.MaLoai,
                TenLoai = LoaiLinhKien.TenLoai,
                status = true
            };

            dc.LoaiLKs.Add(l);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteLoaiLinhKien(string id)
        {
            Models.LoaiLK l = dc.LoaiLKs.Find(id);
            if (l == null) return BadRequest();
            l.status = false;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLoaiLinhKien(Models.CLoaiLinhKien loailk)
        {
            Models.LoaiLK l = dc.LoaiLKs.Find(loailk.MaLoai);
            if (l == null) return BadRequest();
            l.TenLoai = loailk.TenLoai;
            dc.SaveChanges();
            return Ok();
        }
    }
}
