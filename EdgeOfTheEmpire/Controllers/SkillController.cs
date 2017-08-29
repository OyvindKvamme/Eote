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
    public class SkillController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: api/Skill
        public IQueryable<SkillDto> GetSkills()
        {
            return db.Skills.ProjectTo<SkillDto>();
        }

        [ResponseType(typeof(SkillDto))]
        public IHttpActionResult GetSkill(int id)
        {
            SkillDto skill = db.Skills.Where(c => c.Id == id).ProjectTo<SkillDto>().FirstOrDefault();
            if (skill == null)
            {
                return NotFound();
            }

            return Ok(skill);
        }
    }
}
