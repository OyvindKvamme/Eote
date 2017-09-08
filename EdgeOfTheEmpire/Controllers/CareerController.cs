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
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EdgeOfTheEmpire.DTOs;
using EdgeOfTheEmpire.Models;

namespace EdgeOfTheEmpire.Controllers
{
    
    [System.Web.Http.Authorize]
    public class CareerController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Career
        public IQueryable<CareerDto> GetCareers()
        {
            return db.Careers.ProjectTo<CareerDto>();                        
        }

        // GET: api/Career/5
        [ResponseType(typeof(CareerDto))]
        public IHttpActionResult GetCareer(int id)
        {
            CareerDto career = db.Careers.Where(c=>c.Id ==id).ProjectTo<CareerDto>().FirstOrDefault();
            if (career == null)
            {
                return NotFound();
            }
            
            return Ok(career);
        }

        // PUT: api/Career/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCareer(int id, Career career)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != career.Id)
            {
                return BadRequest();
            }

            db.Entry(career).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CareerExists(id))
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

        // POST: api/Career
        [ResponseType(typeof(Career))]
        public IHttpActionResult PostCareer(Career career)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Careers.Add(career);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = career.Id }, career);
        }

        // DELETE: api/Career/5
        [ResponseType(typeof(Career))]
        public IHttpActionResult DeleteCareer(int id)
        {
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return NotFound();
            }

            db.Careers.Remove(career);
            db.SaveChanges();

            return Ok(career);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CareerExists(int id)
        {
            return db.Careers.Count(e => e.Id == id) > 0;
        }
    }
}