using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper.QueryableExtensions;
using EdgeOfTheEmpire.DTOs;
using EdgeOfTheEmpire.Models;

namespace EdgeOfTheEmpire.Controllers
{
    public class SpecializationController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Specialization
        public IQueryable<SpecializationDto> GetSpecializations()
        {
            return db.Specialications.ProjectTo<SpecializationDto>();
        }

        [ResponseType(typeof(SpecializationDto))]
        public IHttpActionResult GetSpecialization(int id)
        {
            SpecializationDto specialization = db.Specialications.Where(c => c.Id == id).ProjectTo<SpecializationDto>().FirstOrDefault();
            if (specialization == null)
            {
                return NotFound();
            }

            return Ok(specialization);
        }
    }
}
