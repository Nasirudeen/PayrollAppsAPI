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
using PayrollAppsAPI.Models;

namespace PayrollAppsAPI.Controllers
{
    public class BonusController : ApiController
    {
        private PayrollDataEntities db = new PayrollDataEntities();

        // GET: api/Bonus
        public IQueryable<Bonu> GetBonus()
        {
            return db.Bonus;
        }

        // GET: api/Bonus/5
        [ResponseType(typeof(Bonu))]
        public IHttpActionResult GetBonu(int id)
        {
            Bonu bonu = db.Bonus.Find(id);
            if (bonu == null)
            {
                return NotFound();
            }

            return Ok(bonu);
        }

        // PUT: api/Bonus/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBonu(int id, Bonu bonu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bonu.BonusId)
            {
                return BadRequest();
            }

            db.Entry(bonu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BonuExists(id))
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

        // POST: api/Bonus
        [ResponseType(typeof(Bonu))]
        public IHttpActionResult PostBonu(Bonu bonu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bonus.Add(bonu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bonu.BonusId }, bonu);
        }

        // DELETE: api/Bonus/5
        [ResponseType(typeof(Bonu))]
        public IHttpActionResult DeleteBonu(int id)
        {
            Bonu bonu = db.Bonus.Find(id);
            if (bonu == null)
            {
                return NotFound();
            }

            db.Bonus.Remove(bonu);
            db.SaveChanges();

            return Ok(bonu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BonuExists(int id)
        {
            return db.Bonus.Count(e => e.BonusId == id) > 0;
        }
    }
}