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
    public class FormerStaffsController : ApiController
    {
        private PayrollDataEntities db = new PayrollDataEntities();

        // GET: api/FormerStaffs
        public IQueryable<FormerStaff> GetFormerStaffs()
        {
            return db.FormerStaffs;
        }

        // GET: api/FormerStaffs/5
        [ResponseType(typeof(FormerStaff))]
        public IHttpActionResult GetFormerStaff(int id)
        {
            FormerStaff formerStaff = db.FormerStaffs.Find(id);
            if (formerStaff == null)
            {
                return NotFound();
            }

            return Ok(formerStaff);
        }

        // PUT: api/FormerStaffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormerStaff(int id, FormerStaff formerStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formerStaff.FormerStaffId)
            {
                return BadRequest();
            }

            db.Entry(formerStaff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormerStaffExists(id))
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

        // POST: api/FormerStaffs
        [ResponseType(typeof(FormerStaff))]
        public IHttpActionResult PostFormerStaff(FormerStaff formerStaff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FormerStaffs.Add(formerStaff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = formerStaff.FormerStaffId }, formerStaff);
        }

        // DELETE: api/FormerStaffs/5
        [ResponseType(typeof(FormerStaff))]
        public IHttpActionResult DeleteFormerStaff(int id)
        {
            FormerStaff formerStaff = db.FormerStaffs.Find(id);
            if (formerStaff == null)
            {
                return NotFound();
            }

            db.FormerStaffs.Remove(formerStaff);
            db.SaveChanges();

            return Ok(formerStaff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FormerStaffExists(int id)
        {
            return db.FormerStaffs.Count(e => e.FormerStaffId == id) > 0;
        }
    }
}