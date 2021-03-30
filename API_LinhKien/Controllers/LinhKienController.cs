using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_LinhKien.Controllers
{
    public class LinhKienController : ApiController
    {
        private Models.qllk dc = new Models.qllk();

        public IHttpActionResult getDanhSachLK()
        {
            var kq = dc.LinhKiens.Select(x => new Models.CLinhKien
            {
                TenLK = x.TenLK,
                MaLK = x.MaLK,
                MaNCC = x.MaNCC,
                MaLoai = x.MaLoai,
                MoTa = x.MoTa,
                Hinh = x.Hinh,
                HangSX = x.HangSX,
                GiaBan = x.GiaBan,
                status = x.status
            });

            return Ok(kq.ToList());
        }

        public IHttpActionResult getLinhKien(string id)
        {
            Models.LinhKien lk = dc.LinhKiens.Find(id);
            if (lk == null) return BadRequest();
            Models.CLinhKien l = new Models.CLinhKien()
            {
                TenLK = lk.TenLK,
                MaLK = lk.MaLK,
                MaNCC = lk.MaNCC,
                MaLoai = lk.MaLoai,
                MoTa = lk.MoTa,
                Hinh = lk.Hinh,
                HangSX = lk.HangSX,
                GiaBan = lk.GiaBan,
                status = lk.status
            };
            return Ok(l);
        }

        public IHttpActionResult postLinhKien(Models.CLinhKien lk)
        {

            if (ModelState.IsValid == false) return BadRequest();
            Models.LinhKien l = new Models.LinhKien()
            {
                TenLK = lk.TenLK,
                MaLK = lk.MaLK,
                MaNCC = lk.MaNCC,
                MaLoai = lk.MaLoai,
                MoTa = lk.MoTa,
                Hinh = lk.Hinh,
                HangSX = lk.HangSX,
                GiaBan = lk.GiaBan,
                status = true
            };
            dc.LinhKiens.Add(l);
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult deleteLinhKien(string id)
        {
            Models.LinhKien ncc = dc.LinhKiens.Find(id);
            if (ncc == null) return BadRequest();
            ncc.status = false;
            dc.SaveChanges();
            return Ok();
        }

        public IHttpActionResult putLinhKien(Models.CLinhKien lk)
        {
            Models.LinhKien l = dc.LinhKiens.Find(lk.MaLK);
            if (l == null) return BadRequest();
            l.TenLK = lk.TenLK;
            l.MaNCC = lk.MaNCC;
            l.MaLoai = lk.MaLoai;
            l.MoTa = lk.MoTa;
            l.Hinh = lk.Hinh;
            l.HangSX = lk.HangSX;
            l.GiaBan = lk.GiaBan;
            dc.SaveChanges();
            return Ok();
        }
    }
}
