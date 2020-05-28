using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using web_do_an.Models;

namespace web_do_an.Controllers
{
    public class DoAnsController : ApiController
    {
        private DoAnContext db = new DoAnContext();

        private IQueryable<DoAnDetail> MapDoAns()
        {
            return from da in db.DoAns select new DoAnDetail()
            {
                MaDA = da.MaDA,
                TenDA = da.TenDA,
                PhanLoai = da.PhanLoai.TenLoai,
                NguonGoc = da.NguonGoc.TenNuoc,
                GiaXuat = da.GiaXuat,
                chiet_khau = da.chiet_khau,
                Anh = da.Anh,
                MoTa = da.MoTa,
                MaNG = da.MaNG,
                MaLoai = da.MaLoai
            };
        }

        //get tat ca do an
        // GET: api/DoAns
        public IQueryable<DoAnDetail> GetDoAns()
        {
            var DoAns = MapDoAns();
            return DoAns; 
        }

       // GET: api/DoAns/5
        [ResponseType(typeof(DoAn))]
        public async Task<IHttpActionResult> GetDoAn(string id)
        {
            var doAn = await MapDoAns().SingleOrDefaultAsync(da => da.MaDA == id);
            if (doAn == null)
            {
                return NotFound();
            }

            return Ok(doAn);
        }

        //get do an theo MaLoai
        [HttpGet]
        [Route("api/DoAnByMaLoai/{MaLoai}")]
        public IQueryable<DoAnDetail> getDoAnByMaLoai(string MaLoai)
        {
            var DoAns = from da in MapDoAns()
                        where da.MaLoai == MaLoai
                        select da;
            return DoAns;
        }

        //get do an theo MaNG
        [HttpGet]
        [Route("api/DoAnByMaNG/{MaNG}")]
        public IQueryable<DoAnDetail> getDoAnByMaNG(string MaNG)
        {
            var DoAns = from da in MapDoAns()
                        where da.MaNG == MaNG
                        select da;
            return DoAns;
        }

        //get do an sale nhieu nhat (orderby da.chiet_khau )
        [HttpGet]
        [Route("api/sale")]
        public IQueryable<DoAnDetail> sale()
        {
            var DoAns = from da in MapDoAns()
                        orderby da.chiet_khau descending
                        select da;
            return DoAns;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
}