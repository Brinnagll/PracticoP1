using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiWebGorena.Models;

namespace ApiWebGorena.Controllers
{
    public class GorenasController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Gorenas
        [Authorize]
        public IQueryable<Gorena> GetGorenas()
        {
            return db.Gorenas;
        }

        // GET: api/Gorenas/5
        [Authorize]
        [ResponseType(typeof(Gorena))]
        public IHttpActionResult GetGorena(int id)
        {
            Gorena gorena = db.Gorenas.Find(id);
            if (gorena == null)
            {
                return NotFound();
            }

            return Ok(gorena);
        }

        // PUT: api/Gorenas/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGorena(int id, Gorena gorena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gorena.GorenaID)
            {
                return BadRequest();
            }

            db.Entry(gorena).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GorenaExists(id))
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

        // POST: api/Gorenas
        [Authorize]
        [ResponseType(typeof(Gorena))]
        public IHttpActionResult PostGorena(Gorena gorena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gorenas.Add(gorena);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gorena.GorenaID }, gorena);
        }

        // DELETE: api/Gorenas/5
        [Authorize]
        [ResponseType(typeof(Gorena))]
        public IHttpActionResult DeleteGorena(int id)
        {
            Gorena gorena = db.Gorenas.Find(id);
            if (gorena == null)
            {
                return NotFound();
            }

            db.Gorenas.Remove(gorena);
            db.SaveChanges();

            return Ok(gorena);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GorenaExists(int id)
        {
            return db.Gorenas.Count(e => e.GorenaID == id) > 0;
        }
    }
}