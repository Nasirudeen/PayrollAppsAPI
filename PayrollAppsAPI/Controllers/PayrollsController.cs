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
    public class PayrollsController : ApiController
    {
        private PayrollDataEntities db = new PayrollDataEntities();

        // GET: api/Payrolls
        public IQueryable<Payroll> GetPayrolls()
        {
            return db.Payrolls;
        }

        // GET: api/Payrolls/5
        [ResponseType(typeof(Payroll))]
        public IHttpActionResult GetPayroll(int id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            if (payroll == null)
            {
                return NotFound();
            }

            return Ok(payroll);
        }

        // PUT: api/Payrolls/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayroll(int id, Payroll payroll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payroll.PayrollId)
            {
                return BadRequest();
            }

            db.Entry(payroll).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PayrollExists(id))
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

        // POST: api/Payrolls
        [ResponseType(typeof(Payroll))]
        public IHttpActionResult PostPayroll(Payroll payroll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Payrolls.Add(payroll);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payroll.PayrollId }, payroll);
        }

        // DELETE: api/Payrolls/5
        [ResponseType(typeof(Payroll))]
        public IHttpActionResult DeletePayroll(int id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            if (payroll == null)
            {
                return NotFound();
            }

            db.Payrolls.Remove(payroll);
            db.SaveChanges();

            return Ok(payroll);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PayrollExists(int id)
        {
            return db.Payrolls.Count(e => e.PayrollId == id) > 0;
        }
    }
}