using PayrollAppsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PayrollAppsAPI.Controllers
{
    public class EmployeeController1 : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Models.Employee> Get()
        {
            PayrollDataEntities entities1 = new PayrollDataEntities();
            return entities1.Employees;
        }

        // GET api/<controller>/5
        public Employee Get(int id)
        {
            PayrollDataEntities entities1 = new PayrollDataEntities();
            Employee em = entities1.Employees.FirstOrDefault(d => d.EmployeeId == id);
            return em;
        }

        // POST api/<controller>
        public string Post([FromBody] Employee ea)
        {
            try
            {
                // TODO: Add insert logic here
                PayrollDataEntities entities = new PayrollDataEntities();
                Employee cs = entities.Employees.FirstOrDefault(d => d.EmailAddress == ea.EmailAddress);
                if (cs == null)
                {
                    entities.Employees.Add(ea);
                    entities.SaveChanges();
                    return "saved"; //entities.Users; // View();
                }
                else
                {

                    return "duplicate";
                }


            }
            catch
            {
                return "error";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] Employee ea)
        {
            try
            {
                // TODO: Add update logic here
                PayrollDataEntities entities1 = new PayrollDataEntities();
                Employee le = entities1.Employees.FirstOrDefault(d => d.EmployeeId == id);

                le.FirstName = ea.FirstName;
                le.LastName = ea.LastName;
                le.OtherName = ea.OtherName;
                le.EmailAddress = ea.EmailAddress;
                le.Address = ea.NextOfKin;
                le.AddressOfNextOfKin = ea.AddressOfNextOfKin;
                le.PhoneNoOfNextOfKin = ea.PhoneNoOfNextOfKin;
                le.StateOfOrigin = ea.StateOfOrigin;
                le.Grade = ea.Grade;
                le.Department = ea.Department;
                le.PhoneNo = ea.PhoneNo;
                le.Created = ea.Created;
                le.Updated = ea.Updated;


                entities1.SaveChanges();
                return "saved";
            }
            catch
            {
                return "error";
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            PayrollDataEntities entities1 = new PayrollDataEntities();
            Employee le = entities1.Employees.FirstOrDefault(d => d.EmployeeId == id);
        }
    }
}
