using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdgeOfTheEmpire.Models
{
    public class CareerSkill
    {
        public int Id { get; set; }
        public int CareerId { get; set; }
        public int SkillId { get; set; }

        public virtual Skill Skill { get; set; }

        public virtual Career Career { get; set; }
    }
}