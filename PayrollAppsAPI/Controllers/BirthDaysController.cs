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
    public class BirthDaysController : ApiController
    {
        private PayrollDataEntities db = new PayrollDataEntities();

        // GET: api/BirthDays
        public IQueryable<BirthDay> GetBirthDays()
        {
            return db.BirthDays;
        }

        // GET: api/BirthDays/5
        [ResponseType(typeof(BirthDay))]
        public IHttpActionResult GetBirthDay(int id)
        {
            BirthDay birthDay = db.BirthDays.Find(id);
            if (birthDay == null)
            {
                return NotFound();
            }

            return Ok(birthDay);
        }

        // PUT: api/BirthDays/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBirthDay(int id, BirthDay birthDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != birthDay.BirthDayId)
            {
                return BadRequest();
            }

            db.Entry(birthDay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirthDayExists(id))
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

        // POST: api/BirthDays
        [ResponseType(typeof(BirthDay))]
        public IHttpActionResult PostBirthDay(BirthDay birthDay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BirthDays.Add(birthDay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = birthDay.BirthDayId }, birthDay);
        }

        // DELETE: api/BirthDays/5
        [ResponseType(typeof(BirthDay))]
        public IHttpActionResult DeleteBirthDay(int id)
        {
            BirthDay birthDay = db.BirthDays.Find(id);
            if (birthDay == null)
            {
                return NotFound();
            }

            db.BirthDays.Remove(birthDay);
            db.SaveChanges();

            return Ok(birthDay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BirthDayExists(int id)
        {
            return db.BirthDays.Count(e => e.BirthDayId == id) > 0;
        }
    }
}