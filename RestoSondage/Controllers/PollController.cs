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
using RestoSondage.Models;

namespace RestoSondage.Controllers
{
    public class PollController : ApiController
    {
        private RestoSondageContext db = new RestoSondageContext();

        // GET: api/Poll
        public IQueryable<Sondage> GetSondages()
        {
            return db.Sondages;
        }

        // GET: api/Poll/5
        [ResponseType(typeof(Sondage))]
        public IHttpActionResult GetSondage(int id)
        {
            Sondage sondage = db.Sondages.Find(id);
            if (sondage == null)
            {
                return NotFound();
            }

            return Ok(sondage);
        }

        // PUT: api/Poll/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSondage(int id, Sondage sondage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sondage.Id)
            {
                return BadRequest();
            }

            db.Entry(sondage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SondageExists(id))
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

        // POST: api/Poll
        [ResponseType(typeof(Sondage))]
        public IHttpActionResult PostSondage(Sondage sondage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sondages.Add(sondage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sondage.Id }, sondage);
        }

        // DELETE: api/Poll/5
        [ResponseType(typeof(Sondage))]
        public IHttpActionResult DeleteSondage(int id)
        {
            Sondage sondage = db.Sondages.Find(id);
            if (sondage == null)
            {
                return NotFound();
            }

            db.Sondages.Remove(sondage);
            db.SaveChanges();

            return Ok(sondage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SondageExists(int id)
        {
            return db.Sondages.Count(e => e.Id == id) > 0;
        }
    }
}