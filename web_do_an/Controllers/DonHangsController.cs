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
    public class DonHangsController : ApiController
    {
        private DoAnContext db = new DoAnContext();

        // GET: api/DonHangs
        public IQueryable<DonHang> GetDonHangs()
        {
            return db.DonHangs.Where(dh => dh.MaKH == User.Identity.Name);
        }

        // GET: api/DonHangs/5
        [ResponseType(typeof(DonHang))]
        public async Task<IHttpActionResult> GetDonHang(string id)
        {
            DonHang donHang = await db.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            return Ok(donHang);
        }

        // PUT: api/DonHangs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDonHang(string id, DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donHang.MaDH)
            {
                return BadRequest();
            }

            db.Entry(donHang).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DonHangs
        [ResponseType(typeof(DonHang))]
        public async Task<IHttpActionResult> PostDonHang(DonHang donHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonHangs.Add(donHang);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DonHangExists(donHang.MaDH))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = donHang.MaDH }, donHang);
        }

        // DELETE: api/DonHangs/5
        [ResponseType(typeof(DonHang))]
        public async Task<IHttpActionResult> DeleteDonHang(string id)
        {
            DonHang donHang = await db.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            db.DonHangs.Remove(donHang);
            await db.SaveChangesAsync();

            return Ok(donHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonHangExists(string id)
        {
            return db.DonHangs.Count(e => e.MaDH == id) > 0;
        }
    }
}